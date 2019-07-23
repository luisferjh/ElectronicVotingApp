<template>
   <v-layout>
    <v-form>
      <v-text-field
      v-model="email"
      label="Email"     
      required
      >

      </v-text-field>

      <v-text-field
      v-model="password"
      type="password"
      label="Password"
      required
      >

      </v-text-field>    

      <v-btn @click="submit"> Log in</v-btn>          
    </v-form>
   </v-layout>
</template>

<script>
import axios from 'axios'

  export default {
    data() {
        return {
          email: '',
          password:'',
          emailRules: [
            v => !!v || 'E-mail is required',
            v => /.+@.+/.test(v) || 'E-mail must be valid'
          ]
        }
    },
    methods: {
      submit () {        
        let me = this;
        me.error=null;
        axios.post('https://localhost:44397/api/login',{											
					Email:this.email,
					Password: this.password					
				}).then(response =>{            												
          return response.data 
        })
        .then(data =>{
          console.log(data)
          this.$store.dispatch('saveToken', data.token)
          this.$router.push({name:'candidate'})        
        })
        .catch(function(err){
          console.log(err)
        })
      },
      showUser(){
         //this.$store.dispatch('saveToken', localStorage.getItem('token'))
        // console.log(this.$store.state.user.Role)
        console.log(this.$store.state.test);
      }
    },
  }
</script>
