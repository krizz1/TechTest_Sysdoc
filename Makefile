install:
	npm install --prefix ./client

start-client:
	npm run start --prefix ./client

start-api:
	dotnet run -p api/TestApi/TestApi

.PHONY: install start-client start-api