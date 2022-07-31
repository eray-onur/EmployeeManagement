#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EmployeeManagement.WebAPI/EmployeeManagement.WebAPI.csproj", "EmployeeManagement.WebAPI/"]
COPY ["EmployeeManagement.Application/EmployeeManagement.Application.csproj", "EmployeeManagement.Application/"]
COPY ["EmployeeManagement.Domain/EmployeeManagement.Domain.csproj", "EmployeeManagement.Domain/"]
COPY ["EmployeeManagement.Persistence/EmployeeManagement.Persistence.Dapper.csproj", "EmployeeManagement.Persistence/"]
RUN dotnet restore "EmployeeManagement.WebAPI/EmployeeManagement.WebAPI.csproj"
COPY . .
WORKDIR "/src/EmployeeManagement.WebAPI"
RUN dotnet build "EmployeeManagement.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmployeeManagement.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeManagement.WebAPI.dll"]