import React from 'react';

const ClassroomForm = ({classroomOptions}) => {
    return (
        <form style={{padding: "10px"}}>
            <label htmlFor="selectOption">Selecciona un Pabellón:</label>
            <select id="selectOption" name="selectOption">
                {classroomOptions.map((classroom) => (
                    <option key={classroom.id} value={classroom.code}>
                        Aula - {classroom.classroomCode}
                    </option>
                ))}
            </select>
            <label htmlFor="selectOption">Selecciona un semestre:</label>
            <select id="selectOption" name="selectOption">
                {classroomOptions.map((classroom) => (
                    <option key={classroom.id} value={classroom.code}>
                        Aula - {classroom.classroomCode}
                    </option>
                ))}
            </select>
        </form>
    );
};

export default ClassroomForm;
