export default function ({ ...rest }) {
    return (
        <input
            {...rest}
            className="bg-neutral-50 shadow focus:outline-none p-3"
        />
    );
}
