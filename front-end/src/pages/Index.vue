<template>
  <List
    :componentType="componentType"
    :list="listProduct"
    :headerName="'Products'"
    :destiny="{ description: 'Category registration'}"
  />
</template>

<script>
import List from "../components/List";
import { ProductService } from "../services";

export default {
  name: "Index",
  components: {
    List
  },
  mounted() {
    // eslint-disable-next-line no-debugger
    debugger;
    console.log(process.env.VUE_APP_API_URL);
    ProductService.getAll()
      .then(result => {
        this.listProduct = result;
        // eslint-disable-next-line no-debugger
        debugger;
      })
      .catch(() => {        
        // eslint-disable-next-line no-debugger
        debugger
        this.listProduct = [];
      });
  },
  data: () => ({
    componentType: "PRODUCT",
    listProduct: null
    // listUser: [
    //   {
    //     Guid: 1111223,
    //     Description: 'COLORADO',
    //     Unity: 2,
    //     UnitValue: 8.15,
    //     Amount: 200,
    //     Category: null
    //   },
    //   {
    //     Guid: 11111000000,
    //     Description: 'CAFÉ PELÉ',
    //     Unity: 1,
    //     UnitValue: 3.05,
    //     Amount: 300,
    //     Category: null
    //   }
    // ]
  })
};
</script>