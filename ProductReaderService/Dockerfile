FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ProductReaderService/ProductReaderService.csproj", "ProductReaderService/"]
COPY ["DbRepository/DbRepository.csproj", "DbRepository/"]
RUN dotnet restore "ProductReaderService/ProductReaderService.csproj"
COPY . .
WORKDIR "/src/ProductReaderService"
RUN dotnet build "ProductReaderService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ProductReaderService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProductReaderService.dll"]
