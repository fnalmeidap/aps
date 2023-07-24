import React, { useState } from "react";
import { Container, Form, FormGroup, Label, Input, Button, ListGroup, ListGroupItem, Badge, Col } from "reactstrap";
import { categoriasLista, categoriesEnum } from '../utils/constants';
import { useNavigate } from 'react-router-dom';

export const TelaCadastrarEvento = () => {
  const navigate = useNavigate()
  const [evento, setEvento] = useState({
    Name: "",
    Endereco: {
      Cidade: "",
      Estado: "",
      Pais: "",
    },
    StartTime: "",
    FinalTime: "",
    Categorias: [],
    Equipes: [] //esse aqui não mexe
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    if (name.includes(".")) {
      const [parent, child] = name.split(".");
      setEvento((prevState) => ({
        ...prevState,
        [parent]: {
          ...prevState[parent],
          [child]: value,
        },
      }));
    } else {
      setEvento((prevState) => ({
        ...prevState,
        [name]: value,
      }));
    }
  };

  const handleCategorySelect = (category) => {
    setEvento((prevState) => ({
      ...prevState,
      Categorias: prevState.Categorias.includes(category)
      ? prevState.Categorias.filter((item) => item !== category)
      : [...prevState.Categorias, category],
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    // Aqui você pode enviar os dados do evento para a API ou realizar alguma outra ação
    console.log("Evento cadastrado:", evento);

    try {
      const response = await fetch("/api/Eventos", {
        method: "POST",
        headers: {
          "Content-Type": "application/json", // Define o tipo de conteúdo como JSON
        },
        body: JSON.stringify(evento),
      });

      if (!response.ok) {
        throw new Error("Erro na requisição");
      }

      //const responseData = await response.json(); // Parse da resposta para JSON
      //console.log("RESPOSTA:", responseData);
      alert('Evento cadastrado')
      navigate('/tela-evento')
    } catch (error) {
      console.error("Erro na requisição PATCH:", error);
      alert("OPS, ALGO DEU ERRADO");
    }
  };

  return (
    <Container>
      <Col
        md={{
          size: 12,
        }}
      >
        <h2>Cadastrar Evento</h2>
        <Form onSubmit={handleSubmit}>
          <FormGroup>
            <Label for="name">Nome</Label>
            <Input
              type="text"
              name="Name"
              id="Name"
              value={evento.Name}
              onChange={handleChange}
              required
            />
          </FormGroup>
          <FormGroup>
            <Label for="Cidade">Cidade</Label>
            <Input
              type="text"
              name="Endereco.Cidade"
              id="Cidade"
              value={evento.Endereco.Cidade}
              onChange={handleChange}
              required
            />
          </FormGroup>
          <FormGroup>
            <Label for="Estado">Estado</Label>
            <Input
              type="text"
              name="Endereco.Estado"
              id="Estado"
              value={evento.Endereco.Estado}
              onChange={handleChange}
              required
            />
          </FormGroup>
          <FormGroup>
            <Label for="Pais">País</Label>
            <Input
              type="text"
              name="Endereco.Pais"
              id="Pais"
              value={evento.Endereco.Pais}
              onChange={handleChange}
              required
            />
          </FormGroup>
          <FormGroup>
            <Label for="StartTime">Início</Label>
            <Input
              type="date"
              name="StartTime"
              id="StartTime"
              value={evento.StartTime}
              onChange={handleChange}
              required
            />
          </FormGroup>
          <FormGroup>
            <Label for="FinalTime">Término</Label>
            <Input
              type="date"
              name="FinalTime"
              id="FinalTime"
              value={evento.FinalTime}
              onChange={handleChange}
              required
            />
          </FormGroup>
          <FormGroup>
            <Label for="Categorias">Categorias</Label>
            <ListGroup horizontal>
              {categoriasLista.map((categoria) => (
                <ListGroupItem
                  key={categoria}
                  tag="button"
                  onClick={() => handleCategorySelect(categoria)}
                  active={evento.Categorias.includes(categoria)}
                  action
                >
                  <Badge color="secondary" style={{ marginLeft: 8 }}>
                    {categoriesEnum[categoria]}
                  </Badge>
                </ListGroupItem>
              ))}
            </ListGroup>
          </FormGroup>
          <Button color="primary">Cadastrar</Button>
        </Form>
      </Col>
    </Container>
  );
};
