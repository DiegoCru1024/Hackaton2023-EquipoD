import {BrowserRouter, Route, Routes} from "react-router-dom";
import SideBar from "./components/sidebarComponent/sidebarComponent";
import LoginComponent from "./components/loginComponent/loginComponent";
import HomeComponent from "./components/homeComponent/homeComponent";
import SemesterComponent from "./components/semesterComponent/semesterComponent";
import './globalStyles.scss';

const SidebarLayout = ({children}) => (
    <div className={'appContainer'}>
        <SideBar/>
        {children}
    </div>
);

function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route
                    path={'/'}
                    element={<LoginComponent/>}
                />
                <Route
                    path={'/home'}
                    element={<SidebarLayout><HomeComponent/></SidebarLayout>}
                />
                <Route
                    path={'/semester'}
                    element={<SidebarLayout><SemesterComponent/></SidebarLayout>}
                />
                <Route
                    path={'/group'}
                    element={<SidebarLayout><SemesterComponent/></SidebarLayout>}
                />
                <Route
                    path={'/classroom'}
                    element={<SidebarLayout><SemesterComponent/></SidebarLayout>}
                />
            </Routes>
        </BrowserRouter>
    )
}

export default App;
