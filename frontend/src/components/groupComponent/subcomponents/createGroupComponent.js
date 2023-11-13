import styles from "./createGroupStyles.module.scss";
import axios from "axios";
import {useEffect, useState} from "react";
import MessageMediator from "../../../mediators/messageMediator";

export default function CreateGroupComponent() {
    const [selectedHour, setSelectedHour] = useState(18);

    const handleInputChange = (e) => {
        const inputValue = e.target.value;

        // Verifica si el valor ingresado es un número y está en el rango permitido
        if (!isNaN(inputValue) && inputValue >= 0 && inputValue <= 23) {
            // Actualiza el estado con el valor interno
            setSelectedHour(parseInt(inputValue, 10));
        }
    };

    // Función para formatear la hora en el formato deseado (HH:00)
    const formatHour = () => {
        return selectedHour < 10 ? `0${selectedHour}:00` : `${selectedHour}:00`;
    };

    const messageMediator = new MessageMediator()
    const [planArray, setPlanArray] = useState([])
    const [coursesArray, setCoursesArray] = useState([])
    const [schedulesArray, setSchedulesArray] = useState([])
    const [groupSchedule, setGroupSchedule] = useState([])
    const [groupData, setGroupData] = useState({
        planID: 'invalid',
        semesterID: 'invalid',
        courseID: 'invalid',
        groupCapacity: 'invalid',
        groupSchedule: []
    })

    const handleChange = (e) => {
        const {name, value} = e.target
        setGroupData((prevState) => ({
            ...prevState,
            [name]: value
        }))

        console.log(groupData)
    }

    const handleScheduleChange = async (e) => {
        const {name, value} = e.target;
        const [scheduleIndex, infoType] = name.split('-');

        setGroupSchedule((prevState) => ({
            ...prevState,
            [scheduleIndex]: {
                ...prevState[scheduleIndex],
                [infoType]: value,
            },
        }));
    };


    const getPlans = async () => {
        try {
            const response = await axios.get('https://sig-fisi.application.ryonadev.me/api/StudyPlan/All')
            setPlanArray(response.data)
        } catch (error) {
            console.log(error)
        }
    }

    const getSchedule = async () => {
        const url = `https://sig-fisi.application.ryonadev.me/api/CourseHoursDictated?courseId=${groupData.courseID}`
        const hasInvalidValue = Object.values(groupData).some((value) => value === 'invalid');

        if (hasInvalidValue) {
            messageMediator.showMessage(`Completa todos los campos antes de continuar...`, 'error');
            return
        }

        try {
            const response = await axios.get(url)
            setSchedulesArray(response.data)
        } catch (error) {
            console.log(error)
        }
    };

    const getCourses = async () => {
        const url = `https://sig-fisi.application.ryonadev.me/api/Course/Search?studyPlanId=${groupData.planID}&semester=${groupData.semesterID}`

        try {
            const response = await axios.get(url)
            setCoursesArray(response.data)
        } catch (error) {
            console.log(error)
        }
    }

    const createGroup = () => {
        console.log(groupData)
    }

    useEffect(() => {
        getPlans().then(() => {
            console.log('Planes recibidos...')
        })
    }, []);

    useEffect(() => {
        if (groupData.planID === 'invalid' || groupData.semesterID === 'invalid') return
        getCourses().then(() => {
            console.log('Cursos obtenidos...')
        })
    }, [groupData.planID, groupData.semesterID])

    useEffect(() => {
        setGroupData((prevState) => ({
            ...prevState,
            groupSchedule: groupSchedule
        }))
    }, [groupSchedule])

    return (
        <div className={'componentContainer'}>
            <h1>Crear Grupo de Curso</h1>
            <div className={styles.groupDataContainer}>
                <div>
                    <label>Plan de Estudios:</label>
                    <select name={'planID'} onChange={handleChange}>
                        <option value={'invalid'}>-- Seleccione un plan --</option>
                        {planArray.map((plan) => (
                            <option key={plan.id} value={plan.id}>{plan.code}</option>
                        ))}
                    </select>
                </div>
                <div>
                    <label>Semestre:</label>
                    <select name={'semesterID'} onChange={handleChange}>
                        <option value={'invalid'}>-- Seleccione un ciclo --</option>
                        <option value={1}>Ciclo I</option>
                        <option value={2}>Ciclo II</option>
                        <option value={3}>Ciclo III</option>
                        <option value={4}>Ciclo IV</option>
                        <option value={5}>Ciclo V</option>
                        <option value={6}>Ciclo VI</option>
                        <option value={7}>Ciclo VII</option>
                        <option value={8}>Ciclo VIII</option>
                        <option value={9}>Ciclo IX</option>
                        <option value={10}>Ciclo X</option>
                    </select>
                </div>
                <div>
                    <label>Curso:</label>
                    <select name={'courseID'} onChange={handleChange}>
                        <option value={'invalid'}>-- Seleccione un curso --</option>
                        {coursesArray.map((course) => (
                            <option key={course.id} value={course.id}>{course.name}</option>
                        ))}
                    </select>
                </div>
                <div>
                    <label>Tope:</label>
                    <input type={'number'} min={0} max={100} placeholder={'Ingrese el tope del grupo...'}
                           name={'groupCapacity'} onChange={handleChange}/>
                </div>
                <button onClick={getSchedule}>Buscar horarios</button>
            </div>

            {schedulesArray.length !== 0 && (
                <div className={styles.groupScheduleContainer}>
                    <h1>Asignar Horario</h1>
                    {schedulesArray.map((schedule) => (
                        <div key={schedule.id} className={styles.scheduleMap}>
                            <div>
                                <label>Tipo de Dictado:</label>
                                <input type={'text'} readOnly={true} value={schedule.dictationTypeName}/>
                            </div>
                            <div>
                                <label>Horas de Dictado:</label>
                                <input type={'text'} readOnly={true} value={schedule.hours}/>
                            </div>
                            <div>
                                <label> Ingrese el día: </label>
                                <select name={`${schedule.id}-dayID`} onChange={handleScheduleChange}>
                                    <option value={'invalid'}>-- Seleccione un día --</option>
                                    <option value={'1'}>Lunes</option>
                                    <option value={'2'}>Martes</option>
                                    <option value={'3'}>Miercoles</option>
                                    <option value={'4'}>Jueves</option>
                                    <option value={'5'}>Viernes</option>
                                    <option value={'6'}>Sabado</option>
                                </select>
                            </div>
                            <div>
                                <label> Ingrese la hora de inicio: </label>
                                <input
                                    type="text"
                                    id="hourInput"
                                    value={formatHour()}
                                    onChange={handleInputChange}
                                />
                            </div>
                            <div>
                                <label> Ingrese la hora de fin: </label>
                                <select name={`${schedule.id}-hour`} onChange={handleScheduleChange}>
                                    <option value={'invalid'}>-- Seleccione una hora --</option>
                                    <option value={1}>1</option>
                                    <option value={2}>2</option>
                                    <option value={3}>3</option>
                                </select>
                            </div>
                        </div>
                    ))}

                    <div>

                    </div>

                    <button onClick={createGroup}>Enviar</button>
                </div>
            )}
        </div>
    )
}