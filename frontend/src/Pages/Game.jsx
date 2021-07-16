import React, { useContext, useEffect, useState } from "react";
import { GameContext } from "../App";
import History from "../History";
import axios from "axios";
import Button from "../Components/Button/Button";

const Game = () => {

    //const { game, setGame } = useContext(GameContext)

    const game = JSON.parse(localStorage.getItem('game'));
    const player = JSON.parse(localStorage.getItem('player'));

    const [guessInput, setGuessInput] = useState('');
    //const [player, setPlayer] = useState();
    const [currentGame, setCurrentGame] = useState(game);

    // const playerId = localStorage.getItem("playerId");
    // console.log(playerId)

    // useEffect(() => {
    //     axios.get(`http://localhost:5000/player/${playerId}`)
    //         .then((response) => {
    //             console.log(response.data)
    //             setPlayer(response.data)
    //         })
    //         .catch(error => {
    //             alert(error.response.data)
    //         })
    // }, [])

    const sendGuess = (input) => {

        axios.post(`http://localhost:5000/game?input=${input}`)
            .then((response) => {
                console.log(response.data)
                setCurrentGame(response.data)
                localStorage.setItem("game", JSON.stringify(response.data));
            })
            .catch(error => {
                alert(error.response.data)
            })
    }

    useEffect(() => {
        if (currentGame.gameEnded) {
            History.push('/leaderboard')
        }
    }, [currentGame])

    return (
        <>
            <h3>Player: {player.name}</h3>

            {
                !currentGame.gameEnded && (
                    <div className='form__form--wrapper'>
                        <form onSubmit={(event) => {
                            event.preventDefault();
                            sendGuess(guessInput);
                        }}>
                            <input type="text" placeholder='Your guess' className='form__form--input-text'
                                value={guessInput}
                                onChange={(event) => {
                                    const guessInput = event.target.value;
                                    setGuessInput(guessInput);
                                }} />

                            <Button text='Guess' type='submit' />
                        </form>

                    </div>
                )
            }

            <div>
                {currentGame && !currentGame.gameEnded && (
                    <div>
                        <div>Tries left: {8 - currentGame.tries}</div>
                        <div>Digits guessed: {currentGame.digitsGuessed}</div>
                        <div>Digits in correct places: {currentGame.digitsInCorrectPlaces}</div>
                    </div>

                )}

                {currentGame.gameEnded && !currentGame.won && (
                    <div>You lost</div>
                )}

                {currentGame.gameEnded && currentGame.won && (
                    <div>You won</div>
                )}
            </div>
        </>
    )
}

export default Game;