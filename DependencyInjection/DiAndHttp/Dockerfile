FROM mcr.microsoft.com/azure-functions/dotnet:2.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["DiAndHttp/DiAndHttp.csproj", "DiAndHttp/"]
RUN dotnet restore "DiAndHttp/DiAndHttp.csproj"
COPY . .
WORKDIR "/src/DiAndHttp"
RUN dotnet build "DiAndHttp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DiAndHttp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV AzureWebJobsScriptRoot=/app