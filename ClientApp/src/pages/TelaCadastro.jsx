import React, { useState, useEffect } from "react";
import GoogleLogin from 'react-google-login';
import { Button, Col, Collapse, Container, Form, FormGroup, Input, Label } from "reactstrap";

export const TelaCadastro = () => {
  const [participante, setParticipante] = useState({
    Name: "",
    TokenId: "",
    Email: "",
    University: "",
    BirthDay: "",
  });

  const [isLogged, setIsLogged] = useState(false);

  useEffect(() => {
    // Check if the user is already logged in
    if (localStorage.getItem("user")) {
      // Redirect to the home page
      window.location.href = "/";
    }
  }, []);

  function onSuccess(data) {
    console.log(data.profileObj.email)
    setParticipante({...participante, Name: data.profileObj.name, Email: data.profileObj.email, TokenId: data.tokenId})
    setIsLogged(true)
  }

  const handleSubmit = (e) => {
    e.preventDefault();

    console.log(participante)

    // Send the registration request to the server
    // fetch("/register", {
    //   method: "POST",
    //   headers: {
    //     "Content-Type": "application/json",
    //   },
    //   body: JSON.stringify({participante}),
    // })
    //   .then((response) => response.json())
    //   .then((data) => {
    //     if (data.success) {
    //       // Redirect to the home page
    //       window.location.href = "/";
    //     } else {
    //       // Show an error message
    //       alert(data.error);
    //     }
    //   });
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
                <Input required type="text" name="universidade" value={participante.University} onChange={handleChange} />
              </FormGroup>
              <FormGroup>
                <Label for="aniversario">Aniversário</Label>
                <Input required type="date" name="aniversario" value={participante.BirthDay} onChange={handleChange} />
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

