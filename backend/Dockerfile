# server/Dockerfile

# Use a .NET SDK image for building and running the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base

WORKDIR /app

# Copy the .NET project file and restore dependencies
COPY ./server/*.fsproj ./server/
RUN dotnet restore ./server/server.fsproj

# Copy the rest of the application code
COPY . .

WORKDIR /app/server

# Expose the port
EXPOSE 5000

# Start the application in watch mode
CMD ["dotnet", "watch", "run"]
