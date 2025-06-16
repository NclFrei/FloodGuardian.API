# FloodGuardian - Global Solution Fiap

Este projeto faz parte da disciplina **Advanced Business Development with .NET** e tem como objetivo criar uma API RESTful voltada para ajudar desenvolvedores a gerenciar dados e eventos de inundações, com endpoints para rastreamento de níveis de água, alertas e persistência de dados.

---
## 💡 Funcionalidades
- Registro e consulta de estações hidrométricas
- Envio de leituras de nível de água
- Geração de alertas com base em limites configuráveis
- Armazenamento de dados em banco relacional

## Tecnologias Utilizadas

- [.NET 8]
- ASP.NET Core 
- Entity Framework Core
- Oracle Database
- Swagger
- JWT Authentication

---


## 👥 GRUPO

- RM557647 - Nicollas Frei
- RM554921 - Eduardo Eiki
- RM558208 - Heitor Pereira Duarte
  
---

## Estrutura do Projeto
MottuChallenge/

  ├── FloodGuardian.API (Presentation)

  ├── FloodGuardian.Application (Services e DTOs)

  ├── FloodGuardian.Domain (Entidades, Models)

  ├── FloodGuardian.Infrastructure (Contexto, Migrations, JWT)


---

### UserController
- `POST /api/User/register` → Criação de usuário
- `POST /api/User/login` → Login e retorno do JWT
- `PATCH /api/User/{id}`  → Altera informações do usuario
- - `DELETE /api/User/{id}`  → deleta usuario

### SensorData
- `POST /api/sensores` → Criação do sensor
- `Get /api/sensores/{sensorId}/historico` → Lista todos os post do sensor especificado
- `Get /api/sensores/{sensorId}/status` → Retorna o status do sensor
- `Get /api/sensores/{sensorId}/periodo` → Lista todos os os sensores no periodo especificado
- `Get /api/sensores/ultimos` → Lista todos os ultimos sensores

###  Alerta
- `Get /api/Alertas/recentes` →  Lista os ultimos alertas
- `Get /api/Alertas/sensor/{sensorId}` →  Lista os ultims alertas do sensor especificado
- `Post /api/Alertas/manual` →  Cria o alerta manualmente

## ✅ Funcionalidades Implementadas

- [x] CRUD completo para `User`, `Patio` e `Area`
- [x] Autenticação com JWT
- [x] Relacionamento entre Alerta → Endereco → Area → User
- [x] Validações com Data Annotations
- [x] Documentação com Swagger
- [x] Clean Architecture aplicada
- [x] Versionamento de banco via EF Migrations

---

## 🧪 Como Executar Localmente

1. Clone o repositório:
```bash
git clone https://github.com/NclFrei/FloodGuardian.API.git
