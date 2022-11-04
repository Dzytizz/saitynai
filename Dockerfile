# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build-env
WORKDIR /saitynai-server
    
# Copy csproj and restore as distinct layers
COPY saitynai-server/*.csproj .
RUN dotnet restore -r linux-musl-x64 /p:PublishReadyToRun=true
    
# Copy everything else and build
COPY saitynai-server/. .
RUN dotnet publish -c Release -o /app -r linux-musl-x64 --self-contained true --no-restore /p:PublishReadyToRun=true /p:PublishSingleFile=true

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime-deps:6.0-alpine-amd64
WORKDIR /app
COPY --from=build-env /app .
ENTRYPOINT ["./saitynai-server"]

ENV \
     DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false \
     LC_ALL=en_US.UTF-8 \
     LANG=en_US.UTF-8
 RUN apk add --no-cache \
     icu-data-full \
     icu-libs