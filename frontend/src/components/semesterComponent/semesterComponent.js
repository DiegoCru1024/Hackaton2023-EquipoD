import React from "react";
import { useNavigate } from "react-router-dom";
import CreateSemesterComponent from "./subComponents/createSemesterComponent";
import DetailSemesterComponent from "./subComponents/detailSemesterComponent";
import UpdateSemesterComponent from "./subComponents/updateSemesterComponent";

const SemesterComponent = () => {
  const [currentSemesterDetails, setCurrentSemesterDetails] = React.useState({
    name: "Semestre de Ejemplo",
    startDate: "2023-01-01",
    endDate: "2023-06-30",
  });

  const navigate = useNavigate();

  const handleUpdateSemester = (updatedSemesterDetails) => {
    console.log("Semester Updated:", updatedSemesterDetails);
    setCurrentSemesterDetails(updatedSemesterDetails);
  };

  const navigateToCreateSemester = () => {
    navigate("/semester/create"); // Ruta a la página de creación
  };

  return (
    <div>
      <h1>Crear Semestre</h1>
      <button onClick={navigateToCreateSemester}>
        Ir a Crear Semestre
      </button>
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
