<template>
  <div>
    <app-query-bar :configs="queryBarConfig" />
    <app-loader v-if="isLoading" />
    <app-table v-else :configs="tableConfigs" :data="filteredData" />
  </div>
</template>

<script>
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
    queryBarConfig: [],
    tableConfigs: [],
    isLoading: false,
  }),
  computed: {
    filteredData() {
      return [];
    },
  },
};
</script>
