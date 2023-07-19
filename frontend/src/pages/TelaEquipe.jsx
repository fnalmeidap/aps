import { Box, Button, Chip, Container, Input, MenuItem, OutlinedInput, Select, TextField, Typography, useTheme } from '@mui/material';
import React, { useState } from "react";

function getStyles(name, personName, theme) {
  return {
    fontWeight:
      personName.indexOf(name) === -1
        ? theme.typography.fontWeightRegular
        : theme.typography.fontWeightMedium,
  };
}

const ITEM_HEIGHT = 48;
const ITEM_PADDING_TOP = 8;
const MenuProps = {
  PaperProps: {
    style: {
      maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
      width: 250,
    },
  },
};

const listCategorias = [
  'Oliver Hansen',
  'Van Henry',
  'April Tucker',
  'Ralph Hubbard',
  'Omar Alexander',
  'Carlos Abbott',
  'Miriam Wagner',
  'Bradley Wilkerson',
  'Virginia Andrews',
  'Kelly Snyder',
];

const TelaEquipe = () => {
  const theme = useTheme();
  const [categorias, setCategorias] = React.useState([]);

  const handleChange = (event) => {
    const {
      target: { value },
    } = event;
    setCategorias(
      // On autofill we get a stringified value.
      typeof value === 'string' ? value.split(',') : value,
    );
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const data = new FormData(e.currentTarget);
    console.log({
      email: data.get('nome'),
      password: data.get('endereco'),
    });
  };
  return (
    <Container component="main" maxWidth="xs">
      <Box
        sx={{
          marginTop: 8,
          display: 'flex',
          flexDirection: 'column',
          alignItems: 'center',
          gap: 4,
        }}
      >
        <Typography component="h1" variant="h3" noWrap>Cadastrar nova Equipe</Typography>
        <Box component="form" onSubmit={handleSubmit} sx={{ mt: 1, width: 500, display: 'flex', flexDirection: 'column', gap: 3 }}  >
          <TextField
            name="nome"
            required
            fullWidth
            id="nome"
            label="Seu nome"
            autoFocus
          />
          <TextField
            name="endereco"
            required
            fullWidth
            id="endereco"
            label="Endereço"
          />
          <TextField
            name="faculdade"
            required
            fullWidth
            id="faculdade"
            label="Faculdade"
          />
          <Select
          labelId="demo-multiple-chip-label"
          id="demo-multiple-chip"
          multiple
          value={categorias}
          onChange={handleChange}
          input={<OutlinedInput id="select-multiple-chip" label="Categorias" color='primary'/>}
          renderValue={(selected) => (
            <Box sx={{ display: 'flex', flexWrap: 'wrap', gap: 0.5 }}>
              {selected.map((value) => (
                <Chip key={value} label={value} />
              ))}
            </Box>
          )}
          MenuProps={MenuProps}
        >
          {listCategorias.map((name) => (
            <MenuItem
              key={name}
              value={name}
              style={getStyles(name, categorias, theme)}
            >
              {name}
            </MenuItem>
          ))}
        </Select>
          <Button variant='contained' type="submit">Salvar</Button>
        </Box>
      </Box>
    </Container>
  );
};

export default TelaEquipe;
