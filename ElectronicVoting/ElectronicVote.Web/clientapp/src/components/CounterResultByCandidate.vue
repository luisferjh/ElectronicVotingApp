<template>
  <v-layout justify-center wrap>
    <v-flex xs12 sm4 md3>

      <div class="display-1 font-weight-medium mb-3">
        Votes By Candidates
      </div>
      
      <v-card>
        <v-card-title><h4>Candidates</h4></v-card-title>
        <v-divider></v-divider>
        <v-list dense v-for="(item, index) in voteCandidates" :key="index">
          <v-list-tile>
            <v-list-tile-content>{{ item.nameCandidate }}</v-list-tile-content>
            <v-list-tile-content class="align-end">{{ item.numVotes }}</v-list-tile-content>
          </v-list-tile>        
                                     
        </v-list>
      </v-card>

    </v-flex>
  
</v-layout>
</template>

<script>
  import axios from 'axios'
  export default {
    name:'counterResultByCandidate',
    data() {
      return {
        voteCandidates:[]
      }
    },
    methods: {
      showVotedByCandidate() {
        let me=this;            
        let AuthorizationHeader = {"Authorization" : "Bearer " + this.$store.state.token}
        let headers = {headers:AuthorizationHeader}
        axios.get('https://localhost:44397/api/vote/listVotes',
          headers)
        .then(function (response) {
         // handle success
         me.voteCandidates = response.data                    
         console.log(me.voteCandidates)
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
    created () {
      this.showVotedByCandidate()
    },
  }
</script>