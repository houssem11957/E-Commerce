# Erp-api-v5 Docker


[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](http://forthebadge.com)

PSZ ERP New Architecture Repository including the docker images reposiotry and compose YML file. 


*docker demon needed to run the scripts*

# How to use this Repo
- Build the docker  images (same directory as docker compose file)

```sh
docker compose build 
```
- Login to the Gitlab registery  (use gitlab credentials)

```sh
docker login registry.gitlab.com
```
- push the docker images to the Gitlab registery  

```sh
docker compose push
```

- pull the docker images from the Gitlab registery  

```sh
docker compose pull 
```




PSZ-DEV TM 2022 
