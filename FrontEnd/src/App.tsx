import { BrowserRouter, Route, Routes } from "react-router-dom";
import AdminRegister from "./pages/AdminRegister";
import Landing from "./pages/Landing";
import EmployeeRegister from "./pages/EmployeeRegister";
import Dashboard from "./pages/Dashboard";

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
                    <Route path="/dashboard" element={<Dashboard />} />
                </Routes>
            </BrowserRouter>
        </>
    );
}

export default App;
