import React from 'react';

const SemesterForm = ({semesterOptions}) => {
    return (
        <form style={{padding: "10px"}}>
            <label htmlFor="selectOption">Selecciona un semestre:</label>
            <select id="selectOption" name="selectOption">
                {semesterOptions.map((semester) => (
                    <option key={semester.id} value={semester.code}>
                        {semester.code} - {semester.isActive ? "Activo" : "Inactivo"}
                    </option>
                ))}
            </select>
        </form>
    );
};

export default SemesterForm;
