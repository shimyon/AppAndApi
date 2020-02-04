<template>
  <v-container fill-height fluid grid-list-xl>
    <v-layout justify-center wrap>
      <v-flex xs12 md8>
        <material-card color="green" title="Edit Profile" text="Complete your profile">
          <v-form>
            <v-container py-0>
              <v-layout wrap>
                <!-- 
                <v-flex xs12 md4>
                  <v-text-field label="Company (disabled)" disabled />
                </v-flex> 
                -->
                <v-flex xs12 md6>
                  <v-text-field class="purple-input" v-model="UserDetails.UserName" label="User Name" />
                </v-flex>
                <v-flex xs12 md6>
                  <v-text-field label="Email Address" v-model="UserDetails.Email" class="purple-input" />
                </v-flex>
                <v-flex xs12 md6>
                  <v-text-field label="First Name" v-model="UserDetails.FirstName" class="purple-input" />
                </v-flex>
                <v-flex xs12 md6>
                  <v-text-field label="Last Name" v-model="UserDetails.SurName" class="purple-input" />
                </v-flex>
                <v-flex xs12>
                  <v-textarea
                    v-model="UserDetails.Address"
                    class="purple-input"
                    label="Address"
                    value=""
                  />
                </v-flex>
                <v-flex xs12 text-xs-right>
                  <v-btn class="mx-0 font-weight-light" @click="UpdateProfile()" color="success">Update Profile</v-btn>
                </v-flex>
              </v-layout>
            </v-container>
          </v-form>
        </material-card>
      </v-flex>
      <!-- 
      <v-flex xs12 md4>
        <material-card class="v-card-profile">
          <v-avatar slot="offset" class="mx-auto d-block" size="130">
            <img src="https://demos.creative-tim.com/vue-material-dashboard/img/marc.aba54d65.jpg" />
          </v-avatar>
          <v-card-text class="text-xs-center">
            <h6 class="category text-gray font-weight-thin mb-3">CEO / CO-FOUNDER</h6>
            <h4 class="card-title font-weight-light">Alec Thompson</h4>
            <p
              class="card-description font-weight-light"
            >Don't be scared of the truth because we need to restart the human foundation in truth And I love you like Kanye loves Kanye I love Rick Owens’ bed design but the back is...</p>
            <v-btn color="success" round class="font-weight-light">Follow</v-btn>
          </v-card-text>
        </material-card>
      </v-flex> 
      -->
    </v-layout>
  </v-container>
</template>

<script>
export default {
  data() {
    return {
      UserDetails: {
        UserName: "",
        Email: "",
        FirstName: "",
        SurName: "",
        Address: ""
      }
    }
  },
  methods: {
    UpdateProfile() {
      this.$json(this.UserDetails,"User/Create")
      .then(res =>{
        if (res.data && res.data.IsOk) {
          alert(res.data.DisplayMsg);
        }
      }).catch(err => {
        alert("Error:" + err);
      })
    }
  }
};
</script>
