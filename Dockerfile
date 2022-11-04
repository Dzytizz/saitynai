# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /saitynai-server
    
# Copy csproj and restore as distinct layers
COPY saitynai-server/*.csproj .
RUN dotnet restore
    
# Copy everything else and build
COPY saitynai-server/. .
RUN dotnet publish -c Release -o out 

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /saitynai-server
COPY --from=build-env /saitynai-server/out .
ENTRYPOINT ["dotnet", "saitynai-server.dll"]