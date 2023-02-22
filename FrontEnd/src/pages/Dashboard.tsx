import cookies from "../lib/stores";
import { useState } from "react";
import { useNavigate, Navigate } from "react-router-dom";

export interface IUserToken {
    employeeId: number;
    email: string;
    isAdmin: boolean;
}

export default function () {
    const navigate = useNavigate();
    const [userToken, setUserToken] = useState<IUserToken | null>(
        cookies.cookies.get("userCookie")
    );

    if (!userToken) {
        return <Navigate to="/" />;
    }

    return (
        <div>
            <h1>Welcome {userToken.email}</h1>
            <p>You are {userToken.isAdmin ? "an admin!" : "an employee!"}</p>
            <button
                onClick={() => {
                    cookies.cookies.remove("userCookie");
                    setUserToken(null);
                    navigate("/");
                }}
            >
                Clear Cookie / Logout
            </button>
        </div>
    );
}
