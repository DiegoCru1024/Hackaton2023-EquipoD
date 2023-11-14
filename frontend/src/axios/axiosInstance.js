import axios from 'axios';
import {useSelector} from 'react-redux';

const instance = axios.create({
    baseURL: 'https://sig-fisi.application.ryonadev.me',
    timeout: 5000
});

instance.interceptors.request.use(
    (config) => {
        const token = localStorage.getItem('token') || ''

        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
        }

        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

export default instance;
