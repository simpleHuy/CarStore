# CarStore

This is a project for Windows Programming.

## Table of Contents

- [CarStore](#carstore)
  - [Table of Contents](#table-of-contents)
  - [Introduction](#introduction)
  - [Features](#features)
  - [Dependencies](#dependencies)
  - [Installation](#installation)

## Introduction

CarStore is an application developed for managing car sales and inventory. It is built using C# and includes a small amount of JavaScript.

## Features

- **Home**: Browse available cars, view featured listings, search for specific car models.
- **Inspect Car Detail**: View detailed specifications, check images and history reports, read customer reviews.
- **Chat with Merchant**: Communicate directly with sellers, negotiate prices and ask questions.
- **Auction**: Participate in car auctions, place bids and track auction status, receive updates on winning or losing bids.

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