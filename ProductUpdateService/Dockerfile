FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ProductUpdateService/ProductUpdateService.csproj", "ProductUpdateService/"]
COPY ["DbRepository/DbRepository.csproj", "DbRepository/"]
RUN dotnet restore "ProductUpdateService/ProductUpdateService.csproj"
COPY . .
WORKDIR "/src/ProductUpdateService"
RUN dotnet build "ProductUpdateService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ProductUpdateService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProductUpdateService.dll"]
