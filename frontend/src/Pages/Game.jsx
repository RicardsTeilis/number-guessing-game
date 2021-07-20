import React, { useState, useRef } from "react";
import History from "../History";
import axios from "axios";
import Button from "../Components/Button/Button";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const Game = () => {

    const game = JSON.parse(localStorage.getItem('game'));
    const player = JSON.parse(localStorage.getItem('player'));

    const [currentGame, setCurrentGame] = useState(game);

    const guessForm = useRef()

    const [input, setInput] = useState({
        inp1: '',
        inp2: '',
        inp3: '',
        inp4: ''
    })

    const handleInputChange = (e) => {

        const { maxLength, value, name } = e.target;
        const [fieldName, fieldIndex] = name.split("-");

        if (value.length >= maxLength) {

            if (parseInt(fieldIndex, 10) < 4) {

                const nextSibling = document.querySelector(
                    `input[name=${fieldName}-${parseInt(fieldIndex, 10) + 1}]`
                );

                if (nextSibling !== null) {
                    nextSibling.focus();
                }
            }
        }

        setInput({
            ...input,
            [`inp${fieldIndex}`]: value
        });
    }

    const sendGuess = () => {

        let inputToSend = ''

        let hasErrors = false

        Object.values(input).forEach(i => {
            if (i === '' || isNaN(i)) {
                hasErrors = true
            } else {
                inputToSend += i
            }
        })

        if (hasErrors) {
            toast.error('The guess input cannot be empty and has to be a digit!', {
                position: "top-center",
                autoClose: 2500,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
            });

            setInput({
                inp1: '',
                inp2: '',
                inp3: '',
                inp4: ''
            })

            return
        }

        axios.post(`http://localhost:5000/game?input=${inputToSend}`)
            .then((response) => {
                console.log(response.data)
                setCurrentGame(response.data)
                localStorage.setItem("game", JSON.stringify(response.data));
            })
            .catch(error => {
                alert(error.response.data)
            })

        setInput({
            inp1: '',
            inp2: '',
            inp3: '',
            inp4: ''
        })
    }

    const goToLeaderBoard = () => {
        if (currentGame.gameEnded) {
            History.push('/leaderboard')
        }
    }

    return (
        <>
            <ToastContainer />

            <h3>Player: <span className="strong">{player.name}</span></h3>

            {
                !currentGame.gameEnded && (
                    <div className='form__form--wrapper'>
                        <form ref={guessForm} onSubmit={(event) => {
                            event.preventDefault();
                            sendGuess();
                        }}>
                            <input type="text" className='form__form--input-text digit' name='inp-1' autoComplete='off' value={input.inp1} maxLength={1} onChange={handleInputChange} />
                            <input type="text" className='form__form--input-text digit' name='inp-2' autoComplete='off' value={input.inp2} maxLength={1} onChange={handleInputChange} />
                            <input type="text" className='form__form--input-text digit' name='inp-3' autoComplete='off' value={input.inp3} maxLength={1} onChange={handleInputChange} />
                            <input type="text" className='form__form--input-text digit' name='inp-4' autoComplete='off' value={input.inp4} maxLength={1} onChange={handleInputChange} />

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

                            <div className='mt-15'><Button text='Go to leaderboard' type='button' onClick={goToLeaderBoard} /></div>

                        </div>

                    </>
                )
            }

            {
                currentGame && !currentGame.gameEnded && currentGame.previousTries !== "" && (
                    <div className="container prevTries">
                        <span className="strong">Previous tries:</span> {currentGame.previousTries?.join(", ")}
                    </div>
                )}
        </>
    )
}

export default Game;