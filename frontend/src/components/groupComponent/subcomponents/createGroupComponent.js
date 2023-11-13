import styles from "./createGroupStyles.module.scss";
import axios from "axios";
import {useEffect, useState} from "react";
import MessageMediator from "../../../mediators/messageMediator";
import ScheduleComponent from "./scheduleComponent";
import {useNavigate} from "react-router-dom";

export default function CreateGroupComponent() {
    const navigate = useNavigate()
    const messageMediator = new MessageMediator()
    const [planArray, setPlanArray] = useState([])
    const [coursesArray, setCoursesArray] = useState([])
    const [schedulesArray, setSchedulesArray] = useState([])
    const [groupSchedule, setGroupSchedule] = useState([])
    const [unavailableHours, setUnavailableHours] = useState([])
    const [selectedHours, setSelectedHours] = useState([])
    const [blockedHours, setBlockedHours] = useState([])
    const [groupData, setGroupData] = useState({
        planID: 'invalid',
        semesterID: 'invalid',
        courseID: 'invalid',
        limit: 'invalid',
        groupNumber: '0',
        groupSchedule: []
    })

    const handleChange = (e) => {
        const {name, value} = e.target
        setGroupData((prevState) => ({
            ...prevState,
            [name]: value
        }))

        if (name === 'courseID' && value !== 'invalid') {
            getGroupNumber(value).then(() => {
                console.log('Grupo recibido...')
            })

            clearScreen()
        }
    }

    const handleScheduleChange = async (e, duration) => {
        const {name, value} = e.target;
        const [scheduleIndex, infoType] = name.split('-');

        if (infoType === 'dayNumber') {
            setGroupSchedule((prevState) => ({
                ...prevState,
                [scheduleIndex]: {
                    ...prevState[scheduleIndex],
                    [infoType]: value,
                },
            }));
        } else {
            setGroupSchedule((prevState) => ({
                ...prevState,
                [scheduleIndex]: {
                    ...prevState[scheduleIndex],
                    [infoType]: value,
                    endTime: (parseInt(value) + duration)
                },
            }));
        }
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
        const url2 = `https://sig-fisi.application.ryonadev.me/api/GroupSchedule/GetAllUnavailable?groupNumber=${groupData.groupNumber}&semester=${groupData.semesterID}`
        const hasInvalidValue = Object.values(groupData).some((value) => value === 'invalid' || value === '0');

        if (hasInvalidValue) {
            messageMediator.showMessage(`Completa todos los campos antes de continuar...`, 'error');
            return
        }

        try {
            const response = await axios.get(url)
            setSchedulesArray(response.data)

            const unavailableResponse = await axios.get(url2)
            setUnavailableHours(unavailableResponse.data)
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

    const getGroupNumber = async (courseGetId) => {
        const url = `https://sig-fisi.application.ryonadev.me/api/Group/NextGroupNumber/${courseGetId}`

        try {
            const response = await axios.get(url)
            setGroupData((prevState) => ({
                ...prevState,
                'groupNumber': response.data
            }))

        } catch (error) {
            console.log(error)
        }
    }

    const clearScreen = () => {
        setGroupSchedule([])
        setSchedulesArray([])
        setSelectedHours([])
    }

    const updateSelectedHours = () => {
        let cellIndexes = [];

        for (const scheduleKey in groupData.groupSchedule) {
            const schedule = groupData.groupSchedule[scheduleKey];

            if (schedule.startTime !== undefined && schedule.endTime !== undefined && schedule.dayNumber !== undefined) {
                const startHour = parseInt(schedule.startTime);
                const dayNumber = parseInt(schedule.dayNumber) - 1;

                for (let i = 0; i < schedule.endTime - startHour; i++) {
                    cellIndexes.push([startHour + i - 8, dayNumber]);
                }
            }
        }

        setSelectedHours(cellIndexes);
    };

    const updateBlockedHours = () => {
        let cellIndexes = [];

        for (const hourKey in unavailableHours) {
            const hour = unavailableHours[hourKey]

            const startHour = parseInt(hour.startTime);
            const dayNumber = parseInt(hour.dayId) - 1;

            for (let i = 0; i < hour.endTime - startHour; i++) {
                cellIndexes.push([startHour + i - 8, dayNumber]);
            }
        }

        setBlockedHours(cellIndexes)
    }

    const convertGroupData = (groupObject) => {
        const {courseID, limit, groupNumber, groupSchedule} = groupObject;

        const result = {
            courseId: courseID,
            limit: limit,
            groupNumber: groupNumber,
            groupSchedules: []
        };

        for (const key in groupSchedule) {
            const {dayNumber, startTime, endTime} = groupSchedule[key];

            result.groupSchedules.push({
                dayId: dayNumber,
                courseDictationTypeId: key,
                startTime: startTime,
                endTime: endTime
            });
        }

        return result;
    }

    const createGroup = async () => {
        const bodyObject = convertGroupData(groupData)
        const url = 'https://sig-fisi.application.ryonadev.me/api/Group'

        try {
            await axios.post(url, bodyObject)
            messageMediator.showMessage('Se registro el grupo correctamente...', 'success')
            navigate('/group')
        } catch (error) {
            console.log(error)
        }
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
        updateSelectedHours()
    }, [groupData.groupSchedule])

    useEffect(() => {
        updateBlockedHours()
    }, [unavailableHours])

    useEffect(() => {
        setGroupData((prevState) => ({
            ...prevState,
            groupSchedule: groupSchedule
        }))
    }, [groupSchedule])

    const horaInicio = 8, horaFin = 22

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
                           name={'limit'} onChange={handleChange}/>
                </div>
                <div>
                    <label>Número de Grupo:</label>
                    <input readOnly={true} value={groupData.groupNumber}/>
                </div>
                <button onClick={getSchedule}>Buscar horarios</button>
            </div>

            {schedulesArray.length !== 0 && (
                <div className={styles.groupScheduleContainer}>
                    <h1>Asignar Horario</h1>
                    {schedulesArray.map((schedule) => (
                        <div key={schedule.dictationTypeId} className={styles.scheduleMap}>
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
                                <select name={`${schedule.dictationTypeId}-dayNumber`} onChange={handleScheduleChange}>
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
                                <label> Hora de inicio: </label>
                                <input type={'number'} min={horaInicio} max={horaFin - schedule.hours}
                                       defaultValue={''} name={`${schedule.dictationTypeId}-startTime`}
                                       onChange={(e) => handleScheduleChange(e, schedule.hours)}
                                       placeholder={'Ingrese la hora...'}/>
                            </div>
                            <div>
                                <label> Hora de fin: </label>
                                <input value={groupSchedule[schedule.dictationTypeId]?.endTime || ''}
                                       readOnly={true}/>
                            </div>
                        </div>
                    ))}

                    <ScheduleComponent blockedHours={blockedHours} selectedHours={selectedHours}/>

                    <button type={'button'} onClick={createGroup}>Enviar</button>
                </div>
            )}
        </div>
    )
}