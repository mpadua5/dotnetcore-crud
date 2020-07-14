<template>
  <List 
    :componentType="componentType"
    :list="listUser"
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
        Id: 1,
        Name: "Shawna Dubbin",
        Email: "sdubbin0@geocities.com",
        Gender: "Male",
        JobTitle: "Assistant Media Planner"
      },
      {
        Id: 2,
        Name: "Odette Demageard",
        Email: "odemageard1@spotify.com",
        Gender: "Famale",
        JobTitle: "Account Coordinator"
      },
      {
        Id: 3,
        Name: "Vera Taleworth",
        Email: "vtaleworth2@google.ca",
        Gender: "Male",
        JobTitle: "Community Outreach Specialist"
      }
    ]
  })
};
</script>