FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN mkdir /shall
COPY ./shall/*.sh ./shall/

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SmartHouseHub.API/SmartHouseHub.API.csproj", "SmartHouseHub.API/"]
COPY ["ZWaveLib/ZWaveLib.csproj", "ZWaveLibZWaveLib/"]
RUN dotnet restore "SmartHouseHub.API/SmartHouseHub.API.csproj"
COPY . .
WORKDIR "/src/SmartHouseHub.API"
RUN dotnet build "SmartHouseHub.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmartHouseHub.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartHouseHub.API.dll"]