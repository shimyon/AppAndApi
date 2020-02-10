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


  <v-dialog
      v-model="ShowViewer"
      max-width="100%"
      height="500"
    >
      <v-card>
        <v-card-title class="headline">Invoice</v-card-title>

        <iframe v-bind:src="pdfPath" type="application/pdf" width="100%" height="400" style="overflow: auto;">
        </iframe>

        <v-card-actions>
          <v-spacer></v-spacer>

          <v-btn
            color="danger darken-1"
            text
            @click="ShowViewer = false"
          >
            Close
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>


      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";

export default {
  data: () => ({
    ShowViewer: false,
    pdfPath: null,
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
          this.ShowViewer = true;
          let blob = new Blob([response.data], { type: 'application/pdf' }),
          url = window.URL.createObjectURL(blob);
          this.pdfPath = url;
          // document.querySelector("iframe").src = url;
          // window.open(url);
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

.pdfobject-container {
  position: fixed;
  top: 0;
  left: 10%;
  width: 80%;
  height: 80%;
  z-index: 10;
  background-color: #e0e0e0;
}
</style>
