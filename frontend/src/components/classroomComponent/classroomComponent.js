import styles from './classroomStyles.module.scss'
import {useEffect, useState} from "react";
import axios from "axios";


export default function ClassroomComponent() {
    const [semesterInfo, setSemesterInfo] = useState({
        semesterID: 1,
        semesterName: '2023-II'
    })

    const [classrooms, setClassrooms] = useState([]);

    useEffect(() => {
        getClassroomData().then(() => {
            console.log('Aulas recibidas...')
        });
    }, []);

    const getClassroomData = async () => {
        try {
            const response = await axios.get('https://sig-fisi.application.ryonadev.me/api/GroupSchedule/GetAllWithoutClassroom');
            setClassrooms(response.data);
        } catch (error) {
            console.error('Error fetching classrooms data:', error);
        }
    };

    return (
        <div className={'componentContainer'}>
            <h1>Asignar Aulas</h1>
            <div className={styles.semesterInfoContainer}>
                <div>
                    <label>Semestre Activo</label>
                    <input type={'text'} readOnly={true} value={semesterInfo.semesterName}/>
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
                {classrooms.map((classroom) => (
                    <tr key={classroom.id}>
                        <td>{classroom.courseName}</td>
                        <td>{classroom.groupNumber}</td>
                        <td>{classroom.courseDictationTypeName}</td>
                        <td>{classroom.limit}</td>
                        <td>
                            <button className={'buttonAsign'}>
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