import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import styles from './updateSemesterStyles.module.scss';
import axios from 'axios';

const UpdateSemesterComponent = () => {
  const { id } = useParams();
  const [semester, setSemester] = useState({
  });

  useEffect(() => {
    axios.get(`http://sig-fisi.application.ryonadev.me/api/Semester/${id}`)
      .then(response => {
        setSemester(response.data);
      })
      .catch(error => {
        console.error('Error fetching semester data:', error);
      });
  }, [id]);

  const formatDate = (dateString) => {
    const dateObject = new Date(dateString);
    const formattedDate = dateObject.toISOString().split('T')[0];
    return formattedDate;
  };

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setSemester(prevSemester => ({
      ...prevSemester,
      [name]: value,
    }));
  };

  const handleUpdateSemester = async (e) => {
    e.preventDefault();

    const formattedStartDate = formatDate(semester.startDate);
    const formattedEndDate = formatDate(semester.endDate);

    const updatedSemester = {
      ...semester,
      startDate: formattedStartDate,
      endDate: formattedEndDate,
    };

    try {
      await axios.put(`https://sig-fisi.application.ryonadev.me/api/Semester/${id}`, updatedSemester);
    } catch (error) {
      console.error('Error updating semester:', error);
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
        <button style={{ backgroundColor: "#4caf50"}} type="submit">Editar Semestre</button>
      </form>
    </div>
  );
};

export default UpdateSemesterComponent;
