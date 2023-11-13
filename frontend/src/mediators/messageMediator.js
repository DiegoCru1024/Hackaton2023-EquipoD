import Swal from "sweetalert2";

class MessageMediator {
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

    showDeleteConfirmation = (executeFunction) => {
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
                executeFunction()
                Swal.fire({
                    title: "Eliminado",
                    text: "El registro se eliminó correctamente.",
                    icon: "success"
                });
            }
        });
    }
}

export default MessageMediator