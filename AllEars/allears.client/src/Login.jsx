// src/login.jsx

// eslint-disable-next-line no-unused-vars
import React, { Fragment, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios  from 'axios';
import './Login.css';
import './Dashboard';


//import { login } from './apiClient'; // Adjust the path if necessary

const Login = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    /*const [error, setError] = useState(null);*/
    const navigate = useNavigate();

    const handleEmailChange = (value) => {
        setEmail(value);
    } 

    const handlePasswordChange = (value) => {
        setPassword(value);
    } 

   

    const handleLogin = (e) => {
        e.preventDefault();
        const authReq = {
            email: email,
            password: password,
        };
        axios
            .post("https://localhost:7032/api/auth/login", authReq, {
                headers: {
                    "Content-Type": "application/json",
                },
            })
            .then((res) => {
                localStorage.setItem("user", JSON.stringify(res.data));
                navigate("/dashboard", { state: res.data });
            })
            .catch((error) => {
                console.log(error);
            });
    


        // try {
        //     const result = await login(email, password);
        //     console.log('Login successful:', result);
        //     // You can handle redirection or saving the user session here
        // } catch (error) {
        //     setError(error.message);
        // }
    };

    return (
        <Fragment>
        <div className="login-container">
            <h1 className="login-heading">LOGIN</h1> 
                <form onSubmit={handleLogin}>
                <div>
                    <label>Email</label>
                    <input
                        type="email"
                        value={email}
                        onChange={(e) => handleEmailChange(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>Password</label>
                    <input
                        type="password"
                        value={password}
                        onChange={(e) => handlePasswordChange(e.target.value)}
                        required
                    />
                </div>
               {/* {error && <p className="error">{error}</p>}*/}
                    <button onClick={handleLogin} type="submit">Login</button>
            </form>
        </div>
        </Fragment>
    );
};

export default Login;






//// src/LoginPage.jsx
//// eslint-disable-next-line no-unused-vars
//import React, { useState } from 'react';
//import './Login.css'; // Optional: Add custom styles here

//const Login = () => {
//    const [username, setUsername] = useState('');
//    const [password, setPassword] = useState('');
//    const [rememberMe, setRememberMe] = useState(false);

//    const handleSubmit = async (e) => {
//        e.preventDefault();
//        // Handle login logic here, e.g., call your .NET Web API
//        const loginData = {
//            username: username,
//            password: password,
//            rememberMe: rememberMe,
//        };

//        try {
//            // Send POST request to your API endpoint
//            const response = await fetch('https://localhost:5173/api/controller/login', {
//                method: 'POST',
//                headers: {
//                    'Content-Type': 'application/json',
//                },
//                body: JSON.stringify(loginData),
//            });

//            // Check if response is ok
//            if (response.ok) {
//                const data = await response.json();
//                console.log('Login successful:', data);
//                // Handle successful login (e.g., save token, redirect)
//            } else {
//                // Handle errors
//                const errorData = await response.json();
//                console.error('Login failed:', errorData);
//                // Display error message to user
//            }
//        } catch (error) {
//            console.error('An error occurred:', error);
//            // Handle network errors or other issues
//        }
//    };

//    return (
//        <div className="login-container">
//            <h1>Login</h1>
//            <form onSubmit={handleSubmit} className="login-form">
//                <div className="form-group">
//                    <label htmlFor="username">Username:</label>
//                    <input
//                        type="text"
//                        id="username"
//                        value={username}
//                        onChange={(e) => setUsername(e.target.value)}
//                        required
//                    />
//                </div>
//                <div className="form-group">
//                    <label htmlFor="password">Password:</label>
//                    <input
//                        type="password"
//                        id="password"
//                        value={password}
//                        onChange={(e) => setPassword(e.target.value)}
//                        required
//                    />
//                </div>
//                <div className="form-group">
//                    <label>
//                        <input
//                            type="checkbox"
//                            checked={rememberMe}
//                            onChange={(e) => setRememberMe(e.target.checked)}
//                        />
//                        Remember Me
//                    </label>
//                </div>
//                <button type="submit" className="login-button">Login</button>
//            </form>
//        </div>
//    );
//};

//export default Login;




////function Login() {
////  return (
////    <p>Hello world!</p>
////  );
////}

////export default Login;