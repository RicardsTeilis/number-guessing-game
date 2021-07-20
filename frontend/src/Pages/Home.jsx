import { useContext, useEffect } from "react";
import { GameContext } from "../App";
import History from "../History";
import axios from "axios";
import Button from "../Components/Button/Button";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const Home = () => {

    const {
        inputValue, setInputValue,
        player, setPlayer,
        setGame
    } = useContext(GameContext)

    const sendNewPlayer = (input) => {
        const trimmedInput = input.trim()

        if (!trimmedInput) {
            toast.error('The player name cannot be empty!', {
                position: "top-center",
                autoClose: 2500,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
            });
            return
        }

        axios.post(`http://localhost:5000/player?name=${input}`)
            .then((response) => {
                setPlayer(response.data)
                localStorage.setItem("player", JSON.stringify(response.data));
            })
            .catch(error => {
                alert(error.response.data)
            })
    }

    useEffect(() => {
        if (player) {
            axios.get(`http://localhost:5000/game/${player.id}`).then((response) => {
                setGame(response.data)
                localStorage.setItem("game", JSON.stringify(response.data));
                History.push('/game')
            })
        }
    }, [player, setGame])

    return (
        <>
            <ToastContainer />

            <h1>Number guessing game</h1>

            <div className="container">
                <p>
                    Program chooses a random secret number with 4 digits. All digits in the secret number are different. You have 8 tries to guess the secret number.
                </p>
            </div>

            <div className='form__form--wrapper'>
                <form onSubmit={(event) => {
                    event.preventDefault();
                    sendNewPlayer(inputValue);
                }}>

                    <input type="text" placeholder='Your name...' className='form__form--input-text'
                        value={inputValue}
                        onChange={(event) => {
                            const inputValue = event.target.value;
                            setInputValue(inputValue);
                        }} />

                    <Button text='Start Game' type='submit' />
                </form>
            </div>
        </>
    )
}

export default Home;