pipeline {
	
    agent any

    environment {
        DOTNET_VERSION = '3.1'
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
				
        stage('Docker Build') {
            steps {
                bat "docker build -t ${env.IMAGE_NAME}:${env.IMAGE_TAG} ."
            }
        }

        stage('Run container (optional)') {
            steps {
                bat "docker run --rm -d -p 8080:80 ${env.IMAGE_NAME}:${env.IMAGE_TAG}"
            }
        }
				
    }

    post {
        always {
            echo 'Pipeline completed.'
        }
    }
		
}

