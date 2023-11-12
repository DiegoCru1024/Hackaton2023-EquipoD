import React from 'react';
import styles from './detailSemesterComponent.module.scss';

const DetailSemesterComponent = ({semesterDetails}) => {

    return (
        <div className={styles.detailSemester}>
            <h2>Detalles del Semestre</h2>
            <table className={styles.table}>
                <thead>
                <tr>
                    <th>Campo</th>
                    <th>Valor</th>
                </tr>
                </thead>
                <tbody>
                <tr>
                    <td><strong>Nombre del Semestre:</strong></td>
                    <td>{semesterDetails.name}</td>
                </tr>
                <tr>
                    <td><strong>Fecha de Inicio:</strong></td>
                    <td>{semesterDetails.startDate}</td>
                </tr>
                <tr>
                    <td><strong>Fecha de Fin:</strong></td>
                    <td>{semesterDetails.endDate}</td>
                </tr>
                </tbody>
            </table>
        </div>
    );
};

export default DetailSemesterComponent;
