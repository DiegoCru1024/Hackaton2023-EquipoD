import styles from './groupStyles.module.scss'
import {useState} from "react";

export default function GroupComponent() {
    const [semesterInfo, setSemesterInfo] = useState({
        active: '2023-II'
    })

    return (
        <div className={'componentContainer'}>
            <h1>Crear Grupos</h1>
            <div className={styles.semesterInfoContainer}>
                <div>
                    <label>Semestre Activo:</label>
                    <input value={semesterInfo.active}/>
                </div>
                <div>
                    <label>Semestre Activo:</label>
                    <input value={semesterInfo.active}/>
                </div>
                <div>
                    <label>Semestre Activo:</label>
                    <input value={semesterInfo.active}/>
                </div>
            </div>
        </div>
    )
}