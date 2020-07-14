<template>
  <div class="w-screen px-20">
    <md-table md-card>
      <md-table-toolbar>
        <h1 class="md-title">Products</h1>
        <md-button class="md-fab md-primary" @click="changeShowModal(true)">
          <md-icon>add</md-icon>
        </md-button>
      </md-table-toolbar>

      <md-table-row>
        <md-table-head v-for="itemHeader in listHeader" :key="itemHeader">{{itemHeader}}</md-table-head>
        <md-table-head>Edit</md-table-head>
        <md-table-head>Delete</md-table-head>
      </md-table-row>

      <md-table-row v-for="itens in list" :key="itens">
        <md-table-cell v-for="value in itens" :key="value">{{ value }}</md-table-cell>
        <md-table-cell>EDITAR</md-table-cell>
        <md-table-cell>DELETAR</md-table-cell>
      </md-table-row>
    </md-table>

    <modal 
        v-if="showModal" 
        :componentType="componentType"
        @close="changeShowModal(false)" />
  </div>
</template>

<script>
import Modal from "../components/Modal";

export default {
  name: "Index",
  components: {
    Modal
  },
  props: {
      componentType: String,
      list: [Object]
  },
  computed: {
      listHeader() {
          return Object.keys(this.list[0])
      }
  },
  data: () => ({
    showModal: false,
  }),
  methods: {
      changeShowModal(value) {
          this.showModal = value;
      }
  }
};
</script>