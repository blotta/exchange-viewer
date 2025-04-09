import axios from 'axios';

export interface ExchangeRate {
    date: string;
    baseCurrency: string;
    currency: string;
    amount: number;
}

function delay(ms: number) {
    return new Promise( resolve => setTimeout(resolve, ms) );
}

export const getExchangeRates = async (): Promise<ExchangeRate[]> => {
    // await delay(200);
    // return [
    //     {
    //         date: '2025-08-04',
    //         baseCurrency: 'USD',
    //         currency: 'EUR',
    //         amount: 1.20
    //     }
    // ]
    const response = await axios.get<ExchangeRate[]>('https://localhost:7037/api/exchangerate');
    return response.data;
};