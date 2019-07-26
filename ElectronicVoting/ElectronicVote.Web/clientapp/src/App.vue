<template>
  <v-app>
   <AppNavigation v-if="loggedIn" />
    <v-content>
      <v-container fluid>
        <router-view></router-view>
      </v-container>
    </v-content>
    <v-footer color="cyan darken-2" inset> <span class="white--text ml-2">Made by Luis Jimenez &copy;2019</span></v-footer>
  </v-app>
</template>

<script>
import HelloWorld from './components/HelloWorld'
import AppNavigation from './components/AppNavigation'

export default {
  name: 'App',
  components: {
    HelloWorld,
    AppNavigation
  },
  data () {
    return {
      //
    }
  },
  computed: {
    loggedIn() {
      return this.$store.state.user
    }
  },
  // beforeCreate () {
  //   this.$store.dispatch('autoLogin')
  // },
}
</script>
