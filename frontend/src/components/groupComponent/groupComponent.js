import styles from './groupStyles.module.scss'
import {useEffect, useState} from "react";
import axios from "../../axios/axiosInstance";
import {Link} from "react-router-dom";
import {AiOutlineEye, AiOutlineEdit, AiOutlineDelete} from 'react-icons/ai';
import MessageFacade from "../../facades/messageFacade";
import {useSelector} from "react-redux";

export default function GroupComponent() {
    const [semesterInfo, setSemesterInfo] = useState({});
    const userRole = useSelector((state) => state.userData.role)
    const messageFacade = new MessageFacade();
    const [groups, setGroups] = useState([]);

    useEffect(() => {
        getGroupData();
        getSemesterInfo();
    }, []);

    const getSemesterInfo = async () => {
        try {
            const response = await axios.get('/api/Semester/Active');
            setSemesterInfo(response.data);
            console.log(response.data)
        } catch (error) {
            console.error('Error fetching semester info:', error);
        }
    };

    const getGroupData = async () => {
        try {
            const response = await axios.get('/api/Group/GetAll');
            setGroups(response.data);
            console.log(groups)
        } catch (error) {
            console.error('Error fetching groups data:', error);
        }
    };

    const handleDeleteGroup = async (id) => {
        try {
            await axios.delete(`/api/Group/${id}`);
            getGroupData().then(() => {
            })
        } catch (error) {
            console.error('Error deleting semester:', error);
        }
    };

    return (
        <div className={'componentContainer'}>
            <h1>Grupos de Curso</h1>
            <div className={styles.semesterInfoContainer}>
                <div>
                    <label>Semestre Activo</label>
                    <input type={'text'} readOnly={true} value={semesterInfo.code}/>
                </div>
                {userRole === 'Decanato' && (<>
                    <Link to={'/group/create'}>
                        <button className={'buttonCreate'}>Crear Grupo</button>
                    </Link>
                </>)}
            </div>
            <table>
                <thead>
                <tr>
                    <th>Nombre Curso</th>
                    <th>Semestre</th>
                    <th>Grupo</th>
                    <th>Límite</th>
                    <th>Acciones</th>
                </tr>
                </thead>
                <tbody>
                {groups.map((group) => (
                    <tr key={group.id}>
                        <td>{group.courseName}</td>
                        <td>{group.semester}</td>
                        <td>{group.groupNumber}</td>
                        <td>{group.limit}</td>
                        <td>
                            <Link to={`/group/details/${group.id}`}>
                                <button className={'buttonDetail'}>
                                    <AiOutlineEye/>
                                </button>
                            </Link>
                            {userRole === 'Decanato' && (<>
                                <Link to={`/group/update/${group.id}`}>
                                    <button className={'buttonUpdate'}>
                                        <AiOutlineEdit/>
                                    </button>
                                </Link>
                                <button className={'buttonDelete'}
                                        onClick={() => messageFacade.showDeleteConfirmation(() => handleDeleteGroup(group.id))}>
                                    <AiOutlineDelete/>
                                </button>
                            </>)}
                        </td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    )
}