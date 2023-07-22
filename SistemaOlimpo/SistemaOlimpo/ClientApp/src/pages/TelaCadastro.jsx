import React, { useState, useEffect } from "react";
import GoogleLogin from 'react-google-login';
import { Button, Form, FormGroup, Input, Label } from "reactstrap";

export const TelaCadastro = () => {
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const [isLogged, setIsLogged] = useState(false);

  useEffect(() => {
    // Check if the user is already logged in
    if (localStorage.getItem("user")) {
      // Redirect to the home page
      window.location.href = "/";
    }
  }, []);

  function onSuccess(data) {
    console.log(data)
    setIsLogged(true)
  }

  const handleSubmit = (e) => {
    e.preventDefault();

    // Send the registration request to the server
    fetch("/register", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        name,
        email,
        password,
      }),
    })
      .then((response) => response.json())
      .then((data) => {
        if (data.success) {
          // Redirect to the home page
          window.location.href = "/";
        } else {
          // Show an error message
          alert(data.error);
        }
      });
  };

  return (
    <div className="container">
      <div className="row">
        <div className="col-md-8 offset-md-2">
          <h1>Cadastre-se</h1>
          <p>Ainda não possui conta?</p>
          {isLogged ? (
            <Form onSubmit={handleSubmit}>
              <FormGroup>
                <Label for="name">Name</Label>
                <Input type="text" name="name" value={name} onChange={(e) => setName(e.target.value)} />
              </FormGroup>
              <FormGroup>
                <Label for="email">Email</Label>
                <Input type="email" name="email" value={email} onChange={(e) => setEmail(e.target.value)} />
              </FormGroup>
              <FormGroup>
                <Label for="password">Password</Label>
                <Input type="password" name="password" value={password} onChange={(e) => setPassword(e.target.value)} />
              </FormGroup>
              <Button type="submit" color="primary">Register</Button>
            </Form>
          ) : (
            <>
              <p>Ainda não possui conta?</p>
              <GoogleLogin
                clientId={process.env.REACT_APP_GOOGLE_CLIENT_ID}
                buttonText="Registre-se com Google"
                onSuccess={onSuccess}
                // onFailure={responseGoogle}
                cookiePolicy={'single_host_origin'}
                isSignedIn={isLogged}
              />
            </>
          )}

        </div>
      </div>
    </div>
  );
};

