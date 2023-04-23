#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TransactionManagement.Web/TransactionManagement.Web.csproj", "TransactionManagement.Web/"]
COPY ["TransactionManagement.BLL/TransactionManagement.BLL.csproj", "TransactionManagement.BLL/"]
COPY ["TransactionManagement.DAL/TransactionManagement.DAL.csproj", "TransactionManagement.DAL/"]
RUN dotnet restore "TransactionManagement.Web/TransactionManagement.Web.csproj"
COPY . .
WORKDIR "/src/TransactionManagement.Web"
RUN dotnet build "TransactionManagement.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TransactionManagement.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TransactionManagement.Web.dll"]