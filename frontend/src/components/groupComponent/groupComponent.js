import styles from './groupStyles.module.scss'
import {useEffect, useState} from "react";
import axios from "../../axios/axiosInstance";
import {Link} from "react-router-dom";
import {AiOutlineEye, AiOutlineEdit, AiOutlineDelete} from 'react-icons/ai';
import {useSelector} from "react-redux";

export default function GroupComponent() {
    const userRole = useSelector((state) => state.userData.role)
    const [semesterInfo] = useState({
        semesterID: 1,
        semesterName: '2023-II'
    })

    const [groups, setGroups] = useState([]);

    useEffect(() => {
        getGroupData().then(() => {
        });
    }, []);

    const getGroupData = async () => {
        try {
            const response = await axios.get('/api/Group/GetAll');
            setGroups(response.data);
            console.log(groups)
        } catch (error) {
            console.error('Error fetching groups data:', error);
        }
    };

    return (
        <div className={'componentContainer'}>
            <h1>Grupos de Curso</h1>
            <div className={styles.semesterInfoContainer}>
                <div>
                    <label>Semestre Activo</label>
                    <input type={'text'} readOnly={true} value={semesterInfo.semesterName}/>
                </div>
                {userRole === 'Decanato' && (
                    <Link to={'/group/create'}>
                        <button className={'buttonCreate'}>Crear Grupo</button>
                    </Link>
                )}
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
                                <button className={'buttonDelete'}>
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