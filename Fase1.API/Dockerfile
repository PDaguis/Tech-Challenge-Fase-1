FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base

WORKDIR /app

EXPOSE 3000
EXPOSE 3001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Fase1.API/Fase1.API.csproj", "Fase1.API/"]
COPY ["Fase1.Infra/Fase1.Infra.csproj", "Fase1.Infra/"]
COPY ["Fase1.Core/Fase1.Core.csproj", "Fase1.Core/"]

RUN dotnet restore "Fase1.API/Fase1.API.csproj"

COPY . .

WORKDIR "/src/Fase1.API"

RUN dotnet build "Fase1.API.csproj" -c Release -o /app/build

FROM build AS publish
# ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Fase1.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "Fase1.API.dll" ]