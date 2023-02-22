import axios from "axios";
import ButtonBlue from "../components/Buttons/ButtonBlue";
import TextInput from "../components/Inputs/TextInput";
import ErrorToast from "../components/Toasts/ErrorToast";
import { IToastNotification } from "../components/Toasts/ErrorToast";
import { useState, FormEvent } from "react";
import cookies from "../lib/stores";
import { useNavigate } from "react-router-dom";

export default function () {
    const navigate = useNavigate();
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [errors, setErrors] = useState<IToastNotification[]>([]);

    function handleSubmit(event: FormEvent<HTMLFormElement>) {
        event.preventDefault();

        axios
            .post("http://localhost:5014/api/employee/login", {
                email,
                password,
            })
            .then((response) => {
                console.log(response);
                const { employeeId, email, isAdmin } = response.data;

                cookies.cookies.set(
                    "userCookie",
                    { employeeId, email, isAdmin },
                    {
                        path: "/",
                        maxAge: 86400,
                    }
                );
                navigate("/dashboard");
            })
            .catch((error) => {
                console.log(error);
                const errorsObject = error.response.data.errors;
                const errorsTemp = [];
                for (const err of Object.values(errorsObject)) {
                    errorsTemp.push({ title: "Error", content: err[0] });
                }

                setErrors(errorsTemp);
            });
    }

    function closeErrorToast(content: string) {
        setErrors([...errors].filter((error) => error.content !== content));
    }

    return (
        <main className="flex items-center justify-center h-screen relative">
            <div className="absolute left-0 right-0 top-0 h-64 p-4">
                {errors &&
                    errors.map((toast, toastIndex) => (
                        <ErrorToast
                            key={toastIndex}
                            title="Error"
                            content={toast.content}
                            closeFunction={() => closeErrorToast(toast.content)}
                        />
                    ))}
            </div>
            <div className="p-5 shadow-lg bg-neutral-200 flex flex-col gap-4">
                <h1 className="text-4xl">Employee Login</h1>
                <form className="flex flex-col gap-4" onSubmit={handleSubmit}>
                    <TextInput
                        placeholder="Email"
                        value={email}
                        onChange={(e: FormEvent<HTMLInputElement>) =>
                            setEmail(e.currentTarget.value)
                        }
                    />
                    <TextInput
                        type="password"
                        placeholder="Password"
                        value={password}
                        onChange={(e: FormEvent<HTMLInputElement>) =>
                            setPassword(e.currentTarget.value)
                        }
                    />
                    <ButtonBlue>Submit</ButtonBlue>
                </form>
            </div>
        </main>
    );
}
