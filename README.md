# Target Product Search API

A product aggregation service that unifies catelog and pricing information.

# Requirements

- Docker

# Usage

## Secrets

1. Navigate to `src/Services/Infinitylabs.Target.ProductSearch.Api/`
1. Create a new file titled `secrets.json` and replace `xxx` with the RedSky API key:
```
{
  "auth": {
    "RedSkyApiKey": "xxx"
  }
}
```

## Running

1. Navigate to the root project directory where the `docker-compose.yml` file is located.
1. Run the `docker-compose up` command.

The following endpoint will allow you to fetch aggregated data using a product id. Try out the sample id `13860428`.

    http://localhost:8080/api/products/{id}

`Not all TCINs are seeded in the DB. See 'PricingSeeder.cs'`

You may also PUT updated pricing information in the MongoDB by changing the HTTP method above from GET to PUT.
The body will be JSON and will replace the document stored in Mongo. JSON scheme below:

    {
        "currencyCode": "CurrencyCodeEnum",
        "value": "decimal",
        "id": "integer"
    }

The docker-compose.yml file includes three services:
- A MongoDb NoSql database
    - Port: `27017`
- MongoDb Express for viewing document information
    - Url: [http://localhost:7999](http://localhost:7999)
    - Port: `7999`
- An AspNetCore web application
    - Sample Url: [http://localhost:8080/api/products/13860428](http://localhost:8080/api/products/13860428)
    - Ports: `8080` and `8081` (http and https respectively)