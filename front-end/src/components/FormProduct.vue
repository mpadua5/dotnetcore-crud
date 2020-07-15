<template>
  <div>
    <md-field>
      <label>Description</label>
      <md-input
        v-model="productAlter.Description"
      ></md-input>
    </md-field>

    <md-field>
      <label>Unit Value</label>
      <span class="md-prefix">$</span>
      <md-input
        v-model="productAlter.UnitValue"
        type="number"
      ></md-input>
    </md-field>

    <md-field>
      <label>Stock</label>
      <md-input
        v-model="productAlter.Amount"
        type="number"
      ></md-input>
    </md-field>

    <div class="md-layout md-gutter">
      <div class="md-layout-item">
        <md-field>
          <label for="unity">Unity</label>
          <md-select
            v-model="productAlter.Unity"
            name="unity"
            id="unity"
          >
            <md-option v-for="item in units" :key="item.Id" :value="item.Id">{{item.Description}}</md-option>
          </md-select>
        </md-field>
      </div>
    </div>

    <div class="md-layout md-gutter">
      <div class="md-layout-item">
        <md-field>
          <label for="category">Category</label>
          <md-select
            v-model="productAlter.Category"
            name="category"
            id="category"
          >
            <md-option
              v-for="item in categories"
              :key="item.Guid"
              :value="item.Guid"
            >{{item.Description}}</md-option>
          </md-select>
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
    </div>
  </div>
</template>

<script>
import { UnitysUtil } from "../utils";
import { ProductService, CategoryService } from '../services';

export default {
  name: "FormProduct",
  props: {
    product: Object
  },
  created() {
    if (Object.keys(this.product).length > 0) {
      this.productAlter = {...this.product};
      if (this.product.Unity !== undefined)
        this.productAlter.Unity = UnitysUtil.getUnityId(this.product.Unity);
      this.methodSave = "PUT";      
    } else {
      this.productAlter = {
        Description: null,
        Unity: 0,
        UnitValue: 0,
        Amount: 0,
        Category: null
      };
      this.methodSave = "POST";
    }
  },
  beforeMount() {
    CategoryService.getAll()
      .then(result => {
        this.categories = result.data;
        if (this.productAlter.Category !== null)
          this.productAlter.Category = this.categories.find(item => item.Description == this.productAlter.Category).Guid;
      })
      .catch(() => {
        this.categories = [];
      });
  },
  data: () => ({
    isLoading: false,
    resultService: '',
    productAlter: null,
    methodSave: '',
    units: UnitysUtil.getAllUnitys(),
    categories: []
  }),
  methods: {
    saveProduct(){
      var objSave = {
        ...this.productAlter,
        Category: this.categories.find(item => item.Guid == this.productAlter.Category)
      }
      this.isLoading = true;
      this.resultService = '';
      if(this.methodSave === "POST")
        ProductService.post(objSave)
          .then(result => {
            this.isLoading = false;
            this.resultService = result.data.message
          })
          .catch(err => {
            console.log(err);
            this.isLoading = false;
            this.resultService = 'It was not possible to insert the product, check the data provided.'
          });
      if(this.methodSave === "PUT")
        ProductService.put(objSave)
          .then(result => {
            this.isLoading = false;
            this.resultService = result.data.message
          })
          .catch(err => {
            console.log(err);
            this.isLoading = false;
            this.resultService = 'It was not possible to update the product, check the data provided.'
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