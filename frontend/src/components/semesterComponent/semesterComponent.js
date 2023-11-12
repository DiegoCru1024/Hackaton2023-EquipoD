import React, { useState } from 'react';
import CreateSemesterComponent from './subComponents/createSemesterComponent';
import DetailSemesterComponent from './subComponents/detailSemesterComponent';
import UpdateSemesterComponent from './subComponents/updateSemesterComponent';

const SemesterComponent = () => {
  const [currentSemesterDetails, setCurrentSemesterDetails] = useState({
    name: 'Semestre de Ejemplo',
    startDate: '2023-01-01',
    endDate: '2023-06-30',
  });

  const handleUpdateSemester = (updatedSemesterDetails) => {
    console.log('Semester Updated:', updatedSemesterDetails);
    setCurrentSemesterDetails(updatedSemesterDetails);
  };

  return (
    <div style={{overflowY:"scroll", height:"100vh", width:"85vw"}}>
      <h1>Crear Semestre</h1>
      <CreateSemesterComponent />
      <hr />
      <DetailSemesterComponent semesterDetails={currentSemesterDetails} />
      <hr />
      <UpdateSemesterComponent
        initialSemesterDetails={currentSemesterDetails}
        onUpdate={handleUpdateSemester}
      />
    </div>
  );
};

export default SemesterComponent;
