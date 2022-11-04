#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /src
COPY ["saitynai-server.csproj", "."]
RUN dotnet restore "./saitynai-server.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "saitynai-server.csproj" -c Release -o /app/build

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "saitynai-server.dll"]