import Swal from "sweetalert2";
import ReactDOMServer from "react-dom/server";
import SemesterForm from "./formToActiveSemester";
import ClassroomForm from "./formToSelectClassroom";
import axios from "axios";
import React from "react";

class MessageFacade {
    showMessage = (message, type) => {
        Swal.fire({
            position: "center",
            icon: type,
            title: message,
            showConfirmButton: true,
            timer: 5000
        }).then(() => {
            console.log('Alerta enviada...')
        });
    }

    messageSuccessCreated = () => {
        Swal.fire({
            position: "center",
            icon: "success",
            title: "El registro se creó correctamente",
            timer: 3000
        })
    }

    messageSuccessUpdated = () => {
        Swal.fire({
            position: "center",
            icon: "success",
            title: "El registro editó correctamente",
            timer: 3000
        })
    }

    showDeleteConfirmation = (functionDelete) => {
        Swal.fire({
            title: "¿Desea borrar el registro?",
            text: "Esta acción es irreversible!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Confirmar"
        }).then((result) => {
            if (result.isConfirmed) {
                functionDelete()
            }
            return false
        });
    }

    openModalSemester = (semesters, fetchData) => {
        Swal.fire({
            title: 'Activar Semestre',
            html: ReactDOMServer.renderToString(<SemesterForm semesterOptions={semesters}/>),
            showCancelButton: true,
            confirmButtonText: 'Activar',
            cancelButtonText: 'Cancelar',
            showLoaderOnConfirm: true,
            preConfirm: (result) => {
                if (result.dismiss === Swal.DismissReason.cancel) {
                    return false;
                }

                const selectedSemesterCode = document.getElementById('selectOption').value;
                const selectedSemester = semesters.find((semester) => semester.code === selectedSemesterCode);

                return axios.put(`https://sig-fisi.application.ryonadev.me/api/Semester/${selectedSemester.id}/Activate`, {})
                    .then(() => {
                        fetchData();
                        return true;
                    })
                    .catch((error) => {
                        console.error('Error al activar el semestre:', error);
                    });
            },

        });
    };

    openModalClassroom = (classrooms, getClassrooms) => {
        Swal.fire({
            title: 'Asignar Aula',
            html: ReactDOMServer.renderToString(<ClassroomForm classroomOptions={classrooms}/>),
            showCancelButton: true,
            confirmButtonText: 'Asignar',
            cancelButtonText: 'Cancelar',
            showLoaderOnConfirm: true,
            preConfirm: (result) => {
                if (result.dismiss === Swal.DismissReason.cancel) {
                    return false;
                }

                const selectedSemesterCode = document.getElementById('selectOption').value;
                const selectedSemester = classrooms.find((semester) => semester.code === selectedSemesterCode);

                return axios.put(`https://sig-fisi.application.ryonadev.me/api/Semester/${selectedSemester.id}/Activate`, {})
                    .then(() => {
                        getClassrooms();
                        return true;
                    })
                    .catch((error) => {
                        console.error('Error al asignar aula:', error);
                    });
            },

        });
    };
}

export default MessageFacade