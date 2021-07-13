import React, { FC } from 'react';
import './Button.css'

type ButtonProps = {
    text: string
    onClick?: () => void
    type?: 'button' | 'submit'
}

const Button: FC<ButtonProps> = ({ text, onClick, type = 'button' }) => (
    <button className="button" type={type} onClick={onClick}>
        {text}
    </button>
);

export default Button;