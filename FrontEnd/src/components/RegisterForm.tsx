import { FormEvent, useState } from "react";
import ButtonBlue from "./Buttons/ButtonBlue";
import TextInput from "./Inputs/TextInput";

interface User {
    firstName: string;
    lastName: string;
    email: string;
    password: string;
    confirmPassword: string;
}

export default function RegisterForm() {
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");

    function handleSubmit(event: FormEvent<HTMLFormElement>) {
        // /api/admin/create
        event.preventDefault();

        fetch("localhost:5014/api/admin/create", {
            method: "POST",
            body: JSON.stringify({
                firstName,
                lastName,
                email,
                password,
                confirmPassword,
            }),
        })
            .then((response) => console.log(response))
            .catch((error) => console.error(error));
    }

    return (
        <main className="p-5 shadow-lg bg-neutral-200 flex flex-col gap-4">
            <h1 className="text-center text-4xl font-bold">
                Admin Registration
            </h1>
            <form className="flex flex-col gap-4" onSubmit={handleSubmit}>
                <TextInput
                    id="firstName"
                    type="text"
                    placeholder="First Name"
                    value={firstName}
                    onChange={(e: FormEvent<HTMLInputElement>) =>
                        setFirstName(e.currentTarget.value)
                    }
                />
                <TextInput
                    id="lastName"
                    type="text"
                    placeholder="Last Name"
                    value={lastName}
                    onChange={(e: FormEvent<HTMLInputElement>) =>
                        setLastName(e.currentTarget.value)
                    }
                />
                <TextInput
                    id="email"
                    type="text"
                    placeholder="Email"
                    value={email}
                    onChange={(e: FormEvent<HTMLInputElement>) =>
                        setEmail(e.currentTarget.value)
                    }
                />
                <TextInput
                    id="password"
                    type="password"
                    placeholder="Password"
                    value={password}
                    onChange={(e: FormEvent<HTMLInputElement>) =>
                        setPassword(e.currentTarget.value)
                    }
                />
                <TextInput
                    id="confirmPassword"
                    type="password"
                    placeholder="Confirm Password"
                    value={confirmPassword}
                    onChange={(e: FormEvent<HTMLInputElement>) =>
                        setConfirmPassword(e.currentTarget.value)
                    }
                />
                <ButtonBlue>Submit</ButtonBlue>
            </form>
        </main>
    );
}
