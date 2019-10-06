# Address - Capital Church

In this is the endpoints for addresses information

## Overview

To see the endpoints just open [swagger page](http://3eb26e7f-7d77-48d7-ae18-c21d166995ad.pub.cloud.scaleway.com/endereco/swagger)  

### Prerequisites

To run this project you will need

* [Docker](https://www.docker.com/) - Run Database(Postgres)
* [Dotnet](https://dotnet.microsoft.com/) - C# source code

### Get Started

After source code cloned; To start project on you machine, just follow these steps

Setup database and last api version

```
docker-compose up --build -d
```

You can see the results on 

* [Result Success](http://localhost:8085/swagger) - http://localhost:8085/swagger

## Running the tests

Running tests

```
dotnet test ./CapitalChurch.Address.IntegrationTests
```

## Deployment

Deployment occurs automatic when publish to Development or Master branch
  
* [Development branch](https://github.com/capitalChurch/CapitalChurch.Address/tree/development) => [Quality Environment](http://3eb26e7f-7d77-48d7-ae18-c21d166995ad.pub.cloud.scaleway.com/endereco/swagger)

## Built With

* [Dotnet](https://dotnet.microsoft.com/) - The web framework used
* [Swagger](https://swagger.io/) - Endpoint discovery
* [Postgres](https://www.postgresql.org/) - Used to store data
* [Postgis](https://postgis.net/) - Used to measure distances
* [Docker](https://www.docker.com/) - To help setup environments
