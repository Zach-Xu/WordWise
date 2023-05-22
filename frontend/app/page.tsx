'use client';

import Login from "@/components/Login";
import Signup from "@/components/Signup";
import { useRouter } from "next/navigation";
import { useEffect } from "react";

export default function Home() {

  const router = useRouter()

  useEffect(() => {
    // redirect to home page
    // skip authentication for now
    router.push('/home')
  }, [])

  return (
    <div className='flex flex-col space-y-4 lg:flex-row min-h-screen w-screen items-center justify-center bg-[#f0f2f5]'>
      <div className='flex flex-col  p-5 px-10 text-xl mt-5 text-center lg:text-left  max-w-[600px]'>
        <h1 className='text-blue-700 font-bold text-5xl md:-mt-20'>Word Wise</h1>
        <p className='py-6 px-2'>
          Learn English words and increase vocabulary in a wise way.
        </p>
      </div>
      <div >
        <Login />
        <Signup />
      </div>
    </div>
  )
}
