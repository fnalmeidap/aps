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

export const TelaEvento = () => {
  const { user } = useLogin();
  const [eventoSelecionado, setEventoSelecionado] = useState(null);
  const [categoriasSelecionadas, setCategoriasSelecionadas] = useState([]);
  const [listaDeEventos, setlistaDeEventos] = useState(null);

  const handleEventoSelect = (evento) => {
    setEventoSelecionado(evento);
    setCategoriasSelecionadas([]); // Limpar a lista de categorias selecionados ao selecionar um novo evento
  };

  const handleCategorySelect = (category) => {
    // Toggle da seleção do participante
    setCategoriasSelecionadas((prevState) =>
      prevState.includes(category)
        ? prevState.filter((item) => item !== category)
        : [...prevState, category]
    );
  };

  useEffect(() => {
    async function fetchEventos() {
      fetch("/api/Eventos", {
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
          alert("OPS, ALGO DEU ERRADO");
        });
    }
    fetchEventos();
  }, []);

  console.log(categoriasSelecionadas);

  const handleInscricaoClick = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch("/api/Eventos", {
        method: "PATCH",
        headers: {
          "Content-Type": "application/json", // Define o tipo de conteúdo como JSON
        },
        body: JSON.stringify({
          EquipeId: user.equipe.id,
          EventoId: eventoSelecionado.id,
          Categorias: categoriasSelecionadas,
        }),
      });

      if (!response.ok) {
        throw new Error("Erro na requisição");
      }

      //const responseData = await response.json(); // Parse da resposta para JSON
      //console.log("RESPOSTA:", responseData);
      alert("Equipe inscrita");
    } catch (error) {
      console.error("Erro na requisição PATCH:", error);
      alert("OPS, ALGO DEU ERRADO");
    }
  };

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
                      <Badge color="secondary" style={{ marginLeft: 8 }}>
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
            <Collapse isOpen={!!eventoSelecionado} className="mt-3">
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
                      <Badge color="secondary" style={{ marginLeft: 8 }}>
                        {categoriesEnum[categoria]}
                      </Badge>
                    </ListGroupItem>
                  ))}
                </ListGroup>
              </div>
            </Collapse>
            <Collapse
              isOpen={!!eventoSelecionado && categoriasSelecionadas.length > 0}
              className="mt-3"
            >
              <Button
                color="primary"
                disabled={!eventoSelecionado || !categoriasSelecionadas.length}
                onClick={handleInscricaoClick}
                className="mt-3"
              >
                Inscrever-se
              </Button>
            </Collapse>
          </>
        )}
      </Col>
    </Container>
  );
};
