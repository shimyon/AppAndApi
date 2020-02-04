import Vue from 'vue'

// Lib imports
import axios from 'axios'
import env from "../environment";

Vue.prototype.$http = axios
// Vue.prototype.$json = axios.create({
//         headers: {
//           "content-Type": 'application/json'
//         }
//       })

Vue.prototype.$json = (senddata, methodaction) => {
  return axios({
          method: 'post',
          url: env.APIPATH + methodaction,
          "content-Type": 'application/json',
          data: senddata
    });
}
Vue.prototype.$pdf = (senddata, methodaction) => {
	return axios({
          method: 'post',
          url: env.APIPATH + methodaction,
          responseType: 'arraybuffer',
          "content-Type": 'application/json',
          data: senddata
    });
}
