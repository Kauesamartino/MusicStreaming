# MusicStreaming - Projeto ASP.NET Core MVC

## Integrantes

Kauê Vinicius Samartino da Silva - RM559317

Lucas Borges de Souza - RM560027

Davi Praxedes Santos Silva - RM560719

Bruno Carlos Soares - RM559250

João dos Santos Cardoso de Jesus - RM560400

Pedro Henrique da Silva - RM560393

## Descrição

MusicStreaming é uma aplicação web desenvolvida em **ASP.NET Core MVC** que permite gerenciar artistas e músicas.
O sistema realiza operações **CRUD (Create, Read, Update e Delete)** e permite pesquisar por nome de artista ou título de música.

O projeto utiliza **Entity Framework Core** com **SQLite** como banco de dados, **Bootstrap 5** para o layout e **Tag Helpers** para facilitar a criação de links e formulários.

---

## Funcionalidades

* Listar artistas e músicas
* Pesquisar por artistas ou músicas
* Criar novos registros de artistas e músicas
* Editar registros existentes
* Visualizar detalhes de artistas e músicas
* Excluir registros com confirmação
* Layout responsivo usando Bootstrap
* Navegação entre Artistas e Músicas

---

## Estrutura de Pastas

```
Controllers/      -> Contém os controllers ArtistasController e MusicasController
Models/           -> Contém os modelos Artista e Musica
Views/            -> Contém as views para cada controller
wwwroot/          -> Arquivos estáticos (CSS, JS, imagens)
Program.cs        -> Configuração e inicialização da aplicação
appsettings.json  -> Configurações do projeto, como connection string
```

---

## Tecnologias Utilizadas

* ASP.NET Core MVC
* Entity Framework Core (EF Core)
* SQLite
* Bootstrap 5
* C# 11 / .NET 8

---

## Como Executar

1. Clonar o repositório:

```bash
git clone <URL_DO_REPOSITORIO>
```

2. Restaurar pacotes:

```bash
dotnet restore
```

3. Aplicar migrations e criar o banco:

```bash
dotnet ef database update
```

4. Executar a aplicação:

```bash
dotnet run
```

5. Acessar no navegador:

```
http://localhost:5241
```

---

## Observações

* Os botões de "Novo", "Editar", "Detalhes" e "Excluir" utilizam **Tag Helpers**.
* A página inicial não redireciona automaticamente; o usuário pode navegar via menu para **Artistas** ou **Músicas**.
* A exclusão de registros requer confirmação do usuário.
* Pesquisas funcionam pelo campo de busca nas listas de artistas e músicas.

---
