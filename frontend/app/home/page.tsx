import React from 'react'

type Props = {}

const page = (props: Props) => {
    return (
        <div className='w-screen h-screen overflow-hidden bg-blue-100'>
            <div>
                <input type="text" className='active:outline-none focus:outline-none p-1 px-2' placeholder='English Word' />
                <button className='bg-blue-400 text-white p-1 rounded-md px-2'>Translate</button>
            </div>
            <div className='flex space-x-2'>
                <div>Result:</div>
                <p>123</p>
            </div>
        </div>
    )
}

export default page