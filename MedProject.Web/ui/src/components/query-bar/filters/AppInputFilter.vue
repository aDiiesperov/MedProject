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
export default {
  props: ["filterKey", "label", "placeholder"],
  methods: {
    onInput(value) {
      const filter = { filterKey: this.filterKey, value };
      this.$store.dispatch("queryBarStore/applyFilter", filter);
    },
  },
};
</script>
