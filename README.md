# Tech Lead coding exercise - Sysdoc Product Hub

Change management programmes design and execute the communications and interactions an organisation has with employees whilst going through a change program. A change program could be anything from implementing a new enterprise wide IT system to changing employee work hours.

Many change management programmes are managed using spreadsheets. The goal of Flight Path is to remove those spreadsheets and create dynamic realtime data which allows organisations to both manage their projects and roll up their data to provide stakeholders with an organisational view of changes occuring in the business.

This demo repo provides you with:

- setup instructions for a SQL Server Docker container.
- a .Net 3.1 solution which contains the initial state of the application, including:
  - Entities for two data types - cxr Projects and Actions.
  - Migrations to create and populate the tables.
  - a single api endpoint to check that the API solution is working.
- a basic frontend client bootstrapped using Create React App with the Typescript template.
- a Makefile with some basic commands to get you up and running quickly.

## Instructions

Clone this repo and create a new branch from `master` for each task. Once a task is complete please push your commits and open a pull request then move onto the next task on a new branch and repeat.

## Prerequisities

- [Docker](https://www.docker.com/products/overview)
- [Node/NPM](https://nodejs.org/en/)
- [Dotnet 3](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- [Make](http://gnuwin32.sourceforge.net/packages/make.htm) (if using Windows)
- SQL Server (if not using Docker)

## Commands

NB: All commands execute from the root of the project

You can either create a database locally on your machine or using a docker container following the below commands. If you use a local database then you will need to change the connection strings for your database connection

### Creating the database using Docker

Start the docker container

```zsh
# Downloads a SQL server image and runs a container with a volume at the specified directory
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=MyPassword001" -p 1433:1433 --name sqlserver-test -d mcr.microsoft.com/mssql/server:2019-latest
```

create a database, to enter the containers integrated terminal run

```zsh
docker container exec -it sqlserver-test bash
```

and then connect to SQL Server with

```zsh
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P MyPassword001
```

once connected to SQL, run the following commands to create the database

```sql
CREATE DATABASE TestAppDb
GO
EXIT
```

Finally, you will need to install the EF Core CLI on your local machine if you do not already have it installed

```sql
dotnet tool install --global dotnet-ef
```

---

### Start the application
You can manually run all the makefile commands if you do not have make installed. All run commands can be found in the Makefile in the repository root.

#### Run API Migrations & Seed DB

```zsh
make api-migrations
```

#### Start API (if not using any IDE)

```zsh
make start-api
```

#### Install client dependencies

```zsh
make install
```

#### Start Client

```zsh
make start-client
```

---

For the following tasks please provide a solution to best of your ability, taking into account perforamance, best practices and scalability

### Task 1
Currently the projects and the actions do not have a relationship between them. Please add a many to many relationship between the projects and the actions so that an action can have multiple projects, and a project can have multiple actions. Then create a migration for the changes you implemented and update your database.

### Task 2

#### Part 1 - GET

Design and implement a RESTful JSON API endpoint for projects - this endpoint should return any relevant project metadata and a list of actions for the project.

Design and implement a RESTful JSON API endpoint for actions - this endpoint should return any relevant action metadata and the number of projects it belongs to.

#### Part 2 - PATCH

Design and implement a RESTful JSON API endpoint for projects that will let the user assign an already created action to a project that already exists

#### Notes

_We have purposefully not provided any design for the endpoints structure and are interested in your take on the design and implementation of the endpoints._

**Please note:** _We're not expecting you to add an endpoint to create actions or create projects - feel free to just assign actions we've created to projects we've created_

### Task 3

Implement a basic frontend application which fulfils the following user stories:

#### Part 1 - Navigation

##### Story 1

- As a **user running the application**
- I want to **be able to navigate between the projects and actions index pages from anywhere**
- So that I can **view a list of projects or actions as needed**

#### Part 2 - Projects

##### Story 1

- As a **user running the application**
- I want to **visit a page with a list of all projects and their metadata**
- So that I can **select a project to view more information**

##### Story 2

- As a **user running the application**
- I want to **see a list of all actions associated to a project when I select one**
- So that I can **view actions and their metadata related to that project**

##### Story 3

- As a **user running the application**
- I want to **see an 'Add New Action' button next to each project**
- So that I can **add an already existing action to a project**

#### Part 3 - Actions

##### Story 1

- As a **user running the application**
- I want to **visit a page showing all actions, including their metadata**
- So that I can **view the number of projects they belong to**

#### Notes

_We are not assessing your design or CSS capabilities and don't mind what the application looks like but please make sure it's legible and has a relatively clean layout._

_You can use any third party libraries you want when implementing the above - we will ask you to justify why you chose a specific library though!_

_We are interested in how you structure the project, how you implement data fetching and the code design decisions you make._