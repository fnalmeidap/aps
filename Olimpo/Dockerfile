#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ENV ASPNETCORE_URLS=http://127.0.0.1:5000
WORKDIR /src
COPY ["Olimpo.csproj", "."]
RUN dotnet restore "./Olimpo.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Olimpo.csproj" -c Release -o /app/build

FROM build AS publish
ENV ASPNETCORE_URLS=http://127.0.0.1:5000
RUN dotnet publish "Olimpo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
ENV ASPNETCORE_URLS=http://127.0.0.1:5000
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Olimpo.dll"]