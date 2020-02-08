/**
 * Vue Router
 *
 * @library
 *
 * https://router.vuejs.org/en/
 */

// Lib imports
import Vue from 'vue'
import VueAnalytics from 'vue-analytics'
import Router from 'vue-router'
import Meta from 'vue-meta'

// Routes
import paths from './paths'

function route (path, view, name, children) {
  let mainview = (name || view);
  let letchildren = []; 
  (children || []).forEach(c => {
      let childview = (c.name || c.view)
      letchildren.push({
        name: childview,
        path: c.path,
        component:(resolve) => import(
            `@/views${path}/${c.view}.vue`
          ).then(resolve) 
      })
  });
  return {
    name: mainview,
    path,
    component: (resolve) => import(
      `@/views/${view}.vue`
    ).then(resolve)
    ,children: letchildren
  };
}

Vue.use(Router)

// Create a new router
const globalroute = paths.map(path => route(path.path, path.view, path.name, path.children)).concat([
    { path: '*', redirect: '/' }
  ]);
// alert(JSON.stringify(globalroute));
const router = new Router({
  mode: 'history',
  routes: globalroute,
  scrollBehavior (to, from, savedPosition) {
    if (savedPosition) {
      return savedPosition
    }
    if (to.hash) {
      return { selector: to.hash }
    }
    return { x: 0, y: 0 }
  }
})

Vue.use(Meta)

// Bootstrap Analytics
// Set in .env
// https://github.com/MatteoGabriele/vue-analytics
if (process.env.GOOGLE_ANALYTICS) {
  Vue.use(VueAnalytics, {
    id: process.env.GOOGLE_ANALYTICS,
    router,
    autoTracking: {
      page: process.env.NODE_ENV !== 'development'
    }
  })
}

export default router
