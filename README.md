# VideoGamesAPI

A REST API for managing video game data built with ASP.NET Core 9.0, featuring JWT authentication, Entity Framework Core, and SQL Server database.



<img width="1920" height="1040" alt="image" src="https://github.com/user-attachments/assets/27aff69a-e6d3-4293-a8a8-0f7c2fb9dcf0" />

<img width="1920" height="1040" alt="image" src="https://github.com/user-attachments/assets/1a2a173a-fbce-4047-b1ce-0000d4550882" />



## 🎮 Features

- **JWT Authentication**: Secure user registration and login with JWT tokens
- **CRUD Operations**: Full Create, Read, Update, Delete operations for video games
- **Entity Relationships**: Complex data model with developers, publishers, genres, and game details
- **OpenAPI Documentation**: Auto-generated API documentation with Scalar UI
- **SQL Server Integration**: Entity Framework Core with SQL Server database
- **Seeded Data**: Pre-populated database with sample video game data

## 🏗️ Architecture

### Technology Stack
- **Framework**: ASP.NET Core 9.0
- **Database**: SQL Server with Entity Framework Core
- **Authentication**: JWT Bearer tokens
- **Documentation**: OpenAPI/Swagger with Scalar UI
- **Language**: C# 

### Data Models
- **VideoGame**: Core game entity with relationships
- **Developer**: Game development companies
- **Publisher**: Game publishing companies  
- **Genre**: Game categories and classifications
- **VideoGameDetails**: Extended game information
- **User**: Authentication and user management

## 🚀 Getting Started

### Prerequisites
- .NET 9.0 SDK
- SQL Server (Express or higher)
- Visual Studio 2022 or VS Code


## 🔐 Authentication

The API uses JWT Bearer token authentication. All video game endpoints require authentication.

Login to get JWT token
```http
POST /api/auth/login
Content-Type: application/json

{
  "username": "your_username", 
  "password": "your_password"
}
```

Using the token
Include the JWT token in the Authorization header:
```
Authorization: Bearer <your_jwt_token>
```


## 📚 API Endpoints

### Authentication
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/auth/register` | Register a new user |
| POST | `/api/auth/login` | Login and get JWT token |
| GET | `/api/auth` | Test authenticated endpoint |

### Video Games (All require authentication)
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/videogames` | Get all video games with related data |
| GET | `/api/videogames/{id}` | Get video game by ID |
| POST | `/api/videogames` | Create a new video game |
| PUT | `/api/videogames/{id}` | Update an existing video game |
| DELETE | `/api/videogames/{id}` | Delete a video game |


