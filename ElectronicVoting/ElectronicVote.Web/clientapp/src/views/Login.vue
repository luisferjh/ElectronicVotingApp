<template>
  <v-container>
    <v-layout justify-center v-if="!showProgressBar">
      <v-flex xs12 sm6 md5>
        <v-card>
          <v-toolbar dark color="cyan darken-2">
            <v-toolbar-title>Electronic Vote</v-toolbar-title>
          </v-toolbar>
          <v-card-text>
            <v-form ref="form">
              <v-text-field
              prepend-icon="person"
              v-model="email"
              :rules="emailRules"
              label="Email"     
              required
              >
              </v-text-field>

              <v-text-field
              prepend-icon="lock"
              v-model="password"
              :rules="passwordRules"
              type="password"
              label="Password"
              required
              >
              </v-text-field>   
            </v-form>  
            <div class="text-xs-center">
              <v-btn align-center dark color="cyan darken-2" @click="submit"> Log in</v-btn> 
              <v-btn align-center dark color="cyan darken-2" @click="$router.push('/signin')"> Sign in</v-btn>                   
            </div>                    
          </v-card-text>
        </v-card>
      </v-flex>
    </v-layout>

    <v-layout justify-center v-if="showProgressBar">
      <ProgressBar/>
    </v-layout>
  </v-container>
</template>

<script>
  import axios from 'axios'
  import ProgressBar from '@/components/ProgressBar'

  export default {
    components: {
      ProgressBar,
    },
    data() {
      return {
        showProgressBar:false,
        email: '',
        password:'',
        emailRules: [
          v => !!v || 'E-mail is required',
          v => /.+@.+/.test(v) || 'E-mail must be valid'
        ],
        passwordRules:[
          v => !!v || 'Password is required',
          v => (v && v.length <= 10) || 'Password must be less than 10 characters'
        ]
      }
    },
    methods: {
      submit () {       
        if(this.validateForm()){
          this.showProgressBar = true
          let me = this;       
          axios.post('https://localhost:44397/api/login',{											
					  Email:me.email,
					  Password: me.password					
				  }).then(response =>{            												
            return response.data 
          })
          .then(data =>{            
            this.$store.dispatch('saveToken', data.token)
            this.$router.push({name:'home'})        
          })
            .catch(function(err){
            console.log(err)
         })
        } 
        else {          
          console.log("please corregir los errores")
        }
        
      }, 
      validateForm(){
        return this.$refs.form.validate()
      }     
    },
  }
</script>
