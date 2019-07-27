<template>
 <v-layout justify-center>  
    <CandidateProfile v-if="!voted" />  
    <VoteSuccess v-if="voted" />
  </v-layout>
</template>

<script>
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
  computed: {
    name() {
      return this.data 
    }
  },
}
</script>
