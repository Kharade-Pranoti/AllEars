// src/apiClient.js

/*const API_URL = "https://localhost:7032";*/ // Adjust the base URL to match your API

export const login = async (email, password) => {
    const response = await fetch(`https://localhost:7032/api/auth/login`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ email, password }),
    });

    if (!response.ok) {
        throw new Error('Invalid credentials');
    }

    return response.json();
};
