NAME="Momentum"

hello: 
	@echo "Welcome to ${NAME}"

build_images:
	docker compose build

database:
	docker compose up -d momentum.database

backend:
	docker compose up momentum.backend

client:
	docker compose up momentum.client

build: build_images

run: 
	docker compose up -d momentum.database momentum.backend momentum.client

stop-database:
	docker compose stop momentum.database
	docker compose rm -f momentum.database

stop-backend:
	docker compose stop momentum.backend
	docker compose rm -f momentum.backend

stop-client:
	docker compose stop momentum.client
	docker compose rm -f momentum.client

stop: stop-client stop-backend stop-database

remove_images:
	@docker images | grep "momentum" | awk '{print $$3}' | xargs docker rmi -f

rebuild: stop remove_images build run