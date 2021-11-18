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
import { DateHelper } from "@helpers";
import AppTable from "@components/table/AppTable.vue";
import AppQueryBar from "@components/query-bar/AppQueryBar.vue";
import AppLoader from "@components/AppLoader.vue";
import { TYPE_FILTER } from "@/components/query-bar/constants/type-filter";

const DATE_FILTER_KEY = "PharmacyAssignDate";

export default {
  components: {
    AppTable,
    AppQueryBar,
    AppLoader,
  },
  data: () => ({
    queryBarConfig: [
      {
        type: TYPE_FILTER.DROPDOWN,
        filterKey: DATE_FILTER_KEY,
        manualHandling: true,
        items: [
          { name: "No", value: null },
          { name: "One month", value: 1 },
          { name: "Three monthes", value: 3 },
        ],
        label: "Date",
        placeholder: "Date...",
      },
    ],
    tableConfigs: [
      { prop: "FirstName", name: "First Name", width: 750, sortable: true },
      { prop: "LastName", name: "Last Name", width: 750, sortable: true },
      { prop: "StateCode", name: "State Code", width: 400, sortable: true },
      {
        prop: "PharmacyName",
        name: "Pharmacy Name",
        width: 750,
        sortable: true,
      },
      {
        prop: DATE_FILTER_KEY,
        name: "Assign Date",
        type: "date",
        width: 400,
        sortable: true,
      },
    ],
    isLoading: true,
  }),
  computed: {
    ...mapGetters({
      patients: $G.PATIENT_LIST,
      filters: $G.QUERY_BAR_LIST,
    }),
    filteredData() {
      const dateFilter = this.filters.find(
        (f) => f.filterKey === DATE_FILTER_KEY
      );

      if (dateFilter) {
        return this.filterByDate(this.patients, dateFilter);
      }

      // we can add additional default filters at any time.

      return this.patients;
    },
  },
  mounted() {
    this.loadList();
  },
  methods: {
    loadList() {
      this.$store
        .dispatch($A.PATIENT_LOAD_LIST)
        .finally(() => (this.isLoading = false));
    },
    // manual filter
    filterByDate(patients, filter) {
      if (!filter.value) return patients;

      const prevMonths = DateHelper.getPrevMonth(filter.value);
      return patients.filter((d) => new Date(d[DATE_FILTER_KEY]) >= prevMonths);
    },
  },
};
</script>
