# Working with SQL Lite

## Installation

### Cloning
First clone down the repository and cd into it

    cd 221-sqlite-example

### Updating dotnet version
Open up the `sql_lite.csproj` file and make sure you have the right target framework selected

    <TargetFramework>net8.0</TargetFramework>

If you are not sure which net version you should have you can run `dotnet --version` to check.

### Adding Database
Within the sql_lite directory, you need to add a file called `car.db`. This will be the file that SQLite uses as its database file

### Adding Packages
you now need to add the packages necessary to connect to and work with the SQLite Database

    dotnet add package System.Data.SQLite.Core

### Running Project
You should now be ready to run the project and play around with the code! Make sure it is working properly by running:

    dotnet run

You should see the following output to your console:

    SQLite version: 3.42.0
    Car: 1, BMW, 2020
    Car: 2, Audi, 2019
    Car: 3, Mercedes, 2018
    Car: 1, Toyota, 2020
    Car: 2, Audi, 2019
    Car: 3, Mercedes, 2018