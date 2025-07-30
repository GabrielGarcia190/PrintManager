# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ProjetoTeste.csproj", "ProjetoTeste/"]
RUN dotnet restore "ProjetoTeste.csproj"
COPY . .
RUN dotnet publish "rojetoTeste.csproj" -c Release -o /app/publish

# Estágio de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "ProjetoTeste.dll"]