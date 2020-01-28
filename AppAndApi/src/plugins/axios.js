import Vue from 'vue'

// Lib imports
import axios from 'axios'

Vue.prototype.$http = axios
Vue.prototype.$json = axios.create({
        headers: {
          "content-Type": 'application/json'
        }
      })
