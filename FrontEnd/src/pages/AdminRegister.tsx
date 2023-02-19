import { useParams } from "react-router";
import RegisterForm from "../components/RegisterForm";

export default function () {
    const { slug } = useParams();

    return (
        <main className="flex items-center justify-center h-screen">
            <RegisterForm />
        </main>
    );
}
