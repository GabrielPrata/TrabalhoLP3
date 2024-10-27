import React from 'react';
import TextField from '@mui/material/TextField';
import { Box, Button, Container, Typography } from '@mui/material';


const ReservaItem = ({ id, data, inicial, final, cliente, quarto, total, servicos, onDelete }) => {
    const handleDelete = () => {
        onDelete(id);
    };
    return (
        <>
            <Box className='flex flex-col items-center justify-center bg-white bg-opacity-10 p-10 rounded-lg'>
                <Typography className='mt-5'>
                    Reserva Número: {id}
                </Typography>
                <Typography className='mt-5'>
                    Realizada em: {data}
                </Typography>
                <Typography className='mt-5'>
                    Check-In: {inicial}
                </Typography>
                <Typography className='mt-5'>
                    Check-Out: {final}
                </Typography>
                <Typography className='mt-5'>
                    Cliente: {cliente}
                </Typography>
                <Typography className='mt-5'>
                    Quarto: {quarto}
                </Typography>
                <Typography className='mt-5'>
                    Total: {total}
                </Typography>
                <Typography className='mt-5'>
                    Serviços Extra: {servicos ? servicos : "Não aplica"}
                </Typography>
                <Button variant="contained" size="large" className='mt-5' fullWidth={true} color="error"  onClick={handleDelete} >
                    Cancelar
                </Button>
            </Box>
            <br />
        </>
    );
};


export default ReservaItem;