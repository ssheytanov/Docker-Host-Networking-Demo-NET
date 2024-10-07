FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["apis/TmdbCollectorApi/src/TmdbCollectorApi.Web/", "src/TmdbCollectorApi.Web/"]
RUN dotnet restore "./src/TmdbCollectorApi.Web/TmdbCollectorApi.Web.csproj"
#COPY . .
WORKDIR "/src/src/TmdbCollectorApi.Web"
RUN dotnet build "./TmdbCollectorApi.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build


FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TmdbCollectorApi.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TmdbCollectorApi.Web.dll"]