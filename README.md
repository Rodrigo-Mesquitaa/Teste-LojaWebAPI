# Teste-LojaWebAPI
 Management API é uma  aplicação ASP.NET Core com os princípios de DDD (Domain-Driven Design) e projetada para gerenciar os pedidos de uma loja. 


 Descrição
A Order Management API é uma aplicação ASP.NET Core projetada para gerenciar os pedidos de uma loja. A aplicação é estruturada seguindo os princípios de DDD (Domain-Driven Design) e boas práticas de desenvolvimento de software. Esta API permite iniciar novos pedidos, adicionar e remover produtos, fechar pedidos e listar todos os pedidos, bem como obter detalhes específicos de um pedido.

Estrutura do Projeto
A solução está organizada em várias camadas para promover a separação de preocupações e facilitar a manutenção e a escalabilidade.

markdown
Copiar código
OrderManagement
│
├── OrderManagement.API
│   ├── Controllers
│   ├── Models
│   ├── DTOs
│   ├── Services
│   ├── Repositories
│   ├── Configurations
│   ├── Program.cs
│
├── OrderManagement.Domain
│   ├── Entities
│   ├── ValueObjects
│   ├── Aggregates
│   ├── Events
│
├── OrderManagement.Infrastructure
│   ├── Data
│   ├── Migrations
│
├── OrderManagement.Application
│   ├── Interfaces
│   ├── Services
│
└── OrderManagement.Tests
    ├── UnitTests


## OrderManagement.API

Controllers: Contém os controladores da API que lidam com as requisições HTTP.
Models: Modelos usados pelos controladores.
DTOs: Objetos de Transferência de Dados utilizados para comunicação entre as camadas.
Services: Serviços específicos da API para lógica de negócios.
Repositories: Repositórios para acesso a dados.
Configurations: Configurações da API, como Swagger.
OrderManagement.Domain
Entities: Entidades do domínio, como Order e Product.
ValueObjects: Objetos de valor do domínio.
Aggregates: Agregados do domínio.
Events: Eventos do domínio.

## OrderManagement.Infrastructure
Data: Contexto do banco de dados e configurações do Entity Framework Core.
Migrations: Migrações do banco de dados.

## OrderManagement.Application
Interfaces: Interfaces dos serviços de aplicação.
Services: Implementações dos serviços de aplicação.

## OrderManagement.Tests
UnitTests: Testes unitários para a aplicação.

## Funcionalidades

Iniciar um novo pedido: Cria um novo pedido.
Adicionar produtos ao pedido: Adiciona produtos a um pedido existente.
Remover produtos do pedido: Remove produtos de um pedido existente.
Fechar o pedido: Fecha um pedido existente.
Listar os pedidos: Lista todos os pedidos.
Obter um pedido pelo ID: Retorna os detalhes de um pedido específico pelo seu ID.

## Requisitos

.NET 8.0
Entity Framework Core
InMemory Database (para simplicidade, mas pode ser substituído por SQL Server ou outro banco de dados)

