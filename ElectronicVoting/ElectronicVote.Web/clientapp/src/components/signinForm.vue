<template>
  <span>
    <v-form v-if="!signed">
      <v-container>
        <v-layout row wrap>  
          <v-flex xs12 sm10 md9>
            <v-toolbar color="cyan darken-2" dark> 
              <v-toolbar-title>Ingresa tus datos</v-toolbar-title>
            </v-toolbar>
          </v-flex>     
          <v-flex xs12 sm10 md4>
            <v-text-field
            v-model="fullName"
            label="Full Name"
            required
            >
            </v-text-field>
          </v-flex>
          <v-flex xs12 sm10 md4>
            <v-text-field
            v-model="password"
            label="Password"
            type="password"
            required
            ></v-text-field>
          </v-flex>
          <v-flex xs12 sm10 md8>
            <v-text-field
            v-model="age"
            label="Age"
            required
            ></v-text-field>
          </v-flex>
          <v-flex xs12 sm10 md8>
            <v-select
            :items="items"
            v-model="record"
            label="Criminal Record"
            required
            >
            </v-select>
          </v-flex>
          <v-flex xs12 sm10 md8>
            <v-text-field
            v-model="email"
            label="Email"
            required
            ></v-text-field>
          </v-flex>
          
          <v-flex xs12 sm10 md8>
            <v-btn @click="signUp()">Sign Up</v-btn>
          </v-flex>
        </v-layout>
      </v-container>
    </v-form>

    <v-flex xs12 sm12 v-if="signed">
      <v-alert
        :value="true"
        type="success"
        transition="scale-transition"      
      >
        You have been registered successfully
      </v-alert>
      <div class="text-xs-center">
        <v-btn large @click="$router.push('/login')" color="cyan darken-2" dark>Back to Log In</v-btn>
      </div>
    </v-flex>   
  </span>
 
</template>

<script>
  import axios from 'axios'
  export default {
    name:'signinForm',
    data() {
      return {
        idRole:'',
        fullName: '',
        age:'',
        record:'',
        email:'',
        password:'',
        voted:false,
        signed:false,
        items:[false,true]
      }
    },
    methods: {
      signUp() {
        let me = this; 
        axios.post('https://localhost:44397/api/user/create',
        {	
          IdRole:2,
          FullName:me.fullName,
          Age:me.age,
          Record:me.record,										
					Email:me.email,
          Password: me.password,
          Voted:false					
        })    
        .then(response => {         
          me.signed = true   												           
        })  
        .catch(function(err){
          console.log(err)
        })       
      }
    },      
  }
</script>
