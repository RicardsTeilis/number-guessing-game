import React from 'react';
import './Button.css'

const Button = ({ text, onClick, type = 'button' }) => (
    <button className="button" type={type} onClick={onClick}>
        {text}
    </button>
);

export default Button;