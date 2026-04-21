FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CLISyncService.csproj", "CLISyncService/"]
RUN dotnet restore "CLISyncService.csproj"
COPY . .
WORKDIR "/src/CLISyncService"
RUN dotnet build "CLISyncService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CLISyncService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CLISyncService.dll"]