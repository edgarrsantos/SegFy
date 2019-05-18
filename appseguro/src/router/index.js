import Vue from 'vue'
import VueRouter from 'vue-router'

import home from '../components/home'
import apolice from '../components/apolice'

Vue.use(VueRouter)

const routes = [
    {
        path: '/', 
        name:'default', 
        component: home
    },
    {
        path: '/home', 
        name:'home', 
        component: home
    },
    {
        path: '/apolices', 
        name:'apolice', 
        component: apolice
    }
]

const router = new VueRouter({
    routes,
    mode: 'history',
    linkActiveClass: 'active'
})

export default router