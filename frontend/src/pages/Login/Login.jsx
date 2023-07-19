import { useEffect, useState } from "react";
import { useNavigate } from "react-router";

import "./styles.css";
import { Link } from "react-router-dom";
import Input from '../../components/Input';
import Button from '../../components/Button';

const Login = () => {
  const navigate = useNavigate();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const onSubmit = (e) => {
    e.preventDefault();
  };


  return (
    <div className="Container">
      <main className="LoginContainer">
        <form onSubmit={onSubmit} className="FormContainer">
          <p className="Title">Login</p>
          <p className="subtitle">
            {"Não é cadastrado? "}
            <Link className="Link" to="/register">
              Faça o cadastro
            </Link>
          </p>
          <Input
            type="email"
            name="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            placeholder="Email"
          >
            Email
          </Input>
          <Input
            type="password"
            name="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          >
            Senha
          </Input>
          <Button type="submit">Entrar</Button>
        </form>
      </main>
    </div>
  );
};

export default Login;
