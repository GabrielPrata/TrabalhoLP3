'use client';
import React, { useEffect, useState } from 'react';
import Container from '@mui/material/Container';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import { LoadingButton } from '@mui/lab';
import Snackbar from '@mui/material/Snackbar';
import Alert from '@mui/material/Alert';
import { DateInput } from "@nextui-org/react";
import { CalendarDate, parseDate } from "@internationalized/date";

import { urlBase } from '../functions';
import "./style.css";
import { CalendarIcon } from '../components/calendarIcon/calendarIcon';
import InputText from '../components/inputText/InputText';
import FormGroup from '@mui/material/FormGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import { DatePicker } from "@nextui-org/react";
import ReservaItem from '../components/reservaItem/reservaItem';


const Page = () => {
    const [reservas, setReservas] = useState();

    const getReservas = async () => {
        const response = await fetch(`${urlBase()}ListarReservas`);
        const data = await response.json();
        setReservas(data);
        console.log(data);
    }
    useEffect(() => {
        getReservas();
    }, [])



    const [warn, setWarn] = useState("");
    const [erro, setErro] = useState("");
    const [success, setSuccess] = useState("");
    const [loading, setLoading] = useState(false);
    const [openSnackbar, setOpenSnackbar] = useState(false);

    const deletarReserva = async (idReserva) => {
        setLoading(true);

        try {
            const urlComParametros = `${urlBase()}DeletarReserva/${idReserva}`;

            const response = await fetch(urlComParametros, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json'
                },
            });

            if (response.status === 200) {
                setWarn("");
                setErro("");
                setSuccess("Reserva deletada com sucesso!")
                setOpenSnackbar(true);
                window.location.href = '/admin';
            } else {
                setErro("Um erro inesperado aconteceu!");

            }
        } catch (error) {
            console.error('Erro ao enviar requisição POST:', error);
            setErro("Erro desconhecido: " + error);
            setOpenSnackbar(true);
        } finally {
            setLoading(false);
        }
    };

    const handleCloseSnackbar = () => {
        setOpenSnackbar(false);
    };



    return (
        <Container className="flex p-12 min-h-screen flex-col items-center flex-1 justify-center">
            <Box className='flex flex-col items-center justify-center bg-gray-700 bg-opacity-50 p-10 rounded-lg'>
                <Typography variant="h2" className='mt-5'>
                    StayManager
                </Typography>
                <Typography variant="h5" className='tituloLogin mt-5'>
                    Sistema de Gerenciamento de hotel
                </Typography>

                {!reservas ? <Typography variant="h5" className='tituloLogin mt-5'>
                    Nenhuma reserva encontrada! :c
                </Typography> : reservas.map((reserva) => (
                    <ReservaItem
                        key={reserva.id}
                        id={reserva.id}
                        cliente={reserva.nomeCliente}
                        data={reserva.dataReserva}
                        inicial={reserva.periodoInicial}
                        final={reserva.periodoFinal}
                        onDelete={deletarReserva}
                        quarto={reserva.tipoQuarto}
                        servicos={reserva.servicosExtras}
                        total={reserva.valorTotal}
                    />
                ))}


                <Snackbar open={openSnackbar} autoHideDuration={6000} onClose={handleCloseSnackbar}>
                    {warn ? <Alert severity='warning'>{warn}</Alert> : erro ? <Alert severity='error'>{erro}</Alert> : success && <Alert severity='success'>{success}</Alert>}
                </Snackbar>
            </Box>
        </Container>
    );
};

export default Page;
