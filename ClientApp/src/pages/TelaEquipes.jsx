import React, { useEffect, useState } from 'react'
import { Badge, Button, Col, Collapse, Container, ListGroup, ListGroupItem, Spinner } from 'reactstrap';
import { useLogin } from '../hooks/Login';

export default function TelaEquipes() {
  const { user, setUser } = useLogin()
  const [equipes, setEquipes] = useState(null);
  const [equipeSelecionada, setEquipeSelecionada] = useState(null);

  const handleEquipeSelect = (equipe) => {
    setEquipeSelecionada(equipe);
  };

  useEffect(() => {
    async function fetchEquipes() {
      fetch("/api/Equipe", {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
        },
      })
        .then((response) => response.json())
        .then((data) => {
          console.log(data);
          if (data) {
            setEquipes(data);
          } else {
            // Show an error message
            alert(data.error);
          }
        })
        .catch(() => {
          alert("OPS, ALGO DEU ERRADO");
        });
    }
    fetchEquipes();
  }, []);

  const handleInscricaoClick = async () => {
    try {
      const response = await fetch("/api/Equipe", {
        method: "PATCH",
        headers: {
          "Content-Type": "application/json", // Define o tipo de conteúdo como JSON
        },
        body: JSON.stringify({
          EquipeId: Number(equipeSelecionada.id),
          ParticipanteId: Number(user.participante.id)
        }),
      });

      if (!response.ok) {
        throw new Error("Erro na requisição");
      }

      const responseData = await response.json(); // Parse da resposta para JSON
      console.log('RESPOSTA:', responseData)
      setUser(p => ({...p, equipe: responseData.id}))
      alert("Inscrito");
    } catch (error) {
      console.error("Erro na requisição POST:", error);
      // alert("OPS, ALGO DEU ERRADO");
    }
  };

  return (
    <Container>
      <Col
        md={{
          size: 12,
        }}
      >
        <h2>Equipes de Robótica</h2>
        {!equipes ? (
          <Spinner>Loading...</Spinner>
        ) : equipes.length === 0 ? (
          <p>NÃO EXISTEM EQUIPES DISPONÍVEIS</p>
        ) : (
          <>
            <ListGroup>
              {equipes.map((equipe) => (
                <ListGroupItem
                  key={equipe.id}
                  active={equipeSelecionada === equipe}
                  tag="button"
                  onClick={() => handleEquipeSelect(equipe)}
                  action
                  className="d-flex justify-content-between align-items-center"
                >
                  <div className="d-flex gap-2">
                    <span>{equipe.name}</span>
                    <Badge color="secondary" style={{ marginLeft: 8 }}>
                      {equipe.university}
                    </Badge>
                  </div>
                </ListGroupItem>
              ))}
            </ListGroup>
            <Collapse
              isOpen={!!equipeSelecionada}
              className="mt-3"
            >
              <Button
                color="primary"
                disabled={!equipeSelecionada}
                onClick={handleInscricaoClick}
                className="mt-3"
              >
                Entrar na equipe
              </Button>
            </Collapse>
          </>
        )}
      </Col>
    </Container>
  );
};
