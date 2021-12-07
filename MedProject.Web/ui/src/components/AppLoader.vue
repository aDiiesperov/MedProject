<template>
  <div class="text-center">
    <div
      :class="{ 'spinner-border-sm': isSmall }"
      class="spinner-border text-secondary"
      role="status"
    ></div>
  </div>
</template>

<script>
export default {
  props: {
    isSmall: {
      typeof: Boolean,
      default: false,
    },
  },
};
</script>
