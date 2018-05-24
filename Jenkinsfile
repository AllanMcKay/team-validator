pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                sh 'dotnet publish src/Service/Service.csproj -c release -f netcoreapp2.0 -o ../../app'
            }
        }
        stage('Publish') 
        {
            when {
                branch 'master'
            }
            steps 
            {
                script
                {
                    docker.withRegistry('https://eu.gcr.io', 'gcr:fantasyfootball')
                    {
                        docker.build('fantasyfootball-204922/team-validator')
                        docker.image('fantasyfootball-204922/team-validator').push("${BUILD_NUMBER}")
                    }

                }
            }
        }
    }
}