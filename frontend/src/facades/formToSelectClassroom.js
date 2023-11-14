import React from 'react';

const ClassroomForm = ({ classroomOptions }) => {
    return (
        <form style={{ padding: "15px" }}>
            <label style={{marginBottom: '15px'}}  htmlFor="selectOption">Seleccione Pabellón:</label>
            <div style={{ display: 'flex',marginBottom: '30px' }} >
                <label htmlFor="nuevoPabellon">Nuevo Pabellón</label>
                <input type="radio" id="nuevoPabellon" name="pabellonType" value="nuevo" />

                <label htmlFor="antiguoPabellon">Antiguo Pabellón</label>
                <input type="radio" id="antiguoPabellon" name="pabellonType" value="antiguo" />

            </div>

            <label htmlFor="selectOption">Seleccione Aula:</label>
            <select id="selectOption" name="selectOption">
                {classroomOptions.map((classroom) => (
                    <option key={classroom.id} value={classroom.code}>
                        Aula - {classroom.code}
                    </option>
                ))}
            </select>
        </form>
    );
};

export default ClassroomForm;
