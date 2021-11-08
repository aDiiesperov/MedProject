<template>
  <div>
    <div
      class="col-lg-3 col-md-4 col-sm-3"
      v-for="config in configs"
      :key="config.filterKey"
    >
      <template v-if="config.type === 'input'">
        <app-input-filter
          :filterKey="config.filterKey"
          :label="config.label"
          :placeholder="config.placeholder"
        />
      </template>

      <template v-else-if="config.type === 'dropdown'"> dropdown </template>

      <template v-else>Filters isn't supported!</template>
    </div>
  </div>
</template>

<script>
import AppInputFilter from "./filters/AppInputFilter.vue";

export default {
  components: { AppInputFilter },
  props: ["configs"],
  created() {
    // TODO: add query params for querybar
    const query = this.$route.query;
    console.log(query);
  },
  destroyed() {
    this.$store.dispatch("queryBarStore/resetFilters");
  },
};
</script>
