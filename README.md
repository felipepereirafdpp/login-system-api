# 🚀 Login System API

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-Language-239120?style=for-the-badge&logo=csharp)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET-Core-512BD4?style=for-the-badge&logo=dotnet)
![SQL Server](https://img.shields.io/badge/SQL-Server-CC2927?style=for-the-badge&logo=microsoftsqlserver)
![JWT](https://img.shields.io/badge/JWT-Authentication-black?style=for-the-badge&logo=jsonwebtokens)
![BCrypt](https://img.shields.io/badge/BCrypt-Security-orange?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Production%20Ready-success?style=for-the-badge)
![Architecture](https://img.shields.io/badge/Architecture-Clean%20Code-blue?style=for-the-badge)

---

## 📌 Sobre o Projeto

API REST de autenticação e gerenciamento de usuários desenvolvida com **ASP.NET Core**, seguindo princípios de arquitetura em camadas, Clean Code e boas práticas de desenvolvimento.

O projeto foi criado para simular uma estrutura profissional utilizada em aplicações reais, com foco em segurança, escalabilidade, organização e manutenção.

---

## 🛠️ Tecnologias Utilizadas

- C#
- .NET 10
- ASP.NET Core
- Entity Framework Core
- SQL Server
- JWT Authentication
- Refresh Tokens
- BCrypt
- REST API
- Dependency Injection

---

## 🧠 Arquitetura do Sistema

O projeto foi dividido em camadas para manter o código limpo, organizado e escalável.

- 📦 **Controllers** → Entrada das requisições HTTP
- ⚙️ **Services** → Regras de negócio
- 📑 **Interfaces** → Contratos das Services
- 📤 **DTOs** → Comunicação segura entre camadas
- 🧱 **Models** → Entidades do banco de dados
- 🗄️ **Data (DbContext)** → Comunicação com o banco de dados
- 📊 **Migrations** → Controle de versão da estrutura do banco

---

## 🔐 Funcionalidades

- ✅ Registro de usuários
- ✅ Login de usuários
- ✅ JWT Authentication
- ✅ Autorização baseada em Token
- ✅ Validação de credenciais
- ✅ Criptografia de senhas com BCrypt
- ✅ Recuperação de senha por e-mail
- ✅ Geração de Refresh Tokens
- ✅ Renovação de Access Tokens
- ✅ Entity Framework Core
- ✅ Persistência em SQL Server

---

## 🧩 Diferenciais Técnicos

### 🔥 Arquitetura em Camadas

Separação clara entre apresentação, regras de negócio e acesso a dados.

### 🔥 Uso de Interfaces

Promove desacoplamento e facilita manutenção e testes.

### 🔥 DTOs Bem Definidos

Evita exposição direta das entidades da aplicação.

### 🔥 JWT Authentication

Implementação de autenticação moderna baseada em tokens.

### 🔥 Refresh Tokens

Permite renovação segura de sessões sem necessidade de novo login.

### 🔥 Recuperação de Senha

Fluxo completo para redefinição segura de senha.

### 🔥 Segurança Aplicada

Senhas armazenadas utilizando hash BCrypt.

### 🔥 Estrutura Escalável

Preparada para crescer sem necessidade de grandes refatorações.

---

## 🧱 Estrutura do Projeto

```text
Controllers/
Services/
Interfaces/
DTOs/
Models/
Data/
Migrations/
```

---

## 📸 Demonstração

### Login

![Login](./Images/login.png)

### JWT Authentication

![JWT](./Images/jwt-token.png)

### Recuperação de Senha

![Forgot Password](./Images/forgot-password.png)

### Refresh Token

![Refresh Token](./Images/refresh-token.png)

### Banco de Dados

![Database](./Images/database.png)

---

## 🚀 Como Executar

### Clonar o repositório

```bash
git clone https://github.com/seu-usuario/login-system-api.git
```

### Entrar na pasta do projeto

```bash
cd login-system-api
```

### Configurar a Connection String

Configure sua string de conexão no arquivo:

```json
appsettings.json
```

### Aplicar as Migrations

```bash
dotnet ef database update
```

### Executar a aplicação

```bash
dotnet run
```

---

## 📈 Roadmap

- [x] Cadastro de usuários
- [x] Login de usuários
- [x] JWT Authentication
- [x] BCrypt
- [x] Entity Framework Core
- [x] Recuperação de senha por e-mail
- [x] Refresh Tokens
- [x] Renovação de Tokens

### 🚀 Próximas Implementações

- [ ] Controle de permissões (Roles)
- [ ] Auditoria de acessos
- [ ] Testes automatizados
- [ ] Deploy em nuvem

---

## 🎯 Conceitos Aplicados

- Clean Code
- Arquitetura em Camadas
- Dependency Injection
- DTO Pattern
- REST API
- JWT Authentication
- Refresh Tokens
- Entity Framework Core
- Password Hashing
- Separação de Responsabilidades

---

## 👨‍💻 Autor

### Felipe De Paula Pereira

🎓 Estudante de Tecnologia da Informação

💻 Desenvolvedor Back-end focado em C# e ASP.NET Core

🚀 Desenvolvendo projetos com foco em arquitetura de software, APIs REST, segurança e boas práticas de desenvolvimento.

⭐ Caso tenha gostado do projeto, considere deixar uma estrela no repositório.
