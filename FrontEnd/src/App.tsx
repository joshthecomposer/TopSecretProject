import { BrowserRouter, Route, Routes } from "react-router-dom";
import AdminRegister from "./pages/AdminRegister";
import Landing from "./pages/Landing";

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
                </Routes>
            </BrowserRouter>
        </>
    );
}

export default App;
