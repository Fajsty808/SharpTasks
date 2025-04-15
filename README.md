# SharpTasks – Simple Todo API in C# (.NET 9)

A lightweight RESTful API built with **C# and .NET 9**, designed for learning and experimenting with **CI/CD using Jenkins**.  
No database required (maybe adding later) – tasks are stored in memory.

---

## 🚀 Features

- Create, read, update, and delete (CRUD) todo tasks
- Clean and minimal API structure using `Controller` and `Model`
- Unit tested with `xUnit`
- CI/CD pipeline using Jenkins (Docker-based or native install)
- Great for learning C#, REST APIs, and Jenkins pipelines!

---

## 🔧 Tech Stack

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- C# with ASP.NET Core Web API
- Jenkins (runs via Docker)
- xUnit (for testing)
- Git + GitHub

---

## 🛠️ Getting Started

### 1. Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [Visual Studio Code](https://code.visualstudio.com/) or other IDE 
- [Docker Desktop](https://www.docker.com/products/docker-desktop) *(for Jenkins)*

---

### 2. Clone the project

```bash
git clone https://github.com/your-username/SharpTasks.git
cd SharpTasks
```
### 3. Jenkins-dotnet Setup

#### After Dockerfile changes (rebuild the image)
```bash
docker build -t jenkins-dotnet -f "C:\YOUR-PATH-TO-DOCKERFILE\Dockerfile" .
```

#### First-time run (create container)
```bash
docker run -d -p 8080:8080 -p 50000:50000 --name jenkins-dotnet --user root -v jenkins_home:/var/jenkins_home jenkins-dotnet
```

#### After reboot (just restart the container)
```bash
docker start jenkins-dotnet
```

## 🧰 Using the API

The API exposes the following endpoints to manage todo tasks.  
All endpoints are prefixed with:

```
/api/task
```

---

### ➕ Create a Task

**POST** `/api/task`

Create a new task by sending a JSON payload.

**Request Body**:
```json
{
  "id": "GUID",         // Optional – can be generated on backend
  "title": "Buy milk",
  "isCompleted": false
}
```

**Response**:  
`201 Created`  
Returns the created task object.

---

### 📋 Get All Tasks

**GET** `/api/task`

Fetches all tasks.

**Response**:  
`200 OK`  
Returns a list of task objects.

---

### 🔍 Get Task by ID

**GET** `/api/task/{id}`

Fetch a specific task by its `GUID`.

**Response**:  
`200 OK` – if found  
`404 Not Found` – if no task with the given ID exists

---

### ✏️ Update a Task

**PUT** `/api/task/{id}`

Update a task. The `id` in the URL must match the one in the request body.

**Request Body**:
```json
{
  "id": "GUID",
  "title": "Buy almond milk",
  "isCompleted": false
}
```

**Response**:  
`204 No Content` – if successful  
`400 Bad Request` – if ID mismatch  
`404 Not Found` – if task doesn't exist

---

### ❌ Delete a Task

**DELETE** `/api/task/{id}`

Deletes the task with the given ID.

**Response**:  
`204 No Content` – if successful  
`404 Not Found` – if task doesn't exist

---

### ✅ Mark Task as Completed

**PATCH** `/api/task/{id}/complete`

Marks the specified task as completed.

**Response**:  
`204 No Content` – if successful  
`404 Not Found` – if task doesn't exist
