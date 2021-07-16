import axios from 'axios';
import { useEffect, useContext, useState } from 'react';
import { GameContext } from "../App";
import History from "../History";
import Button from '../Components/Button/Button';

const Leaderboard = () => {
    const { player, setGame } = useContext(GameContext)

    const [newPlayerForm, setNewPlayerForm] = useState(false);
    const [buttonsVisible, setButtonsVisible] = useState(true);
    const [leaderboard, setLeaderboard] = useState([]);

    useEffect(() => {
        axios.get('http://localhost:5000/leaderboard').then((response) => {
            setLeaderboard(response.data)
            console.log(response.data)
        })
    }, [])

    const playAgain = () => {
        axios.get(`http://localhost:5000/game/${player.id}`).then((response) => {
            setGame(response.data)
            History.push('/game')
        })
    }

    const showNewPlayerForm = () => {
        setNewPlayerForm(!newPlayerForm)
        setButtonsVisible(false)
    }

    return (
        <>
            <h1>Leaderboard</h1>

            <div className='container'>

                {
                    buttonsVisible && (
                        <div className='form__form--wrapper'>
                            <Button text='Play again' type='button' onClick={playAgain} />
                            <Button text='Change player' type='button' />
                            <Button text='New player' type='button' onClick={showNewPlayerForm} />
                        </div>
                    )

                }


                {
                    newPlayerForm && (

                        <div className='form__form--wrapper'>
                            <form onSubmit={(event) => {
                                event.preventDefault();
                                //sendNewPlayer(inputValue);
                            }}>

                                <input type="text" placeholder='Name' className='form__form--input-text' />

                                <Button text='Start Game' type='submit' />
                            </form>
                        </div>
                    )
                }

                {
                    <table>
                        <thead>
                            <tr>
                                <td>Id</td>
                                <td>Name</td>
                                <td>Games won</td>
                                <td>Total tries</td>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                leaderboard.map(({ id, name, gamesWon, totalTries }, index) => {
                                    return (
                                        <tr key={index}>
                                            <td>{id}</td>
                                            <td>{name}</td>
                                            <td>{gamesWon}</td>
                                            <td>{totalTries}</td>
                                        </tr>
                                    )
                                })
                            }
                        </tbody>
                    </table>
                }
            </div>
        </>
    )
}

export default Leaderboard