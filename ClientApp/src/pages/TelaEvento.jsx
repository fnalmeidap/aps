import React, { useState } from "react";
import { Container, ListGroup, ListGroupItem, Button, Col, Collapse, Badge } from "reactstrap";
import { categoriesEnum } from '../utils/constants';
import { formatAddress, formatDate } from '../utils/formatters';

const eventosMock = [
  {
    name: 'Qualquer',
    endereco: {
        cidade: "Recife",
        estado: "Pernambuco",
        pais: "Brasil"
    },
    startTime: "2023-07-22T00:00:00Z",
    finalTime: "2023-07-27T00:00:00Z",
    categorias: [
        1,
        2
    ],
    id: 0
  },
  {
    name: 'Qualquer 2',
    endereco: {
        cidade: "Recife",
        estado: "Pernambuco",
        pais: "Brasil"
    },
    startTime: "2023-07-22T00:00:00Z",
    finalTime: "2023-07-27T00:00:00Z",
    categorias: [
        1,
    ],
    id: 1
  },
  {
    name: 'Qualquer 4',
    endereco: {
        cidade: "Recife",
        estado: "Pernambuco",
        pais: "Brasil"
    },
    startTime: "2023-07-22T00:00:00Z",
    finalTime: "2023-07-27T00:00:00Z",
    categorias: [
        1,2,3
    ],
    id: 2
  },
];

export const TelaEvento = () => {
  const [eventoSelecionado, setEventoSelecionado] = useState(null);
  const [categoriasSelecionadas, setCategoriasSelecionadas] = useState([]);

  const handleEventoSelect = (evento) => {
    setEventoSelecionado(evento);
    setCategoriasSelecionadas([]); // Limpar a lista de categorias selecionados ao selecionar um novo evento
  };

  const handleInscricaoClick = () => {
    console.log( eventoSelecionado.id, categoriasSelecionadas);
  };

  const handleCategorySelect = (category) => {
    // Toggle da seleção do participante
    setCategoriasSelecionadas((prevState) =>
      prevState.includes(category)
        ? prevState.filter((item) => item !== category)
        : [...prevState, category]
    );
  };

  return (
    <Container>
      <Col
        md={{
          size: 12
        }}
      >
      <h2>Eventos de Robótica</h2>
      <ListGroup>
        {eventosMock.map((evento) => (
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
            {evento.categorias.map(categoria => (
              <Badge color="secondary" style={{marginLeft: 8}}>
                {categoriesEnum[categoria]}
              </Badge>
            ))}
          </div>
          <div className="d-flex gap-2">
            <span style={{marginLeft: 8}} >{formatAddress(evento.endereco)}</span>
            <span>{formatDate(evento.startTime)} a {formatDate(evento.finalTime)}</span>
          </div>
        </ListGroupItem>
        ))}
      </ListGroup>
      <Collapse isOpen={eventoSelecionado} className="mt-3">
        <div className="mt-4">
          <h3>Categorias</h3>
          <ListGroup horizontal>
            {eventoSelecionado?.categorias.map((categoria) => (
              <ListGroupItem
                key={categoria}
                tag="button"
                onClick={() => handleCategorySelect(categoria)}
                active={categoriasSelecionadas.includes(categoria)}
                action
              >
                <Badge color="secondary" style={{marginLeft: 8}}>
                  {categoriesEnum[categoria]}
                </Badge>
              </ListGroupItem>
            ))}
          </ListGroup>
        </div>
      </Collapse>
      <Collapse isOpen={eventoSelecionado && categoriasSelecionadas.length > 0} className="mt-3">
        <Button
          color="primary"
          disabled={!eventoSelecionado || !categoriasSelecionadas.length}
          onClick={handleInscricaoClick}
          className="mt-3"
        >
          Inscrever-se
        </Button>
      </Collapse>
      </Col>
    </Container>
  );
};
