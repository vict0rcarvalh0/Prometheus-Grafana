# Use uma imagem base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 8080

# Copie os arquivos do projeto e restaure as dependências
COPY . .
RUN dotnet restore

# Compile o projeto
RUN dotnet build -c Release -o /app/build

# Publicar a aplicação
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# Executar a aplicação publicada
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenTelemetryProject.dll"]
