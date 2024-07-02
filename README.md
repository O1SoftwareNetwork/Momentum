<h1 align="center"> MOMENTUM <br/> </h1>
<p align="center">A great mix of hosting your property, visit a place and discover nearby experience</p>

## Table of Contents

1. [Introduction](#introduction)
2. [Project Structure](#project-structure)
3. [Prerequisites](#prerequisites)
4. [Setup Instructions](#setup-instructions)
   1. [Clone the Repository](#clone-the-repository)
   2. [Running the Project](<#Running-Project-(Development)>)

## Introduction

Provide a brief overview of the project, its purpose, and its main features.

## Project Structure

```
my_place
├── client
│ └── src
├── backend
│ ├── server
│ └── server.test
└── backend.sln
```

## Prerequisites

Download docker if developing containerized route.

- [Docker](https://www.docker.com/) (version 26.1.1)

Download the following dependencies if running software locally (Without docker).

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (version 21.6.1)

## Setup Instructions

### Clone the Repository

```sh
git clone https://github.com/O1SoftwareNetwork/my_place.git
cd my_place
```

## Running Project (Development)

```sh
# Build docker images
docker compose build
# Run docker
docker compose up
```

### Alternatively

The project can be run locally instead of using docker

```sh
# Install pnpm as a package manager
npm install -g pnpm

# Enter front end project
cd client

# Run install
pnpm install

# run both front end and back end
pnpm devserver
```
