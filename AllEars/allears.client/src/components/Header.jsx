//import React from 'react';
import { useNavigate } from 'react-router-dom';
import './Header.css';
import logo from '../assets/logo.png';

const Header = () => {
    const navigate = useNavigate();

    const handleLoginClick = () => {
        navigate('/login'); // Replace '/login' with the correct path to your login page
    };

    return (
        <header className="header">
            <img src={logo} alt="Logo" className="logo" />
            <h3>AllEars</h3>
            <nav className="nav">
                <a href="#">Home</a>
                <a href="#">About Us</a>
                <a href="#">Contact</a>
                <a href="#">Book Online</a>
                <a href="#">Blog</a>
            </nav>
            <div className="header-buttons">
                <button className="login" onClick={handleLoginClick}>Log In</button>
                <button className="register">Register</button>
                <button className="book-session">Book Session</button>
            </div>
        </header>
    );
};

export default Header;




//function Header() {
//  return (
//    <p>Hello world!</p>
//  );
//}

//export default Header;