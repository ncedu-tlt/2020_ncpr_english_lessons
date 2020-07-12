FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR Languages.API/

# Copy csproj and restore as distinct layers
COPY Languages.API/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR Languages.API/
COPY --from=build-env Languages.API/out .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Api.dll

# testing
# FROM build AS testing
# WORKDIR Languages.API
# RUN dotnet build
