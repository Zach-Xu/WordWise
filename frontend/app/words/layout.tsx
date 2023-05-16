import { Fragment } from "react";

export default function HomeLayout({
    children,
}: {
    children: React.ReactNode;
}) {
    return <Fragment>
        <div>words header</div>
        {children}
    </Fragment>
}