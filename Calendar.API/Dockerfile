FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Calendar.API/Calendar.API.csproj", "Calendar.API/"]
RUN dotnet restore "Calendar.API/Calendar.API.csproj"
COPY . .
WORKDIR "/src/Calendar.API"
RUN dotnet build "Calendar.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Calendar.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Calendar.API.dll"]
