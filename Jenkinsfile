pipeline {
  agent any
  stages {
    stage('Checkout') {
      steps {
        git credentialsId: 'a181d81e-cc6a-46fb-bd0e-e1d8cf1c2eeb', branch: 'main', url: 'https://github.com/Fajsty808/SharpTasks.git'
      }
    }
    stage('Restore') {
      steps {
        dir('SharpTasks') {
          sh 'dotnet restore'
        }
      }
    }
    stage('Build') {
      steps {
        dir('SharpTasks') {
          sh 'dotnet build --no-restore'
        }
      }
    }
  }
}
