# BestRoute

É um projeto construído em C# utilizando .net core 3.1 para resolução do problema:

## Cénario ##

### Rota de Viagem ###

Um turista deseja viajar pelo mundo pagando o menor preço possível independentemente do número de conexões necessárias.
Vamos construir um programa que facilite ao nosso turista, escolher a melhor rota para sua viagem.

Para isso precisamos inserir as rotas através de um arquivo de entrada.

#### Input Example #####
```csv
GRU,BRC,10
BRC,SCL,5
GRU,CDG,75
GRU,SCL,20
GRU,ORL,56
ORL,CDG,5
SCL,ORL,20
```

#### Explicando #### 
Caso desejemos viajar de **GRU** para **CDG** existem as seguintes rotas:

1. GRU - BRC - SCL - ORL - CDG ao custo de **$40**
2. GRU - ORL - CGD ao custo de **$64**
3. GRU - CDG ao custo de **$75**
4. GRU - SCL - ORL - CDG ao custo de **$45**

O melhor preço é da rota **4** logo, o output da consulta deve ser **GRU - BRC - SCL - ORL - CDG**.


## Instalação

É necessário ter o **dotnet CLI** instalado na versão 3.1.0 ou superior. Para instalação só seguir os passo [clicando aqui](https://dotnet.microsoft.com/download "download dotnet CLI").``


## Uso

Na raiz do repositório você irá a seguinte estrutura de diretórios e arquivos:
```
|-- README.md
|-- docs
|   |-- README.md
|   `-- input-routes.csv
|-- src
|   |-- core
|   |   `-- BestRoute.Core
|   |       |-- BestRoute.Core.csproj          
|   |       |-- business
|   |       |   |-- IShortestPathFinder.cs
|   |       |   `-- impl
|   |       |       `-- algorithms
|   |       |           |-- Dijkstra.cs
|   |       |           |-- FlightPlan.cs
|   |       |           `-- ScalePrice.cs
|   |       |-- exceptions
|   |       |   `-- AirportsFromOrToNotExist.cs
|   |       |-- models
|   |       |   |-- Airport.cs
|   |       |   |-- BestRouteInfo.cs
|   |       |   |-- ConnectionInfo.cs
|   |       |   `-- Route.cs
|   |       |-- repository
|   |       |   |-- IAirportRepository.cs
|   |       |   |-- IRouteRepository.cs
|   |       |   `-- impl
|   |       |       |-- AirportRepository.cs
|   |       |       `-- RouteRepository.cs
|   |       `-- services
|   |           |-- IBestRouteServices.cs
|   |           `-- impl
|   |               `-- BestRouteService.cs
|   `-- output-console
|       `-- BestRoute.OutputConsole
|           |-- BestRoute.OutputConsole.csproj
|           |-- Program.cs
|           |-- input-routes.csv      
```
Para rodar o projeto console, basta ao entrar no diretório do projeto é executar e executar o comando:
```
dotnet run -- input-routes.csv
```
Usamos o comando **dotnet run** para rodar o projeto e o opcional **--** é para informar o argumento **input-routes.csv** que é nome do arquivo de input com as rotas.


## Contributing
Pull requests são bem-vindas.

## License
[MIT](https://choosealicense.com/licenses/mit/)
