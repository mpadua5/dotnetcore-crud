<template>
  <List
    :componentType="componentType"
    :list="listCategory"
    :headerName="'Category'"
    :destiny="{ description: 'Product registration', url: '/' }"
    :isRemoveLoading="isRemoveLoading"
    @loadList="loadItens"
    @removeItem="removeItem"
  />
</template>

<script>
import List from "../components/List";
import { CategoryService } from "../services";

export default {
  name: "Category",
  components: {
    List
  },
  beforeMount() {
    this.loadItens();
  },
  data: () => ({
    isRemoveLoading: false,
    componentType: "CATEGORY",
    listCategory: []
  }),
  methods: {
    loadItens() {
      CategoryService.getAll()
      .then(result => {
        this.listCategory = result.data;
      })
      .catch(() => {
        this.listCategory = [];
      });
    },
    removeItem(obj) {
      this.isRemoveLoading = true;
      CategoryService.delete(obj.Guid)
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