import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import SemesterComponent from "./components/semesterComponent/semesterComponent";
import CreateSemesterComponent from "./components/semesterComponent/subComponents/createSemesterComponent";
import Sidebar from "./components/sidebarComponent/sidebarComponent";
import LoginComponent from "./components/loginComponent/loginComponent";
import HomeComponent from "./components/homeComponent/homeComponent";
import "./globalStyles.scss";

const SidebarLayout = ({ children }) => (
  <div className={"appContainer"}>
    <Sidebar />
    {children}
  </div>
);

function App() {
  return (
    <Router>
      <Routes>
        <Route path={"/"} element={<LoginComponent />} />
        <Route
          path={"/home"}
          element={
            <SidebarLayout>
              <HomeComponent />
            </SidebarLayout>
          }
        />
        <Route
          path={"/semester"}
          element={
            <SidebarLayout>
              <SemesterComponent />
            </SidebarLayout>
          }
        />
        <Route
          path={"/semester/create"}
          element={
            <SidebarLayout>
              <CreateSemesterComponent />
            </SidebarLayout>
          }
        />
        <Route
          path={"/group"}
          element={
            <SidebarLayout>
              <SemesterComponent />
            </SidebarLayout>
          }
        />
        <Route
          path={"/classroom"}
          element={
            <SidebarLayout>
              <SemesterComponent />
            </SidebarLayout>
          }
        />
      </Routes>
    </Router>
  );
}

export default App;
