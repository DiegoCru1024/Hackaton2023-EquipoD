import React from 'react';

const ClassroomForm = ({ classroomOptions, idSchedule }) => {
  return (
    <form style={{ padding: '15px' }}>
      <label htmlFor="selectOption">Seleccione Aula:</label>
      <select id="selectOption" name="selectOption">
        {classroomOptions.map((classroom) => (
          <option key={classroom.id} value={classroom.id}>
            {classroom.code}
          </option>
        ))}
      </select>
    </form>
  );

};

export default ClassroomForm;
