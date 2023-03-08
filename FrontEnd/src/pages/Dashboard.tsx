import cookies from "../lib/stores";
import { useState } from "react";
import { Navigate } from "react-router-dom";
import Navbar from "../components/Navbar/Navbar";

export interface IUserToken {
    employeeId: number;
    email: string;
    isAdmin: boolean;
}

export default function () {
    const [userToken, setUserToken] = useState<IUserToken | null>(
        cookies.cookies.get("userCookie")
    );

    if (!userToken) {
        return <Navigate to="/login" />;
    }

    return (
        <>
            <Navbar />
        </>
    );
}
