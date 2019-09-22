FROM microsoft/dotnet:2.2-aspnetcore-runtime as base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk as build
WORKDIR /src
COPY ["CapitalChurch.Address.Shared.Contracts/CapitalChurch.Address.Shared.Contracts.csproj", "CapitalChurch.Address.Shared.Contracts/"]
COPY ["CapitalChurch.Address.Shared/CapitalChurch.Address.Shared.csproj", "CapitalChurch.Address.Shared/"]
COPY ["CapitalChurch.Address.Domain/CapitalChurch.Address.Domain.csproj", "CapitalChurch.Address.Domain/"]
COPY ["CapitalChurch.Address.Data/CapitalChurch.Address.Data.csproj", "CapitalChurch.Address.Data/"]
COPY ["CapitalChurch.Address.Business/CapitalChurch.Address.Business.csproj", "CapitalChurch.Address.Business/"]
COPY ["CapitalChurch.Address.WebApi/CapitalChurch.Address.WebApi.csproj", "CapitalChurch.Address.WebApi/"]

RUN dotnet restore "./CapitalChurch.Address.WebApi/CapitalChurch.Address.WebApi.csproj"
COPY . .
WORKDIR /src
RUN dotnet build "./CapitalChurch.Address.WebApi/CapitalChurch.Address.WebApi.csproj" -c Debug -o /app

FROM build as publish
RUN dotnet publish "./CapitalChurch.Address.WebApi/CapitalChurch.Address.WebApi.csproj" -c Debug -o /app

FROM base as final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "./CapitalChurch.Address.WebApi.dll"]