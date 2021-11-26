<template>
  <div>
    <p class="mb-1" v-for="pharmacy in item.Pharmacies" :key="pharmacy.Name">
      {{ pharmacy.Name }} - {{ pharmacy.AssignDate | formatDate }}
    </p>
  </div>
</template>

<script>
export default {
  props: {
    item: {
      typeof: Object,
      required: true,
    },
  },
};
</script>
