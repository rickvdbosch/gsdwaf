FROM mcr.microsoft.com/azure-functions/dotnet:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["BasicDi/BasicDi.csproj", "BasicDi/"]
RUN dotnet restore "BasicDi/BasicDi.csproj"
COPY . .
WORKDIR "/src/BasicDi"
RUN dotnet build "BasicDi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasicDi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV AzureWebJobsScriptRoot=/app