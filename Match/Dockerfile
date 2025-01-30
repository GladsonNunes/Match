FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app

# Etapa 1: Usar a imagem com o SDK do .NET (necessário para build e migrations)
FROM base AS build
WORKDIR /src



# Copiar os arquivos de projeto para o container
COPY ["Match.Api/Match.Api.csproj", "Match.Api/"]
COPY ["Match.Application/Match.Application.csproj", "Match.Application/"]
COPY ["Match.Domain/Match.Domain.csproj", "Match.Domain/"]
COPY ["Match.Infrastructure/Match.Infrastructure.csproj", "Match.Infrastructure/"]

# Restaurar dependências
RUN dotnet restore "Match.Api/Match.Api.csproj"

# Instalar a ferramenta dotnet-ef
RUN dotnet tool install --global dotnet-ef



# Copiar o restante dos arquivos
COPY . .


# Etapa 2: Compilar a aplicação
WORKDIR "/src/Match.Api"
RUN dotnet build "Match.Api.csproj" -c Release -o /app/build

# Etapa 3: Publicar a aplicação
FROM build AS publish
RUN dotnet publish "Match.Api.csproj" -c Release -o /app/publish


# Etapa 4: Usar a imagem base para rodar a aplicação (apenas o runtime)
FROM base AS final
WORKDIR /app

# Copiar a aplicação publicada do container anterior
COPY --from=publish /app/publish .



# Iniciar a aplicação
ENTRYPOINT ["dotnet", "Match.Api.dll"]


