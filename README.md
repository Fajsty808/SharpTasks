# 🧠 SharpTasks – Simple Todo API in C# (.NET 9)

A lightweight RESTful API built with **C# and .NET 9**, designed for learning and experimenting with **CI/CD using Jenkins**.  
No database required (maybe adding later) – tasks are stored in memory.

---

## 🚀 Features

- ✅ Create, read, update, and delete (CRUD) todo tasks
- 🧠 Clean and minimal API structure using `Controller` and `Model`
- 🧪 Unit tested with `xUnit`
- 🔁 CI/CD pipeline using Jenkins (Docker-based or native install)
- 💡 Great for learning C#, REST APIs, and Jenkins pipelines!

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

- ✅ [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- ✅ [Visual Studio Code](https://code.visualstudio.com/)
- ✅ [Docker Desktop](https://www.docker.com/products/docker-desktop) *(for Jenkins)*
- ✅ Git

---

### 2. Clone the project

```bash
git clone https://github.com/your-username/SharpTasks.git
cd SharpTasks
```
### 🐳 Jenkins-dotnet Setup


#### 🛠️ After Dockerfile changes (rebuild the image)
```bash
docker build -t jenkins-dotnet -f "C:\YOUR-PATH-TO-DOCKERFILE\Dockerfile" .
```

#### 🏗️ First-time run (create container)
```bash
docker run -d -p 8080:8080 -p 50000:50000 --name jenkins-dotnet --user root -v jenkins_home:/var/jenkins_home jenkins-dotnet
```

#### 🔄 After reboot (just restart the container)
```bash
docker start jenkins-dotnet
```