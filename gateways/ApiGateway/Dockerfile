FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

RUN apt-get update \
    && apt-get install -y curl jq

USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["gateways/ApiGateway/src/ApiGateway.Web/", "src/ApiGateway.Web/"]
RUN dotnet restore "./src/ApiGateway.Web/ApiGateway.Web.csproj"

WORKDIR "/src/src/ApiGateway.Web"
RUN dotnet build "./ApiGateway.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build


FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ApiGateway.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiGateway.Web.dll"]