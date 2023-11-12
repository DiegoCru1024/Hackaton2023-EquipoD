import styles from './groupStyles.module.scss'
import {useEffect, useState} from "react";
import axios from "axios";

export default function GroupComponent() {
    const [componentState, setComponentState] = useState('read')
    const [semesterInfo, setSemesterInfo] = useState({
        semesterID: 1,
        semesterName: '2023-II'
    })

    const updateState = (newState) => {
        setComponentState(newState)
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
    }, [])

    return (
        <div className={'componentContainer'}>
            <h1>Grupos de Curso</h1>
            <div>
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
                <tr>
                    <td>asd</td>
                    <td>asd</td>
                    <td>asd</td>
                    <td>asd</td>
                </tr>
                <tr>
                    <td>asd</td>
                    <td>asd</td>
                    <td>asd</td>
                    <td>asd</td>
                </tr>
                <tr>
                    <td>asd</td>
                    <td>asd</td>
                    <td>asd</td>
                    <td>asd</td>
                </tr>
                <tr>
                    <td>asd</td>
                    <td>asd</td>
                    <td>asd</td>
                    <td>asd</td>
                </tr>
                <tr>
                    <td>asd</td>
                    <td>asd</td>
                    <td>asd</td>
                    <td>asd</td>
                </tr>
                </tbody>
            </table>
        </div>
    )
}