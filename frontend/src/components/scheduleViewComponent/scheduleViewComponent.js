import styles from "./scheduleViewStyles.module.scss";
import React, {useEffect, useState} from "react";
import axios from "../../axios/axiosInstance";
import GroupScheduleComponent from "./groupScheduleComponent";
import MessageFacade from "../../facades/messageFacade";

export default function ScheduleViewComponent() {
    const messageFacade = new MessageFacade()
    const [scheduleData, setScheduleData] = useState({
        planId: 'invalid',
        semesterId: 'invalid',
        groupNumber: 'invalid'
    })
    const [schedulesArray, setSchedulesArray] = useState([])
    const [scheduleTableData, setScheduleTableData] = useState({
        indexes: [],
        labels: []
    })
    const [planArray, setPlanArray] = useState([])
    const [groupNumbers, setGroupNumbers] = useState([])

    const handleChange = (e) => {
        const {name, value} = e.target
        setScheduleData((prevState) => ({
            ...prevState,
            [name]: value
        }))
    }

    const getGroupNumbers = async () => {
        const url = `/api/Group/GetGroupNumbers?studyPlanId=${scheduleData.planId}&semester=${scheduleData.semesterId}`

        try {
            const response = await axios.get(url)
            setGroupNumbers(response.data)
        } catch (error) {
            console.log(error)
        }
    }

    const getPlans = async () => {
        try {
            const response = await axios.get('/api/StudyPlan/All')
            setPlanArray(response.data)
        } catch (error) {
            console.log(error)
        }
    }

    const getGroupSchedules = async () => {
        const url = `/api/GroupSchedule/Search?groupNumber=${scheduleData.groupNumber}&semester=${scheduleData.semesterId}&studyPlanId=${scheduleData.planId}`

        if (scheduleData.groupNumber === 'invalid') {
            messageFacade.showMessage('Ingresa un grupo válido...', 'error')
            return
        }

        try {
            const response = await axios.get(url)
            setSchedulesArray(response.data)
        } catch (error) {
            console.log(error)
        }

    }

    const updateHours = () => {
        let cellIndexes = [];
        let indexLabels = [];

        for (const schedule of schedulesArray) {
            if (schedule.startTime !== undefined && schedule.endTime !== undefined && schedule.dayId !== undefined) {
                const startHour = parseInt(schedule.startTime);
                const dayNumber = parseInt(schedule.dayId) - 1;

                for (let i = 0; i < schedule.endTime - startHour; i++) {
                    cellIndexes.push([startHour + i - 8, dayNumber]);
                    indexLabels.push(schedule.courseName);
                }
            }
        }

        setScheduleTableData({
            indexes: cellIndexes,
            labels: indexLabels
        });
    };

    useEffect(() => {
        updateHours()
    }, [schedulesArray])

    useEffect(() => {
        if (scheduleData.planId !== 'invalid' && scheduleData.semesterId !== 'invalid') {
            getGroupNumbers().then(() => {
            })
        }
    }, [scheduleData.planId, scheduleData.semesterId])

    useEffect(() => {
        getPlans().then(() => {
            console.log('Planes recibidos...')
        })
    }, []);

    return (
        <div className={'componentContainer'}>
            <h1>Vista de Horarios</h1>

            <div className={styles.scheduleDataContainer}>
                <div>
                    <label>Plan de Estudios:</label>
                    <select name={'planId'} onChange={handleChange} value={scheduleData.planId}>
                        <option value={'invalid'}>-- Seleccione un plan --</option>
                        {planArray.map((plan) => (
                            <option key={plan.id} value={plan.id}>{plan.code}</option>
                        ))}
                    </select>
                </div>
                <div>
                    <label>Semestre:</label>
                    <select name={'semesterId'} onChange={handleChange} value={scheduleData.semesterId}>
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
                    <label>Número de Grupo:</label>
                    <select name={'groupNumber'} onChange={handleChange} value={scheduleData.groupNumber}>
                        <option value={'invalid'}>-- Seleccione un grupo --</option>
                        {groupNumbers.map((item) => (
                            <option key={item.number} value={item.number}>Grupo {item.number}</option>
                        ))}
                    </select>
                </div>
                <button onClick={getGroupSchedules}>Buscar horario</button>
            </div>

            <GroupScheduleComponent selectedObject={scheduleTableData}/>
        </div>
    )
}