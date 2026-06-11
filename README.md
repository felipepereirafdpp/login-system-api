# 🚀 Login System API

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-Language-239120?style=for-the-badge&logo=csharp)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET-Core-512BD4?style=for-the-badge&logo=dotnet)
![Entity Framework Core](https://img.shields.io/badge/Entity_Framework-Core-68217A?style=for-the-badge)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver)
![JWT](https://img.shields.io/badge/JWT-Authentication-black?style=for-the-badge&logo=jsonwebtokens)
![BCrypt](https://img.shields.io/badge/BCrypt-Security-orange?style=for-the-badge)
![REST API](https://img.shields.io/badge/REST-API-blue?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Completed-success?style=for-the-badge)
![Architecture](https://img.shields.io/badge/Architecture-Clean_Code-blueviolet?style=for-the-badge)

---

## 📌 Sobre o Projeto

API de autenticação e gerenciamento de usuários desenvolvida em **ASP.NET Core**, estruturada com foco em **organização, escalabilidade e boas práticas de mercado**.

O projeto já segue uma arquitetura próxima a sistemas profissionais utilizados em empresas reais.

---

## 🧠 Arquitetura do Sistema

O projeto foi dividido em camadas para manter o código limpo e organizado:

* 📦 **Controllers** → Entrada das requisições HTTP
* ⚙️ **Services** → Regras de negócio
* 📑 **Interfaces** → Contratos das services
* 📤 **DTOs** → Comunicação segura entre camadas
* 🧱 **Models** → Entidades do banco de dados
* 🗄️ **Data (DbContext)** → Acesso ao banco com Entity Framework Core
* 📊 **Migrations** → Versionamento do banco

---

## 🔐 Funcionalidades

- ✅ Registro de usuários
- ✅ Login de usuários
- ✅ JWT Authentication
- ✅ Rotas protegidas com Authorize
- ✅ Refresh Token
- ✅ Renovação automática de sessão
- ✅ Recuperação de senha
- ✅ Geração de token para redefinição
- ✅ Envio de token por e-mail
- ✅ Alteração segura de senha
- ✅ Validação de credenciais
- ✅ Criptografia de senhas com BCrypt
- ✅ Persistência de dados com SQL Server
- ✅ Entity Framework Core
- ✅ Arquitetura em Camadas
- ✅ DTOs para transferência de dados
- ✅ Injeção de Dependência

---

## 🧩 Diferenciais Técnicos

🔥 **Arquitetura limpa (Clean Code)**
Separação clara entre Controller e lógica de negócio.

🔥 **Uso de Interfaces**
Facilita manutenção, testes e escalabilidade.

🔥 **DTOs bem definidos**
Evita exposição direta das entidades do banco.

🔥 **Estrutura escalável**
Pronto para crescer sem necessidade de refatoração.

🔥 **Segurança aplicada**
Senhas armazenadas com hash (BCrypt).

🔥 **Preparado para JWT**
Base pronta para autenticação moderna com tokens.

---

## 🧱 Estrutura do Projeto

```text
Controllers/
Services/
Interfaces/
Dto/
Models/
Data/
Migrations/
```

---

### 📌 Organização das camadas

* 📦 **Controllers** → Responsáveis por receber as requisições HTTP e devolver respostas
* ⚙️ **Services** → Contém toda a regra de negócio da aplicação
* 📑 **Interfaces** → Definem contratos das services
* 📤 **DTOs** → Objetos de transferência de dados entre camadas
* 🧱 **Models** → Entidades do banco de dados
* 🗄️ **Data (DbContext)** → Contexto do Entity Framework Core
* 📊 **Migrations** → Controle de versionamento do banco

---

## 👨‍💻 Autor

### Felipe De Paula Pereira

🎓 Estudante de Tecnologia da Informação

💻 Desenvolvedor Back-end focado em C# e ASP.NET Core

🚀 Desenvolvendo projetos com foco em arquitetura de software, APIs REST, segurança e boas práticas de desenvolvimento.

⭐ Caso tenha gostado do projeto, considere deixar uma estrela no repositório.
