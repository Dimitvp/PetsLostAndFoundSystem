pipeline {
  agent any
  stages {
    // stage('Verify Branch') {
    //   steps {
    //     echo "$GIT_BRANCH"
    //   }
    // }
    // stage('Pull Changes') {
    //   steps {
    //     powershell(script: "git pull")
    //   }
    // }
    stage('Run Unit Tests') {
      steps {
        powershell(script: """ 
          cd PetsLostAndFound
          dotnet test
          cd ..
        """)
      }
    }
    stage('Docker Build') {
      steps {
        powershell(script: 'docker-compose build')     
        powershell(script: 'docker images -a')
      }
    }
    stage('Run Test Application') {
      steps {
        powershell(script: 'docker-compose up -d')    
      }
    }
    stage('Run Integration Tests') {
      steps {
        powershell(script: './Tests/ContainerTests.ps1') 
      }
    }
    stage('Stop Test Application') {
      steps {
        powershell(script: 'docker-compose down') 
        // powershell(script: 'docker volumes prune -f')   		
      }
      post {
	    success {
	      echo "Build successfull! You should deploy! :)"
	    }
	    failure {
	      echo "Build failed! You should receive an e-mail! :("
	    }
      }
    }
    stage('Push Images') {
      when { branch 'main' }
      steps {
        script {
          docker.withRegistry('https://index.docker.io/v1/', 'DockerHub') {
            def image = docker.image("dimitvp/petslostandfoundsystem-identity-services")
            image.push("1.0.${env.BUILD_ID}")
            image.push('latest')
          }
        }
      }
    }
    stage('Deploy Development') {
      when { branch 'main' }
      steps {
        withKubeConfig([credentialsId: 'DevelopmentServer', serverUrl: '']) {
		       powershell(script: 'kubectl apply -f ./.k8s/.environment/development.yml') 
		       powershell(script: 'kubectl apply -f ./.k8s/databases') 
		       powershell(script: 'kubectl apply -f ./.k8s/event-bus') 
		       powershell(script: 'kubectl apply -f ./.k8s/web-services') 
        }
      }
    }
  }
}