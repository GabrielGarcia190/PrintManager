# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar arquivos de solução e projetos primeiro (para cache de layers)
COPY Optima.sln ./
COPY Optima.API/Optima.API.csproj Optima.API/
COPY Optima.Application/Optima.Application.csproj Optima.Application/
COPY Optima.Domain/Optima.Domain.csproj Optima.Domain/
COPY Optima.Infrastructure/Optima.Infrastructure.csproj Optima.Infrastructure/
COPY Optima.Infrastructure.Ioc/Optima.Infrastructure.Ioc.csproj Optima.Infrastructure.Ioc/

# Restaurar dependências
RUN dotnet restore "Optima.API/Optima.API.csproj"

# Copiar todo o código fonte
COPY . .

# Publicar a aplicação
RUN dotnet publish "Optima.API/Optima.API.csproj" -c Release -o /app/publish

# Estágio de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar arquivos publicados
COPY --from=build /app/publish .

# Expor portas
EXPOSE 80
EXPOSE 443

# Definir ponto de entrada
ENTRYPOINT ["dotnet", "Optima.API.dll"]
