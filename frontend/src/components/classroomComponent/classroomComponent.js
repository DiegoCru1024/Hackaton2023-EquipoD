import styles from './classroomStyles.module.scss'
import {useEffect, useState} from "react";
import axios from "../../axios/axiosInstance";
import MessageFacade from '../../facades/messageFacade';

export default function ClassroomComponent() {
    const [semesterInfo, setSemesterInfo] = useState({});

    const [groupSchedules, setGroupSchedules] = useState([]);
    const messageFacade = new MessageFacade()

    useEffect(() => {
        getGroupSchedulesData();
        getSemesterInfo();
    }, []);

    const getSemesterInfo = async () => {
        try {
            const response = await axios.get('/api/Semester/Active');
            setSemesterInfo(response.data);
            console.log(response.data)
        } catch (error) {
            console.error('Error fetching semester info:', error);
        }
    };

    const getGroupSchedulesData = async () => {
        try {
            const response = await axios.get('/api/GroupSchedule/GetAllWithoutClassroom');
            setGroupSchedules(response.data);
        } catch (error) {
            console.error('Error fetching classrooms data:', error);
        }
    };

    const getClassroomsAvaible = async (id) => {
        try {
            const response = await axios.get(`/api/Classroom/GetAllAvailable/${id}`);
            return response.data

        } catch (error) {
            console.error('Error fetching classrooms data:', error);
        }
    }

    const showModalDialog = async (idSchedule) => {
        const array = await getClassroomsAvaible(idSchedule)
        console.log(array)
        messageFacade.openModalClassroom(array, idSchedule)
    }

    return (
        <div className={'componentContainer'}>
            <h1>Asignar Aulas</h1>
            <div className={styles.semesterInfoContainer}>
                <div>
                    <label>Semestre Activo</label>
                    <input type={'text'} readOnly={true} value={semesterInfo.code}/>
                </div>
            </div>
            <table>
                <thead>
                <tr>
                    <th>Nombre Curso</th>
                    <th>Grupo</th>
                    <th>Tipo Dictado</th>
                    <th>Límite</th>
                    <th>Aula</th>
                </tr>
                </thead>
                <tbody>
                    {groupSchedules.map((schedule) => (
                        <tr key={schedule.id}>
                            <td>{schedule.courseName}</td>
                            <td>{schedule.groupNumber}</td>
                            <td>{schedule.courseDictationTypeName}</td>
                            <td>{schedule.limit}</td>
                            <td>
                                <button onClick={() => showModalDialog(schedule.id)} className={'buttonAsign'}>
                                    Asignar Aula
                                </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    )
}