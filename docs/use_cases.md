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
| Pós ocndições | O usuário está registrado no sistema e logado. |

#### Login no sistema
| Identificação | [UC002] |
| --- | --- |
| Descrição | Permitir que o usuário se autentique e acesso o sistema através da API do Google |
| Atores | GoogleLoginAPI, Usuário |
| Pré-condições | O usuário tem uma conta cadastrada no sistema |
| Fluxo principal | 1. O usuário informa email e senha na tela de login e clica em "entrar" <br> 2. O sistema busca se as credenciais informadas pertencem a uma conta existente <br> 3. O sistema registra a sessão do usuário <br> 4. O Usuário é redirecionado para a página principal |
| Pós ocndições | O usuário está registrado no sistema e logado. |