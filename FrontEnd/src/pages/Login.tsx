import ButtonBlue from "../components/Buttons/ButtonBlue";
import TextInput from "../components/Inputs/TextInput";
import ErrorToast from "../components/Toasts/ErrorToast";
import { IToastNotification } from "../components/Toasts/ErrorToast";
import { useState, FormEvent } from "react";

export default function () {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [errors, setErrors] = useState<IToastNotification[]>([]);

    function handleSubmit(event: FormEvent<HTMLFormElement>) {
        event.preventDefault();
    }

    function closeErrorToast() {
        setErrors([]);
    }

    return (
        <main className="flex items-center justify-center h-screen relative">
            <div className="absolute left-0 right-0 top-0 h-64 p-4">
                {errors &&
                    errors.map((toast, toastIndex) => (
                        <ErrorToast
                            title="Error"
                            content={toast.content}
                            closeFunction={closeErrorToast}
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
