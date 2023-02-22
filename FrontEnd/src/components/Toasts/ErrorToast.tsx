export interface IToastNotification {
    title: string;
    content: string;
    closeFunction?: () => void;
}

export default function ErrorToast({
    title,
    content,
    closeFunction,
    ...rest
}: IToastNotification) {
    return (
        <div
            {...rest}
            className="bg-red-500 p-4 text-white shadow-lg flex justify-between"
        >
            <div>
                <h2 className="text-3xl">{title}</h2>
                <p>{content}</p>
            </div>
            <button
                onClick={closeFunction}
                className="shadow bg-red-600 hover:bg-red-400 transition-colors p-4 font-bold"
            >
                Close
            </button>
        </div>
    );
}
