import { LoginDTO } from '@/types/dto/AuthDto'
import { useRouter } from 'next/navigation'

import React, { useState } from 'react'

type Props = {}

const Login = (props: Props) => {

    const router = useRouter()

    const [user, setUser] = useState<LoginDTO>({
        email: '',
        password: ''
    })

    const LoginHandler = async (e: React.FormEvent) => {
        e.preventDefault()
        router.push('/home')
    }

    return (
        <div className='w-[90vw] md:w-[500px]  px-10 bg-white rounded-xl py-10 mx-auto lg:mr-10 flex flex-col items-center shadow-lg'>
            <form className='flex flex-col w-full items-center space-y-3' onSubmit={LoginHandler}>
                <input type="email" name="email" required
                    onChange={e => setUser({ ...user, [e.target.name]: e.target.value })}
                    placeholder='Email' className='w-full border border-gray-400 px-2 py-3 rounded-md' />
                <input type="password" name='password' required
                    onChange={e => setUser({ ...user, [e.target.name]: e.target.value })}
                    placeholder="Password" className='w-full border border-gray-400 px-2 py-3 rounded-md' />
                <input className='bg-[#1877f2] cursor-pointer hover:bg-[#1668d2] w-full py-2 text-white font-bold text-xl rounded-md' type="submit" value="Log In" />

            </form>
            <div className='border-t my-5 border-gray-300 w-full'></div>
            <label htmlFor="my-modal-3" className='btn border-0 hover:bg-[#399d25] bg-[#42b72a] px-4 py-3 text-md font-bold rounded-md text-white'>Create new account</label>
        </div>
    )
}

export default Login