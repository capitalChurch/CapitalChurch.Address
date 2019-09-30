# Address - Capital Church

In this is the endpoints for addresses information

## Getting Started

This is a .net core project with swagger. To see the endpoints just [open](http://capitalchurch-address-qa.sa-east-1.elasticbeanstalk.com/swagger) swagger

### Prerequisites

To run this project you will need

* [Docker](https://www.docker.com/) - To simulate production environment
* [Dotnet](https://dotnet.microsoft.com/) - To run C# source code

### Installing

After source code cloned; To start project on you machine, just follow these steps

Setup database

```
docker-compose -f./database/docker-compose.yml up --build -d
```

After that you can try connect to Postgres local database created by docker

With:
* User - address
* Password - 12345678
* Database - capitalChurch
* Host - Localhost
* Port - 5455

```
psql "postgresql://address:12345678@localhost:5455/capitalChurch"
```

Running project

```
dotnet run --project ./CapitalChurch.Address.WebApi
```

And See endpoints on your browser

* [Result Success](http://localhost:5000/swagger) - http://localhost:5000/swagger

## Running the tests

Running tests

```
dotnet test ./CapitalChurch.Address.IntegrationTests
```

<!--
### Break down into end to end tests

Explain what these tests test and why

```
Give an example
```

### And coding style tests

Explain what these tests test and why

```
Give an example
```

-->
## Deployment

Deployment occurs automatic when publish to Quality Branch(Quality environment) and Master Branch(Production environment)

## Built With

* [Dotnet](https://dotnet.microsoft.com/) - The web framework used
* [Swagger](https://swagger.io/) - Endpoint discovery
* [Postgres](https://www.postgresql.org/) - Used to store data
* [Postgis](https://postgis.net/) - Used to measure distances
* [Docker](https://www.docker.com/) - To help setup environments

<!--
## Contributing

Please read [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/your/project/tags). 

## Authors

* **Billie Thompson** - *Initial work* - [PurpleBooth](https://github.com/PurpleBooth)

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Hat tip to anyone whose code was used
* Inspiration
* etc
-->