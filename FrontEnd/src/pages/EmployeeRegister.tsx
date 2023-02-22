import { useParams } from "react-router";
import RegisterForm from "../components/Registration/RegisterForm";

export default function () {
    const { slug } = useParams();

    return (
        <main className="flex items-center justify-center h-screen">
            <RegisterForm isAdmin={false} />
        </main>
    );
}
