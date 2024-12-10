<div align="center">
  
  <h1>Car Store</h1>

  <p>A Windows desktop app for a Car Store using Winui 3</p> 
  
</div>

## 📘 Table of Contents
1. [Introduction](#introduction) 🌟
2. [Team Members](#team-members) 🤝
3. [Technologies](#technologies) 💻
4. [Features](#features) 🔎
5. [Development](#development) ✈️
6. [Contact](#contact) 🌐

## 🌟 <a name="introduction">Introduction</a>

**Car Store** is a Windows application for Buying, Selling, Auctioning Cars. It is built using winui3, dotnet and C#. The application allows users to inspect car, sell a car, auction car.

This project is a part of the **Windows Programing** course at **University of Science**. The project is developed by a team of **3 students**.

## 🤝 <a name="team-members">Team Members</a>

- **Hoang Tien Huy** - 22120134 - [simpleHuy](https://github.com/simpleHuy)
- **Nguyen Minh Truc** - 22120394 - [mituc24](https://github.com/CatHuyuH24)
- **Huynh Tran Ty** - 22120418 - [huynhtranty](https://github.com/huynhtranty)

## 💻 <a name="technologies">Technologies</a>
<div align="center">
  
  ![Technologies](https://skillicons.dev/icons?i=cs,dotnet,postgres)

</div>

- **C#:** Build all Bussiness logic.
- **Winui 3:** A modern UI framework for creating high-performance, visually appealing Windows desktop applications.
- **.Net:** A versatile framework for building scalable, cross-platform applications with rich libraries and seamless integration.
- **Postgres:** Store and manage data of the application.
- **EF Core:** Build Table/Schema from model in project.

## 🔎 <a name="features">Features</a>

## ✈️ <a name="development">Development</a>

#### 📌 Note: The application is currently in development and may contain bugs or incomplete features.

### Prerequisites
- [.Net](https://dotnet.microsoft.com/en-us/download/dotnet-framework)
- [Postgres](https://www.postgresql.org/)

### Installation
1. Clone the repository
   ```bash
   git clone https://github.com/mituc24/CarStore.git
   cd CarStore
   ```
2. Create a `.env` file in the `CarStore.Core` directory and add the following environment variables in `.env.sample`
  ```env.sample
  CONNECTION_STRING=Host=; Database=; Port=; User Id=; Password=
  ```

3. Run all migration in CarStore.Core:
   - Open Project in [Visual Studio](https://visualstudio.microsoft.com/vs/)
   - Open Package Manage Console, [Click to view instructions](https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-powershell)
   - Choose Default project is CarStore.Core
   - Use
     ```bash
     update-database
     ```
4. Now you can run the App.

## 🌐 <a name="contact">Contact</a>

- **Hoang Tien Huy** - [simpleHuy](https://github.com/simpleHuy)
- **Nguyen Minh Truc** - [mituc24](https://github.com/CatHuyuH24)
- **Huynh Tran Ty** - [huynhtranty](https://github.com/huynhtranty)
