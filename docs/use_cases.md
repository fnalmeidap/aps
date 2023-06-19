# Sistema Olimpo
## Proposta de projeto

O Sistema Olimpo 2.0 é uma reestruturação do antigo [Sistema Olimpo](https://novo.sistemaolimpo.org/), uma plataforma de coordenação de competições e eventos de Robótica no Brasil, assim como gerenciamento de inscrições, pagamentos e emissão de certificados.

## Casos de uso
### Diagrama
![diagrama_uc](/resources/diagram-uc.png)
### Fluxos de caso de uso
#### Cadastro no sistema
| Identificação | [UC001] |
| --- | --- |
| Descrição | Permitir que o usuário se cadastre no sistema através da API do Google |
| Atores | GoogleLoginAPI, Usuário |
| Pré-condições | Não há pré-condições |
| Fluxo principal | 1. O usuário clica em “registrar-se” <br> 2. O usuário se autentica com uma conta do google <br> 3. O sistema registra o usuário com a conta associada do Google <br> 4. O Usuário é redirecionado para  a página principal |
| Pós condições | O usuário está registrado no sistema e logado. |

#### Login no sistema
| Identificação | [UC002] |
| --- | --- |
| Descrição | Permitir que o usuário se autentique e acesso o sistema através da API do Google |
| Atores | GoogleLoginAPI, Usuário |
| Pré-condições | O usuário tem uma conta cadastrada no sistema |
| Fluxo principal | 1. O usuário informa email e senha na tela de login e clica em "entrar" <br> 2. O sistema busca se as credenciais informadas pertencem a uma conta existente <br> 3. O sistema registra a sessão do usuário <br> 4. O Usuário é redirecionado para a página principal |
| Pós condições | O usuário está registrado no sistema e logado. |

#### Submissão de Team Description Paper
| Identificação | [UC003] |
| --- | --- |
| Descrição | Permitir que o usuário submeta um arquivo .pdf para avaliação dos revisores |
| Atores | Usuário |
| Pré-condições | O usuário está logado no sistema |
| Fluxo principal | 1. O usuário busca por um evento que uma equipe que ele faz parte está inscrita clicando na página de "eventos". <br> 2. Na página do evento selecionado, o usuário clica em "gerenciar inscrição" da sua equipe. <br> 3. Na página de gerenciamento de inscrição de equipe, o usuário clica no botão "Escolher arquivo". <br> 4. O usuário escolhe um arquivo .pdf no pop-up que surge em sua tela. <br> 5. O usuário clica em "Submeter" e arquivo é enviado ao sistema. |
| Pós condições | A inscrição da equipe é atualizada com o arquivo submetido pelo usuário. |

#### Inscrição de usuário em evento
| Identificação | [UC004] |
| --- | --- |
| Descrição | Permitir que um usuário se inscreva em um evento|
| Atores | Usuário |
| Pré-condições | O usuário está logado no sistema e precisa fazer parte de uma equipe que está inscrita no evento |
| Fluxo principal | 1. O usuário busca por um evento que uma equipe que ele faz parte está inscrita clicando na página de "eventos". <br> 2. Na página do evento selecionado, o usuário clica em inscrever-se. <br> 3. O usuário preenche os campos textuais obrigatórios com suas informações pessoais. <br> 4. O usuário escolhe um método de pagamento de inscrição e clica em "pagar". <br> 5. O usuário é registrado na competição como "participante" e a inscrição da equipe é atualizada com mais um membro participante. |
| Pós condições | O usuário está registrado na competição, a equipe tem mais um usuário participante. |

#### Inscrição de equipe em evento
| Identificação | [UC005] |
| --- | --- |
| Descrição | Permitir que um usuário inscreva sua equipe em um evento|
| Atores | Usuário |
| Pré-condições | O usuário está logado no sistema |
| Fluxo principal | 1. O usuário busca por um evento que uma equipe que ele faz parte não está inscrita clicando na página de "eventos". <br> 2. Na página do evento selecionado, o usuário clica em "gerenciar inscrição" da sua equipe. <br> 3. Na página de gerenciamento de inscrição de equipe, o usuário clica no botão "Escolher arquivo". <br> 4. O usuário escolhe um arquivo .pdf no pop-up que surge em sua tela. <br> 5. O usuário clica em "Submeter" e arquivo é enviado ao sistema. |
| Pós ocndições | A inscrição da equipe é atualizada com o arquivo submetido pelo usuário. |