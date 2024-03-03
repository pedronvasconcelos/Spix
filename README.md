# Spix

# ENG
## About the Project

This project introduces an API inspired by the dynamics and structure of Twitter, developed with the purpose of serving as a field for study and experimentation.

### Terms:
**Spixer**: It's the same as a publication. Our "tweet".

### Origin of the Name

The name "Spix" is a homage to the Spix's macaw (Cyanopsitta spixii), a rare and fascinating species of macaw found in Brazil, which was once extinct in the wild. However, thanks to the efforts of a German NGO, the macaw was reintroduced into the wild.

Beyond its ecological importance, the Spix's macaw gained cultural prominence as the protagonist in the animation movie "Rio".

In addition to paying tribute to the blue bird of Twitter, the choice of this name reflects not only the inspiration in the vibrant communication and socialization of these birds but also our desire to highlight the importance of environmental conservation. Just as the Spix's macaw faces challenges for its survival, Spixer seeks to create a space where voices can be shared to promote awareness and positive change.

## Technical Specification

This project leverages technologies and practices designed to ensure efficiency, readability, testability, and easy maintenance of the code, adhering to good development practices. Below are the main technologies and approaches used:

### Technologies

- **.NET 8**: The latest version of the .NET LTS is used as the development framework.
- **PostgreSQL**: Chosen as the SQL database.
- **Entity Framework Core (EFCore)**: We use EFCore as the ORM for command operations (CQRS).
- **Dapper**: We use Dapper as a Micro ORM for query operations (CQRS).
- **MediatR**: The Mediator pattern is implemented through MediatR, facilitating decoupled communication between objects and promoting a cleaner and more organized architecture.
- **Keycloak**: For managing authentication and authorization, Keycloak is integrated as a robust solution for Identity and Access Management (IAM), ensuring security and compliance for login, registration, and access control operations.

### Architecture and Practices

- **Clean Architecture**: We adopt the Clean Architecture to ensure that the project's structure remains flexible, testable, and easy to understand.
- **Domain-Driven Design (DDD)**: DDD is applied to align the design and implementation of the project with complex business requirements and domain rules, promoting more focused and higher-quality development.
- **EventBus**: We implement an EventBus to effectively manage domain events, allowing asynchronous and decoupled communication between different parts of the application, facilitating scalability and extensibility.
- **CQRS (Command Query Responsibility Segregation)**: We implement the CQRS pattern to separate data reading (queries) from update operations (commands), enhancing scalability and maintenance of the system, while also allowing for a clearer and more functional code organization.








# PT-BR
## Sobre o Projeto

Este projeto apresenta uma API inspirada na dinâmica e estrutura do Twitter, desenvolvida com o propósito de servir como um campo de estudo e experimentação.

###Termos:
**Spixer**: É o mesmo que uma publicação. O nosso "tweet".

### Origem do Nome

O nome "Spix" é uma homenagem à ararinha-azul (Cyanopsitta spixii), uma espécie rara e fascinante de arara encontrada no Brasil, que chegou a ser estinta em natureza, porém graças ao trabalho de uma ONG alemã, a arara foi reintroduzida na natureza.

Além de sua importância ecológica, a Ararinha-Azul ganhou destaque cultural ao ser retratada como protagonista no filme de animação "Rio".


Além da homeangem ao pássaro azul do Twitter, a escolha desse nome reflete não apenas a inspiração na comunicação vibrante e na socialização dessas aves, mas também nosso desejo de destacar a importância da conservação ambiental. Assim como a araromha-azul enfrenta desafios para sua sobrevivência, a Spixer busca criar um espaço onde as vozes possam ser compartilhadas para promover a conscientização e a mudança positiva.


## Especificação Técnica


Este projeto utiliza tecnologias e práticas que buscam gerar eficiência, legibilidade, testabilidade e fácil manutenção do código, seguindo boas práticas de desenvolvimento. Veja abaixo as principais tecnologias e abordagens utilzadas:

### Tecnologias

- **.NET 8**: A mais recente versão do .NET LTS é utilizada como o framework de desenvolvimento.
- **PostgreSQL**: Escolhido como o banco de dados SQL.
- **Entity Framework Core (EFCore)**: Utilizamos o EFCore como ORM para operações de comando (CQRS).
- **Dapper**: Utilizamos o Dapper como Micro ORM para operações de query (CQRS).
- **MediatR**: O padrão Mediator é implementado através do MediatR, facilitando a comunicação entre objetos de maneira desacoplada e promovendo uma arquitetura mais limpa e organizada.
- **Keycloak**: Para a gestão de autenticação e autorização, o Keycloak é integrado como uma solução robusta de Identity and Access Management (IAM), garantindo segurança e conformidade às operações de login, registro e controle de acesso.

### Arquitetura e Práticas

- **Clean Architecture**: Adotamos a Clean Architecture para garantir que a estrutura do projeto seja mantida flexível, testável e fácil de entender.
- **Domain-Driven Design (DDD)**: O DDD é aplicado para alinhar o design e a implementação do projeto com os complexos requisitos de negócios e regras do domínio, promovendo um desenvolvimento mais focado e de maior qualidade.
- **EventBus**: Implementamos um EventBus para gerenciar eventos de domínio de forma eficaz, permitindo uma comunicação assíncrona e desacoplada entre diferentes partes da aplicação, facilitando a escalabilidade e a extensibilidade.
- **CQRS (Command Query Responsibility Segregation)**: Implementamos o padrão CQRS para separar a leitura de dados (queries) das operações de atualização (commands), facilitando a escalabilidade e a manutenção do sistema, ao mesmo tempo que permite uma organização mais clara e funcional do código.



