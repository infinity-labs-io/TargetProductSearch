FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine as build
WORKDIR /src

COPY . .

RUN dotnet publish src/Services/Infinitylabs.Target.ProductSearch.Api/Infinitylabs.Target.ProductSearch.Api.csproj -c Release -o /build

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
WORKDIR /app
COPY --from=build /build .
ENTRYPOINT [ "dotnet", "Infinitylabs.Target.ProductSearch.Api.dll" ]