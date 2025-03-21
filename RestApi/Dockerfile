# Use the official .NET SDK image to build the application (for .NET 7)
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the .csproj file and restore any dependencies (via NuGet)
COPY *.csproj ./
RUN dotnet restore

# Copy the entire application into the container
COPY . ./

# Publish the application to a folder (for example, /out)
RUN dotnet publish -c Release -o /out

# Use the official .NET Runtime image to run the application (for .NET 7)
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

# Set the working directory in the container
WORKDIR /app

# Copy the published app from the build stage
COPY --from=build /out .

# Expose the port the app will run on
EXPOSE 80

# Define the entry point to run the application
ENTRYPOINT ["dotnet", "RestApi.dll"]

