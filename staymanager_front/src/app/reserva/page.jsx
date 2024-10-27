'use client';
import React, { useState } from 'react';
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
import Notifications from '../utils/notifications';


const Page = () => {

    // Funções para obter a data de hoje e de amanhã
    const today = new Date();
    const tomorrow = new Date(today);
    tomorrow.setDate(tomorrow.getDate() + 1);

    const formatDate = (date) => {
        return parseDate(`${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`);
    };


    const [inicial, setInicial] = useState(formatDate(today));
    const [final, setFinal] = useState(formatDate(tomorrow));
    const [nome, setNome] = useState('');
    const [quarto, setQuarto] = useState('standart');
    const [servicos, setServicos] = useState({
        cafeManha: false,
        transporteAeroporto: false
    });

    const [warn, setWarn] = useState("");
    const [erro, setErro] = useState("");
    const [success, setSuccess] = useState("");
    const [loading, setLoading] = useState(false);
    const [openSnackbar, setOpenSnackbar] = useState(false);

    const handleSubmit = async (e) => {
        e.preventDefault();
        setLoading(true);
        if (!nome) {
            setWarn("Preencha todos os campos do formulário!");
            setOpenSnackbar(true);
            setLoading(false);
            return;
        }
        try {
            var servicosSelecionados = null;
            if (servicos.cafeManha) {
                servicosSelecionados = "CafeManha";
            }

            if (servicos.transporteAeroporto) {
                if (servicosSelecionados != null) {
                    servicosSelecionados = servicosSelecionados + ",TransporteAeroporto";
                } else {
                    servicosSelecionados = "TransporteAeroporto";
                }
            }

            const parametros = {
                DataReserva: formatDate(today),
                PeriodoInicial: inicial.toString(),
                PeriodoFinal: final.toString(),
                NomeCliente: nome,
                TipoQuarto: quarto,
                ServicosExtras: servicosSelecionados,
                ValorTotal: 0,
            };
            const queryString = new URLSearchParams(parametros).toString();
            const urlComParametros = `${urlBase()}FazerReserva?${queryString}`;

            const response = await fetch(urlComParametros, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
            });

            if (response.status === 200) {
                setWarn("");
                setErro("");
                setSuccess("Reserva efetuada com sucesso!")
                setOpenSnackbar(true);
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

    const handleChangeQuarto = (e) => {
        setQuarto(e.target.value);
        console.log(e.target.value);
    }

    const handleChangeServicos = (event) => {
        setServicos(prevServicos => ({
            ...prevServicos,
            [event.target.name]: event.target.checked
        }));
    }

    const handleChangeInicial = (value) => {
        setInicial(value);
        console.log(value);
    };

    const handleChangeFinal = (value) => {
        setFinal(value);
        console.log(value);
    };

    return (
        <Container className="flex p-12 min-h-screen flex-col items-center flex-1 justify-center">
            <Box className='flex flex-col items-center justify-center bg-gray-700 bg-opacity-50 p-10 rounded-lg'>
                <Notifications />
                <Typography variant="h2" className='mt-5'>
                    StayManager
                </Typography>
                <Typography variant="h5" className='tituloLogin mt-5'>
                    Sistema de Gerenciamento de hotel
                </Typography>
                <form>
                    <InputText label="Nome Do Cliente" isPassword={false} value={nome} onChange={(e) => setNome(e.target.value)} />
                    <br /><br />

                    <DatePicker
                        label="Data Check-In"
                        className="max-w-[284px]"
                        defaultValue={inicial}
                        onChange={handleChangeInicial}
                    />
                    <br />
                    <DatePicker
                        label="Data Check-Out"
                        className="max-w-[284px]"
                        defaultValue={final}
                        onChange={handleChangeFinal}
                    />

                    <br />
                    <label htmlFor="large" className="block mb-2 text-base font-medium text-gray-900 dark:text-white">Tipo do Quarto</label>
                    <select
                        id="large"
                        className="block w-full px-4 py-3 text-base text-gray-900 border border-gray-300 rounded-lg bg-gray-50 focus:ring-blue-500 focus:border-blue-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                        onChange={handleChangeQuarto}
                    >
                        <option value="standart">Standart</option>
                        <option value="casal">Casal</option>
                        <option value="deluxe">Deluxe</option>
                        <option value="presidencial">Presidencial</option                ></select>
                    <br />
                    <br />
                    <Typography variant="h5">
                        Serviços Adicionais?
                    </Typography>

                    <FormGroup>
                        <FormControlLabel
                            control={
                                <Checkbox
                                    checked={servicos.cafeManha}
                                    onChange={handleChangeServicos}
                                    name="cafeManha"
                                />
                            }
                            label="Café da Manhã"
                        />
                        <FormControlLabel
                            control={
                                <Checkbox
                                    checked={servicos.transporteAeroporto}
                                    onChange={handleChangeServicos}
                                    name="transporteAeroporto"
                                />
                            }
                            label="Transporte até/para o aeroporto"
                        />
                    </FormGroup>

                    {!loading
                        ? <Button variant="contained" size="large" className='mt-5' fullWidth={true} onClick={handleSubmit}>Fazer Reserva</Button>
                        : <LoadingButton
                            variant="contained"
                            size="large"
                            className='mt-5'
                            fullWidth={true}
                            color="secondary"
                            loading={loading}
                            loadingPosition="start"
                        >
                            <span>Reservando...</span>
                        </LoadingButton>
                    }
                    <Snackbar open={openSnackbar} autoHideDuration={6000} onClose={handleCloseSnackbar}>
                        {warn ? <Alert severity='warning'>{warn}</Alert> : erro ? <Alert severity='error'>{erro}</Alert> : success && <Alert severity='success'>{success}</Alert>}
                    </Snackbar>
                </form>
            </Box>
        </Container>
    );
};

export default Page;
