<template>
  <div>
    <!-- Name -> Apply | Cancel | Notify -->
    <p v-if="!item.ItemOrders">There are not orders</p>
    <div v-else>
      <div v-for="order in item.ItemOrders" :key="order.id">
        <span class="mr-2">
          {{ order.UserName }} - {{ order.OrderedQuantity }} -
        </span>
        <span class="btn-group btn-group-sm">
          <button class="btn btn-success">Accept</button>
          <button class="btn btn-danger">Cancel</button>
          <button class="btn btn-primary">Notify</button>
        </span>
      </div>
    </div>
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

<style lang="scss" scoped>
.mr-2 {
  margin-right: 0.5em;
}
</style>
