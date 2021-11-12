<template>
  <div class="input-group mb-3">
    <span class="input-group-text">{{ label }}</span>
    <input
      @input="onInput($event.target.value)"
      type="text"
      class="form-control"
      :placeholder="placeholder"
    />
  </div>
</template>

<script>
import { TYPE_FILTER } from "../constants/type-filter";
import { actions as $A } from "@store/types";

export default {
  props: ["filterKey", "label", "placeholder"],
  methods: {
    onInput(value) {
      const filter = {
        type: TYPE_FILTER.INPUT,
        filterKey: this.filterKey,
        value,
      };
      this.$store.dispatch($A.QUERY_BAR_APPLY_FILTER, filter);
    },
  },
};
</script>
