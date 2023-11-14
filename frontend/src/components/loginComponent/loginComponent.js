import logo from '../../assets/logo.png'
import styles from "./loginStyles.module.scss";
import {useEffect, useState} from "react";
import {BiUserCircle, BiLock} from "react-icons/bi";
import {useNavigate} from "react-router-dom";
import {useDispatch, useSelector} from "react-redux";
import {setUser} from "../../redux/userSlice";
import axios from "../../axios/axiosInstance";
import MessageFacade from "../../facades/messageFacade";
import {jwtDecode} from "jwt-decode";

const iconStyle = {color: "#002388", fontSize: 30, marginRight: 5};

const LoginPage = () => {
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const userRole = useSelector((state) => state.userData.role)
    const messageMediator = new MessageFacade()
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
            const url = "/api/User/Login";
            const response = await axios.post(url, loginData);

            const payload = jwtDecode(response.data.token)

            const userData = {
                token: response.data.token,
                userID: payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"],
                userEmail: payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"],
                name: payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"],
                role: payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"],
            };

            dispatch(setUser(userData));
            localStorage.setItem('token', response.data.token)
            navigate("/home");
        } catch (e) {
            setWaitingResponse(false);
            messageMediator.showMessage('Insertar error', 'error')
        }
    };

    useEffect(() => {
        if (userRole !== '') {
            navigate('/home')
        }
    }, [])

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