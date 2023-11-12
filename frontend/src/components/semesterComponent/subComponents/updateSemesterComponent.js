import React, { useState } from 'react';
import styles from './updateSemesterStyles.module.scss';

const UpdateSemesterComponent = ({ initialSemesterDetails, onUpdate }) => {
  const [semesterDetails, setSemesterDetails] = useState(initialSemesterDetails);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setSemesterDetails({
      ...semesterDetails,
      [name]: value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onUpdate(semesterDetails);
  };

  return (
    <form className={styles.updateSemester} onSubmit={handleSubmit}>
      <div>
        <label htmlFor="semesterName">Nombre del Semestre:</label>
        <input
          type="text"
          id="semesterName"
          name="name"
          value={semesterDetails.name}
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
          value={semesterDetails.startDate}
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
          value={semesterDetails.endDate}
          onChange={handleInputChange}
          required
        />
      </div>
      <button type="submit">Actualizar Semestre</button>
    </form>
  );
};

export default UpdateSemesterComponent;
