<template>
  <div>
    <app-query-bar :configs="queryBarConfig" />
    <app-loader v-if="isLoading" />
    <app-table v-else :configs="tableConfigs" :data="filteredData" />
  </div>
</template>

<script>
import { mapGetters } from "vuex";
import axios from "axios";
import AppTable from "../../components/table/AppTable.vue";
import AppQueryBar from "../../components/query-bar/AppQueryBar.vue";
import AppLoader from "../../components/AppLoader.vue";

export default {
  components: {
    AppTable,
    AppQueryBar,
    AppLoader,
  },
  mounted() {
    axios
      .get(`${process.env.VUE_APP_API_URL}/pharmacy`)
      .then((response) => (this.data = response.data))
      .finally(() => (this.isLoading = false));
  },
  data: () => ({
    queryBarConfig: [
      {
        type: "input",
        filterKey: "Name",
        label: "Name",
        placeholder: "Search...",
      },
    ],
    tableConfigs: [
      { prop: "Name", width: 750, sortable: true },
      { prop: "StateCode", name: "State Code", width: 400, sortable: true },
      { prop: "Address", width: 1000, sortable: true },
      {
        prop: "Email",
        name: "Contact Email",
        width: 550,
        sortable: true,
      },
      {
        prop: "Phone",
        name: "Contact Phone",
        width: 550,
      },
    ],
    data: [],
    isLoading: true,
  }),
  computed: {
    ...mapGetters({
      filterData: "queryBarStore/filterData",
    }),
    filteredData() {
      return this.filterData(this.data);
    },
  },
};
</script>
