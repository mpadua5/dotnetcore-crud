<template>
  <List
    :componentType="componentType"
    :list="listProduct"
    :headerName="'Products'"
    :destiny="{ description: 'Category registration'}"
    :isRemoveLoading="isRemoveLoading"
    @loadList="loadItens"
    @removeItem="removeItem"
  />
</template>

<script>
import List from "../components/List";
import { ProductService } from "../services";
import { UnitysUtil } from "../utils";

export default {
  name: "Index",
  components: {
    List
  },
  beforeMount() {
    this.loadItens();
  },
  data: () => ({
    isRemoveLoading: false,
    componentType: "PRODUCT",
    listProduct: []    
  }),
  methods: {
    loadItens() {
      ProductService.getAll()
      .then(result => {
        this.listProduct = result.data;
        this.listProduct.map(item => {
          item.Unity = UnitysUtil.getUnityDescription(item.Unity);
          item.Category = item.Category != null ? item.Category.Description : null;
        });
      })
      .catch(() => {
        this.listProduct = [];
      });
    },
    removeItem(obj) {
      this.isRemoveLoading = true;
      ProductService.delete(obj.Guid)
        .then(() => {
            this.isRemoveLoading = false;
            this.loadItens();
          })
          .catch(() => {
            this.isLoading = false;
          });
    }
  }
};
</script>