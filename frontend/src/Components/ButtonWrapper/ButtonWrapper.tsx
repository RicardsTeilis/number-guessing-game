import React, { FC } from 'react';
import './ButtonWrapper.css';
import Button from '../Button/Button';

type ButtonWrapperProps = {
    className: string
}

const ButtonWrapper: FC<ButtonWrapperProps> = ({ className = 'button-wrapper' }) => (
    <div className={className}>
        <Button text="New player" />
        <Button text="Existing player" />
    </div>
)

export default ButtonWrapper;