import { PropsWithChildren } from "react";

interface IProps extends PropsWithChildren {}

export default function ({ children, ...rest }: IProps) {
    return (
        <button
            {...rest}
            className="bg-blue-300 hover:bg-blue-200 transition-colors shadow focus:outline-none p-3 font-bold"
        >
            {children}
        </button>
    );
}
