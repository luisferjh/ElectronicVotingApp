<template>
<v-container grid-list-xl>
  <v-layout row wrap>

    <v-flex xs12 sm6 md4 v-for="(item, index) in candidates" :key="index">
      <v-card>
        <v-img
        v-bind:src='item.picture'
        height="200px" 
        contain      
        ></v-img>
          <v-card-title class="pa-0 justify-center">
            <div class="d-inline-block display-2 headline mb-0"> 
              {{ item.fullName }}
            </div>                   
        </v-card-title>
        <v-card-actions >
          <v-radio-group v-model="idVoted" hide-details class="justify-center mt-0">            
            <v-radio v-bind:value='item.idCandidate' label=""></v-radio>
          </v-radio-group>
        </v-card-actions>
      </v-card>     
    </v-flex>       
  </v-layout>
  
  <v-layout>
    <v-flex>
       <v-btn color="success" @click="toVote(idVoted)">Vote</v-btn>
    </v-flex>
  </v-layout>
 

 <!-- <v-layout>
   <p>{{idVoted}}</p>
 </v-layout> -->
</v-container>

</template>

<script>
import axios from 'axios'

export default {
    name:'CandidateProfile',
    data() {
      return {
        candidates:[],
        idVoted:0
      }
    },
    computed: {
      name() {
        return this.data 
      }
    },
    created () {
      this.fetchCandidates()  
    },
    methods: {
      fetchCandidates() {
        let me=this;    
        console.log(this.$store.state.user.Role)
        let AuthorizationHeader = {"Authorization" : "Bearer " + this.$store.state.token}
        let headers = {headers:AuthorizationHeader}
        axios.get('https://localhost:44397/api/candidate/list',
          headers)
        .then(function (response) {
         // handle success
          me.candidates = response.data                  
          console.log(response);            
          })
        .catch(function (error) {
          // handle error          
          console.log(error);
        })
      },
      toVote(idVoted){
        console.log(idVoted)
      }        
    },
}
</script>