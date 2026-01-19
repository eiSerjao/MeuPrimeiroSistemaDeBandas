# 🎧🎸 Screen Sound

**Screen Sound** é um sistema de gerenciamento de **bandas e podcasts**, desenvolvido em **C# (.NET 9.0)** e executado em **console**.
O projeto tem como objetivo praticar **Programação Orientada a Objetos**, estruturas de dados e lógica de negócio por meio de uma interface interativa baseada em menus.

---

## 📋 Visão Geral

O sistema permite ao usuário:

* Gerenciar bandas, álbuns, músicas e gêneros musicais
* Avaliar bandas e calcular médias de notas
* Visualizar discografias completas com duração total
* Gerenciar podcasts, episódios e convidados

Tudo isso utilizando boas práticas de organização de código e uma arquitetura modular.

---

## 🏗️ Arquitetura do Projeto

O projeto segue uma estrutura organizada em camadas:

### 📁 Dominio/ — Entidades do Negócio

Contém as classes que representam o modelo da aplicação:

* **Banda.cs**: Representa uma banda musical com nome e coleção de álbuns
* **Album.cs**: Representa um álbum com músicas e cálculo de duração total
* **Musica.cs**: Representa uma música com duração, disponibilidade e gênero
* **Genero.cs**: Representa um gênero musical
* **Podcast.cs**: Representa um podcast com nome, host e episódios
* **Episodio.cs**: Representa um episódio de podcast com convidados

---

### 📁 Infraestrutura/ — Persistência de Dados

* **BandasRegistradas.cs**

  * Gerencia o cadastro de bandas e gêneros
  * Avaliação de bandas
  * Cálculo de médias de notas
  * Recuperação de dados

* **PodcastsRegistrados.cs**

  * Gerencia o cadastro de podcasts
  * Busca e exibição de episódios

---

### 📄 Program.cs — Orquestração da Aplicação

Responsável por:

* Menus interativos (navegação com `switch-case`)
* Cadastro de bandas, álbuns, músicas, gêneros e podcasts
* Consultas e exibição de dados
* Dados iniciais (mock data)
* Métodos utilitários (conversão de tempo, exibição de logo)

---

## 💡 Funcionalidades Principais

### 🎸 Gerenciamento de Bandas

* Registrar novas bandas
* Listar bandas cadastradas
* Avaliar bandas (notas de 0 a 10)
* Calcular média de avaliações

### 💿 Gerenciamento de Álbuns e Músicas

* Adicionar álbuns às bandas
* Registrar músicas com duração (minutos:segundos)
* Associar músicas a álbuns
* Visualizar discografia completa
* Exibir músicas de um álbum específico

### 🎼 Gerenciamento de Gêneros

* Registrar novos gêneros musicais
* Associar gêneros às músicas

### 🎙️ Gerenciamento de Podcasts

* Registrar podcasts com nome e host
* Adicionar episódios com número, título e duração
* Adicionar convidados aos episódios
* Exibir episódios ordenados por número

---

## 🔑 Estruturas de Dados Utilizadas

| Estrutura                                | Uso                      |
| ---------------------------------------- | ------------------------ |
| `Dictionary<string, (Banda, List<int>)>` | Bandas e suas avaliações |
| `Dictionary<string, Genero>`             | Gêneros musicais         |
| `Dictionary<string, Podcast>`            | Podcasts cadastrados     |
| `List<Album>`                            | Álbuns por banda         |
| `List<Musica>`                           | Músicas por álbum        |
| `List<Episodio>`                         | Episódios por podcast    |

---

## 📊 Dados Mock Pré-carregados

O sistema inicia com dados de exemplo para testes:

* **The Beatles** — Álbum *Abbey Road*
* **Pink Floyd** — Álbum *The Dark Side of the Moon*
* **Oficina G3** — Álbum *Depois da Guerra*
* **Podcast do Paulo** — 2 episódios
* **Hipsters Ponto Tech** — 1 episódio

---

## 🛠️ Tecnologias Utilizadas

* **Linguagem:** C# 12.0
* **Framework:** .NET 9.0
* **Interface:** Console Application
* **Paradigma:** Programação Orientada a Objetos

---

## 🧠 Conceitos Praticados

* ✅ Classes e Objetos
* ✅ Propriedades (`get` / `set`)
* ✅ Construtores
* ✅ Métodos
* ✅ Listas e Dicionários
* ✅ Tuplas
* ✅ Validação de Entrada
* ✅ LINQ (`OrderBy`, `Average`, `Sum`)
* ✅ Menus Interativos
* ✅ Tratamento de Exceções

---

## 🚧 Próximos Passos

Como evolução natural do projeto, o próximo passo será a **integração com um banco de dados relacional**, visando tornar o sistema mais próximo de um cenário real de aplicação.

### 🔜 Planejamento Futuro

* Persistir dados de bandas, álbuns, músicas e podcasts em banco de dados
* Substituir dados mock por dados persistentes
* Aplicar conceitos de:

  * Modelagem relacional
  * CRUD (Create, Read, Update, Delete)
  * Separação entre domínio e persistência
* Possível uso de:

  * Entity Framework Core
  * SQL Server ou SQLite

Essa etapa permitirá aprofundar conhecimentos em **arquitetura de software**, **persistência de dados** e **aplicações escaláveis em C#**.

---

## ▶️ Como Executar

1. Clone o repositório:

```bash
git clone https://github.com/eiSerjao/MeuPrimeiroSistemaDeBandas.git
```

2. Acesse a pasta do projeto:

```bash
cd MeuPrimeiroSistemaDeBandas
```

3. Execute a aplicação:

```bash
dotnet run
```

---

## 📌 Requisitos

* .NET SDK 9.0 ou superior instalado

---

🚀 **Projeto desenvolvido para fins educacionais e evolução prática em C# e POO.**
