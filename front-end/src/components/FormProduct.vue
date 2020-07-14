<template>
  <div>
    <md-field>
      <label>Description</label>
      <md-input v-model="initial"></md-input>
    </md-field>

    <md-field>
      <label>Unit Value</label>
      <span class="md-prefix">$</span>
      <md-input v-model="number" type="number"></md-input>
    </md-field>

    <md-field>
      <label>Stock</label>
      <md-input v-model="number" type="number"></md-input>
    </md-field>

    <div class="md-layout md-gutter">
      <div class="md-layout-item">
        <md-field>
          <label for="amount">Amount</label>
          <md-select v-model="amount" name="amount" id="amount">
            <md-option v-for="item in units" :key="item.Id" :value="item.Id" >{{item.Description}}</md-option>
          </md-select>
        </md-field>
      </div>
    </div>

    <div class="md-layout md-gutter">
      <div class="md-layout-item">
        <md-field>
          <label for="amount">Category</label>
          <md-select v-model="category" name="category" id="category">
            <!-- <md-option v-for="item in units" :key="item.Id" :value="item.Id" >{{item.Description}}</md-option> -->
          </md-select>
        </md-field>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "FormProduct",
  data: () => ({
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