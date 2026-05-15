# 🚀 Login System API

![.NET](https://img.shields.io/badge/.NET-API-512BD4?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-Language-239120?style=for-the-badge&logo=csharp)
![Status](https://img.shields.io/badge/Status-Em%20Desenvolvimento-yellow?style=for-the-badge)
![Architecture](https://img.shields.io/badge/Architecture-Clean%20Style-blue?style=for-the-badge)

---

## 📌 Sobre o Projeto

API de autenticação e gerenciamento de usuários desenvolvida em **ASP.NET Core**, estruturada com foco em **organização, escalabilidade e boas práticas de mercado**.

O projeto já segue uma arquitetura próxima a sistemas profissionais utilizados em empresas reais.

---

## 🧠 Arquitetura do Sistema

O projeto foi dividido em camadas para manter o código limpo e organizado:

- 📦 **Controllers** → Entrada das requisições HTTP  
- ⚙️ **Services** → Regras de negócio  
- 📑 **Interfaces** → Contratos das services  
- 📤 **DTOs** → Comunicação segura entre camadas  
- 🧱 **Models** → Entidades do banco de dados  
- 🗄️ **Data (DbContext)** → Acesso ao banco com Entity Framework Core  
- 📊 **Migrations** → Versionamento do banco  

---

## 🔐 Funcionalidades

- ✅ Registro de usuários  
- ✅ Login de usuários  
- ✅ Validação de credenciais  
- 🔒 Senhas criptografadas com BCrypt  
- 🚧 Estrutura pronta para JWT Authentication  

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
Controllers/
Services/
Interfaces/
Dto/
Models/
Data/
Migrations/

---

### 📌 Organização das camadas

- 📦 **Controllers** → Responsáveis por receber as requisições HTTP e devolver respostas
- ⚙️ **Services** → Contém toda a regra de negócio da aplicação
- 📑 **Interfaces** → Definem contratos das services
- 📤 **DTOs** → Objetos de transferência de dados entre camadas
- 🧱 **Models** → Entidades do banco de dados
- 🗄️ **Data (DbContext)** → Contexto do Entity Framework Core
- 📊 **Migrations** → Controle de versionamento do banco
