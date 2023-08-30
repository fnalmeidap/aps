import React, { useState, useEffect } from "react";
import GoogleLogin from 'react-google-login';
import { Button, Col, Collapse, Container, Form, FormGroup, Input, Label } from "reactstrap";
import { useLogin } from '../hooks/Login';
import { useNavigate } from 'react-router-dom';

export const TelaCadastro = () => {
  const navigate = useNavigate()
  const { setUser } = useLogin()
  const [participante, setParticipante] = useState({
    name: "",
    tokenId: "",
    email: "",
    university: "",
    birthday: "",
  });

  const [isLogged, setIsLogged] = useState(false);

  function onSuccess(data) {
    console.log(data)
    setParticipante({...participante, name: data.profileObj.name, email: data.profileObj.email, tokenId: data.googleId})
    setIsLogged(true)
  }

  const handleSubmit = (e) => {
    e.preventDefault();

    console.log(participante)
    fetch("/api/participante", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(participante),
    })
      .then((response) => response.json())
      .then((data) => {
        setUser({
          "participante": data,
          "equipe": null
        })
        navigate('/tela-evento')
      }).catch(error => {
        alert('Ops, algo deu errado!')
        console.log(error)
      })
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setParticipante({ ...participante, [name]: value });
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
          <h1>Cadastre-se</h1>
          <Collapse isOpen={!isLogged}>
            <p>Ainda não possui conta?</p>
            <GoogleLogin
              clientId={process.env.REACT_APP_GOOGLE_CLIENT_ID}
              buttonText="Registre-se com Google"
              onSuccess={onSuccess}
              // onFailure={responseGoogle}
              cookiePolicy={'single_host_origin'}
              isSignedIn={isLogged}
            />
          </Collapse>
          <Collapse isOpen={isLogged}>
            <p>Preencha mais alguns dados</p>
            <Form onSubmit={handleSubmit}>
              <FormGroup>
                <Label for="universidade">Universidade</Label>
                <Input required type="text" name="university" value={participante.university} onChange={handleChange} />
              </FormGroup>
              <FormGroup>
                <Label for="aniversario">Aniversário</Label>
                <Input required type="date" name="birthday" value={participante.birthday} onChange={handleChange} />
              </FormGroup>
              <Button type='submit' color='primary'>
                Enviar
              </Button>
            </Form>
          </Collapse>
      </Col>
    </Container>
  );
};

