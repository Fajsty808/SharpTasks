pipeline {
  agent any
  stages {
    stage('Checkout') {
      steps {
        git 'https://github.com/Fajsty808/SharpTasks.git'
      }
    }
    stage('Restore') {
      steps {
        bat 'dotnet restore'
      }
    }
    stage('Build') {
      steps {
        bat 'dotnet build --no-restore'
      }
    }
  }
}
