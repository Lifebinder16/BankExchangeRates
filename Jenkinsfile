pipeline {
	
    agent any

    environment {
        IMAGE_NAME = 'bankexchangerates'
        IMAGE_TAG = 'latest'
    }

    tools {
        dotnetsdk 'net-3.1'
    }

    stages {
        stage('Restore') {
            steps {
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build --configuration Release'
            }
        }

        stage('Publish') {
            steps {
                bat 'dotnet publish -c Release -o out'
            }
        }
				
        // Создаю образ Docker
        stage('Docker Build') {
            steps {
                bat "docker build -t ${env.IMAGE_NAME}:${env.IMAGE_TAG} ."
            }
        }

        stage('Run container') {
            steps {
                bat "docker run --rm -d -p 8081:80 ${env.IMAGE_NAME}:${env.IMAGE_TAG}"
            }
        }
				
    }

    post {
        always {
            echo 'Pipeline completed.'
        }
    }
		
}

