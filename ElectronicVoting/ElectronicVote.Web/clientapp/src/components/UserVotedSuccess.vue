<template> 
    <v-flex xs12 sm8>
    <v-alert
      :value="alert"
      type="success"
      transition="scale-transition"      
    >
      Your vote has been registered successfully
    </v-alert>
    <div class="text-xs-center">
      <v-btn @click="$router.push('/')" color="cyan darken-2" dark>Back to home</v-btn>
    </div>
  </v-flex>   
</template>

<script>
  export default {
    name:'voteSuccess',
    data() {
      return {
        alert: true
      }
    },
  }
</script>