<template>
  <v-container fill-height fluid grid-list-xl>
    <v-layout justify-center wrap>
      <v-flex xs12 md12>
        <material-card
          color="green"
          title="Users List"
        >
        <v-fab-transition>
          <v-btn :to="'/user/usercreate'" color="pink" fab dark round small absolute bottom right>
            <v-icon>mdi-plus</v-icon>
          </v-btn>
        </v-fab-transition>
          <v-data-table
            :headers="headers"
            :items="items"
            hide-actions
          >
            <template
              slot="headerCell"
              slot-scope="{ header }"
            >
              <span
                class="subheading font-weight-light text-success text--darken-3"
                v-text="header.text"
              />
            </template>
            <template
              slot="items"
              slot-scope="{ item }"
            >
              <td>{{ item.UserName }}</td>
              <td>{{ item.FirstName }}</td>
              <td>{{ item.SurName }}</td>
              <td>{{ item.CreatedOn }}</td>
              <td>
                <div class="d-flex">
                    <v-tooltip top content-class="top">
                      <v-btn slot="activator" :to="'usercreate/' + item.Id" class="v-btn--simple" color="success" icon>
                        <v-icon color="primary">mdi-pencil</v-icon>
                      </v-btn>
                      <span>Edit</span>
                    </v-tooltip>
                    <v-tooltip top content-class="top">
                      <v-btn slot="activator" class="v-btn--simple" color="danger" icon>
                        <v-icon color="error">mdi-close</v-icon>
                      </v-btn>
                      <span>Remove</span>
                    </v-tooltip>
                  </div>
              </td>
            </template>
          </v-data-table>
        </material-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import {  mapMutations,  mapState} from 'vuex'
export default {
  beforeMount() {
    this.GetData();
  },
  methods: {
    GetData() {
      this.$json(null, "User/GetAll")
      .then(res =>{
        if (res.data) {
          this.items = res.data;
        }
      }).catch(err => {
        alert("Error:" + err);
      })
    }
  },
  data: () => ({
    type: ['', 'info', 'success', 'warning', 'danger'],
    TenentName:'',
    headers: [
      {
        sortable: false,
        text: 'User Name',
        value: 'UserName'
      },
      {
        sortable: false,
        text: 'First Name',
        value: 'FirstName'
      },
      {
        sortable: false,
        text: 'Sur Name',
        value: 'Sur1Name'
      },
      {
        sortable: false,
        text: 'Created On',
        value: 'CreatedOn'
      },
      {
        sortable: false,
        text: '',
        value: ''
      }
    ],
    items: []
  })
}
</script>
