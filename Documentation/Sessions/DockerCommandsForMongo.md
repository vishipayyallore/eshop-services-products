# Docker Commands for creating MongoDB Docker Container

Reference: [Mongo Db on Docker Hub](https://hub.docker.com/_/mongo?tab=description)

## Retrieving the Docker Image and Creating the Container
```
docker image pull mongo
docker container run -d -p 27017:27017 --name shop-mongo mongo
```

```
docker container ps
docker container logs -f shop-mongo
docker container exec -it shop-mongo /bin/bash
```

## Verify the IP Address of the Container
```
docker container inspect --format '{{ .NetworkSettings.IPAddress }}' <ContainerNameORId>

//WINDOWS ONLY
docker container inspect --format "{{ .NetworkSettings.IPAddress }}" <ContainerNameORId>
```