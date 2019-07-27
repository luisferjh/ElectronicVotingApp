<template>
  <v-container>
    <v-layout justify-center>
      <v-flex xs12 sm6 md5>
        <v-card>
          <v-toolbar dark color="cyan darken-2">
            <v-toolbar-title>Electronic Vote</v-toolbar-title>
          </v-toolbar>
          <v-card-text>
            <v-form>
              <v-text-field
              prepend-icon="person"
              v-model="email"
              label="Email"     
              required
              >
              </v-text-field>

              <v-text-field
              prepend-icon="lock"
              v-model="password"
              type="password"
              label="Password"
              required
              >
              </v-text-field>   
            </v-form>  
            <div class="text-xs-center">
              <v-btn align-center dark color="cyan darken-2" @click="submit"> Log in</v-btn> 
              <v-btn align-center dark color="cyan darken-2" @click="submit"> Sign in</v-btn>                   
            </div>                    
          </v-card-text>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
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
          this.$router.push({name:'home'})        
        })
        .catch(function(err){
          console.log(err)
        })
      },      
    },
  }
</script>
