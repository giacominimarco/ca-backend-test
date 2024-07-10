Criação de uma API REST para gerenciar faturamento de clientes.
---------------------
**Tecnologias utilizadas :**
* .NET 7;
* C#;
* Entity Framework Core com banco relacional SQL Server;
* Swagger;
* Manipulação de JSON;
* API REST / CRUD;
* Manipulação de Erros / Exceptions;
----------------------
**Serviços :**
* CRUD de Produtos;
* CRUD de Customers;
* CRUD de Billings;
* Importação de dados a partir de APIs externas para populas as tabelas Billings e BillingLines no DB;
----------------------
**Configurações necessário para executar a aplicação :**
1. Ter o banco de dados SQL Server instalado na maquina;
2. Baixar o repositório do github;
3. Atualizar as strings de conexção com seu BD em appsettings.json;
4. Rodar as migrations;
```
add-migration CreateDB -context ConnectionContext;
update-database;
```
6. Rodar o projeto
7. Chamar a API ImportFirstData para popular os Customers e Products de acordo com o primeiro registro da API esterna;
8. Chamar a API ImportData para inserir o registro do billing e billingLines de acordo com as informações disponivais na primeira API externa;
---------------------
**Lista de API’s :**
* Get https://65c3b12439055e7482c16bca.mockapi.io/api/v1/billing
* Get https://65c3b12439055e7482c16bca.mockapi.io/api/v1/billing/:id
* Post https://65c3b12439055e7482c16bca.mockapi.io/api/v1/billing
* Delete https://65c3b12439055e7482c16bca.mockapi.io/api/v1/billing/:id
* PUT https://65c3b12439055e7482c16bca.mockapi.io/api/v1/billing/:id
---------------------
**Funcionalidades : 🛠️**

* Controle de conferência e importação de billing.
    * Utilizar postman para consulta dos dados da API’s para criação das tabelas de billing e billingLines.
	  * Após consulta, e criação do passo anterior, inserir no banco de dados o primeiro registro do retorno da API de billing para criação de cliente e produto através do swagger ou dataseed.

    * Utilizar as API’s para consumo dos dados a partir da aplicação que está criada e fazer as seguintes verificações:
      * Se o cliente e o produto existirem, inserir o registro do billing e billingLines no DB local.
      * Caso se o cliente existir ou só o produto existir, deve retornar um erro na aplicação informando sobre a criação do registro faltante.
      * Criar exceptions tratando mal funcionamento ou interrupção de serviço quando API estiver fora.

