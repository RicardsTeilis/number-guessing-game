import React, { useState } from 'react';
import './Form.css';
import Button from '../Button/Button';

const Form = () => {

    const [inputValue, setInputValue] = useState('');

    const sendNewPlayer = (input: string) => {
        console.log(input)
    }

    return (
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

                <Button text='Submit' type='submit' />
            </form>
        </div>
    )
}

export default Form;