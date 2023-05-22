export interface WordRecord {
    id: number
    englishWord: string
    translation: Translation
    createdTime: string
    isMemorized: boolean
    frequency: number
}

export interface Translation {
    language: number
    definition: string
}