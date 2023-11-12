import logo from '../../assets/logo.png'
import styles from "./loginStyles.module.scss";
import {useState} from "react";
import {BiUserCircle, BiLock} from "react-icons/bi";
import {useNavigate} from "react-router-dom";
import {useDispatch} from "react-redux";
import {setUser} from "../../redux/userSlice";
import axios from "axios";
import MessageMediator from "../../mediators/messageMediator";

const iconStyle = {color: "#002388", fontSize: 30, marginRight: 5};

const LoginPage = () => {
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const messageMediator = new MessageMediator
    const [waitingResponse, setWaitingResponse] = useState(false);
    const [loginData, setLoginData] = useState({
        email: "",
        password: "",
    });

    const handleChange = (e) => {
        const {name, value} = e.target;
        setLoginData({
            ...loginData,
            [name]: value,
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            setWaitingResponse(true);
            const url = "LoginURL";
            const response = await axios.post(url, loginData);

            //Decodificar JWT
            const payload = response.data.token;
            const userData = {
                token: response.data.token,
                userID: payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"],
                name: payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"],
                role: payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"],
            };
            dispatch(setUser(userData));
            navigate("/home");
        } catch (e) {
            setWaitingResponse(false);
            messageMediator.showMessage('Insertar error', 'error')
        }
    };

    return (
        <div className={styles.mainContainer}>
            <div className={styles.loginWrapper}>
                <form className={styles.loginForm} onSubmit={handleSubmit}>
                    <div className={styles.headerWrapper}>
                        <img src={logo} alt={"logo"}/>
                        <h1>Sistema Integral de Gestión</h1>
                    </div>
                    <div className={styles.labelWrapper}>
                        <BiUserCircle style={iconStyle}/>
                        <label htmlFor={"userInput"}>Correo:</label>
                    </div>
                    <input
                        type={"text"}
                        id={"userInput"}
                        name={"email"}
                        placeholder={"Ingrese su correo..."}
                        onChange={handleChange}
                        value={loginData.email}
                    />
                    <div className={styles.labelWrapper}>
                        <BiLock style={iconStyle}/>
                        <label htmlFor={"passwordInput"}>Contraseña:</label>
                    </div>
                    <input
                        type={"password"}
                        id={"passwordInput"}
                        name={"password"}
                        placeholder={"Ingrese su contraseña..."}
                        onChange={handleChange}
                        value={loginData.password}
                    />
                    <button type={"submit"} disabled={waitingResponse}>
                        Iniciar Sesión
                    </button>
                </form>
            </div>
        </div>
    );
};

export default LoginPage;