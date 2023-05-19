'use client';

import Link from 'next/link';
import React from 'react'

type Props = {}

const Navbar = (props: Props) => {

    const menu = (e: React.MouseEvent) => {

    }
    return (
        <nav className="p-5 bg-white shadow md:flex md:items-center md:justify-between sticky top-0 z-1 ">
            <div className="flex justify-between items-center ">
                <span className="text-2xl font-[Poppins] cursor-pointer text-blue-400">
                    Word Wise
                </span>

                <span className="text-3xl cursor-pointer mx-2 md:hidden block">
                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24"
                        strokeWidth={1.5} stroke="currentColor" className="w-6 h-6" onClick={e => menu(e)}>
                        <path strokeLinecap="round" strokeLinejoin="round" d="M3.75 6.75h16.5M3.75 12h16.5m-16.5 5.25h16.5" />
                    </svg>
                </span>
            </div>

            <ul className="md:flex md:items-center z-[-1] md:z-auto md:static absolute bg-white w-full left-0 md:w-auto md:py-0 py-4 md:pl-0 pl-7 md:opacity-100 opacity-0 top-[-400px] transition-all ease-in duration-500">
                <li className="mx-4 my-6 md:my-0">
                    <Link href="/home" className="text-xl hover:text-cyan-500 duration-500">HOME</Link>
                </li>
                <li className="mx-4 my-6 md:my-0">
                    <Link href="/history" className="text-xl hover:text-cyan-500 duration-500">HISTORY</Link>
                </li>
                <button className="bg-cyan-400 text-white font-[Poppins] duration-500 px-6 py-2 mx-4 hover:bg-cyan-500 rounded ">
                    Logout
                </button>
                <h2 className=""></h2>
            </ul>
        </nav>
    )
}

export default Navbar