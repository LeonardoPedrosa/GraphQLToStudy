# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

# Build image with SDK
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy your corporate certificates into the image
COPY corp-root-ca.crt /usr/local/share/ca-certificates/corp-root-ca.crt

# Install the certificates inside the image
RUN apt-get update \
    && apt-get install -y ca-certificates \
    && update-ca-certificates

# Copy and restore
COPY ["GraphQLBooksApi.csproj", "./"]
RUN dotnet restore "./GraphQLBooksApi.csproj"

# Copy the rest of the code and build
COPY . .
RUN dotnet build "GraphQLBooksApi.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "GraphQLBooksApi.csproj" -c Release -o /app/publish

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GraphQLBooksApi.dll"]
