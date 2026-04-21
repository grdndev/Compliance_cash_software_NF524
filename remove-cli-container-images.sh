
./stop-cli.sh
docker container rm app_cliapi_1 
docker image rm app_cliapi:latest 
docker container rm app_clisyncservice_1 
docker image rm app_clisyncservice:latest 

