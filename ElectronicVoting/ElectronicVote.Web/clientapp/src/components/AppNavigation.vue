<template>
<span>
  <v-navigation-drawer app v-model="drawer" class="cyan darken-2 hidden-md-and-up" dark disable-resize-watcher>
    <v-list>
      <template>
        <v-list-tile @click="$router.push('/')">        
            <v-list-tile-action>
          
              <v-icon>home</v-icon>
            </v-list-tile-action>

            <v-list-tile-content>
                Home
            </v-list-tile-content>
         
        </v-list-tile>
      </template>

      <template>
        <v-list-tile @click="$router.push('/candidate')">        
            <v-list-tile-action>
          
              <v-icon>how_to_vote</v-icon>
            </v-list-tile-action>

            <v-list-tile-content>
                Vote
            </v-list-tile-content>
         
        </v-list-tile>
      </template>

      <template>
        <v-list-tile @click="$router.push('/counter')">      
            <v-list-tile-action>          
              <v-icon>format_list_numbered</v-icon>
            </v-list-tile-action>

            <v-list-tile-content>
               Counter
            </v-list-tile-content>         
        </v-list-tile>
      </template>

      <v-list-group
        prepend-icon="account_circle"
        value="true"
        dark
      >

        <template v-slot:activator>
          <v-list-tile>
            <v-list-tile-title>Users</v-list-tile-title>
          </v-list-tile>             
        </template>

        <template>
         <v-list-tile>
          <div class="pl-3">
            {{userLoggin.user}}
          </div>              
         </v-list-tile>
         <v-list-tile>         
           <div class="pl-3">
            {{userLoggin.role}}
          </div>         
         </v-list-tile>
        </template>

        <template>
           <v-list-tile @click="$store.dispatch('exit')">
           <v-list-tile-title>
            Log Out 
           </v-list-tile-title>            
          </v-list-tile>      
        </template>
            
      </v-list-group>

    </v-list>
  </v-navigation-drawer>

  <v-toolbar app color="cyan darken-2" dark>
    <v-toolbar-side-icon class="hidden-md-and-up" @click="drawer = !drawer"></v-toolbar-side-icon>
    <v-toolbar-title class="headline text-uppercase" >
      <span>Electronic Vote App</span>    
    </v-toolbar-title>
    <v-spacer class="hidden-xs-and-down"></v-spacer>
    <v-btn flat class="hidden-sm-and-down" to="/">
      <v-icon dark>home</v-icon>     
      <span class="mr-2">Home</span>
    </v-btn >
     <v-btn flat class="hidden-sm-and-down" to="/candidate">
      <v-icon dark>how_to_vote</v-icon>
      <span class="mr-2">Vote</span>
    </v-btn>
    <v-btn flat class="hidden-sm-and-down" to="/counter">
      <v-icon dark>format_list_numbered</v-icon>   
      <span class="mr-2">Counter</span>
    </v-btn>    

    <v-btn flat class="hidden-sm-and-down">
                         
      <v-menu :nudge-width="100">
        <template v-slot:activator="{ on }">
          <v-toolbar-title v-on="on">
            <v-icon dark>account_box</v-icon>     
          </v-toolbar-title>
        </template>
     
         <v-list>
          <template>
         <v-list-tile>
          <div>
            {{userLoggin.user}}
          </div>              
         </v-list-tile>
         <v-list-tile>         
           <div>
            {{userLoggin.role}}
          </div>         
         </v-list-tile>
        </template>
          <hr>   
          <template>                
            <v-list-tile avatar @click="$store.dispatch('exit')">
              <v-list-tile-content>
                <v-list-tile-title v-html="title"></v-list-tile-title>               
              </v-list-tile-content>
            </v-list-tile>
          </template>
        </v-list>
      </v-menu>
          
    </v-btn>
  </v-toolbar>
</span>
 
</template>

<script>
  export default {
    name:'AppNavigation',
    data() {
      return {
        drawer: false,       
         userLoggin:{ 
          user:  this.$store.state.user.Name,
          role: this.$store.state.user.Role
        },
        items: [
                { title: 'Home', icon:'home'},
                { title: 'Vote', icon:'how_to_vote'  },
                { title: 'Counter', icon:'format_list_numbered'},
                { title: 'User', icon:'account_box'  }
        ],
        title:'Log Out',
        log:false                 
      }
    },
    
  }
</script>
