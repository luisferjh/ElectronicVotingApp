import Vue from 'vue'
import Vuex from 'vuex'
import decode from 'jwt-decode'
import router from './router'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {    
    token:null,
    user:null,
    test:48
  },
  mutations: {
    setToken:function(state,token){
      state.token = token          
    },
    setUser:function(state,user){
      state.user = user
    }
  },
  actions: {
    saveToken({commit},token){
      commit('setToken',token)
      commit('setUser',decode(token))
      localStorage.setItem('token',token)
    },
    autoLogin({commit}){
      let token = localStorage.getItem('token')
      if(token){
        commit('setToken',token)
        commit('setUser',decode(token))
      }
      //router.push({name:'home'})
    },
    exit({commit}){
      commit('setToken',null)
      commit('setUser', null)
      localStorage.removeItem('token')
      router.push({name:'login'})
    }   
  }
})
