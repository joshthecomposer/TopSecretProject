import { FormEvent, useState, useEffect } from "react";
import { IUser } from "../../pages/Dashboard";
import axios from "axios";

export interface IPunch {
    employee: IUser;
    employeeId: number;
    punchIn: string;
    punchOut: string;
    createdAt: string;
    updatedAt: string;
    timePunchId: number;
}

export default function TimeClock({
    userInfo,
}: {
    userInfo: IUser | undefined | null;
}) {
    const [userPunches, setUserPunches] = useState<IPunch[]>();

    async function handleSubmit(event: FormEvent<HTMLFormElement>) {
        if (!userPunches) return;
        if (!userInfo) return;

        event.preventDefault();

        if (userPunches.length === 0) {
            axios
                .post("http://localhost:5014/api/timeclock/punch", {
                    employeeId: userInfo.employeeId,
                    punchIn: new Date(),
                })
                .then((response) => console.log(response))
                .catch((error) => console.error(error));
            return;
        }

        const { data: latest }: { data: IPunch } = await axios.get(
            `http://localhost:5014/api/timeclock/punch/${userInfo.employeeId}/latest`
        );

        if (!latest.punchOut) {
            axios
                .put(
                    `http://localhost:5014/api/timeclock/punch/${latest.timePunchId}`,
                    { punchOut: new Date() }
                )
                .then((response) => console.log(response))
                .catch((error) => console.error(error));
            return;
        }

        axios
            .post("http://localhost:5014/api/timeclock/punch", {
                employeeId: userInfo.employeeId,
                punchIn: new Date(),
            })
            .then((response) => console.log(response))
            .catch((error) => console.error(error));
        return;
    }

    useEffect(() => {
        if (!userInfo) return;

        axios
            .get(
                `http://localhost:5014/api/timeclock/punch/${userInfo.employeeId}/all`
            )
            .then((response) => setUserPunches(response.data))
            .catch((error) => console.log(error));
    }, [userInfo]);

    return (
        <section className="bg-[#26263a] p-4 flex flex-col gap-4">
            <h2 className="text-xl">Time Clock</h2>
            <div className="flex gap-4">
                <div className="bg-[#2f2f47] p-4 flex-1">
                    <p>You are scheduled to work today.</p>
                </div>
                <div className="bg-[#2f2f47] p-4 flex-[3]">
                    <table className="w-full text-left">
                        <thead>
                            <tr className="flex gap-4 mb-2">
                                <th className="flex-1">Date</th>
                                <th className="flex-1">In</th>
                                <th className="flex-1">Out</th>
                                <th className="flex-1">Hours</th>
                            </tr>
                        </thead>
                        <tbody className="flex flex-col gap-4 mb-4">
                            {userPunches?.map((punch: IPunch) => {
                                return (
                                    <tr
                                        key={punch.timePunchId}
                                        className="flex gap-4"
                                    >
                                        <td className="p-2 bg-[#26263a] flex-1">
                                            date
                                        </td>
                                        <td className="p-2 bg-[#26263a] flex-1">
                                            time
                                        </td>
                                        <td className="p-2 bg-[#26263a] flex-1">
                                            time
                                        </td>
                                        <td className="p-2 bg-[#26263a] flex-1">
                                            time
                                        </td>
                                    </tr>
                                );
                            })}
                        </tbody>
                    </table>
                    <form className="flex gap-4" onSubmit={handleSubmit}>
                        <button className="bg-[#ADADF6] text-[#26263a] p-2 border-[#ADADF6] border-2 hover:bg-[#26263a] hover:text-[#ADADF6] transition-colors">
                            Add Punch
                        </button>
                    </form>
                </div>
            </div>
        </section>
    );
}
