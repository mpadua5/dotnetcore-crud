<template>
  <div>
    <md-field>
      <label>Description</label>
      <md-input
        v-model="productAlter.Description"
        @keyup="() => this.$emit('changeProduct', productAlter)"
      ></md-input>
    </md-field>

    <md-field>
      <label>Unit Value</label>
      <span class="md-prefix">$</span>
      <md-input
        v-model="productAlter.UnitValue"
        type="number"
        @keyup="() => this.$emit('changeProduct', productAlter)"
      ></md-input>
    </md-field>

    <md-field>
      <label>Stock</label>
      <md-input
        v-model="productAlter.Amount"
        type="number"
        @keyup="() => this.$emit('changeProduct', productAlter)"
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
            @md-selected="() => this.$emit('changeProduct', productAlter)"
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
            @change="() => this.$emit('changeProduct', productAlter)"
          >
            <md-option v-for="item in units" :key="item.Id" :value="item.Id">{{item.Description}}</md-option>
          </md-select>
        </md-field>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "FormProduct",
  props: {
    product: Object
  },
  created() {
    if (this.product !== undefined) this.productAlter = this.product;
    else
      this.productAlter = {
        Description: null,
        Unity: 0,
        UnitValue: 0,
        Amount: 0,
        Category: null
      };
    // eslint-disable-next-line no-debugger
    debugger;
  },
  data: () => ({
    productAlter: null,
    units: [
      {
        Id: 1,
        Description: "Kg"
      },
      {
        Id: 2,
        Description: "Lt"
      },
      {
        Id: 3,
        Description: "Ml"
      },
      {
        Id: 4,
        Description: "Mg"
      }
    ]
  })
};
</script>

<style scoped>
.md-select-menu-container {
  z-index: 99999 !important;
}
</style>