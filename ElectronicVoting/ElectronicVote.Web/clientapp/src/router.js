import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import Candidate from './views/Candidate.vue'
import Login from './views/Login.vue'
import Counter from './views/Counter.vue'
import store from './store'

Vue.use(Router)

var router =  new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      meta:{
        admin:true,
        voter:true
      }
    },
    {
      path: '/candidate',
      name: 'candidate',
      component: Candidate,
      meta:{
        admin:true,
        voter:true
      }
    },
    {
      path: '/login',
      name: 'login',
      component: Login,
      meta:{
        free:true 
      }
    },
    {
      path: '/counter',
      name: 'counter',
      component: Counter,
      meta:{
        admin:true
      }
    }
  ]
})

router.beforeEach((to, from, next) =>{
  store.dispatch('autoLogin')
  if (to.matched.some(record => record.meta.free)) {
    next()
  }  
  else if(store.state.user && store.state.user.Role == 'Admin'){
    if(to.matched.some(record => record.meta.admin)){
      next()
    }
  }
  else if(store.state.user && store.state.user.Role == 'Voter'){
    if(to.matched.some(record => record.meta.voter)){
      next()
    }
  }
  else{
    next({
      name:'login'
    })
  }
})

export default router