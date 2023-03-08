import cookies from "../lib/stores";
import { useState, useEffect } from "react";
import { Navigate } from "react-router-dom";
import Navbar from "../components/Navbar/Navbar";
import TimeClock from "../components/TimeClock/TimeClock";

export interface IUserToken {
    employeeId: number;
    email: string;
    isAdmin: boolean;
}

export interface IUser extends IUserToken {
    firstName: string;
    lastName: string;
    punches: [];
}

export default function () {
    const [userToken, setUserToken] = useState<IUserToken | null>(
        cookies.cookies.get("userCookie")
    );
    const [userInfo, setUserInfo] = useState<IUser | null>();
    const currentDate = new Date();

    useEffect(() => {
        fetch("http://localhost:5014/api/" + userToken?.employeeId)
            .then((response) => response.json())
            .then((responseData) => {
                console.log(responseData);
                setUserInfo(responseData);
            })
            .catch((error) => console.error(error));
    }, []);

    if (!userToken) {
        return <Navigate to="/login" />;
    }

    return (
        <>
            <Navbar />
            <main className="p-4 w-[1440px] mx-auto text-[#ADADF6] flex flex-col gap-4">
                <header className="bg-[#26263a] p-4 flex justify-between">
                    <h1 className="text-2xl">
                        Welcome back,{" "}
                        <span className="block text-6xl">
                            {userInfo?.firstName} {userInfo?.lastName}
                        </span>
                    </h1>
                    <p className="text-3xl">{currentDate.toDateString()}</p>
                </header>
                <TimeClock userInfo={userInfo} />
            </main>
        </>
    );
}
