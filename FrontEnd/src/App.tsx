import { BrowserRouter, Route, Routes } from "react-router-dom";
import AdminRegister from "./pages/AdminRegister";
import Landing from "./pages/Landing";
import EmployeeRegister from "./pages/EmployeeRegister";

function App() {
    return (
        <>
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<Landing />} />
                    <Route
                        path="/admin/register/:slug"
                        element={<AdminRegister />}
                    />
                    <Route
                        path="/employee/register/:slug"
                        element={<EmployeeRegister />}
                    />
                </Routes>
            </BrowserRouter>
        </>
    );
}

export default App;
