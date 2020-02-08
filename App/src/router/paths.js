/**
 * Define all of your application routes here
 * for more information on routes, see the
 * official documentation https://router.vuejs.org/en/
 */
export default [
  {
    path: '',
    // Relative to /src/views
    view: 'Dashboard'
  },
  {
    path: '/tenent',
    name: 'Tenent',
    view: 'Tenent'
  },
  {
    path: '/user',
    name: 'User Profile',
    view: 'user/user',
    children:[
      {
        path: 'userlist',
        name: 'User List',
        view: 'userlist'
      },
      {
        path: 'usercreate/:id?',
        name: 'User Create',
        view: 'usercreate'
      }
    ]
  },
  {
      path: '/invoice',
      name: 'Invoice',
      view: 'Invoice'
  },
  {
    path: '/table-list',
    name: 'Table List',
    view: 'TableList'
  },
  {
    path: '/typography',
    view: 'Typography'
  },
  {
    path: '/icons',
    view: 'Icons'
  },
  {
    path: '/maps',
    view: 'Maps'
  },
  {
    path: '/notifications',
    view: 'Notifications'
  },
  {
    path: '/upgrade',
    name: 'Upgrade to PRO',
    view: 'Upgrade'
  }
]
