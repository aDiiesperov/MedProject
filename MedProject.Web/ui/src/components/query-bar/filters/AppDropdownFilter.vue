<template>
  <div class="input-group mb-3">
    <label class="input-group-text" :for="'filter-' + config.filterKey">
      {{ config.label }}
    </label>
    <select
      @change="onSelect($event.target.value)"
      class="form-select"
      :id="'filter-' + config.filterKey"
    >
      <!-- <option disabled selected>
        {{ config.placeholder }}
      </option> -->
      <option
        v-for="item in config.items"
        :key="item.value"
        :value="item.value"
      >
        {{ item.name }}
      </option>
    </select>
  </div>
</template>

<script>
import { TYPE_FILTER } from "@/helpers/query-bar.helper";
import { actions as $A } from "@store/types";

export default {
  props: {
    config: {
      type: Object,
      required: true,
    },
  },
  methods: {
    onSelect(value) {
      const filter = {
        type: TYPE_FILTER.DROPDOWN,
        filterKey: this.config.filterKey,
        value,
      };
      this.$store.dispatch($A.QUERY_BAR_APPLY_FILTER, filter);
    },
  },
};
</script>
