<template>
  <div>
    <div
      class="col-lg-3 col-md-4 col-sm-3"
      v-for="config in configs"
      :key="config.filterKey"
    >
      <template v-if="config.type === 'input'">
        <app-input-filter :config="config" />
      </template>

      <template v-else-if="config.type === 'dropdown'">
        <app-dropdown-filter :config="config" />
      </template>

      <template v-else>Filters isn't supported!</template>
    </div>
  </div>
</template>

<script>
import AppInputFilter from "./filters/AppInputFilter.vue";
import AppDropdownFilter from "./filters/AppDropdownFilter.vue";
import { actions as $A } from "@store/types";

export default {
  components: { AppInputFilter, AppDropdownFilter },
  props: {
    configs: {
      type: Array,
      required: true,
    },
  },
  created() {
    // TODO: add query params for querybar (it isn't a requirement)
    const query = this.$route.query;
    console.log(query);
  },
  destroyed() {
    this.$store.dispatch($A.QUERY_BAR_RESET_FILTERS);
  },
};
</script>
