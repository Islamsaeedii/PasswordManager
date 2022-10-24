import { createRouter, createWebHistory } from 'vue-router'
import NProgress from 'nprogress';
import SignIn from '../views/SignIn.vue'
const routes = [
  {
    path: '/',
    name: 'Home',
    component: SignIn,

  },

  {
    path: '/signUp',
    name: 'signUp',
    component: () => import('../views/SignUp.vue')
  },
  {
    path: '/info',
    name: 'Info',
    component: () => import('../views/Home.vue')
  },
  {
    path: '/signIn',
    name: 'signIn',
    component: () => import('../views/SignIn.vue')
  },
  {
    path: '/info/create',
    name: 'Info Create',
    component: () => import('../views/products/ProductCreate.vue')
  },
  {
    path: '/products/edit/:id',
    name: 'ProductEdit',
    params:true,
    component: () => import('../views/products/ProductEdit.vue')
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

router.beforeResolve((to, from, next) => {
  if (to.name) {
    NProgress.start()
  }
  next()
});

router.afterEach(() => {
  NProgress.done()
});

export default router
