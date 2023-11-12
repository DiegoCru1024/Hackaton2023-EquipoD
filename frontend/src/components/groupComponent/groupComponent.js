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
                    <input value={semesterInfo.active} readOnly={true}/>
                </div>
                <div>
                    <label>Ciclo:</label>
                    <select>
                        <option>-- Seleccione un ciclo --</option>
                        <option>1</option>
                        <option>2</option>
                        <option>3</option>
                        <option>4</option>
                        <option>5</option>
                        <option>6</option>
                        <option>7</option>
                        <option>8</option>
                        <option>9</option>
                        <option>10</option>
                    </select>
                </div>
                <div>
                    <label>Semestre Activo:</label>
                    <input value={semesterInfo.active}/>
                </div>
            </div>
        </div>
    )
}