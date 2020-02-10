<template>
  <v-app>
    <core-filter />

    <core-toolbar />

    <core-drawer />

    <core-view />
	
	<div v-if="isLoading">
		<div class="lds-ellipsis-wrap">
	    </div>
	  	<div class="lds-ellipsis">
	  		<img src="./img/loading.gif" style="height: 200px;" />
	  	</div>
  	</div>
    
  </v-app>
</template>

<style lang="scss">
@import '@/styles/index.scss';

.v-datatable thead th.column.sortable i {
  vertical-align: unset;
}

.lds-ellipsis-wrap {
 height:100%;
 width: 100%;
 position: absolute;
 top: 0;
 right: 0;
 background: #000;
 opacity: 0.1;
 z-index:10000;
}

.lds-ellipsis {
  display: inline-block;
  position: fixed;
  top: 40%;
  left: 40%;
  width: 64px;
  height: 64px;
}
</style>
<script>
import axios from 'axios';

export default {
  data() {
    return {
      refCount: 0,
      isLoading: false
    }
  },
  methods: {
    setLoading(isLoading) {
      if (isLoading) {
        this.refCount++;
        this.isLoading = true;
      } else if (this.refCount > 0) {
        this.refCount--;
        this.isLoading = (this.refCount > 0);
      }
    }
  },
  created() {
    axios.interceptors.request.use((config) => {
      this.setLoading(true);
      return config;
    }, (error) => {
      this.setLoading(false);
      return Promise.reject(error);
    });

    axios.interceptors.response.use((response) => {
      this.setLoading(false);
      return response;
    }, (error) => {
      this.setLoading(false);
      return Promise.reject(error);
    });
  }
};
</script>

