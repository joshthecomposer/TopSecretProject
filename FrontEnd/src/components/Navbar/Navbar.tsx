import { useState } from "react";
import {
    BsFillHouseDoorFill,
    BsGearFill,
    BsFillCalendarEventFill,
} from "react-icons/bs";
import { useNavigate } from "react-router-dom";
import cookies from "../../lib/stores";
import { RiLogoutBoxFill } from "react-icons/ri";

export default function Navbar() {
    const [expandNav, setExpandNav] = useState(false);
    const navigate = useNavigate();

    return (
        <div
            onMouseEnter={() => setExpandNav(true)}
            onMouseLeave={() => setExpandNav(false)}
            className="h-[100svh] p-4 flex flex-col gap-4 justify-center items-center bg-[#2a2a40] w-fit fixed shadow-lg"
        >
            <a
                href="/dashboard"
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
                        transitionDuration: expandNav ? "500ms" : "100ms",
                        transitionDelay: expandNav ? "300ms" : "0ms",
                    }}
                >
                    Home
                </p>
            </a>
            <hr className="h-[3px] my-4 border-0 bg-[#ADADF6] w-full" />
            <a
                href="/schedule"
                className="flex items-center justify-start relative transition-all duration-500 p-3 rounded-full shadow-lg bg-[#32324d] hover:bg-[#ADADF6] text-[#ADADF6] hover:text-[#2a2a40]"
                style={{
                    width: expandNav ? 256 : 56,
                }}
            >
                <BsFillCalendarEventFill size={32} className="flex-none" />
                <p
                    className="absolute right-3 font-bold transition-opacity"
                    style={{
                        opacity: expandNav ? 100 : 0,
                        transitionDuration: expandNav ? "500ms" : "100ms",
                        transitionDelay: expandNav ? "300ms" : "0ms",
                    }}
                >
                    Schedule
                </p>
            </a>
            <a
                href="/settings"
                className="flex items-center justify-start relative transition-all duration-500 p-3 rounded-full shadow-lg bg-[#32324d] hover:bg-[#ADADF6] text-[#ADADF6] hover:text-[#2a2a40]"
                style={{
                    width: expandNav ? 256 : 56,
                }}
            >
                <BsGearFill size={32} className="flex-none" />
                <p
                    className="absolute right-3 font-bold transition-opacity"
                    style={{
                        opacity: expandNav ? 100 : 0,
                        transitionDuration: expandNav ? "500ms" : "100ms",
                        transitionDelay: expandNav ? "300ms" : "0ms",
                    }}
                >
                    Settings
                </p>
            </a>
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
                        transitionDuration: expandNav ? "500ms" : "100ms",
                        transitionDelay: expandNav ? "300ms" : "0ms",
                    }}
                >
                    Logout
                </p>
            </button>
        </div>
    );
}
