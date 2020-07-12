# NuGet restore
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY Languages.API/*.sln .
COPY Languages.API/*.csproj .
RUN dotnet restore
COPY . .

# testing
FROM build AS testing
WORKDIR /src/Languages.API
RUN dotnet build

# publish
FROM build AS publish
WORKDIR /src/Languages.API
RUN dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
# ENTRYPOINT ["dotnet", "Languages.API.dll"]
# heroku uses the following
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Languages.API.dll