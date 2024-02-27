pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        script {
            dockerapp = docker.build("pedroandrade03/pokemonreviewapp", '-f ./PokemonReviewApp/Dockerfile .')
        }
      }
    }
    stage('Test') {
      steps {
        echo 'Testings...'
      }
    }
    stage('Deploy') {
      steps {
        echo 'Deployings....'
      }
    }
  }
}
