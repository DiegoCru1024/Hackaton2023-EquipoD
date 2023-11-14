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
}

export default MessageMediator