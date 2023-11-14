import React, {useEffect, useState} from "react";
import {Link} from "react-router-dom";
import axios from 'axios';
import {AiOutlineEye, AiOutlineEdit, AiOutlineDelete} from 'react-icons/ai';
import MessageFacade from "../../facades/messageFacade";

const SemesterComponent = () => {
    const messageMediator = new MessageFacade();
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
                <button className={'buttonCreate'}>
                    Crear Semestre
                </button>
            </Link>
            <button className={'buttonAsign'}
                    onClick={() => messageMediator.openModalSemester(semesters, () => fetchData())}>
                Desginar Semestre Activo
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
                                    onClick={() => messageMediator.showDeleteConfirmation(() => handleDeleteSemester(semester.id))}>
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
