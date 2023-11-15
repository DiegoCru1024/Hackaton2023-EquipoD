import React, {useState, useEffect} from 'react';
import {useParams} from 'react-router-dom';
import axios from "../../../axios/axiosInstance";
import styles from './detailGroupStyles.module.scss';

const DetailGroupComponent = () => {
    const {id} = useParams();
    const [group, setGroup] = useState(null);

    useEffect(() => {
        const fetchGroupDetails = async () => {
            try {
                const response = await axios.get(`/api/Group/${id}`);
                setGroup(response.data);
            } catch (error) {
                console.error('Error fetching group details:', error);
            }
        };
        if (id) {
            fetchGroupDetails();
        }
    }, [id]);

    if (!group) {
        return <div>Cargando...</div>;
    }

    return (
        <div className='componentContainer'>
            <div className={styles.detailGroup}>
                <h1>Detalle del Grupo</h1>
                <table className={styles.table}>
                    <tbody>
                    <tr>
                        <td><strong>Nombre Curso:</strong></td>
                        <td>{group.courseName}</td>
                        <td><strong>Semestre:</strong></td>
                        <td>{group.semester}</td>
                    </tr>
                    <tr>
                        <td><strong>Grupo:</strong></td>
                        <td>{group.groupNumber}</td>
                        <td><strong>Límite:</strong></td>
                        <td>{group.limit}</td>
                    </tr>
                    </tbody>
                </table>
            </div>

            <div>
                <h1>Horarios</h1>
                {group.groupSchedules.map((schedule, index) => (
                    <div key={index}>
                        <table className={styles.table}>
                            <tbody>
                            <tr>
                                <td><strong>Día :</strong></td>
                                <td>{schedule.dayName}</td>
                            </tr>
                            <tr>
                                <td><strong>Tipo de Dictado :</strong></td>
                                <td>{schedule.courseDictationTypeName}</td>
                            </tr>
                            <tr>
                                <td><strong>Inicio:</strong></td>
                                <td>{schedule.startTime}</td>
                            </tr>
                            <tr>
                                <td><strong>Fin:</strong></td>
                                <td>{schedule.endTime}</td>
                            </tr>
                            <tr>
                                <td><strong>Aula:</strong></td>
                                <td>{schedule.classroomCode || 'SIN ASIGNAR'}</td>
                            </tr>
                            </tbody>
                        </table>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default DetailGroupComponent;
