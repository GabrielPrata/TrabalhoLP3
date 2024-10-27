import { useEffect, useState } from 'react';
import Snackbar from '@mui/material/Snackbar';
import Alert from '@mui/material/Alert';
import { urlWebSocket } from '../functions/url-base/urlWebSocket';

export default function Notifications() {
    const [messages, setMessages] = useState([]);
    const [openSnackbar, setOpenSnackbar] = useState(false);
    const [currentMessage, setCurrentMessage] = useState('');

    useEffect(() => {
        const ws = new WebSocket(urlWebSocket());

        ws.onopen = () => {
            console.log('WebSocket connected');
        };

        ws.onmessage = (event) => {
            const message = event.data;
            setMessages((prevMessages) => [...prevMessages, message]);
            setCurrentMessage(message); // Define a mensagem atual
            setOpenSnackbar(true); // Abre a Snackbar
        };

        ws.onclose = () => {
            console.log('WebSocket disconnected');
        };

        return () => {
            ws.close();
        };
    }, []);

    const handleCloseSnackbar = () => {
        setOpenSnackbar(false);
    };

    return (
        <Snackbar 
            open={openSnackbar} 
            autoHideDuration={6000} 
            onClose={handleCloseSnackbar}
            anchorOrigin={{ vertical: 'top', horizontal: 'left' }}
        >
            <Alert onClose={handleCloseSnackbar} severity="info" sx={{ width: '100%' }}>
                {currentMessage}
            </Alert>
        </Snackbar>
    );
}
