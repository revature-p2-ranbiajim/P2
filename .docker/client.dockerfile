FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build
WORKDIR /app
COPY . .
RUN dotnet build
RUN dotnet publish --configuration Release --output out Project2.Client.csproj

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /www
COPY --from=build /app/out .
CMD [ "dotnet", "Project2.Client.dll" ]