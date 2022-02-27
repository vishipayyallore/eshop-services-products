#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Source/Products.API/Products.API.csproj", "Source/Products.API/"]
COPY ["Source/Products.Infrastructure/Products.Infrastructure.csproj", "Source/Products.Infrastructure/"]
COPY ["Source/Products.Data/Products.Data.csproj", "Source/Products.Data/"]
COPY ["Source/Products.Core/Products.Core.csproj", "Source/Products.Core/"]
COPY ["Source/Products.Repository/Products.Repository.csproj", "Source/Products.Repository/"]
RUN dotnet restore "Source/Products.API/Products.API.csproj"
COPY . .
WORKDIR "/src/Source/Products.API"
RUN dotnet build "Products.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Products.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Products.API.dll"]
