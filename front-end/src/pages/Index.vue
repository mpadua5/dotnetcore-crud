<template>
  <List 
    :componentType="componentType"
    :list="listUser"
    :headerName="'Products'"
    :destiny="{ description: 'Category registration'}"
  />
</template>

<script>
import List from "../components/List";

export default {
  name: "Index",
  components: {
    List
  },
  data: () => ({
    componentType: 'PRODUCT',
    listUser: [
      {
        Guid: 1111223,
        Description: 'COLORADO',
        Unity: 2,
        UnitValue: 8.15,
        Amount: 200,
        Category: null
      },
      {
        Guid: 11111000000,
        Description: 'CAFÉ PELÉ',
        Unity: 1,
        UnitValue: 3.05,
        Amount: 300,
        Category: null
      }
    ]
  })
};
</script>