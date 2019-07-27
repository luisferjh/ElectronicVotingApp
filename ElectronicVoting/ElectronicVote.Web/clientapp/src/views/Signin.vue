<template>
  <v-layout justify-center>
   <SignInForm/> 
  </v-layout>
</template>

<script>
  import SignInForm from '@/components/signinForm'
    export default {
        components: {
          SignInForm,
        },
    }
</script>
