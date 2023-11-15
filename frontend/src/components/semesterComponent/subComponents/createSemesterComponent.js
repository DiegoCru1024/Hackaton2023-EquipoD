import React, {useState} from 'react';
import axios from "../../../axios/axiosInstance";
import styles from './createSemesterStyles.module.scss';
import MessageFacade from '../../../facades/messageFacade';
import {useNavigate} from 'react-router-dom';

const CreateSemesterComponent = () => {
    const navigate = useNavigate();
    const messageMediator = new MessageFacade()
    const [semesterName, setSemesterName] = useState('');
    const [startDate, setStartDate] = useState('');
    const [endDate, setEndDate] = useState('');

    const handleInputChange = (e) => {
        const {name, value} = e.target;
        if (name === 'semesterName') {
            setSemesterName(value);
        } else if (name === 'startDate') {
            setStartDate(value);
        } else if (name === 'endDate') {
            setEndDate(value);
        }
    };

    const handleSubmit = async (e) => {
        let created = false;
        e.preventDefault();
        const newSemester = {
            code: semesterName,
            startDate: startDate,
            endDate: endDate,
        };

        try {
            const response = await axios.post('/api/Semester', newSemester);
            console.log('Semester created successfully:', response.data);
            setSemesterName('');
            setStartDate('');
            setEndDate('');
            created = true
        } catch (error) {
            console.error('Error creating semester:', error);
        }

        if (created) {
            messageMediator.showConformationToast('El registro se creó con éxito');
            navigate(-1);
        }
    }

    return (
        <div className='componentContainer'>
            <form className={styles.createSemester} onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="semesterName">Nombre del Semestre:</label>
                    <input
                        type="text"
                        id="semesterName"
                        name="semesterName"
                        value={semesterName}
                        onChange={handleInputChange}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="startDate">Fecha de Inicio:</label>
                    <input
                        type="date"
                        id="startDate"
                        name="startDate"
                        value={startDate}
                        onChange={handleInputChange}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="endDate">Fecha de Fin:</label>
                    <input
                        type="date"
                        id="endDate"
                        name="endDate"
                        value={endDate}
                        onChange={handleInputChange}
                        required
                    />
                </div>
                <div className={styles.buttonContainer}>
                    <button type="submit" className={'buttonCreate'}>Crear Semestre</button>
                    <button type="button" onClick={() => navigate(-1)} className={'buttonCancel'}>Cancelar</button>
                </div>
            </form>
        </div>
    );
};

export default CreateSemesterComponent;
