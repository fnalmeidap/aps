import React, { useState } from "react";
import { useNavigate } from 'react-router-dom';
import {
  Container,
  Form,
  FormGroup,
  Label,
  Input,
  Button,
  Col,
} from "reactstrap";

export const TelaEquipe = () => {
  const navigate = useNavigate()
  const [equipe, setEquipe] = useState({
    nome: "",
    endereco: "",
    faculdade: "",
    categorias: [],
  });

  const handleChange = (e) => {
    const { name, value, checked } = e.target;
    if (name === "categorias") {
      const categoriasSelecionadas = equipe.categorias;
      if (checked) {
        categoriasSelecionadas.push(value);
      } else {
        const index = categoriasSelecionadas.indexOf(value);
        if (index !== -1) {
          categoriasSelecionadas.splice(index, 1);
        }
      }
      setEquipe({ ...equipe, [name]: categoriasSelecionadas });
    } else {
      setEquipe({ ...equipe, [name]: value });
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    console.log("Dados da equipe:", equipe);

    try {
      const response = await fetch("/api/Equipe", {
        method: "POST",
        headers: {
          "Content-Type": "application/json", // Define o tipo de conteúdo como JSON
        },
        body: JSON.stringify({
          Name: equipe.nome,
          University: equipe.faculdade,
          Members: []
        }), // Converte os dados para JSON
      });

      if (!response.ok) {
        throw new Error("Erro na requisição");
      }

      const responseData = await response.json(); // Parse da resposta para JSON
      console.log('RESPOSTA:', responseData)
      navigate('/tela-equipes')
    } catch (error) {
      console.error("Erro na requisição POST:", error);
      alert("OPS, ALGO DEU ERRADO");
    }
  };

  return (
    <Container>
      <Col
        md={{
          offset: 3,
          size: 6
        }}
        sm="12"
      >
      <h2>Cadastro de Equipe</h2>
      <Form onSubmit={handleSubmit}>
        <FormGroup>
          <Label for="nome">Nome</Label>
          <Input
            type="text"
            name="nome"
            id="nome"
            value={equipe.nome}
            onChange={handleChange}
            required
          />
        </FormGroup>
        {/* <FormGroup>
          <Label for="endereco">Endereço</Label>
          <Input
            type="text"
            name="endereco"
            id="endereco"
            value={equipe.endereco}
            onChange={handleChange}
            required
          />
        </FormGroup> */}
        <FormGroup>
          <Label for="faculdade">Faculdade</Label>
          <Input
            type="text"
            name="faculdade"
            id="faculdade"
            value={equipe.faculdade}
            onChange={handleChange}
            required
          />
        </FormGroup>
        {/* <FormGroup>
          <Label for="categorias">Categorias</Label>
          {categoriasOpcoes.map((categoria) => (
            <FormGroup check key={categoria}>
              <Label check>
                <Input
                  type="checkbox"
                  name="categorias"
                  value={categoria}
                  checked={equipe.categorias.includes(categoria)}
                  onChange={handleChange}
                />{" "}
                {categoria}
              </Label>
            </FormGroup>
          ))}
        </FormGroup> */}
        <Button type="submit" color="primary">
          Cadastrar Equipe
        </Button>
      </Form>
    </Col>
    </Container>
  );
};

