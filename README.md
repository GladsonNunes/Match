
# Projeto Match - back-end 

O projeto é uma API desenvolvida em .NET 8 que gerencia o processo de "match" entre desenvolvedores e projetos. Ele possui funcionalidades para criar matches, associar desenvolvedores a projetos e vice-versa, além de atualizar o status de um match.

## 🚀 Como Executar
🔧 Requisitos

- Docker
- Docker Compose
## Como executar o projeto no Docker

### Passo 1: Clonar o repositório

Clone o repositório do projeto para sua máquina local:
```bash
git clone https://github.com/GladsonNunes/match-api.git cd match-api
```


### Passo 2: Construir e executar o contêiner

Execute os seguintes comandos para construir e iniciar o contêiner Docker:
```bash
docker-compose build 
```
```bash
docker-compose up
```

### Passo 3: Acessar a API

A API estará disponível em `http://localhost:8080`. Você pode testar os endpoints usando ferramentas como Postman ou cURL.



## 📜 Tecnologias Utilizadas

🔹 Back-End
- Linguagem: C#
- Framework: .NET 8

🔹 Banco de Dados
- Banco de Dados Relacional: Oracle
- ORM: Entity Framework Core


🔹 Infraestrutura e DevOps
- Containerização: Docker
- Gerenciamento de Containers: Docker Compose

🔹 Testes Automatizados
- Testes Unitários e de Integração: xUnit
- Mock de Dependências: Moq


## 🌐 Endpoints Principais

Os controllers responsáveis pelos classes Developer, Project e Skill possuem endpoints semelhantes, seguindo o padrão CRUD (Create, Read, Update, Delete)

Os controllers abaixo possuem os mesmo endpoint de cadastro
- DeveloperControllers
- ProjectControllers
- SkillControllers

| Método | Endpoint             | Descrição                       |
|--------|----------------------|---------------------------------|
| POST   | /Create              | Cria um novo cadastro (Developer, Project, ou Skill).          |
| GET    | /GetByAll            |  Retorna todos os recursos cadastrados (todos os Developers, Projects ou Skills).     |
| GET    | /GetById             | Retorna um cadastro específico pelo Id.        |
| PUT    | /Update              | Atualiza os dados de um cadastro existente.          |
| DELETE | /Delete              | Exclui um cadastro específico pelo Id.          |

🔹 MatchController

- O `MatchController` é responsável por gerenciar as operações relacionadas a "matches" entre desenvolvedores e projetos. Ele fornece endpoints para criar matches, obter informações sobre matches e realizar o match entre desenvolvedores e projetos.


| Método | Endpoint             | Descrição                       |
|--------|----------------------|---------------------------------|
| POST   | /CreateMatch         | Cria um novo match.          |
| GET    | /GetMatch            |  Obtém informações sobre um match específico.               |
| GET    | /MatchDevelopersToProject             | Realiza o match de desenvolvedores para um projeto específico.       |
| GET    | /MatchProjectToDevelopers              | Realiza o match de projetos para um desenvolvedor específico.          |

🔹 MatchMakerController

- O `MatchMakerController` é responsável por gerenciar as operações relacionadas ao processamento de "matchmakers". Ele fornece endpoints para atualizar o status de processamento de um matchmaker.


| Método | Endpoint             | Descrição                       |
|--------|----------------------|---------------------------------|
| PUT   | /UpdateStatusProcessed         | Atualiza o status de processamento de um matchmaker específico.
