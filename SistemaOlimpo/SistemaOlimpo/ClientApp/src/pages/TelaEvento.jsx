import React, { useState } from "react";
import { Container, ListGroup, ListGroupItem, Button, Col, Collapse } from "reactstrap";

const eventosMock = [
  { id: 1, nome: "Evento 1" },
  { id: 2, nome: "Evento 2" },
  { id: 3, nome: "Evento 3" },
];

const participantesMock = [
  { id: 1, nome: "Participante 1" },
  { id: 2, nome: "Participante 2" },
  { id: 3, nome: "Participante 3" },
];

export const TelaEvento = () => {
  const [eventoSelecionado, setEventoSelecionado] = useState(null);
  const [participantesSelecionados, setParticipantesSelecionados] = useState([]);

  const handleEventoSelect = (evento) => {
    setEventoSelecionado(evento);
    setParticipantesSelecionados([]); // Limpar a lista de participantes selecionados ao selecionar um novo evento
  };

  const handleInscricaoClick = () => {
    // Implemente aqui a lógica para se inscrever no evento selecionado com os participantes selecionados
    console.log("Evento selecionado:", eventoSelecionado);
    console.log("Participantes selecionados:", participantesSelecionados);
  };

  const handleParticipanteSelect = (participante) => {
    // Toggle da seleção do participante
    setParticipantesSelecionados((prevState) =>
      prevState.includes(participante)
        ? prevState.filter((item) => item !== participante)
        : [...prevState, participante]
    );
  };

  return (
    <Container>
      <h2>Eventos de Robótica</h2>
      <ListGroup >
        {eventosMock.map((evento) => (
          <ListGroupItem
            key={evento.id}
            active={eventoSelecionado === evento}
            tag="button"
            onClick={() => handleEventoSelect(evento)}
            action
          >
            {evento.nome}
          </ListGroupItem>
        ))}
      </ListGroup>
      <Collapse isOpen={eventoSelecionado} className="mt-3">
        <div className="mt-4">
          <h3>Participantes</h3>
          <ListGroup>
            {participantesMock.map((participante) => (
              <ListGroupItem
                key={participante.id}
                tag="button"
                onClick={() => handleParticipanteSelect(participante)}
                active={participantesSelecionados.includes(participante)}
                action
              >
                {participante.nome}
              </ListGroupItem>
            ))}
          </ListGroup>
        </div>
      </Collapse>
      <Collapse isOpen={eventoSelecionado && participantesSelecionados.length > 0} className="mt-3">
        <Button
          color="primary"
          disabled={!eventoSelecionado || !participantesSelecionados.length}
          onClick={handleInscricaoClick}
          className="mt-3"
        >
          Inscrever-se
        </Button>
      </Collapse>
    </Container>
  );
};
