# Configuração e Uso do Exemplo Consumo API

Este documento fornece instruções para configurar e usar o arquivo index.html incluído na pasta Exemplo Consumo API. Este HTML permite testar a API REST do seu projeto de banco de dados de jogos digitais.

### Pré-Requisitos

1. **Servidor da API**
  - Certifique-se de que a API REST está em execução e acessível. A URL padrão usada no exemplo é https://localhost:7121.

3. **Configurar a URL da API**
  - Abra o arquivo index.html em um editor de texto.
  - erifique se a URL da API nas funções fetch está correta:
    ```bash
    fetch('https://localhost:7121/api/dev-events')
  - Substitua https://localhost:7121 pela URL correta do seu servidor API se necessário.
# Uso

1. Carregar Jogos
  - Clique no botão Carregar Jogos para buscar e listar todos os jogos disponíveis na API.
2. Cadastrar Novo Jogo
  - Preencha o formulário em Cadastrar Novo Jogo com os detalhes do novo jogo e clique em Cadastrar Jogo.
3. Atualizar Jogo
  - Forneça o ID do jogo que deseja atualizar e os novos detalhes no formulário de Atualizar Jogo, e clique em Atualizar Jogo.
4.Deletar Jogo
  - Insira o ID do jogo que deseja deletar no formulário de Deletar Jogo e clique em Deletar Jogo.
5. Cadastrar Nova Desenvolvedora
  - Preencha os detalhes da nova desenvolvedora no formulário Cadastrar Nova Desenvolvedora e clique em Cadastrar Desenvolvedora.
6. Buscar Jogo por ID
  - Insira o ID do jogo que deseja buscar no formulário de Buscar Jogo por ID e clique em Buscar Jogo. Os detalhes do jogo serão exibidos abaixo do formulário.
    
### Observações
 - Se você encontrar problemas com CORS, ajuste a configuração da sua API para permitir solicitações do local onde o index.html está hospedado.
 - Certifique-se de que a API está acessível a partir da URL fornecida e que o servidor da API está em execução.
   
### Suporte
Para problemas ou dúvidas, consulte a documentação da API ou entre em contato com o desenvolvedor da API.
