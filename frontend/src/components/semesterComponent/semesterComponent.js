import React, {useEffect, useState} from "react";
import {Link} from "react-router-dom";
import axios from "../../axios/axiosInstance";
import {AiOutlineEye, AiOutlineEdit, AiOutlineDelete} from 'react-icons/ai';
import MessageFacade from "../../facades/messageFacade";

const SemesterComponent = () => {
    const messageFacade = new MessageFacade();
    const [semesters, setSemesters] = useState([]);

    useEffect(() => {
        fetchData().then(() => {
        });
    }, []);

    const fetchData = async () => {
        try {
            const response = await axios.get('/api/Semester/All');
            setSemesters(response.data);
        } catch (error) {
            console.error('Error fetching semesters data:', error);
        }
    };

    const handleDeleteSemester = async (id) => {
        try {
            await axios.delete(`/api/Semester/${id}`);
            fetchData().then(() => {
            })
        } catch (error) {
            console.error('Error deleting semester:', error);
        }
    };

    return (
        <div className={'componentContainer'}>
            <h1>Semestres</h1>
            <Link to={'/semester/create'}>
                <button className={'buttonCreate'}>
                    Crear Semestre
                </button>
            </Link>
            <button className={'buttonAsign'}
                    onClick={() => messageFacade.openModalSemester(semesters, () => fetchData())}>
                Activar Semestre
            </button>
            <table>
                <thead>
                <tr>
                    <th>Semestre</th>
                    <th>Fecha Inicio</th>
                    <th>Fecha Fin</th>
                    <th>Activo</th>
                    <th>Acciones</th>
                </tr>
                </thead>
                <tbody>
                {semesters.map((semester) => (
                    <tr key={semester.id}>
                        <td>{semester.code}</td>
                        <td>{semester.startDate}</td>
                        <td>{semester.endDate}</td>
                        <td>{semester.isActive ? "Activo" : "Inactivo"}</td>
                        <td>
                            <Link to={`/semester/details/${semester.id}`}>
                                <button title="Ver" className={'buttonDetail'}>
                                    <AiOutlineEye/>
                                </button>
                            </Link>
                            <Link to={`/semester/update/${semester.id}`}>
                                <button title="Editar" className={'buttonUpdate'}>
                                    <AiOutlineEdit/>
                                </button>
                            </Link>
                            <button title="Eliminar" className={'buttonDelete'}
                                    onClick={() => messageFacade.showDeleteConfirmation(() => handleDeleteSemester(semester.id))}>
                                <AiOutlineDelete/>
                            </button>
                        </td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    );
};
export default SemesterComponent;
