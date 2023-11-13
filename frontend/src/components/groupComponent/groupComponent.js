import styles from './groupStyles.module.scss'
import { useEffect, useState } from "react";
import axios from "axios";
import { Link } from "react-router-dom";
import { AiOutlineEye, AiOutlineEdit, AiOutlineDelete } from 'react-icons/ai';

export default function GroupComponent() {
    const [semesterInfo, setSemesterInfo] = useState({
        semesterID: 1,
        semesterName: '2023-II'
    })

    const [groups, setGroups] = useState([]);

    useEffect(() => {
        getGroupData();
    }, []);
    
    const getGroupData = async () => {
        try {
            const response = await axios.get('https://sig-fisi.application.ryonadev.me/api/Group/GetAll');
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
                    <input type={'text'} readOnly={true} value={semesterInfo.semesterName} />
                </div>
                <Link to={'/group/create'}>
                    <button className={'buttonCreate'} >Crear Grupo</button>
                </Link>
            </div>
            <table>
                <thead>
                    <tr>
                        <th>Id Grupo</th>
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
                            <td>{group.id}</td>
                            <td>{group.courseName}</td>
                            <td>{group.semester}</td>
                            <td>{group.groupNumber}</td>
                            <td>{group.limit}</td>
                            <td>
                                <Link to={`/group/details/${group.id}`}>
                                    <button className={'buttonDetail'}>
                                        <AiOutlineEye />
                                    </button>
                                </Link>
                                <Link to={`/group/update/${group.id}`}>
                                    <button className={'buttonUpdate'}>
                                        <AiOutlineEdit />
                                    </button>
                                </Link>
                                <button className={'buttonDelete'}>
                                    <AiOutlineDelete />
                                </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    )
}