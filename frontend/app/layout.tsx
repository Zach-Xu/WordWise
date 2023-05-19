'use client'

import { usePathname } from 'next/navigation'
import './globals.css'
import { Inter } from 'next/font/google'
import { Fragment } from 'react'
import Navbar from '@/components/Navbar'

const inter = Inter({ subsets: ['latin'] })

export const metadata = {
  title: 'Word Wise',
  description: 'Learn English words here',
}

export default function RootLayout({ children, }: {
  children: React.ReactNode
}) {

  const pathname = usePathname()

  return (
    <html lang="en">
      <body className={inter.className}>
        {
          pathname === '/' ? children :
            <div className='w-screen h-screen overflow-x-hidden overflow-y-scroll bg-blue-100 flex flex-col'>
              <Navbar />
              <section className='flex-1 '>{children}</section>
            </div>
        }
      </body>
    </html>
  )
}
