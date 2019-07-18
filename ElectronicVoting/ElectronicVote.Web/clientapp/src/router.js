import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import Candidate from './views/Candidate.vue'
import Login from './views/Login.vue'
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
      path: '/about',
      name: 'about',
      component: () => import(/* webpackChunkName: "about" */ './views/About.vue')
    }
  ]
})

router.beforeEach((to, from, next) =>{
  if (to.matched.some(record => record.meta.free)) {
    next()
  }
  // else if(store.state.usuario && store.state.usuario.role == 'admin'){

  // }
})

export default router