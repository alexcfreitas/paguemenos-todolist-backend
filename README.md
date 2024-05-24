# PagueMenos TodoList

## Descrição do Projeto

Este projeto é uma aplicação de gerenciamento de tarefas (to-do list) desenvolvida usando .NET Core no backend e ReactJS com TypeScript no frontend.

## Requisitos

- [Node.js](https://nodejs.org/) (versão 14 ou superior)
- [.NET SDK](https://dotnet.microsoft.com/download) (versão 8.0.300 ou superior)
- [Git](https://git-scm.com/)

## Clonando o Repositório

Primeiro, clone os repositórios backend e frontend:

bash

Copy code

`git clone <URL_DO_REPOSITORIO_BACKEND>
git clone <URL_DO_REPOSITORIO_FRONTEND>`

Substitua `<URL_DO_REPOSITORIO_BACKEND>` e `<URL_DO_REPOSITORIO_FRONTEND>` pelas URLs reais dos repositórios.

## Executando o Backend

### Passo 1: Navegue até o Diretório do Backend

bash

Copy code

`cd paguemenos-todolist-backend`

### Passo 2: Restaurar Pacotes

bash

Copy code

`dotnet restore`

### Passo 3: Executar a Aplicação

bash

Copy code

`dotnet run`

A aplicação backend será executada no endereço `http://localhost:5030`.

## Executando o Frontend

### Passo 1: Navegue até o Diretório do Frontend

bash

Copy code

`cd paguemenos-todolist-frontend`

### Passo 2: Instalar Dependências

bash

Copy code

`npm install`

### Passo 3: Executar a Aplicação

bash

Copy code

`npm start`

A aplicação frontend será executada no endereço `http://localhost:3000`.

## Estrutura do Projeto

### Backend

- Controllers: Define as APIs REST para a aplicação.
- Services: Contém a lógica de negócios.
- Entities: Define os modelos de dados.
- Data: Configurações e contexto do banco de dados.

### Frontend

- components: Contém os componentes React.
- services: Contém as chamadas para a API backend.
- domains: Define os tipos e interfaces usados na aplicação.
- App.tsx: Componente principal da aplicação.

## Notas Adicionais

- Certifique-se de que as portas `5030` (backend) e `3000` (frontend) estão disponíveis em sua máquina.
- Para qualquer problema ou dúvida, consulte a documentação oficial do [Node.js](https://nodejs.org/), [.NET](https://docs.microsoft.com/dotnet/) e React.
