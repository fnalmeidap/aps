import React, { useEffect, useState } from "react";
import {
  Container,
  ListGroup,
  ListGroupItem,
  Button,
  Col,
  Collapse,
  Badge,
  Spinner,
} from "reactstrap";
import { categoriesEnum } from "../utils/constants";
import { formatAddress, formatDate } from "../utils/formatters";
import { useLogin } from "../hooks/Login";
import { useNavigate } from 'react-router-dom';

export const TelaEvento = () => {
  const { user } = useLogin();
  const [listaDeEventos, setlistaDeEventos] = useState(null);
  const [eventoSelecionado, setEventoSelecionado] = useState(null);
  const [temEquipe, setTemEquipe] = useState(false);
  const navigate = useNavigate()

  const handleEventoSelect = (evento) => {
    setEventoSelecionado(evento);
  };

  const handleInscreverSeEvento = () => {
    navigate('/tela-evento/' + eventoSelecionado.id)
  }

  useEffect(() => {
    async function fetchEventos() {
      fetch("/api/evento", {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
        },
      })
        .then((response) => response.json())
        .then((data) => {
          console.log(data);
          if (data) {
            setlistaDeEventos(data);
          } else {
            // Show an error message
            alert(data.error);
          }
        })
        .catch(() => {
          alert("OPS, ALGO DEU ERRADO AO PUXAR EQUIPES");
        });
    }
    fetchEventos();
  }, []);

  useEffect(() => {
    async function fetchEquipes() {
      fetch("/api/equipe", {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
        },
      })
        .then((response) => response.json())
        .then((data) => {
          console.log(data, user);
          if (data) {
            data.forEach(equipe => {
              const memberFound = equipe.members.find(member => member.id === user.id)
              if(memberFound){
                setTemEquipe(true)
              }
            })
          } else {
            // Show an error message
            alert(data.error);
          }
        })
        .catch(() => {
          // alert("OPS, ALGO DEU ERRADO");
        });
    }
    fetchEquipes();
  }, []);

  return (
    <Container>
      <Col
        md={{
          size: 12,
        }}
      >
        <h2>Eventos de Robótica</h2>
        {!listaDeEventos ? (
          <Spinner>Loading...</Spinner>
        ) : listaDeEventos.length === 0 ? (
          <p>NÃO EXISTEM EVENTOS DISPONÍVEIS</p>
        ) : (
          <>
            <ListGroup>
              {listaDeEventos.map((evento) => (
                <ListGroupItem
                  key={evento.id}
                  active={eventoSelecionado === evento}
                  tag="button"
                  onClick={() => handleEventoSelect(evento)}
                  action
                  className="d-flex justify-content-between align-items-center"
                >
                  <div className="d-flex gap-2">
                    <span>{evento.name}</span>
                    {evento.categorias.map((categoria) => (
                      <Badge key={categoria} color="secondary" style={{ marginLeft: 8 }}>
                        {categoriesEnum[categoria]}
                      </Badge>
                    ))}
                  </div>
                  <div className="d-flex gap-2">
                    <span style={{ marginLeft: 8 }}>
                      {formatAddress(evento.endereco)}
                    </span>
                    <span>
                      {formatDate(evento.startTime)} a{" "}
                      {formatDate(evento.finalTime)}
                    </span>
                  </div>
                </ListGroupItem>
              ))}
            </ListGroup>
            <Collapse
              isOpen={!!eventoSelecionado}
              className="mt-3"
            >
              <Container className='d-flex gap-2'>
                <Button
                  color="primary"
                  disabled={!eventoSelecionado}
                  onClick={() => null}
                  className="mt-3"
                >
                  Ver detalhes do evento
                </Button>
                <Button
                  color="primary"
                  disabled={!eventoSelecionado || !temEquipe}
                  onClick={handleInscreverSeEvento}
                  className="mt-3"
                >
                  Inscrever-se
                </Button>
              </Container>
            </Collapse>
          </>
        )}
      </Col>
    </Container>
  );
};
