#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-image
WORKDIR /home/app
COPY src/Hospital/Hospital.API/Hospital.API.csproj ./Hospital.API/ 
COPY src/Hospital/Hospital.Application/Hospital.Application.csproj ./Hospital.Application/ 
COPY src/Hospital/Hospital.Domain/Hospital.Domain.csproj ./Hospital.Domain/ 
COPY src/Hospital/Hospital.Infrastructure/Hospital.Infrastructure.csproj ./Hospital.Infrastructure/ 

RUN dotnet restore "Hospital.API/Hospital.API.csproj"
COPY . . 
RUN dotnet publish src/Hospital/Hospital.API/Hospital.API.csproj -o /publish/ 
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /publish 
COPY --from=build-image /publish . 
ENTRYPOINT ["dotnet", "Hospital.API.dll"]