# Sistema Olimpo

## Proposta de projeto

O Sistema Olimpo 2.0 é uma reestruturação do antigo [Sistema Olimpo](https://novo.sistemaolimpo.org/), uma plataforma de coordenação de competições e eventos de Robótica no Brasil, assim como gerenciamento de inscrições, pagamentos e emissão de certificados.

## Casos de uso

### Diagrama

![diagrama_uc](/resources/diagram_uc.png)

### Fluxos de caso de uso

#### Cadastro no sistema

| Identificação   | [UC001]                                                                                                                                                                                                                  |
| --------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Descrição       | Permitir que o usuário se cadastre no sistema através da API do Google                                                                                                                                                   |
| Atores          | GoogleLoginAPI, Usuário                                                                                                                                                                                                  |
| Pré-condições   | O usuário tem uma conta do Google                                                                                                                                                                                        |
| Fluxo principal | 1. O usuário clica em “registrar” <br> 2. O usuário se autentica com uma conta do google <br> 3. O sistema registra o usuário com a conta associada do Google <br> 4. O Usuário é redirecionado para a página de eventos |
| Pós condições   | O usuário está registrado no sistema e logado na página de eventos.                                                                                                                                                      |

#### Login no sistema

| Identificação   | [UC002]                                                                                                                                                                                                                                          |
| --------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Descrição       | Permitir que o usuário se autentique e acesso o sistema através da API do Google                                                                                                                                                                 |
| Atores          | GoogleLoginAPI, Usuário                                                                                                                                                                                                                          |
| Pré-condições   | O usuário tem uma conta cadastrada no sistema                                                                                                                                                                                                    |
| Fluxo principal | 1. O usuário se autentica com uma conta do google <br> 2. O sistema busca se as credenciais informadas pertencem a uma conta existente <br> 3. O sistema registra a sessão do usuário <br> 4. O Usuário é redirecionado para a página de eventos |
| Pós condições   | O usuário está registrado no sistema e logado.                                                                                                                                                                                                   |

#### Inscrição de equipe em evento

| Identificação   | [UC003]                                                                                                                                                                                                                                                                 |
| --------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Descrição       | Permitir que um usuário inscreva sua equipe em um evento                                                                                                                                                                                                                |
| Atores          | Usuário                                                                                                                                                                                                                                                                 |
| Pré-condições   | O usuário está logado no sistema, precisa fazer parte de uma equipe e o evento precisa existir                                                                                                                                                                          |
| Fluxo principal | 1. O usuário navega para página de "eventos". <br> 2. Ele escolhe e clica em um evento na página de "eventos" <br>3. O usuário seleciona o conjunto de categorias desejadas e clica em "inscrever equipe". <br> 4. A equipe é registrados nas categorias da competição. |
| Pós condições   | A equipe está registrada na competição.                                                                                                                                                                                                                                 |

#### Submissão de Team Description Paper

| Identificação   | [UC004]                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
| --------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Descrição       | Permitir que o usuário submeta um arquivo .pdf para avaliação dos revisores                                                                                                                                                                                                                                                                                                                                                                                                |
| Atores          | Usuário                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
| Pré-condições   | O usuário está logado no sistema e pré-inscrito em um evento                                                                                                                                                                                                                                                                                                                                                                                                               |
| Fluxo principal | 1. O usuário busca por um evento que uma equipe que ele faz parte está inscrita clicando na página de "eventos". <br> 2. Na página do evento selecionado, o usuário clica em "gerenciar inscrição" da sua equipe. <br> 3. Na página de gerenciamento de inscrição de equipe, o usuário clica no botão "Escolher arquivo". <br> 4. O usuário escolhe um arquivo .pdf no pop-up que surge em sua tela. <br> 5. O usuário clica em "Submeter" e arquivo é enviado ao sistema. |
| Pós condições   | A inscrição da equipe é atualizada com o arquivo submetido pelo usuário.                                                                                                                                                                                                                                                                                                                                                                                                   |

#### Criação de uma equipe

| Identificação   | [UC005]                                                                                                                                                                                                                                                                                  |
| --------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Descrição       | Permitir que um usuário crie uma nova equipe                                                                                                                                                                                                                                             |
| Atores          | Usuário                                                                                                                                                                                                                                                                                  |
| Pré-condições   | O usuário está logado no sistema                                                                                                                                                                                                                                                         |
| Fluxo principal | 1. O usuário vai para a página de Cadastrar Equipes. <br> 2. Ele clica no botão "criar nova equipe". <br> 3. O usuário preenche os campos textuais obrigatórios com as informações da equipe e dos possíveis usuários iniciais. <br> 4. O participante clica no botão de "Criar equipe". |
| Pós condições   | A equipe está registrada no sistema.                                                                                                                                                                                                                                                     |

#### Vínculo de usuário a equipe

| Identificação   | [UC006]                                                                                                                                                |
| --------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Descrição       | Permitir que um usuário entre em uma equipe e a equipe que ele deseja se vincular já existe                                                            |
| Atores          | Usuário                                                                                                                                                |
| Pré-condições   | O usuário está logado no sistema                                                                                                                       |
| Fluxo principal | 1. O usuário vai para a página de Equipes. <br> 2. Ele seleciona a equipe que deseja entrar. <br> 3. O usuário clica no botão "Entrar em equipe". <br> |
| Pós condições   | O usuário está vinculado na equipe escolhida.                                                                                                          |
