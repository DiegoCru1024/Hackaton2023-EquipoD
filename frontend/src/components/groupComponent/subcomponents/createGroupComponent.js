import styles from "../groupStyles.module.scss";
import axios from "axios";
import {useState} from "react";

export default function CreateGroupComponent() {
    const [coursesArray, setCoursesArray] = useState([
        {
            courseID: 1,
            courseName: 'Sistemas'
        }, {
            courseID: 2,
            courseName: 'Diseño'
        }
    ])

    const [groupData, setGroupData] = useState({
        semesterID: 1,
        courseID: 0,
        groupCapacity: 0
    })

    const changeSemester = async (e) => {
        const {value} = e.target
        const url = `getCoursesArray/${value}`

        try {
            const response = await axios.get(url)
            setCoursesArray(response.data)
        } catch (error) {
            console.log(error)
        }
    }

    return (
        <div>
            <div className={styles.semesterInfoContainer}>
                <div>
                    <label>Semestre Activo:</label>
                    <input value={1} readOnly={true}/>
                </div>
                <div>
                    <label>Ciclo:</label>
                    <select onChange={changeSemester}>
                        <option value={0}>-- Seleccione un ciclo --</option>
                        <option value={1}>Ciclo I</option>
                        <option value={2}>Ciclo II</option>
                        <option value={3}>Ciclo III</option>
                        <option value={4}>Ciclo IV</option>
                        <option value={5}>Ciclo V</option>
                        <option value={6}>Ciclo VI</option>
                        <option value={7}>Ciclo VII</option>
                        <option value={8}>Ciclo VIII</option>
                        <option value={9}>Ciclo IX</option>
                        <option value={10}>Ciclo X</option>
                    </select>
                </div>
                <div>
                    <label>Curso:</label>
                    <select>
                        <option>-- Seleccione un curso --</option>
                        {coursesArray.map((course) => (
                            <option key={course.courseID} value={course.courseID}>
                                {course.courseName}
                            </option>
                        ))}
                    </select>
                </div>
            </div>

            <form className={styles.groupInfoContainer}>
                <div>
                    <label>Código de Curso</label>
                    <input type={'text'}/>
                </div>
                <div>
                    <label>Nombre de Curso</label>
                    <input type={'text'}/>
                </div>
                <div>
                    <label>Capacidad de Alumnos</label>
                    <input type={'text'}/>
                </div>
                <div>
                    <label>asd</label>
                    <input type={'text'}/>
                </div>
                <div>
                    <label>Código Curso</label>
                    <input type={'text'}/>
                </div>
            </form>
        </div>
    )
}