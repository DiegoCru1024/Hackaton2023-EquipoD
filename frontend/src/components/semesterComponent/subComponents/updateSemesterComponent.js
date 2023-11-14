import React, {useEffect, useState} from 'react';
import {useNavigate, useParams} from 'react-router-dom';
import styles from './updateSemesterStyles.module.scss';
import MessageFacade from '../../../facades/messageFacade';
import axios from "../../../axios/axiosInstance";

const UpdateSemesterComponent = () => {
    const navigate = useNavigate();

    const messageMediator = new MessageFacade()
    const {id} = useParams();
    const [semester, setSemester] = useState({});

    useEffect(() => {
        axios.get(`/api/Semester/${id}`)
            .then(response => {
                setSemester(response.data);
            })
            .catch(error => {
                console.error('Error fetching semester data:', error);
            });
    }, [id]);

    const formatDate = (dateString) => {
        const dateObject = new Date(dateString);
        return dateObject.toISOString().split('T')[0];
    };

    const handleInputChange = (e) => {
        const {name, value} = e.target;
        setSemester(prevSemester => ({
            ...prevSemester,
            [name]: value,
        }));
    };

    const handleUpdateSemester = async (e) => {
        let created = false;
        e.preventDefault();

        const formattedStartDate = formatDate(semester.startDate);
        const formattedEndDate = formatDate(semester.endDate);

        const updatedSemester = {
            ...semester,
            startDate: formattedStartDate,
            endDate: formattedEndDate,
        };

        try {
            await axios.put(`/api/Semester/${id}`, updatedSemester);
            created = true
        } catch (error) {
            console.error('Error updating semester:', error);
        }

        if (created) {
            messageMediator.messageSuccessUpdated();
            navigate(-1);
        }
    };

    return (

        <div className='componentContainer'>
            <form className={styles.updateSemester} onSubmit={handleUpdateSemester}>
                <div>
                    <label htmlFor="semesterName">Nombre del Semestre:</label>
                    <input
                        type="text"
                        id="semesterName"
                        name="code"
                        value={semester.code || ''}
                        onChange={handleInputChange}
                    />
                </div>
                <div>
                    <label htmlFor="startDate">Fecha de Inicio:</label>
                    <input
                        type="date"
                        id="startDate"
                        name="startDate"
                        value={semester.startDate ? semester.startDate.split('T')[0] : ''}
                        onChange={handleInputChange}
                    />
                </div>
                <div>
                    <label htmlFor="endDate">Fecha de Fin:</label>
                    <input
                        type="date"
                        id="endDate"
                        name="endDate"
                        value={semester.endDate ? semester.endDate.split('T')[0] : ''}
                        onChange={handleInputChange}
                        required
                    />
                </div>
                <button style={{backgroundColor: "#4caf50"}} type="submit">Editar Semestre</button>
            </form>
        </div>
    );
};

export default UpdateSemesterComponent;
