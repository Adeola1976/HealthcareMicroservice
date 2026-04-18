#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-image
WORKDIR /home/app
COPY src/User/User.API/User.API.csproj ./User.API/ 
COPY src/User/User.Application/User.Application.csproj ./User.Application/ 
COPY src/User/User.Domain/User.Domain.csproj ./User.Domain/ 
COPY src/User/User.Infrastructure/User.Infrastructure.csproj ./User.Infrastructure/ 

RUN dotnet restore "User.API/User.API.csproj"
COPY . . 
RUN dotnet publish src/User/User.API/User.API.csproj -o /publish/ 
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /publish 
COPY --from=build-image /publish . 
ENTRYPOINT ["dotnet", "User.API.dll"]