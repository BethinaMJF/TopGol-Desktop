# ⚽ TopGol - Sistema de Acompanhamento de Jogos de Futebol
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows_Forms-0078D4?style=for-the-badge&logo=windows&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity_Framework-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

TopGol é um sistema impulsionado por indicações de usuários, permitindo acompanhar jogos de futebol, exibir placares e rankings, além de gerenciar usuários.  

---
## 💡 Tecnologias Utilizadas

- **C#** com **Windows Forms**
- **Entity Framework (ADO.NET)**
- **SQL Server**
- **Arquitetura em Camadas (MVC - Model, View, Controller)**


---
## 📌 Funcionalidades


- **Autenticação e Login:** O acesso é feito por e-mail. Convidados são redirecionados para o cadastro no primeiro acesso, enquanto usuários já registrados fazem login com senha.

- **Esqueci minha senha:** Se o usuário esquecer a senha, poderá redefini-la após responder corretamente a algumas perguntas de segurança.

- **Gestão de Usuários:** O acesso é feito por indicação. O sistema verifica o prazo de 30 dias do convite feito ao convidado, garantindo que a inscrição seja feita dentro do período válido.

- **Sistema de Indicação:** Todos os usuários podem indicar amigos por e-mail para expandir a comunidade de acompanhamento de jogos.

- **Jogos e Ranking:** A apresentação de jogos é feita de forma clara, exibindo o placar, data e hora das partidas. O ranking das competições é calculado com base em vitórias, empates e gols. Os jogos e rankings podem ser filtrados por ano e ordenados por diferentes critérios.

- **Personalização de Perfil:** Usuários podem alterar seus dados de perfil (exceto o email).

- **Preenchimento Automático:** Nos campos "Cor favorita" e "Time favorito", o sistema oferece sugestões automáticas após o terceiro caractere digitado. A sugestão é baseada em dados previamente cadastrados no banco de dados. A palavra sugerida aparece parcialmente completada em uma fonte mais clara. O usuário pode aceitar a sugestão ao clicar no campo.

- **Notificações Inteligentes:** Quando habilitadas, as notificações pendentes são exibidas na área de trabalho ao abrir o aplicativo. Ao clicar na notificação, o usuário pode visualizar os detalhes, marcando-a como "lida". Caso a notificação seja ignorada ou fechada, a próxima na fila será exibida até que todas sejam vistas.

---

## 📦 Instalação  

### 1️⃣  **Clone este repositório**:

```sh
    git clone https://github.com/BethinaMJF/TopGol-Desktop.git
````

### 2️⃣ Configure o Banco de Dados
- Execute o arquivo script.sql para criar o bando de dados.
- Configure a string de conexão no arquivo **App.config**:
- Substitua SEU_SERVIDOR pelo nome do seu servidor SQL Server.

````
<connectionStrings>
    <add name="ModuloDesktopEntities" ... Data Source=SEU_SERVIDOR; />
</connectionStrings>
````

### 3️⃣ Execute o Projeto no Visual Studio
Abra o projeto no Visual Studio e execute-o para testar as funcionalidades.
