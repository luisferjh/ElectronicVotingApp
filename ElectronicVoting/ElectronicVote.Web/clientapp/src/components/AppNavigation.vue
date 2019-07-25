<template>
<span>
  <v-toolbar app color="cyan darken-2" dark>
    <v-toolbar-side-icon class="hidden-md-and-up" @click="drawer = !drawer"></v-toolbar-side-icon>
    <v-toolbar-title class="headline text-uppercase" >
      <span>Electronic Vote App</span>    
    </v-toolbar-title>
    <v-spacer class="hidden-xs-and-down"></v-spacer>
    <v-btn flat class="hidden-sm-and-down" to="/">
      <span class="mr-2">Home</span>
    </v-btn >
     <v-btn flat class="hidden-sm-and-down" to="/candidate">
      <v-icon dark>how_to_vote</v-icon>
      <span class="mr-2">Vote</span>
    </v-btn>
    <v-btn flat class="hidden-sm-and-down" to="/counter">
 
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
          <v-list-tile v-for="(item,index) in items" :key="index">
            <v-list-tile-title v-text="item.title"></v-list-tile-title>
          </v-list-tile>
        </v-list>
      </v-menu>
      <!-- <span class="mr-2">Log Out</span> -->
     
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
        items:[              
          {title:'Log Out'}
        ],
        userLoggin:{ 
          user: `${this.$store.sate.user}`,
          role: `${this.$store.sate.user.Role}`
        },              
      }
    },
  }
</script>
