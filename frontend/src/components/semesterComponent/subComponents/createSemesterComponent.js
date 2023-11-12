import React, { useState } from 'react';
import styles from './createSemesterStyles.module.scss';

const CreateSemesterComponent = () => {
  const [semesterName, setSemesterName] = useState('');
  const [startDate, setStartDate] = useState('');
  const [endDate, setEndDate] = useState('');

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    if (name === 'semesterName') {
      setSemesterName(value);
    } else if (name === 'startDate') {
      setStartDate(value);
    } else if (name === 'endDate') {
      setEndDate(value);
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log('Semester Details:', { semesterName, startDate, endDate });
  };

  return (
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
      <button type="submit">Crear Semestre</button>
    </form>
  );
};

export default CreateSemesterComponent;
