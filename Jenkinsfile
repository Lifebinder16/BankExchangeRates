pipeline {
	
    agent any

    environment {
        DOTNET_VERSION = '3.1'
        IMAGE_NAME = 'BankExchangeRates'
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
				
    }

    post {
        always {
            echo 'Pipeline completed.'
        }
    }
}

