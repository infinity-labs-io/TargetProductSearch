FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine as build
WORKDIR /src

COPY . .

RUN dotnet publish src/Services/InfinityLabs.Target.ProductSearch.Api/InfinityLabs.Target.ProductSearch.Api.csproj -c Release -o /build

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine
WORKDIR /app
COPY --from=build /build .
ENTRYPOINT [ "dotnet", "InfinityLabs.Target.ProductSearch.Api.dll" ]