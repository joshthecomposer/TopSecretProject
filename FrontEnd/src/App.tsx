<<<<<<< HEAD
import { BrowserRouter, Route, Routes } from "react-router-dom";
import AdminRegister from "./pages/AdminRegister";
import Landing from "./pages/Landing";
import EmployeeRegister from "./pages/EmployeeRegister";
import Dashboard from "./pages/Dashboard";
import Login from "./pages/Login";

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
                    <Route path="/login" element={<Login />} />
                </Routes>
            </BrowserRouter>
        </>
    );
}

export default App;
=======
import { useState } from 'react'
import reactLogo from './assets/react.svg'
import './App.css'

function App() {
  const [count, setCount] = useState(0)

  return (
    <div className="App">
      <div>
        <a href="https://vitejs.dev" target="_blank">
          <img src="/vite.svg" className="logo" alt="Vite logo" />
        </a>
        <a href="https://reactjs.org" target="_blank">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
      </div>
      <h1>Vite + React</h1>
      <div className="card">
        <button onClick={() => setCount((count) => count + 1)}>
          count is {count}
        </button>
        <p>
          Edit <code>src/App.tsx</code> and save to test HMR
        </p>
      </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>
    </div>
  )
}

export default App
>>>>>>> dev
