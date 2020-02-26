<template>
  <v-container fill-height fluid grid-list-xl>
    <v-layout justify-center wrap>
      <v-flex xs12 md4>
         <!-- text="Complete your profile" -->
        <material-card color="green" title="New Tenent">
          <v-form>
            <v-container py-0>
              <v-layout wrap>
                <v-flex xs12 md12>
                  <v-text-field class="purple-input" label="Client Id" v-model='ClientId' />
                </v-flex>
                <v-flex xs12 md12>
                  <v-text-field class="purple-input" label="Tenent Name" v-model='TenentName' />
                </v-flex>
                <v-flex xs12 text-xs-right>
                  <v-btn @click="SaveTenent()" class="mx-0 font-weight-light" color="success">Save Tenent</v-btn>
                </v-flex>
              </v-layout>
            </v-container>
          </v-form>
        </material-card>
      </v-flex>
      <v-flex xs12 md8>
          <!-- text="Here is a subtitle for this table" -->  
        <material-card
          color="green"
          title="Tenent List"
        >
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
              <td>{{ item.ClientId }}</td>
              <td>{{ item.TenentName }}</td>
              <td>{{ item.CreatedOn }}</td>
              <td class="text-xs-right">{{ item.IsActive }}</td>
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
    SaveTenent() {
      this.$json({
        "TenentName" : this.TenentName,
        "ClientId": this.ClientId
        },"Tanent/Create")
      .then(res =>{
        if (res.data) {
          if (res.data.IsOk) {
            this.$alertify.success(res.data.DisplayMsg);
          } else {
            this.$alertify.error(res.data.DisplayMsg);
          }
          this.GetData();
        }
      }).catch(err => {
        this.$alertify.error("Error:" + err);
      })      
    },
    GetData() {
      this.$json(null, "Tanent/GetAll")
      .then(res =>{
        if (res.data) {
          this.items = res.data;
        }
      }).catch(err => {
        this.$alertify.error("Error:" + err);
      })
    }
  },
  data: () => ({
    type: ['', 'info', 'success', 'warning', 'danger'],
    TenentName:'',
    ClientId:'',
    headers: [
      {
        sortable: false,
        text: 'Client Id',
        value: 'ClientId'
      },      
      {
        sortable: false,
        text: 'Tenent Name',
        value: 'TenentName'
      },
      {
        sortable: false,
        text: 'Created On',
        value: 'CreatedOn'
      },
      {
        sortable: false,
        text: 'Active',
        value: 'IsActive'
      }
    ],
    items: []
  })
}
</script>
