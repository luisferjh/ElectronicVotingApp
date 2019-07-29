<template>
 <v-layout justify-center>  
    <CandidateProfile v-if="!voted" @updateState="fetchState()" />  
    <VoteSuccess v-if="voted" />
  </v-layout>
</template>

<script>
import axios from 'axios'
import CandidateProfile from '@/components/CandidateProfile'
import VoteSuccess from '@/components/UserVotedSuccess'

export default {
  components: {
      CandidateProfile,
      VoteSuccess
  },
  data() {
    return {
      voted: false
    }
  },
  methods: {
    fetchState() {
      let me=this;                         
      axios.get('https://localhost:44397/api/user/getState/' + this.$store.state.user.IdVoterUser)
      .then(function (response) {
        // handle success      
        me.voted = response.data.state                           
        })
      .catch(function (error) {
        // handle error          
        console.log(error);              
      })
    }
  },
  created () {
    this.fetchState()  
  }
}
</script>
