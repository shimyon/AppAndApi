<template>
  <v-container fill-height fluid>
    <v-layout justify-center align-center>
      <v-flex xs12>
        <material-card
         :active-class="color"
          title="Generate Invoice"
        >
          <v-card-text>

            <ckeditor :editor="editor" v-model="editorData" :config="editorConfig"></ckeditor>
            <v-btn
              class="mx-0 font-weight-light"
              color="success"
              @click="GenerateInvoice()"
            >Generate Invoice</v-btn>
          </v-card-text>
        </material-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import env from "../environment";
const leader =
  "I will be the leader of a company that ends up being worth billions of dollars, because I got the answers. I understand culture. I am the nucleus. I think that’s a responsibility that I have, to push possibilities, to show people, this is the level that things could be at.";
const leaderShort = leader.slice(0, 105) + "...";
const material = "The Life of Material Dashboard";
const small = "Header with small subtitle";

export default {
  data: () => ({
    editor: ClassicEditor,
    editorData: "<p>Content of the editor.</p>",
    editorConfig: {
      // The configuration of the editor.
    }
  }),
  methods: {
    GenerateInvoice() {
        const senddata = {
          Data: this.editorData,
          Type: "PDF"
        };
        this.$pdf(senddata, "Invoice/GenereteFile").then(response => {
          let blob = new Blob([response.data], { type: 'application/pdf' }),
          url = window.URL.createObjectURL(blob);
          window.open(url);
        })
        .catch(err => {
          alert(err);
        });
    }
  }
};
</script>

<style lang="scss">
.tim-note {
  bottom: 10px;
  color: #c0c1c2;
  display: block;
  font-weight: 400;
  font-size: 13px;
  line-height: 13px;
  left: 0;
  margin-left: 20px;
  width: 260px;
}
.ck-editor__editable {
    min-height: 350px;
}
</style>
