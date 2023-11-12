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
}

export default MessageMediator