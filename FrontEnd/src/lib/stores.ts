import Cookies from "universal-cookie";
import { atom } from "jotai";

const cookies = new Cookies();

function useLogout() {
    cookies.remove("userCookie");
}

export default {
    cookies,
    useLogout,
};
