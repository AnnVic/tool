# Use the official .NET SDK image as a build environment
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy the .csproj and restore as distinct layers
COPY src/BookSharingApi/ ./
RUN dotnet restore

# Copy the remaining source code
COPY . ./
RUN dotnet publish src/BookSharingApi/ -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Set the environment variable
# ENV ASPNETCORE_ENVIRONMENT=Development

# Start the application
CMD ["dotnet", "BookSharingApi.dll"]
