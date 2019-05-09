# Target Product Search API

A product aggregation service that unifies catelog and pricing information.

# Requirements

- Docker

# Basic Usage

Should be as easy as 1..2..3. No seriously.

    docker-compose up

The following endpoint will allow you to fetch aggregated data using a product id. Try out the sample id `13860428`.

    http://localhost:8080/api/products/{id}

The docker-compose.yml file includes three services:
- A MongoDb NoSql database
    - Port: `27017`
- MongoDb Express for viewing document information
    - Url: [http://localhost:7999](http://localhost:7999)
    - Port: `7999`
- An AspNetCore web application
    - Ports: `8080` and `8081` (http and https respectively)