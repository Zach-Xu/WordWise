
import Navbar from "@/components/Navbar";
import { Fragment } from "react";

export default function HomeLayout({
    children,
}: {
    children: React.ReactNode;
}) {
    return <Fragment>
        <div className='w-screen h-screen overflow-x-hidden overflow-y-scroll bg-blue-100 flex flex-col'>
            <Navbar />
            <section className='flex-1 '>{children}</section>
        </div>
    </Fragment>
}