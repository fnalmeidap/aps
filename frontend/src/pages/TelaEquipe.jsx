import Input from "../components/Input";
import Button from "../components/Button";
import React, { useState } from "react";

const TelaEquipe = () => {
  const [nome, setNome] = useState('');
  const [endereco, setEndereco] = useState('');
  const [faculdade, setFaculdade] = useState('');
  const [categoria, setCategoria] = useState('');

  const onSubmit = async (e) => {
    e.preventDefault();
  };
  return (
    <div className="Container">
      <div className="MainContainer">
        <h1 className="Title">Cadastrar nova Equipe</h1>
        <form onSubmit={onSubmit} className="FormContainer">
          <Input
            placeholder="Nome"
            onChange={(e) => setNome(e.target.value)}
            value={nome}
            label="Nome da equipe"
          />
          <Input
            placeholder="Endereço"
            onChange={(e) => setEndereco(e.target.value)}
            value={endereco}
            label="Endereço"
          />
          <Input
            placeholder="Faculdade"
            onChange={(e) => setFaculdade(e.target.value)}
            value={faculdade}
            label="Faculdade"
          />
          <Input
            placeholder="Categoria"
            onChange={(e) => setCategoria(e.target.value)}
            value={categoria}
            label="Categoria"
          />
          <Button type="submit">Salvar</Button>
        </form>
      </div>
    </div>
  );
};

export default TelaEquipe;
