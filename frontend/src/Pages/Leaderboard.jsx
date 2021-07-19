import axios from 'axios';
import { useEffect, useState } from 'react';
import History from "../History";
import Button from '../Components/Button/Button';

const Leaderboard = () => {

    const player = JSON.parse(localStorage.getItem('player'));

    const [inputValue, setInputValue] = useState('');

    const [newPlayerForm, setNewPlayerForm] = useState(false);
    const [buttonsVisible, setButtonsVisible] = useState(true);
    const [leaderboard, setLeaderboard] = useState([]);
    const [newPlayer, setNewPlayer] = useState();

    useEffect(() => {
        axios.get('http://localhost:5000/leaderboard').then((response) => {
            setLeaderboard(response.data)
            console.log(response.data)
        })
    }, [])

    const playAgain = () => {
        axios.get(`http://localhost:5000/game/${player.id}`).then((response) => {
            localStorage.setItem("game", JSON.stringify(response.data));
            History.push('/game')
        })
    }

    const showNewPlayerForm = () => {
        setNewPlayerForm(!newPlayerForm)
        setButtonsVisible(false)
    }

    const changePlayer = (input) => {
        axios.post(`http://localhost:5000/player?name=${input}`)
            .then((response) => {
                setNewPlayer(response.data)
                localStorage.setItem("player", JSON.stringify(response.data));
            })
    }

    useEffect(() => {
        if (newPlayer) {
            axios.get(`http://localhost:5000/game/${newPlayer.id}`).then((response) => {
                localStorage.setItem("game", JSON.stringify(response.data));
                History.push('/game')
            })
        }
    }, [newPlayer])

    return (
        <>
            <h1>Leaderboard</h1>

            <div className='container leaderboard'>

                {
                    buttonsVisible && (
                        <div className='form__form--wrapper'>
                            <Button text='Play again' type='button' onClick={playAgain} />
                            <Button text='New player' type='button' onClick={showNewPlayerForm} />
                        </div>
                    )

                }

                {
                    newPlayerForm && (

                        <div className='form__form--wrapper'>
                            <form onSubmit={(event) => {
                                event.preventDefault();
                                changePlayer(inputValue);
                            }}>
                                <input type="text" placeholder='Name' className='form__form--input-text'
                                    value={inputValue}
                                    onChange={(event) => {
                                        const inputValue = event.target.value;
                                        setInputValue(inputValue);
                                    }} />

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