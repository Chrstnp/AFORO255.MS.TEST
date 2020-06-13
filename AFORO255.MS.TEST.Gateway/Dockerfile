#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT docker
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["AFORO255.MS.TEST.Gateway/AFORO255.MS.TEST.Gateway.csproj", "AFORO255.MS.TEST.Gateway/"]
RUN dotnet restore "AFORO255.MS.TEST.Gateway/AFORO255.MS.TEST.Gateway.csproj"
COPY . .
WORKDIR "/src/AFORO255.MS.TEST.Gateway"
RUN dotnet build "AFORO255.MS.TEST.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AFORO255.MS.TEST.Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AFORO255.MS.TEST.Gateway.dll"]