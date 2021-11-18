<template>
  <div class="input-group mb-3">
    <label class="input-group-text" :for="'filter-' + config.filterKey">
      {{ config.label }}
    </label>
    <input
      @input="onInput($event.target.value)"
      type="text"
      class="form-control"
      :placeholder="config.placeholder"
      :id="'filter-' + config.filterKey"
    />
  </div>
</template>

<script>
import { TYPE_FILTER } from "../constants/type-filter";
import { actions as $A } from "@store/types";

export default {
  props: {
    config: {
      type: Object,
      required: true,
    },
  },
  methods: {
    onInput(value) {
      const filter = {
        type: TYPE_FILTER.INPUT,
        filterKey: this.config.filterKey,
        value,
      };
      this.$store.dispatch($A.QUERY_BAR_APPLY_FILTER, filter);
    },
  },
};
</script>
