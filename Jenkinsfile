pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        script {
            dockerapp = docker.build("pokemonapp", "-f ./PokemonReviewApp/Dockerfile ./PokemonReviewApp")
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
