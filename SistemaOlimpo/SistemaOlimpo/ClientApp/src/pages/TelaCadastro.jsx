import React from 'react'
import { GoogleLogin } from 'react-google-login'


export function TelaCadastro() {

  const responseGoogle = (response) => {
    console.log(response);
  }

  return (
    <div>
      <GoogleLogin
        clientId={process.env.REACT_APP_GOOGLE_CLIENT_ID}
        buttonText='Cadastre-se com Google'
        cookiePolicy='single_host_origin'
        onSuccess={responseGoogle}
        // isSignedIn={true}
      />
    </div>
  )
}
