# 🚀 Login System API

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-Language-239120?style=for-the-badge&logo=csharp)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET-Core-512BD4?style=for-the-badge&logo=dotnet)
![SQL Server](https://img.shields.io/badge/SQL-Server-CC2927?style=for-the-badge&logo=microsoftsqlserver)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-68217A?style=for-the-badge)
![Swagger](https://img.shields.io/badge/Swagger-Documentation-85EA2D?style=for-the-badge&logo=swagger)
![Status](https://img.shields.io/badge/Status-Em%20Desenvolvimento-yellow?style=for-the-badge)
![Architecture](https://img.shields.io/badge/Architecture-Clean%20Code-blue?style=for-the-badge)

---

## 📌 Sobre o Projeto

API de autenticação e gerenciamento de usuários desenvolvida em **ASP.NET Core**, utilizando arquitetura em camadas e boas práticas de desenvolvimento.

O objetivo do projeto é simular a estrutura utilizada em aplicações reais, priorizando organização, manutenção, escalabilidade e segurança.

---

## 🛠️ Tecnologias Utilizadas

- C#
- ASP.NET Core
- Entity Framework Core
- SQL Server
- BCrypt
- Swagger/OpenAPI
- Dependency Injection
- REST API

---

## 🧠 Arquitetura do Sistema

O projeto foi dividido em camadas para manter o código organizado e de fácil manutenção.

- 📦 **Controllers** → Entrada das requisições HTTP
- ⚙️ **Services** → Regras de negócio
- 📑 **Interfaces** → Contratos das Services
- 📤 **DTOs** → Comunicação segura entre camadas
- 🧱 **Models** → Entidades do banco de dados
- 🗄️ **Data (DbContext)** → Acesso ao banco de dados
- 📊 **Migrations** → Controle de versão do banco

---

## 🔐 Funcionalidades

- ✅ Registro de usuários
- ✅ Login de usuários
- ✅ Validação de credenciais
- ✅ Criptografia de senhas com BCrypt
- ✅ Entity Framework Core
- 🚧 JWT Authentication
- 🚧 Recuperação de senha
- 🚧 Refresh Tokens

---

## 🧩 Diferenciais Técnicos

### 🔥 Arquitetura em Camadas

Separação clara entre apresentação, negócio e acesso a dados.

### 🔥 Uso de Interfaces

Facilita manutenção, testes e desacoplamento.

### 🔥 DTOs Bem Definidos

Evita exposição direta das entidades da aplicação.

### 🔥 Estrutura Escalável

Preparada para crescimento sem necessidade de grandes refatorações.

### 🔥 Boas Práticas de Segurança

Proteção de senhas utilizando BCrypt.

### 🔥 Pronto para JWT

Estrutura preparada para autenticação baseada em tokens.

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

### Swagger

![Swagger](./Images/swagger.png)

### Cadastro de Usuário

![Register](./Images/register.png)

### Login

![Login](./Images/login.png)

---

## 🚀 Como Executar

### Clonar o projeto

```bash
git clone https://github.com/seu-usuario/login-system-api.git
```

### Entrar na pasta

```bash
cd login-system-api
```

### Executar as migrations

```bash
dotnet ef database update
```

### Executar a aplicação

```bash
dotnet run
```

### Acessar Swagger

```text
https://localhost:xxxx/swagger
```

---

## 📈 Roadmap

- [x] Cadastro de usuários
- [x] Login de usuários
- [x] BCrypt
- [x] Entity Framework Core
- [ ] JWT Authentication
- [ ] Recuperação de senha
- [ ] Refresh Tokens
- [ ] Controle de permissões

---

## 👨‍💻 Autor

**Felipe De Paula Pereira**

🎓 Estudante de Tecnologia da Informação

💻 Desenvolvedor Back-end focado em C# e ASP.NET Core

🚀 Construindo projetos para evoluir em arquitetura de software, APIs REST e desenvolvimento profissional.

⭐ Caso tenha gostado do projeto, considere deixar uma estrela no repositório.
