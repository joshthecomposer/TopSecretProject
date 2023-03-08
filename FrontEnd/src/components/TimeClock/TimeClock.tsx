import { FormEvent, useState, useEffect } from "react";
import { IUser } from "../../pages/Dashboard";
import axios from "axios";

export interface IPunch {
    timePunchId: number;
    employeeId: number;
    punchType: boolean;
    punchTime: Date;
    employee: IUser;
}

export default function TimeClock({
    userInfo,
}: {
    userInfo: IUser | undefined | null;
}) {
    const [checked, setChecked] = useState(false);

    function handleSubmit(event: FormEvent<HTMLFormElement>) {
        event.preventDefault();

        axios
            .post("http://localhost:5014/api/timeclock/punch", {
                punchType: checked,
                employeeId: userInfo?.employeeId,
            })
            .then((response) => console.log(response))
            .catch((error) => console.log(error));
    }

    return (
        <section className="bg-[#26263a] p-4 flex flex-col gap-4">
            <h2 className="text-xl">Time Clock</h2>
            <div className="flex gap-4">
                <div className="bg-[#2f2f47] p-4 flex-1">
                    <p>You are scheduled to work today.</p>
                </div>
                <div className="bg-[#2f2f47] p-4 flex-[3]">
                    <table className="w-full text-left">
                        <thead className="flex gap-4 mb-2">
                            <tr>
                                <th className="flex-1">Date</th>
                                <th className="flex-1">In</th>
                                <th className="flex-1">Out</th>
                                <th className="flex-1">Hours</th>
                            </tr>
                        </thead>
                        <tbody className="flex flex-col gap-4 mb-4">
                            {/* {userInfo?.punches.map((punch: IPunch, idx) => {
                                return (
                                    <tr className="flex gap-4">
                                        <td className="p-2 bg-[#26263a] flex-1">
                                            3/8/2023
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
                            })} */}
                        </tbody>
                    </table>
                    <form className="flex gap-4" onSubmit={handleSubmit}>
                        <div className="flex flex-col gap-2 items-center justify-center">
                            <label htmlFor="type">In?</label>
                            <input
                                type="checkbox"
                                id="type"
                                checked={checked}
                                onChange={(e) => setChecked(!checked)}
                            />
                        </div>
                        <button className="bg-[#ADADF6] text-[#26263a] p-2 border-[#ADADF6] border-2 hover:bg-[#26263a] hover:text-[#ADADF6] transition-colors">
                            Add Punch
                        </button>
                    </form>
                </div>
            </div>
        </section>
    );
}
