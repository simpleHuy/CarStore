# CarStore

This is a project for Windows Programming.

## Table of Contents

- [CarStore](#carstore)
  - [Table of Contents](#table-of-contents)
  - [Dependencies](#dependencies)
  - [Installation](#installation)

## Dependencies
- **Nodejs**
- **.Net**
- **Postgresql**

## Installation

To install and run this project locally, follow these steps:

1. Clone the repository:
   ```sh
   git clone https://github.com/simpleHuy/CarStore.git
   ```

2. Open the project in your preferred IDE (e.g., Visual Studio).

3. Restore the required packages:
   ```sh
   dotnet restore
   ```

4. Create a `.env` file in the CarStore.Core directory and add the following environment variables in `.env.sample`
   ```sh
   CONNECTION_STRING=Host=; Database=; Port=; User Id=; Password=
   ```
5. Run migration:
   ```sh
    dotnet ef database update --project CarStore.Core --startup-project CarStore
   ``` 
  
6. Build the project:
   ```sh
   dotnet build
   ```

7. Run servers:
   - Auction server:
       ```sh
       npm install && npm start
       ```
   - Chat server:
      ```sh
       ./Server/ChatServer/ChatServer.exe
      ```
8. Run the project:
   ```sh
   dotnet run
   ```
