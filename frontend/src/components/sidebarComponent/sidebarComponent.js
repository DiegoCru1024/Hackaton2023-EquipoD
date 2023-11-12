import styles from './sidebarStyles.module.scss'
import {HiClipboardList, HiHome, HiInformationCircle} from "react-icons/hi";
import {HiUserCircle} from "react-icons/hi2";
import {Link, useNavigate} from "react-router-dom";
import {useDispatch, useSelector} from "react-redux";
import {clearUser} from "../../redux/userSlice";
import {AiFillHome} from "react-icons/ai";

export default function SideBar() {
    const userData = useSelector((state) => state.userData)
    const navigate = useNavigate()
    const dispatch = useDispatch()
    const handleLogOut = () => {
        dispatch(clearUser())
        navigate('/')
    }

    return (
        <div className={styles.sideBarContainer}>
            <div>
                <div className={styles.userContainer}>
                    <HiUserCircle style={{fontSize: '50px'}}/>
                    <div className={styles.userInfo}>
                        <h3>{userData.name}</h3>
                        <p>Rol: {userData.role}</p>
                    </div>
                </div>

                <ul className={styles.navBar}>
                    <li><Link to={'/'}>
                        <AiFillHome className={styles.navBarIcon}/> Inicio</Link>
                    </li>

                    <li><Link to={'/requestList'}>
                        <HiClipboardList className={styles.navBarIcon}/> Semestre</Link>
                    </li>

                    <li><Link to={'/repairRequest'}>
                        <HiInformationCircle className={styles.navBarIcon}/> Grupos</Link>
                    </li>
                    <li><Link to={'/repairRequest'}>
                        <HiInformationCircle className={styles.navBarIcon}/> Aulas</Link>
                    </li>
                </ul>
            </div>

            <button type={"button"} onClick={handleLogOut} className={styles.logOut}>Cerrar Sesión</button>
        </div>
    )
}