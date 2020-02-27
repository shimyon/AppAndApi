<template>
  <v-container fill-height fluid grid-list-xl>
    <v-layout justify-center wrap>
      <v-flex xs12 md4>
        <material-card color="green" title="Login" text="Fill login details">
          <v-form>
            <v-container py-0>
              <v-layout wrap>
                <!-- 
                <v-flex xs12 md4>
                  <v-text-field label="Company (disabled)" disabled />
                </v-flex> 
                -->
                <v-flex xs12 md12>
                  <v-text-field label="Client Id" v-model="UserDetails.ClientId" class="purple-input" />
                </v-flex>
                <v-flex xs12 md12>
                  <v-text-field class="purple-input" v-model="UserDetails.UserName" label="User Name" />
                </v-flex>
                <v-flex xs12 md12>
                  <v-text-field label="Password" v-model="UserDetails.Password" class="purple-input" />
                </v-flex>
                <v-flex xs12 text-xs-center>
                  <v-btn class="mx-0 font-weight-light" @click="Login()" color="red">Login</v-btn>
                </v-flex>
              </v-layout>
            </v-container>
          </v-form>
        </material-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
export default {
  data() {
    return {
      UserDetails: {
        ClientId: "",
        UserName: "",
        Password: ""
      }
    }
  },
  beforeMount() {
    // this.GetProfile();
  },
  methods: {
    // GetProfile() {
    //   if (!this.$route.params.id) return;
    //   this.$json(null, `User/Get?tblId=${this.$route.params.id}`)
    //   .then(res => {
    //     if (res.data) {
    //       this.UserDetails = res.data;
    //     }
    //   }).catch(err => {
    //     this.$alertify.error("Error:" + err);
    //   })
    // },
    Login() {
      let actionUrl = "Tenent/Login";
      this.$json(this.UserDetails, actionUrl)
      .then(res =>{
        if (res.data) { // && res.data.IsOk
          // alert(res.data.DisplayMsg);
          if (res.data.IsOk) {
            this.$alertify.success(res.data.DisplayMsg);
          } else {
            this.$alertify.error(res.data.DisplayMsg);
          }
        }
      }).catch(err => {
        // alert("Error:" + err);
        this.$alertify.error("Error:" + err);
      })
    }
  }
};
</script>
