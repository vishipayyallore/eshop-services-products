# Docker Commands for creating MongoDB Docker Container

Reference: [Mongo Db on Docker Hub](https://hub.docker.com/_/mongo?tab=description)

## Retrieving the Docker Image and Creating the Container

```
docker image pull mongo
docker container run -d -p 27017:27017 --name shop-mongo mongo
```

## Verify the IP Address of the Container

```
docker container inspect --format '{{ .NetworkSettings.IPAddress }}' <ContainerNameORId>

//WINDOWS ONLY
docker container inspect --format "{{ .NetworkSettings.IPAddress }}" <ContainerNameORId>
```

![Deploy Mongo Db as Container |150x150](../Images/S3_CreateMongoContainer.PNG)

## Verify the Container is executing, its logs

```
docker container ps
docker container logs -f shop-mongo
```

![Mongo Db Container Logs |150x150](../Images/S3_MongoContainerLogs.PNG)

## Entering into the Mongo Db Container

```
docker container exec -it shop-mongo /bin/bash
```

![Mongo Db Container Logs |150x150](../Images/S3_Inside_MongoDbContainer.PNG)

## Introduction to Mongo CLI

Reference: [MongoDb CLI](https://www.mongodb.com/docs/v4.4/mongo/)

```
mongo
db
show dbs
```

![Mongo Db Container Logs |150x150](../Images/S3_MongoCli.PNG)

## Creating a Database and Collection

```
use productsDb;
db.createCollection('Products');
```

![Creating Products Db and Collections |150x150](../Images/S3_Creating_Products_Db_and_Collections.PNG)

![Mongo Db's Docker Volume |150x150](../Images/S3_Docker_Volume.PNG)

## Delete existing Container and re-create

> 1. In this demo, we will delete the existing container and re-create it.
> 1. Also, the previously create database and collection will be deleted.

```
docker container rm -f shop-mongo
docker container run -d -p 27017:27017 --name shop-mongo mongo
docker container ps -a
docker exec -it shop-mongo /bin/bash
```

![Re-creating Docker Container |150x150](../Images/S3_Recreating_MongoDbContainer.PNG)

