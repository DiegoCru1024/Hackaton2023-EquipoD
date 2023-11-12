import styles from "./createGroupStyles.module.scss";
import axios from "axios";
import {useEffect, useState} from "react";
import MessageMediator from "../../../mediators/messageMediator";

export default function CreateGroupComponent() {
    const messageMediator = new MessageMediator()
    const [schedulesArray, setSchedulesArray] = useState([{
        id: 1
    }, {
        id: 2
    }])
    const [coursesArray, setCoursesArray] = useState([])
    const [groupData, setGroupData] = useState({
        planID: 'invalid',
        semesterID: 'invalid',
        courseID: 'invalid',
        groupCapacity: 'invalid'
    })

    const handleChange = (e) => {
        const {name, value} = e.target
        setGroupData((prevState) => ({
            ...prevState,
            [name]: value
        }))

        console.log(groupData)
    }

    const planes = [{
        id: 1,
        nombre: 'Plan 2015'
    }, {
        id: 2,
        nombre: 'Plan 2018'
    }]

    const getSchedule = async () => {
        const hasInvalidValue = Object.values(groupData).some((value) => value === 'invalid');

        if (hasInvalidValue) {
            messageMediator.showMessage(`Completa todos los campos antes de continuar...`, 'error');
            return
        }

        try {
            const response = await axios.get('/getSchedule')
            setSchedulesArray(response.data)
        } catch (error) {
            console.log(error)
        }

    };


    const getCourses = async () => {
        const url = '/getCourses'

        try {
            const response = await axios.get(url)
            setCoursesArray(response.data)
        } catch (error) {
            console.log(error)
        }
    }

    useEffect(() => {

    }, []);

    useEffect(() => {
        if (groupData.planID === 'invalid' || groupData.semesterID === 'invalid') return
        getCourses().then(() => {
            console.log('Cursos obtenidos...')
        })
    }, [groupData.planID, groupData.semesterID])

    return (
        <div className={'componentContainer'}>
            <h1>Crear Grupo de Curso</h1>
            <div className={styles.groupDataContainer}>
                <div>
                    <label>Plan de Estudios:</label>
                    <select name={'planID'} onChange={handleChange}>
                        <option value={'invalid'}>-- Seleccione un plan --</option>
                        {planes.map((plan) => (
                            <option key={plan.id} value={plan.id}>{plan.nombre}</option>
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
                        <option value={1}>asd</option>
                        {coursesArray.map((course) => (
                            <option key={course.id} value={course.id}>{course.nombre}</option>
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
                                <input type={'text'} readOnly={true}/>
                            </div>
                            <div>
                                <label> Ingrese el día: </label>
                                <select>
                                    <option>a</option>
                                    <option>a</option>
                                    <option>a</option>
                                </select>
                            </div>
                            <div>
                                <label> Ingrese la hora: </label>
                                <select>
                                    <option>a</option>
                                    <option>a</option>
                                    <option>a</option>
                                </select>
                            </div>
                        </div>
                    ))}
                </div>
            )}
        </div>
    )
}