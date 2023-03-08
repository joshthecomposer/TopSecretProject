import cookies from "../lib/stores";
import { useState } from "react";
import { useNavigate, Navigate } from "react-router-dom";
import { DiAptana } from "react-icons/di";
import { BsFillHouseDoorFill } from "react-icons/bs";
import { RiLogoutBoxFill } from "react-icons/ri";

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
    const [expandNav, setExpandNav] = useState(false);

    if (!userToken) {
        return <Navigate to="/login" />;
    }

    return (
        <div
            onMouseEnter={() => setExpandNav(true)}
            onMouseLeave={() => setExpandNav(false)}
            className="h-[100svh] p-4 flex flex-col justify-center items-center bg-[#2a2a40] w-fit"
        >
            <a
                href="#"
                className="flex items-center justify-start relative transition-all duration-500 p-3 rounded-full shadow-lg bg-[#32324d] hover:bg-[#ADADF6] text-[#ADADF6] hover:text-[#2a2a40]"
                style={{
                    width: expandNav ? 256 : 56,
                }}
            >
                <BsFillHouseDoorFill size={32} className="flex-none" />
                <p
                    className="absolute right-3 font-bold transition-opacity"
                    style={{
                        opacity: expandNav ? 100 : 0,
                        transitionDuration: expandNav ? "500ms" : "400ms",
                    }}
                >
                    Home
                </p>
            </a>
            <hr className="h-[3px] my-4 border-0 bg-[#ADADF6] w-full" />
            <hr className="h-[3px] my-4 border-0 bg-[#ADADF6] w-full" />
            <button
                onClick={() => {
                    cookies.useLogout();
                    navigate("/login");
                }}
                className="flex items-center justify-start relative transition-all duration-500 p-3 rounded-full shadow-lg bg-[#32324d] hover:bg-[#ADADF6] text-[#ADADF6] hover:text-[#2a2a40]"
                style={{
                    width: expandNav ? 256 : 56,
                }}
            >
                <RiLogoutBoxFill size={32} className="flex-none" />
                <p
                    className="absolute right-3 font-bold transition-opacity"
                    style={{
                        opacity: expandNav ? 100 : 0,
                        transitionDuration: expandNav ? "500ms" : "400ms",
                    }}
                >
                    Logout
                </p>
            </button>
        </div>
    );
}
