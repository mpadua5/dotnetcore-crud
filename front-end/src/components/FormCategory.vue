<template>
  <div>
    <md-field>
      <label>Description</label>
      <md-input v-model="categoryAlter.Description"></md-input>
    </md-field>

    <md-button v-if="!isLoading" class="md-raised md-primary" @click="() => this.saveProduct()">Save</md-button>
    <md-button v-if="!isLoading" class="md-accent" @click="() => this.$emit('close')">Cancel</md-button>
    <div v-if="isLoading" class="flex justify-center">
      <md-progress-spinner class="md-primary" :md-diameter="30" md-mode="indeterminate" />
    </div>
    <div v-if="resultService != ''" class="flex justify-end">
      <span class="text-xs text-red-700">{{resultService}}</span>
    </div>
  </div>
</template>

<script>
import { UnitysUtil } from "../utils";
import { CategoryService } from "../services";

export default {
  name: "FormCategory",
  props: {
    category: Object
  },
  created() {
    if (Object.keys(this.category).length > 0) {
      this.categoryAlter = { ...this.category };
      this.methodSave = "PUT";
    } else {
      this.categoryAlter = {
        Description: null
      };
      this.methodSave = "POST";
    }
  },
  data: () => ({
    isLoading: false,
    resultService: "",
    categoryAlter: null,
    methodSave: "",
    units: UnitysUtil.getAllUnitys(),
    categories: []
  }),
  methods: {
    saveProduct() {
      var objSave = {
        ...this.categoryAlter,        
      };
      this.isLoading = true;
      this.resultService = "";
      if (this.methodSave === "POST")
        CategoryService.post(objSave)
          .then(result => {
            this.isLoading = false;
            this.resultService = result.data.message;
          })
          .catch(err => {
            console.log(err);
            this.isLoading = false;
            this.resultService =
              "It was not possible to insert the product, check the data provided.";
          });
      if (this.methodSave === "PUT")
        CategoryService.put(objSave)
          .then(result => {
            this.isLoading = false;
            this.resultService = result.data.message;
          })
          .catch(err => {
            console.log(err);
            this.isLoading = false;
            this.resultService =
              "It was not possible to update the product, check the data provided.";
          });
    }
  }
};
</script>

<style scoped>
.md-select-menu-container {
  z-index: 99999 !important;
}
</style>