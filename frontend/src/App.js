import {BrowserRouter, Route, Routes} from "react-router-dom";
import SideBar from "./components/sidebarComponent/sidebarComponent";
import './globalStyles.scss'

function App() {
    return (
        <BrowserRouter>
            <SideBar/>
            <Routes>
                <Route/>
            </Routes>
        </BrowserRouter>
    );
}

export default App;
