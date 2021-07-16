import { useContext, useEffect } from "react";
import { GameContext } from "../App";
import History from "../History";
import axios from "axios";
import Button from "../Components/Button/Button";

const Home = () => {

    //localStorage.clear();

    const {
        inputValue, setInputValue,
        player, setPlayer,
        setGame
    } = useContext(GameContext)

    const sendNewPlayer = (input) => {
        axios.post(`http://localhost:5000/player?name=${input}`)
            .then((response) => {
                setPlayer(response.data)
                localStorage.setItem("player", JSON.stringify(response.data));
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
            <h1>Number guessing game</h1>

            <div className='form__form--wrapper'>
                <form onSubmit={(event) => {
                    event.preventDefault();
                    sendNewPlayer(inputValue);
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
        </>
    )
}

export default Home;