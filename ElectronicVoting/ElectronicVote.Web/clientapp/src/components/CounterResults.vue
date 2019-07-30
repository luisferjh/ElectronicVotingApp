<template>
<v-layout justify-center wrap>

  <v-flex xs12 sm4 md3>

    <div class="display-1 font-weight-medium my-3">
       Most voted candidate
    </div>
    
    <v-card>
      <v-card-title><h4>{{ winnerCandidate.candidateName }}</h4></v-card-title>
        <v-divider></v-divider>
        <v-list dense>             
          <v-list-tile>
            <v-list-tile-content>Number of votes</v-list-tile-content>
            <v-list-tile-content class="align-end">{{ winnerCandidate.numVotes }}</v-list-tile-content>
          </v-list-tile>
        </v-list>
      </v-card>
   </v-flex>
  
</v-layout>
</template>

<script>
  import axios from 'axios'
  export default {
    name:'counterResults',
    data() {
      return {
        winnerCandidate:''
      }
    },        
    created(){
      this.showCandMostVoted()  
    },  
    methods: {
      showCandMostVoted() {
        let me=this;            
        let AuthorizationHeader = {"Authorization" : "Bearer " + this.$store.state.token}
        let headers = {headers:AuthorizationHeader}
        axios.get('https://localhost:44397/api/vote/GetMostVoted',
          headers)
        .then(function (response) {
         // handle success         
         me.winnerCandidate = response.data                    
        })
        .catch(function (error) {
          // handle error          
          console.log(error);
          if (error.response.status === 401) {						
						me.$store.dispatch('exit')
          }
        })
      }
    },  
  }
</script>

