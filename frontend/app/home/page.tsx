import React from 'react'

type Props = {}

const languageNames: string[] = [
    "Bulgarian",
    "Czech",
    "Danish",
    "German",
    "Greek",
    "English",
    "Spanish",
    "Estonian",
    "Finnish",
    "French",
    "Hungarian",
    "Indonesian",
    "Italian",
    "Japanese",
    "Korean",
    "Lithuanian",
    "Latvian",
    "Norwegian (Bokmål)",
    "Dutch",
    "Polish",
    "Portuguese (all Portuguese varieties mixed)",
    "Romanian",
    "Russian",
    "Slovak",
    "Slovenian",
    "Swedish",
    "Turkish",
    "Ukrainian",
    "Chinese",
];

const page = (props: Props) => {
    return (
        <div className='h-full flex flex-col justify-center'>
            <div className='flex flex-col max-w-[700px] mx-auto border-2 bg-white shadow-lg rounded-lg p-4 space-y-4'>
                <input type="text" className='active:outline-none focus:outline-none p-1 px-2' placeholder='English Word' />
                <select name="" id="">
                    <option value="" disabled selected hidden>Targeted language</option>
                    {
                        languageNames.map((name, idx) => (
                            <option key={idx} value={name}>{name}</option>
                        ))
                    }
                </select>
                <button className='bg-blue-400 text-white p-1 rounded-md px-2 hover:bg-blue-500'>Translate</button>
                <p className='bg-gray-200 p-2 rounded-md'>Transaltion</p>
                <button className='bg-blue-400 text-white p-1 rounded-md px-2 hover:bg-blue-500'>Save the word</button>
            </div>
        </div>
    )
}

export default page