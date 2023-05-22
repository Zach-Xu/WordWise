'use client'

import { ResponseResult } from '@/types/response/ResponseResult';
import { WordRecord } from '@/types/response/WordRecord';
import axios from 'axios';
import React, { ChangeEvent, FormEvent, useEffect, useRef, useState } from 'react'
import { toast } from 'react-toastify';

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

const Page = (props: Props) => {

    const [word, setWord] = useState<string>('')
    const [languageCode, setLanguageCode] = useState<number>()
    const [wordRecord, setWordRecord] = useState<WordRecord>()
    const wordInputRef = useRef<HTMLInputElement>(null)

    useEffect(() => {
        let language = localStorage.getItem('language_preference')
        if (language && !isNaN(Number(language))) {
            setLanguageCode(Number(language))
        } else {
            setLanguageCode(-1)
        }
        if (wordInputRef.current) {
            wordInputRef.current.focus()
        }
    }, [])


    const translateWord = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault()
        try {
            const { data } = await axios.post<ResponseResult<WordRecord>>('/api/words', {
                word,
                language: languageCode
            })
            if (data.status === 200) {
                setWordRecord(data.data)
            }

        } catch (error) {
            if (axios.isAxiosError(error)) {
                toast.error(error.message)
            }
        }
    }

    const changeLanguage = (e: ChangeEvent<HTMLSelectElement>) => {
        setLanguageCode(Number(e.target.value))
        localStorage.setItem('language_preference', e.target.value)
    }

    return (
        <div className='h-full flex flex-col justify-center'>
            <form className='flex flex-col max-w-[700px] mx-auto border-2 bg-white shadow-lg rounded-lg p-4 space-y-4' onSubmit={translateWord}>
                <input type="text" required ref={wordInputRef} className='active:outline-none focus:outline-none p-1' value={word} onChange={e => setWord(e.target.value)} placeholder='English Word' />
                <select required value={languageCode} className='py-2 focus:outline-none' onChange={changeLanguage}>
                    <option value={-1} disabled hidden >Targeted language</option>
                    {
                        languageNames.map((name, idx) => (
                            <option key={idx} value={idx}>{name}</option>
                        ))
                    }
                </select>
                <input type='submit' className='bg-blue-400 text-white p-1 rounded-md px-2 hover:bg-blue-500 cursor-pointer' value='Translate' />
                <p className='bg-gray-200 p-2 rounded-md'>
                    {
                        word && wordRecord ? wordRecord.translation.definition : 'Translation'
                    }
                </p>
            </form>
        </div>
    )
}

export default Page