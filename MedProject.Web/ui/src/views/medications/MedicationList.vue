<template>
  <div>
    <!-- <app-query-bar :configs="queryBarConfig" /> -->
    <app-loader v-if="isLoading" />
    <app-table v-else :configs="tableConfigs" :data="medsToOrder" />
  </div>
</template>

<script>
import AppTable from "@components/table/AppTable.vue";
import AppLoader from "@components/AppLoader.vue";
import { actions as $A, getters as $G } from "@store/types";
import { mapGetters } from "vuex";
import { actionResolver } from "./action.resolver";

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
      },
      {
        prop: "Medication",
        width: 700,
      },
      {
        name: "Total Quantity",
        prop: "TotalQuantity",
        width: 400,
      },
      {
        name: "Status",
        width: 400,
        valueResolver: (item) =>
          item.Status ? `${item.Status} (${item.OrderedQuantity})` : "—",
      },
      {
        name: "Actions",
        width: 700,
        type: "button",
        buttonsResolver: actionResolver,
      },
    ],
    isLoading: false,
  }),
  computed: {
    ...mapGetters({
      medsToOrder: $G.MED_MEDS_TO_ORDER,
      filters: $G.QUERY_BAR_LIST,
    }),
  },
  mounted() {
    this.loadList();
  },
  methods: {
    loadList() {
      this.$store
        .dispatch($A.MED_LOAD_MEDS_TO_ORDER)
        .finally(() => (this.isLoading = false));
    },
  },
};
</script>
