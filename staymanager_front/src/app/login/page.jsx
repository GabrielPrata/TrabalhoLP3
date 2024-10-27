'use client';
import * as React from 'react';
import Container from '@mui/material/Container';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import "./style.css";

const Page = () => {


    const redirectoToAdmin = () => {
        window.location.href = '/admin';
    }
    
    const redirectoToReserva = () => {
        window.location.href = '/reserva';
    }

    return (
        <Container className="flex p-12 min-h-screen flex-col items-center flex-1 justify-center">
            <Box className='flex flex-col items-center justify-center bg-white bg-opacity-10 p-10 rounded-lg'>
                <Typography variant="h2" className='mt-5'>
                    StayManager
                </Typography>
                <Typography variant="h5" className='tituloLogin mt-5'>
                    Sistema de Gerenciamento de hotel
                </Typography>
                <form>
                    <Button variant="contained" size="large" className='mt-5' fullWidth={true} onClick={redirectoToAdmin}>
                        Acessar Admin
                    </Button>
                    <Button variant="contained" size="large" className='mt-5' fullWidth={true} onClick={redirectoToReserva}>
                        Fazer Reserva
                    </Button>

                </form>
            </Box>
        </Container>
    );
};

export default Page;
