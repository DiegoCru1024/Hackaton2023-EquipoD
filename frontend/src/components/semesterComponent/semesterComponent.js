import React, { useEffect, useState } from "react";
import ReactDOMServer from 'react-dom/server';

import { Link } from "react-router-dom";
import axios from 'axios';
import { AiOutlineEye, AiOutlineEdit, AiOutlineDelete } from 'react-icons/ai';
import MessageMediator from "../../mediators/messageMediator";
import MyForm from "./subComponents/formToActiveSemester";
import Swal from 'sweetalert2';

const SemesterComponent = () => {
    const messageMediator = new MessageMediator();
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

    const openModal = () => {
        Swal.fire({
            title: 'Activar Semestre',
            html: ReactDOMServer.renderToString(<MyForm semesterOptions={semesters} />),
            showCancelButton: true,
            confirmButtonText: 'Activar',
            cancelButtonText: 'Cancelar',
            showLoaderOnConfirm: true,
            preConfirm: (result) => {
                const selectedSemesterCode = result.value;
                const selectedSemester = semesters.find((semester) => semester.code === selectedSemesterCode);

                return axios.put(`https://sig-fisi.application.ryonadev.me/api/Semester/${selectedSemester.id}/Activate`, {
                    // Puedes enviar más datos según tus necesidades
                })
                    .then(() => {
                        fetchData(); // Actualizar la lista de semestres después de la operación
                        return true; // Indicar a SweetAlert2 que cierre el modal
                    })
                    .catch((error) => {
                        console.error('Error al activar el semestre:', error);
                    });
            },
        });
    };

    return (
        <div className={'componentContainer'}>
            <h1>Semestres</h1>
            <Link to={'/semester/create'}>
                <button style={{ backgroundColor: "#4caf50" }}>
                    Crear Semestre
                </button>
            </Link>
            <button onClick={() => openModal()}>
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
                        <tr key={semester.id} >
                            <td>{semester.code}</td>
                            <td>{semester.startDate}</td>
                            <td>{semester.endDate}</td>
                            <td>{semester.isActive ? "Activo" : "Inactivo"}</td>
                            <td>
                                <Link to={`/semester/details/${semester.id}`}>
                                    <button title="Ver" className={'buttonDetail'}>
                                        <AiOutlineEye />
                                    </button>
                                </Link>
                                <Link to={`/semester/update/${semester.id}`}>
                                    <button title="Editar" className={'buttonUpdate'} >
                                        <AiOutlineEdit />
                                    </button>
                                </Link>
                                <button title="Eliminar" className={'buttonDelete'} onClick={() => messageMediator.showDeleteConfirmation(() => handleDeleteSemester(semester.id))}>
                                    <AiOutlineDelete />
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
