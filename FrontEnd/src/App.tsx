import { useEffect, useState } from "react";

interface User {
    userId: number;
    userName: string;
}

function App() {
    const [testData, setTestData] = useState<User>();

    useEffect(() => {
        fetchData()
            .then((result) => {
                setTestData(result);
                console.log(result);
            })
            .catch((error) => {
                console.error(error);
            });
    }, []);

    return (
        <div>
            {testData?.userId}: {testData?.userName}
        </div>
    );
}

const fetchData = async () => {
    const data = await fetch("http://localhost:5014/user");

    if (!data.ok) return null;

    const json = await data.json();
    return json;
};

export default App;
