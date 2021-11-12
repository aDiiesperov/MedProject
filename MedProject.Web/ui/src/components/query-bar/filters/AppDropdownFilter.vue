<template>
  <div class="input-group mb-3">
    <label class="input-group-text" for="inputGroupSelect01">{{ label }}</label>
    <select
      @change="onSelect($event.target.value)"
      class="form-select"
      id="inputGroupSelect01"
    >
      <!-- <option disabled selected>
        {{ placeholder }}
      </option> -->
      <option v-for="item in items" :key="item.value" :value="item.value">
        {{ item.name }}
      </option>
    </select>
  </div>
</template>

<script>
import { TYPE_FILTER } from "../constants/type-filter";
import { actions as $A } from "@store/types";

export default {
  props: ["filterKey", "items", "label", "placeholder"],
  methods: {
    onSelect(value) {
      const filter = {
        type: TYPE_FILTER.DROPDOWN,
        filterKey: this.filterKey,
        value,
      };
      this.$store.dispatch($A.QUERY_BAR_APPLY_FILTER, filter);
    },
  },
};
</script>
