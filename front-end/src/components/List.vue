<template>
  <div class="w-screen px-20 pt-5">
    <md-table md-card>
      <md-table-toolbar class="mb-5">
        <h1 class="md-title">{{this.headerName}}</h1>
        <md-button class="md-fab md-primary" @click="changeShowModal(true)">
          <md-icon>add</md-icon>
        </md-button>
      </md-table-toolbar>
      <a :href="this.destiny.url" class="mb-5"><h4 class="mx-6">{{this.destiny.description}}</h4></a>

      <md-table-row>
        <md-table-head v-for="itemHeader in listHeader" :key="itemHeader">{{itemHeader}}</md-table-head>
        <md-table-head v-if="listHeader.length > 0">Edit</md-table-head>
        <md-table-head v-if="listHeader.length > 0">Delete</md-table-head>
      </md-table-row>

      <md-table-row v-for="itens in list" :key="itens[0]">
        <md-table-cell v-for="value in itens" :key="value">{{value}}</md-table-cell>

        <md-table-cell>
          <md-button
            class="md-icon-button md-dense md-raised md-primary"
            @click="changeShowModal(true, itens)"
          >
            <md-icon>edit</md-icon>
          </md-button>
        </md-table-cell>

        <md-table-cell>
          <md-progress-spinner v-if="isRemoveLoading" class="md-accent" :md-diameter="30" md-mode="indeterminate" />
          <md-button v-if="!isRemoveLoading" class="md-icon-button md-dense md-raised md-accent" @click="$emit('removeItem', itens)">
            <md-icon>delete</md-icon>
          </md-button>
        </md-table-cell>
      </md-table-row>
    </md-table>

    <modal
      v-if="showModal"
      :componentType="componentType"
      :obj="obj"
      @close="changeShowModal(false)"
    />
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
    headerName: String,
    destiny: Object,
    componentType: String,
    list: Array,
    isRemoveLoading: Boolean
  },
  computed: {
    listHeader() {
        if (this.list.length === 0)
            return [];
        return Object.keys(this.list[0]);
    }
  },
  data: () => ({
    showModal: false,
    obj: null
  }),
  methods: {
    changeShowModal(value, obj) {
      this.obj = obj;
      this.showModal = value;
      if (!value)
        this.$emit('loadList');
    }
  }
};
</script>