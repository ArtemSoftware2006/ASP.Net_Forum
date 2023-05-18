#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ASP.Net_Forum/ASP.Net_Forum.csproj", "ASP.Net_Forum/"]
COPY ["ASP.Net_Forum.DAL/ASP.Net_Forum.DAL.csproj", "ASP.Net_Forum.DAL/"]
COPY ["ASP.Net_Forum.Domain/ASP.Net_Forum.Domain.csproj", "ASP.Net_Forum.Domain/"]
COPY ["Servises/ASP.Net_Forum.Service.csproj", "Servises/"]
RUN dotnet restore "ASP.Net_Forum/ASP.Net_Forum.csproj"
COPY . .
WORKDIR "/src/ASP.Net_Forum"
RUN dotnet build "ASP.Net_Forum.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ASP.Net_Forum.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ASP.Net_Forum.dll"]