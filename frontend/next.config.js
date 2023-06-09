const { PHASE_DEVELOPMENT_SERVER } = require('next/dist/shared/lib/constants')

/** @type {import('next').NextConfig} */
const nextConfig = (phase) => {
    if (phase === PHASE_DEVELOPMENT_SERVER) {
        return {
            env: {
                API_BASE_URL: 'http://localhost:5263'
            }
        }
    } else {
        return {
            env: {
                API_BASE_URL: 'https://word-wise.azurewebsites.net'
            }
        }
    }

}



module.exports = nextConfig
