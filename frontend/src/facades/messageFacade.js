import Swal from "sweetalert2";
import ReactDOMServer from "react-dom/server";
import SemesterForm from "./formToActiveSemester";
import ClassroomForm from "./formToSelectClassroom";
import axios from "../axios/axiosInstance";
import React from "react";
import Toast from "sweetalert2";

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

    showConformationToast = (message) => {
        Toast.fire({
            icon: 'success',
            title: message,
            toast: true,
            position: "bottom-right",
            iconColor: 'white',
            customClass: {
                popup: 'colored-toast',
            },
            showConfirmButton: false,
            timer: 5000,
            timerProgressBar: true,
        }).then(() => {
            console.log('Toast enviado...')
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

                return axios.put(`/api/Semester/${selectedSemester.id}/Activate`, {})
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

    openModalClassroom = (classroomsAvaibles) => {
        Swal.fire({
            title: 'Asignar Aula',
            html: ReactDOMServer.renderToString(<ClassroomForm classroomOptions={classroomsAvaibles}/>),
            showCancelButton: true,
            confirmButtonText: 'Asignar',
            cancelButtonText: 'Cancelar',
            showLoaderOnConfirm: true,
            preConfirm: (result) => {
                if (result.dismiss === Swal.DismissReason.cancel) {
                    return false;
                }
            },

        });
    };
}

export default MessageFacade