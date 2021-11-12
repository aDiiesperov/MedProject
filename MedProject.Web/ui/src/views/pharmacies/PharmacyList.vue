<template>
  <div>
    <app-query-bar :configs="queryBarConfig" />
    <app-loader v-if="isLoading" />
    <app-table v-else :configs="tableConfigs" :data="filteredData" />
  </div>
</template>

<script>
import { mapGetters } from "vuex";
import { actions as $A, getters as $G } from "@store/types";
import AppTable from "@components/table/AppTable.vue";
import AppQueryBar from "@components/query-bar/AppQueryBar.vue";
import AppLoader from "@components/AppLoader.vue";

export default {
  components: {
    AppTable,
    AppQueryBar,
    AppLoader,
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
        sortable: true,
      },
    ],
    isLoading: true,
  }),
  computed: {
    ...mapGetters({
      pharmacies: $G.PHARMACY_LIST,
      filterData: $G.QUERY_BAR_FILTER_DATA,
    }),
    filteredData() {
      return this.filterData(this.pharmacies);
    },
  },
  mounted() {
    this.loadList();
  },
  methods: {
    loadList() {
      this.$store
        .dispatch($A.PHARMACY_LOAD_LIST)
        .finally(() => (this.isLoading = false));
    },
  },
};
</script>
