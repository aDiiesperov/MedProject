<template>
  <div>
    <!-- <app-query-bar :configs="queryBarConfig" /> -->
    <app-loader v-if="isLoading" />
    <app-table v-else :configs="tableConfigs" :data="medsInfo" />
  </div>
</template>

<script>
import AppTable from "@components/table/AppTable.vue";
import AppLoader from "@components/AppLoader.vue";
import { actions as $A, getters as $G } from "@store/types";
import { mapGetters } from "vuex";
import ActionsOrdersCell from "./ActionsOrdersCell.vue";

export default {
  components: {
    AppTable,
    AppLoader,
  },
  data: () => ({
    queryBarConfig: [],
    tableConfigs: [
      {
        prop: "Pharmacy",
        width: 700,
        sortable: true,
      },
      {
        prop: "Medication",
        width: 700,
        sortable: true,
      },
      {
        name: "Total Quantity",
        prop: "TotalQuantity",
        width: 400,
        sortable: true,
      },
      {
        name: "Actions",
        width: 700,
        component: ActionsOrdersCell,
      },
    ],
    isLoading: false,
  }),
  computed: {
    ...mapGetters({
      medsInfo: $G.MED_MEDS_INFO,
    }),
  },
  mounted() {
    this.loadList();
  },
  methods: {
    loadList() {
      this.$store
        .dispatch($A.MED_LOAD_MEDS_INFO)
        .finally(() => (this.isLoading = false));
    },
  },
};
</script>
