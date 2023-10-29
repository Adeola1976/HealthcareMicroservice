#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-image
WORKDIR /home/app
COPY ./Hospital.API/Hospital.API.csproj ./Hospital.API/ 
COPY ./Hospital.Application/Hospital.Application.csproj ./Hospital.Application/ 
COPY ./Hospital.Domain/Hospital.Domain.csproj ./Hospital.Domain/ 
COPY ./Hospital.Infrastructure/Hospital.Infrastructure.csproj ./Hospital.Infrastructure/ 

RUN dotnet restore "Hospital.API/Hospital.API.csproj"
COPY . . 
RUN dotnet publish ./Hospital.API/Hospital.API.csproj -o /publish/ 
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /publish 
COPY --from=build-image /publish . 
ENV ASPNETCORE_URLS=https://+:5001;http://+:5000
ENTRYPOINT ["dotnet", "MyFramework.dll"]



