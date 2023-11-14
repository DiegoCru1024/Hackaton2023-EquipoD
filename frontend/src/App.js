import React from "react";
import {BrowserRouter as Router, Route, Routes} from "react-router-dom";
import SemesterComponent from "./components/semesterComponent/semesterComponent";
import CreateSemesterComponent from "./components/semesterComponent/subComponents/createSemesterComponent";
import UpdateSemesterComponent from "./components/semesterComponent/subComponents/updateSemesterComponent";
import DetailSemesterComponent from "./components/semesterComponent/subComponents/detailSemesterComponent";
import Sidebar from "./components/sidebarComponent/sidebarComponent";
import LoginComponent from "./components/loginComponent/loginComponent";
import HomeComponent from "./components/homeComponent/homeComponent";
import './globalStyles.scss';
import GroupComponent from "./components/groupComponent/groupComponent";
import CreateGroupComponent from "./components/groupComponent/subcomponents/createGroupComponent";
import DetailGroupComponent from "./components/groupComponent/subcomponents/detailGroupComponent";
import UpdateGroupComponent from "./components/groupComponent/subcomponents/updateGroupComponent";
import ClassroomComponent from "./components/classroomComponent/classroomComponent";


const SidebarLayout = ({children}) => (
    <div className={"appContainer"}>
        <Sidebar/>
        {children}
    </div>
);

function App() {
    return (
        <Router>
            <Routes>
                <Route path={"/"} element={<LoginComponent/>}/>
                <Route
                    path={"/home"}
                    element={
                        <SidebarLayout>
                            <HomeComponent/>
                        </SidebarLayout>
                    }
                />
                <Route
                    path={"/semester"}
                    element={
                        <SidebarLayout>
                            <SemesterComponent/>
                        </SidebarLayout>
                    }
                />
                <Route
                    path={"/semester/create"}
                    element={
                        <SidebarLayout>
                            <CreateSemesterComponent/>
                        </SidebarLayout>
                    }
                />
                <Route
                    path={"/semester/details/:id"}
                    element={
                        <SidebarLayout>
                            <DetailSemesterComponent/>
                        </SidebarLayout>
                    }
                />
                <Route
                    path={"/semester/update/:id"}
                    element={
                        <SidebarLayout>
                            <UpdateSemesterComponent/>
                        </SidebarLayout>
                    }
                />
                <Route
                    path={"/group"}
                    element={
                        <SidebarLayout>
                            <GroupComponent/>
                        </SidebarLayout>
                    }
                />
                <Route
                    path={"/group/create"}
                    element={
                        <SidebarLayout>
                            <CreateGroupComponent/>
                        </SidebarLayout>
                    }
                />
                <Route
                    path={"/group/details/:id"}
                    element={
                        <SidebarLayout>
                            <DetailGroupComponent/>
                        </SidebarLayout>
                    }
                />
                <Route
                    path={"/group/update/:groupID"}
                    element={
                        <SidebarLayout>
                            <UpdateGroupComponent/>
                        </SidebarLayout>
                    }
                />
                <Route
                    path={"/classroom"}
                    element={
                        <SidebarLayout>
                            <ClassroomComponent/>
                        </SidebarLayout>
                    }
                />
            </Routes>
        </Router>
    );
}

export default App;
