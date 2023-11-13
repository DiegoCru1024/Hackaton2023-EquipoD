import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import axios from 'axios';
import styles from './detailSemesterComponent.module.scss';

const DetailSemesterComponent = () => {
    const { id } = useParams();
    const [semester, setSemester] = useState(null);

    useEffect(() => {
        const fetchSemesterDetails = async () => {
            try {
                const response = await axios.get(`https://sig-fisi.application.ryonadev.me/api/Semester/${id}`);
                setSemester(response.data);
            } catch (error) {
                console.error('Error fetching semester details:', error);
            }
        };
        if (id) {
            fetchSemesterDetails();
        }
    }, [id]);

    if (!semester) {
        return <div>Cargando...</div>;
    }

    return (
        <div className='componentContainer'>
            <div className={styles.detailSemester}>
                <h2>Detalles del Semestre</h2>
                <table className={styles.table}>
                    <tbody>
                        <tr>
                            <td><strong>Nombre del Semestre:</strong></td>
                            <td>{semester.code}</td>
                        </tr>
                        <tr>
                            <td><strong>Fecha de Inicio:</strong></td>
                            <td>{semester.startDate}</td>
                        </tr>
                        <tr>
                            <td><strong>Fecha de Fin:</strong></td>
                            <td>{semester.endDate}</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    );
};

export default DetailSemesterComponent;
