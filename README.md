# Opea
Teste para Tech Lead .NET na Opea

## Arquitetura

Toda a aplicação foi desenvolvida utilizando ASP.NET Core 6 com padrão de projetos DDD. Optei pela Segunda Opção, MVC Core, utilizando o conceito de ViewModel, validações com Data Annotations e utilizrei a requisição para popular os Combobox de Porte da Empresa com JQuery e Ajax.

## Domínio da Aplicação

Todo o modelo de banco de dados da aplicação foi implementado conforme as especificações. Sendo assim foi criando uma tabela Client com os dados solicitados. O modelo Porte da Empresa foi implementado como um Enumerador, pois se trata de um objeto imutável, assim se adaptando ao padrão DDD.

O SQL Server foi utilizando conforme solicitado para a criação do banco de dados, o mapeamento objeto-relacional foi realizado com o Entity Framework e as queries de consulta utlizando o SqlConnection com o Dapper, que contem uma abstração do SqlCommand, portanto atendendo as solicitações da aplicação.

## Ambiente

Para criar o ambiente da aplicação será necessário utilizar o Microsoft Visual Studio e o SQL Server.

### Docker
Acesse o link abaixo para baixar as seguintes imagens do docker:
* https://hub.docker.com/_/microsoft-mssql-server

Em seguida execute o seguintes comandos:
```
CMD> docker pull mcr.microsoft.com/mssql/server
```
Após a execução dos comandos acima, basta inicializar os container das imagens com os comandos:
```
CMD> docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Str0ngPa$$w0rd" -p 1433:1433 -d mcr.microsoft.com/mssql/server
```
* Para MacOs com arquitetura AMR64, utiliza o Azure-SQL-Edge ao invés do MSSQL
```
CLI> docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=Str0ngPa$$w0rd' -p 1433:1433 -d mcr.microsoft.com/azure-sql-edge
```
### Banco de Dados
Para a criação do banco de dados e tabela, entre no Gerenciador de Pacotes Nuget e selecione o projeto "Opea.Infrastructure.Data" e execute o seguinte comando:
```
PM> Update-Database
```
* Para MasOs/Linux,ir até o diretório "Opea.Infrastructure.Data" e executar o seguinte comando:
```
CLI> dotnet ef database update
```
Para acessar o SQL Server no client, utilize as seguintes credenciais:
```
Server: localhost
User: sa
Password: Str0ngPa$$w0rd
```
### Aplicação
Com todo o ambiente criado, agora basta iniciar a aplicação no Visual Studio!
