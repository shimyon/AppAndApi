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
          headers: {
            "content-Type": 'application/json',
            'tenentid': localStorage['tenentid'] || ''
          },
          data: senddata
      });
}

Vue.prototype.$pdf = (senddata, methodaction) => {
	return axios({
          method: 'post',
          url: env.APIPATH + methodaction,
          responseType: 'arraybuffer',
          headers: {
            "content-Type": 'application/json',
            'tenentid': localStorage['tenentid'] || ''
          },
          data: senddata
      });
}
