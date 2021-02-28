FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY ./src/SimplePoll.Api ./SimplePoll.Api
COPY ./src/SimplePoll.Application ./SimplePoll.Application
COPY ./src/SimplePoll.Domain ./SimplePoll.Domain
COPY ./src/SimplePoll.Infrastructure.DataAccess ./SimplePoll.Infrastructure.DataAccess
COPY ./src/SimplePoll.Infrastructure.Identity ./SimplePoll.Infrastructure.Identity

WORKDIR /src/SimplePoll.Api
RUN dotnet restore

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=build /src/SimplePoll.Api/out ./

ENTRYPOINT ["dotnet", "SimplePoll.Api.dll"]