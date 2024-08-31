# Games Database - REST API com ASP.NET Core

## Descrição

Este projeto é uma API REST desenvolvida com ASP.NET Core 7 para gerenciar um banco de dados de jogos digitais. A aplicação permite a criação, listagem, detalhamento, atualização e remoção de eventos relacionados a jogos, além do cadastro de desenvolvedores associados.

## Tecnologias e Ferramentas Utilizadas

- **Visual Studio 2022**
- **ASP.NET Core 7**
- **Entity Framework Core (EF Core)**
- **Swagger**
- **AutoMapper**

## Funcionalidades

- **CRUD de Eventos**:
  - Cadastro
  - Listagem
  - Detalhes
  - Atualização
  - Remoção
- **Cadastro de Estúdios Desenvolvedores**

## Como Usar

1. **Clone o Repositório**
   ```bash
   git clone https://github.com/seuusuario/nomedoprojeto.git
2. **Configuração**
  - Abra o projeto no Visual Studio 2022.
  - Configure a string de conexão com o banco de dados no arquivo **appsettings.json**.
3. **Restaurar Pacotes**
  - Navegue até a pasta do projeto e execute:
    ```bash
    dotnet restore
4. **Executar Migrations**
  - Abra o console do Gerenciador de Pacotes no Visual Studio.
  - Execute os seguintes comandos para aplicar as migrations e criar o banco de dados:
    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
5. **Rodar o Projeto**
  - Compile e execute a aplicação no Visual Studio.
  - A API estará disponível em **https://localhost:7121** o valor da porta (7121) irá variar dependendo da configuração.
6. **Testar API**
  - Acesse o Swagger UI em https://localhost:7121/swagger para interagir com a API e testar as funcionalidades.
7. **Consumo na Prática**
  - Acesse index.html em "Exemplo Consumo API".
  - Você pode testar o CRUD diretamente pelo site.
  - Mais detalhes dentro do diretório

# Exemplo de Consumo da API

Para interagir com a API, você pode usar ferramentas como o Swagger UI integrado ou criar requisições HTTP usando ferramentas como curl ou Postman.

Por exemplo, para criar um novo evento, faça uma requisição POST para /api/dev-events com o seguinte corpo JSON:

    
    {
      "title": "Novo Evento",
      "description": "Descrição do evento",
      "announcementDate": "2024-08-31T12:00:00",
      "endDate": "2024-08-31T14:00:00"
    }

### Contribuições
Sinta-se à vontade para contribuir com melhorias ou correções. Para isso, abra um pull request ou abra um issue no GitHub.

### Licença
Este projeto está licenciado sob a Licença MIT.
