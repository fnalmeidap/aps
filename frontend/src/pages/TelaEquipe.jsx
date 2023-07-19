import Input from "../components/Input";
import Button from "../components/Button";
import React, { useState } from "react";

const TelaEquipe = () => {
  const [name, setName] = useState(null);
console.log(name)
  const onSubmit = async (e) => {
    e.preventDefault();
  };
  return (
    <div className="Container">
      <div className="MainContainer">
        <h1 className="Title">Cadastrar nova música</h1>
        <form onSubmit={onSubmit} className="FormContainer">
          <Input
            placeholder="Nome"
            id="name"
            onChange={(e) => setName(e.target.value)}
            value={name}
          >
            Nome da equipe
          </Input>
          <Button type="submit">Salvar</Button>
        </form>
      </div>
    </div>
  );
};

export default TelaEquipe;
