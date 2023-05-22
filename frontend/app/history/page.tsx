'use client';

import { ResponseResult } from "@/types/response/ResponseResult";
import { WordRecord } from "@/types/response/WordRecord";
import customAxios from "@/utils/axiosConfig";
import { generateDate, months } from "@/utils/calendar";
import cn from "@/utils/cn";
import axios from "axios";
import dayjs from "dayjs";
import moment from "moment";
import React, { useEffect, useState } from "react";
import { GrFormNext, GrFormPrevious } from "react-icons/gr";
import { toast } from "react-toastify";

type Props = {
}

const Page = (props: Props) => {

    const days = ["S", "M", "T", "W", "T", "F", "S"];
    const currentDate = dayjs();
    const [today, setToday] = useState(currentDate);
    const [selectDate, setSelectDate] = useState(currentDate);
    const [wordRecords, setWordRecords] = useState<WordRecord[]>()

    useEffect(() => {
        const fetchWordsByDate = async () => {
            try {
                const date = moment(selectDate.toDate().toLocaleDateString()).format('YYYY-MM-DD')
                const { data } = await customAxios.get<ResponseResult<WordRecord[]>>(`/api/words?date=${date}`)
                if (data.status === 200) {
                    setWordRecords(data.data)
                }

            } catch (error) {
                if (axios.isAxiosError(error)) {
                    toast.error(error.message)
                }
            }
        }
        fetchWordsByDate()
    }, [selectDate])

    return (
        <div className="flex gap-10 justify-center mx-auto h-full items-center sm:flex-row flex-col px-4">
            <div className="w-96 h-96 mt-5 md:mt-0">
                <div className="flex justify-between items-center">
                    <h1 className="select-none font-semibold">
                        {months[today.month()]}, {today.year()}
                    </h1>
                    <div className="flex gap-10 items-center ">
                        <GrFormPrevious
                            className="w-5 h-5 cursor-pointer hover:scale-105 transition-all"
                            onClick={() => {
                                setToday(today.month(today.month() - 1));
                            }}
                        />
                        <h1
                            className=" cursor-pointer hover:scale-105 transition-all"
                            onClick={() => {
                                setToday(currentDate);
                            }}
                        >
                            Today
                        </h1>
                        <GrFormNext
                            className="w-5 h-5 cursor-pointer hover:scale-105 transition-all"
                            onClick={() => {
                                setToday(today.month(today.month() + 1));
                            }}
                        />
                    </div>
                </div>
                <div className="grid grid-cols-7 ">
                    {days.map((day, index) => {
                        return (
                            <h1
                                key={index}
                                className="text-sm text-center h-14 w-14 grid place-content-center text-gray-500 select-none"
                            >
                                {day}
                            </h1>
                        );
                    })}
                </div>
                <div className=" grid grid-cols-7 ">
                    {generateDate(today.month(), today.year()).map(
                        ({ date, currentMonth, today }, index) => {
                            return (
                                <div
                                    key={index}
                                    className="p-2 text-center h-14 grid place-content-center text-sm border-t"
                                >
                                    <h1
                                        className={cn(
                                            currentMonth ? "" : "text-gray-400",
                                            today
                                                ? "bg-red-600 text-white"
                                                : "",
                                            selectDate
                                                .toDate()
                                                .toDateString() ===
                                                date.toDate().toDateString()
                                                ? "bg-black text-white"
                                                : "",
                                            "h-10 w-10 rounded-full grid place-content-center hover:bg-black hover:text-white transition-all cursor-pointer select-none"
                                        )}
                                        onClick={() => {
                                            setSelectDate(date);
                                        }}
                                    >
                                        {date.date()}
                                    </h1>
                                </div>
                            );
                        }
                    )}
                </div>
            </div>
            <div className="h-96 w-96 ">
                <h1 className="font-semibold">
                    Words transalted on {selectDate.toDate().toDateString()}
                </h1>
                <div className="mt-2 bg-white pl-2">
                    {
                        wordRecords && wordRecords.map(word =>
                        (
                            <div key={word.id} className="flex text-black space-x-2">
                                <div>{word.englishWord}</div>
                                <div>{word.translation.definition}</div>
                            </div>
                        ))
                    }
                </div>
            </div>
        </div>
    );
}


export default Page