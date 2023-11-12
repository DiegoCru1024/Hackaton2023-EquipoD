import styles from './groupStyles.module.scss'
import {useEffect, useState} from "react";
import axios from "axios";
import {Link} from "react-router-dom";

export default function GroupComponent() {
    const [semesterInfo, setSemesterInfo] = useState({
        semesterID: 1,
        semesterName: '2023-II'
    })

    const [groupArray, setGroupArray] = useState([
        {
            groupID: 1,
            semesterID: 5,
            courseID: 3,
            groupCapacity: 45
        }, {
            groupID: 2,
            semesterID: 2,
            courseID: 7,
            groupCapacity: 15
        }, {
            groupID: 3,
            semesterID: 9,
            courseID: 12,
            groupCapacity: 65
        }
    ])

    const handleDelete = async (groupID) => {
        const url = '/delete'
        const response = await axios.delete(url)
    }

    const getGroupData = async (e) => {
        const url = '/getGroupData'

        try {
            const response = await axios.get(url)
            setGroupArray(response.data)
        } catch (error) {
            console.log(error)
        }
    }

    const getSemesterInfo = async (e) => {
        const url = '/getActiveSemesterInfo'

        try {
            const response = await axios.get(url)
            setSemesterInfo(response.data)
        } catch (error) {
            console.log(error)
        }
    }

    useEffect(() => {
        getSemesterInfo().then(() => {
            console.log('Datos semestre...')
        })

        getGroupData().then(() => {
            console.log('Datos grupos...')
        })
    }, [])

    return (
        <div className={'componentContainer'}>
            <h1>Grupos de Curso</h1>
            <div className={styles.semesterInfoContainer}>
                <div>
                    <label>Semestre Activo</label>
                    <input type={'text'} readOnly={true}/>
                </div>
                <button>Crear Grupos</button>
            </div>
            <table>
                <thead>
                <tr>
                    <th>Grupo</th>
                    <th>Semestre</th>
                    <th>Curso</th>
                    <th>Capacidad</th>
                    <th>Acciones</th>
                </tr>
                </thead>
                <tbody>
                {groupArray.map((group) => (
                    <tr>
                        <td>{group.groupID}</td>
                        <td>{group.semesterID}</td>
                        <td>{group.courseID}</td>
                        <td>{group.groupCapacity}</td>
                        <td>
                            <Link to={`/group/details/${group.groupID}`}>
                                <button>Ver</button>
                            </Link>
                            <Link to={`/group/update/${group.groupID}`}>
                                <button>Editar</button>
                            </Link>
                            <button>Eliminar</button>
                        </td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    )
}