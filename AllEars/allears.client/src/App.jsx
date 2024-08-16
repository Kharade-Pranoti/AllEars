//import React from 'react';
// eslint-disable-next-line no-unused-vars
import React, { useState } from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Header from './components/Header';
import HeroSection from './components/HeroSection';
import Login from './Login';
import './index.css';
import './Login.css';

function App ()  {
    

    return (
        <div>

            <Router>
                <Header /> {/* Header is outside Routes to appear on every page */}
                <Routes>
                    <Route path="/" element={<HeroSection />} />
                    <Route path="/login" element={<Login />} />
                </Routes>
            </Router>

        </div>
    );
};

export default App;







//import React, { useState } from 'react';
////import './Login.css';

//const Login = () => {
//    const [email, setEmail] = useState('');
//    const [password, setPassword] = useState('');

//    const handleSubmit = async (e) => {
//        e.preventDefault();

//        try {
//            const response = await fetch('http://localhost:5000/api/auth/login', {
//                method: 'POST',
//                headers: {
//                    'Content-Type': 'application/json',
//                },
//                body: JSON.stringify({ email, password }),
//            });

//            if (response.ok) {
//                const data = await response.json();
//                console.log('Login successful:', data);
//                // Redirect to another page if needed
//            } else {
//                console.error('Login failed');
//            }
//        } catch (error) {
//            console.error('Error during login:', error);
//        }
//    };

//    return (
//        <div className="login-container">
//            <h2>Login to AllEars</h2>
//            <form onSubmit={handleSubmit}>
//                <div className="form-group">
//                    <label>Email</label>
//                    <input
//                        type="email"
//                        value={email}
//                        onChange={(e) => setEmail(e.target.value)}
//                        required
//                    />
//                </div>
//                <div className="form-group">
//                    <label>Password</label>
//                    <input
//                        type="password"
//                        value={password}
//                        onChange={(e) => setPassword(e.target.value)}
//                        required
//                    />
//                </div>
//                <button type="submit">Login</button>
//            </form>
//        </div>
//    );
//};

//export default Login;
