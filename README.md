# BUILD THE DOCKER IMAGE
# docker build -t RestApi

# RUN THE DOCKER CONTAINER
# docker run -d -p 5159:80 --name RestApiContainer RestApi

# RUNNING THE DOCKER CONTAINER WITH DOCKER COMPOSE

# 1. Build the image
docker-compose build

# 2. Run the container
docker-compose up
