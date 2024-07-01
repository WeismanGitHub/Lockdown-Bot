ARG DOTNET_OS_VERSION="-alpine"
ARG DOTNET_SDK_VERSION=8.0
ARG VITE_OAUTH_URL

# Build stage for the server
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_SDK_VERSION}${DOTNET_OS_VERSION} AS build-server
WORKDIR /src

# Copy everything from root directory
COPY . .

# Restore dependencies for the server
WORKDIR /src
RUN dotnet restore

# Build and publish the server
RUN dotnet publish -c Release -o /app/Server

# Build stage for the client
FROM node:alpine AS build-client
WORKDIR /src/Client

# Copy and install npm dependencies for the client
COPY Client/package*.json ./
RUN npm install

# Copy the client application
COPY Client/ ./

# Build the client application
RUN npm run build:production

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_SDK_VERSION}${DOTNET_OS_VERSION}

# Set environment variables for the ASP.NET Core application
ENV ASPNETCORE_URLS http://+:8080
ENV ASPNETCORE_ENVIRONMENT Production

# Expose port
EXPOSE 8080

# Set the working directory for the server
WORKDIR /app/Server

# Copy published files from the server
COPY --from=build-server /app/Server .

# Copy client build output to /app/Server/wwwroot
COPY --from=build-client /src/Server/wwwroot /app/Server/wwwroot

# Set the entrypoint for the server
ENTRYPOINT [ "dotnet", "Server.dll" ]
