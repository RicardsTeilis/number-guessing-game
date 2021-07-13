import axios, { AxiosResponse } from 'axios';
import { useState, useEffect } from 'react';

type Player = {
    id: number
    name: string
    gamesWon: number
    totalTries: number
}

const Leaderboard = () => {
    const [players, setPlayers] = useState<Player[]>([])

    useEffect(() => {
        axios.get('http://localhost:5000/numberGuessingGame').then((response: AxiosResponse) => {
            setPlayers(response.data)
            console.log(response.data)
        })
    }, [])

    return (
        <>
            <h1>Leaderboard</h1>

            {
                <div>
                    {
                        players.map(({ id, name, gamesWon, totalTries }, index) => {
                            return (
                                <div key={index}>
                                    <span>{id}</span> <span>{name}</span> <span>{gamesWon}</span> <span>{totalTries}</span>
                                </div>
                            )
                        })
                    }
                </div>

            }
        </>
    )
}

export default Leaderboard