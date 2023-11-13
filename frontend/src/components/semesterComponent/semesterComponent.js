import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import axios from 'axios';
import styles from './semesterStyles.module.scss';

const SemesterComponent = () => {

    const [semesters, setSemesters] = useState([]);

    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = async () => {
        try {
            const response = await axios.get('https://sig-fisi.application.ryonadev.me/api/Semester/All');
            setSemesters(response.data);
        } catch (error) {
            console.error('Error fetching semesters data:', error);
        }
    };

    const handleDeleteSemester = async (id) => {
        try {
            await axios.delete(`https://sig-fisi.application.ryonadev.me/api/Semester/${id}`);
            fetchData()
        } catch (error) {
            console.error('Error deleting semester:', error);
        }
    };

    return (
        <div className={'componentContainer'}>
            <h1>Semestres</h1>
            <Link to={'/semester/create'}>
                <button style={{ backgroundColor: "#4caf50"}}>
                    Crear Semestre
                </button>
            </Link>
            <table>
                <thead>
                    <tr>
                        <th>Semestre</th>
                        <th>Fecha Inicio</th>
                        <th>Fecha Fin</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    {semesters.map((semester) => (
                        <tr key={semester.id} >
                            <td>{semester.code}</td>
                            <td>{semester.startDate}</td>
                            <td>{semester.endDate}</td>
                            <td>
                                <Link to={`/semester/details/${semester.id}`}>
                                    <button style={{ backgroundColor: "#3498db"}}>Ver</button>
                                </Link>
                                <Link to={`/semester/update/${semester.id}`}>
                                    <button style={{ backgroundColor: "#4caf50"}} >Editar</button>
                                </Link>
                                <button style={{ backgroundColor: "#c0392b"}} onClick={() => handleDeleteSemester(semester.id)}>Eliminar</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default SemesterComponent;
