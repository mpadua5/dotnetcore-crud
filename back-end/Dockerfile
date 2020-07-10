FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY ./src/DotnetCoreCrud/*.csproj ./
RUN dotnet restore

COPY src/DotnetCoreCrud/ ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
RUN apt-get update 
RUN apt-get install -y jq curl
RUN rm /etc/localtime \
    && cp /usr/share/zoneinfo/America/Sao_Paulo /etc/localtime \
    && echo "America/Sao_Paulo" > /etc/timezone

COPY --from=build-env /app/out .
EXPOSE 19000
ENTRYPOINT ["dotnet", "DotnetCoreCrud.dll"]