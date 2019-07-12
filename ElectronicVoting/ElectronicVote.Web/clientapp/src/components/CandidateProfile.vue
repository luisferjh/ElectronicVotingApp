<template>
  <v-layout>
    <v-flex xs12 sm6>

      <v-card  v-for="(item, index) in candidates" :key="index">
        <v-img
        v-bind:src='item.picture'       
        ></v-img>
          <v-card-title primary-title>
          <div>
            <h3 class="headline mb-0"> {{ item.fullName }}</h3>          
          </div>
        </v-card-title>
      </v-card>
      <v-btn color="success" @click="fetchCandidates()">Fetch candidates</v-btn>
    </v-flex>
  </v-layout>
</template>

<script>
import axios from 'axios'

export default {
    name:'CandidateProfile',
    data() {
      return {
        candidates:[]
      }
    },
    methods: {
      fetchCandidates() {
        let me=this;
        axios.get('https://localhost:44397/api/candidate/list')
        .then(function (response) {
         // handle success
          me.candidates = response.data
          console.log(me.candidates[0]);
          console.log(response);
          })
        .catch(function (error) {
          // handle error
          console.log(error);
        })
      }
    },
}
</script>