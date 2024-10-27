import React from 'react';
import TextField from '@mui/material/TextField';


const InputText = ({ label, isPassword, value, onChange }) => {
    return (
        <TextField
            fullWidth
            label={label}
            value={value}
            onChange={onChange}
            required
            sx={{
                '& label.Mui-focused': {
                    color: 'white', // Muda a cor do texto do label quando está focado
                },
                '& label': {
                    color: 'rgba(255, 255, 255, 0.7)', // Muda a cor do texto do label em estado normal
                },
                '& .MuiOutlinedInput-root': {
                    color: 'white', // Muda a cor do texto digitado no input
                    '&::placeholder': {
                        color: 'rgba(255, 255, 255, 0.5)', // Muda a cor do placeholder
                    },
                    backgroundColor: 'rgba(255, 255, 255, 0.05)', // Fundo levemente esbranquiçado
                    '& fieldset': {
                        borderColor: 'white', // Cor da borda
                    },
                    '&:hover fieldset': {
                        borderColor: 'white', // Cor da borda no hover
                    },
                    '&.Mui-focused fieldset': {
                        borderColor: 'white', // Cor da borda quando está focado
                    },
                }
            }}
            type={isPassword ? "password" : "text"}
            margin="normal" />
    );
};


export default InputText;