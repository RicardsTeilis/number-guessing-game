import React, { useEffect, useState } from "react";
import History from "../History";
import axios from "axios";
import Button from "../Components/Button/Button";

const Game = () => {

    const game = JSON.parse(localStorage.getItem('game'));
    const player = JSON.parse(localStorage.getItem('player'));

    const [guessInput, setGuessInput] = useState('');
    const [currentGame, setCurrentGame] = useState(game);

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

    const goToLeaderBoard = () => {
        if (currentGame.gameEnded) {
            History.push('/leaderboard')
        }
    }

    // useEffect(() => {
    //     if (currentGame.gameEnded) {
    //         History.push('/leaderboard')
    //     }
    // }, [currentGame])

    return (
        <>
            <h3>Player: <span className="strong">{player.name}</span></h3>

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

            <div className="container result">
                {currentGame && !currentGame.gameEnded && (
                    <>
                        <div>Tries left: <span className="strong">{8 - currentGame.tries}</span></div>
                        <div>Digits guessed: <span className="strong">{currentGame.digitsGuessed}</span></div>
                        <div>Digits in correct places: <span className="strong">{currentGame.digitsInCorrectPlaces}</span></div>
                    </>

                )}
            </div>

            {
                currentGame.gameEnded && !currentGame.won && (
                    <h2>You lost!</h2>
                )
            }

            {
                currentGame.gameEnded && currentGame.won && (
                    <h2>You won!</h2>
                )
            }

            {
                currentGame && currentGame.gameEnded && (
                    <>
                        <div className="container d-block text-center">
                            The number to guess was <span className="strong green">{currentGame.numberToGuess}</span>

                            <div><Button text='Go to leaderboard' type='button' onClick={goToLeaderBoard} /></div>

                        </div>

                    </>
                )
            }

            {
                currentGame && !currentGame.gameEnded && currentGame.previousTries != "" && (
                    <div className="container prevTries">
                        <span className="strong">Previous tries:</span> {currentGame.previousTries?.join(", ")}
                    </div>
                )}
        </>
    )
}

export default Game;