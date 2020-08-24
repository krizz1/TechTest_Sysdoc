install:
	cd client && npm install

start-client:
	cd client && npm run start

api-migrations:
	dotnet ef database update -p api/TestApi/TestApi

start-api:
	dotnet run -p api/TestApi/TestApi

.PHONY: install start-client start-api