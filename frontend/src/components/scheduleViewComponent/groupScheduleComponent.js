import React from 'react';
import styles from "./scheduleViewStyles.module.scss";

export default function ScheduleComponent({selectedObject}) {
    const scheduleHours = [
        {text: '08:00 - 09:00'},
        {text: '09:00 - 10:00'},
        {text: '10:00 - 11:00'},
        {text: '11:00 - 12:00'},
        {text: '12:00 - 13:00'},
        {text: '13:00 - 14:00'},
        {text: '14:00 - 15:00'},
        {text: '15:00 - 16:00'},
        {text: '16:00 - 17:00'},
        {text: '17:00 - 18:00'},
        {text: '18:00 - 19:00'},
        {text: '19:00 - 20:00'},
        {text: '20:00 - 21:00'},
        {text: '21:00 - 22:00'}
    ];

    const selectedHours = selectedObject.indexes

    const getLabelForRowAndColumn = (rowIndex, colIndex) => {
        const selectedHourIndex = selectedHours.findIndex(coord => coord[0] === rowIndex && coord[1] === colIndex);
        return selectedObject.labels[selectedHourIndex];
    };

    const isCellSelected = (rowIndex, colIndex) => {
        return selectedHours.some(coord => coord[0] === rowIndex && coord[1] === colIndex);
    };


    return (
        <div className={styles.schedulePreview}>
            <table>
                <thead>
                <tr>
                    <th></th>
                    <th>Lunes</th>
                    <th>Martes</th>
                    <th>Miércoles</th>
                    <th>Jueves</th>
                    <th>Viernes</th>
                    <th>Sábado</th>
                </tr>
                </thead>
                <tbody>
                {scheduleHours.map((hour, rowIndex) => (
                    <tr key={hour.text}>
                        <td>{hour.text}</td>
                        {Array.from({length: 6}).map((_, colIndex) => (
                            <td key={colIndex}>
                                {
                                    isCellSelected(rowIndex, colIndex) && (
                                        <p>{getLabelForRowAndColumn(rowIndex, colIndex)}</p>
                                    )
                                }
                            </td>
                        ))}
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    );
}
