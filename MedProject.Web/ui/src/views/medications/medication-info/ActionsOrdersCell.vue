<template>
  <div>
    <p v-if="!item.ItemOrders">There are not orders</p>
    <div v-else>
      <div v-for="order in item.ItemOrders" :key="order.id">
        <span class="mr-2">
          {{ order.UserName }} - {{ order.OrderedQuantity }} -
        </span>
        <span class="btn-group btn-group-sm">
          <button class="btn btn-success" @click.once="onAccept(order)">
            Accept
          </button>
          <button class="btn btn-danger" @click.once="onCancel(order)">
            Cancel
          </button>
          <button class="btn btn-primary" @click.once="onNotify(order)">
            Notify
          </button>
        </span>
      </div>
    </div>
  </div>
</template>

<script>
import { actions as $A } from "@/store/types";

export default {
  props: {
    item: {
      typeof: Object,
      required: true,
    },
  },
  methods: {
    onAccept(item) {
      this.$store.dispatch($A.MED_ACTION_ACCEPT, item.Id);
    },
    onCancel(item) {
      this.$store.dispatch($A.MED_ACTION_CANCEL, item.Id);
    },
    onNotify(item) {
      const quantity = +prompt("How much medication can you give?", 0);
      const data = {
        quantity,
        orderId: item.Id,
      };
      this.$store.dispatch($A.MED_ACTION_NOTIFY, data);
    },
  },
};
</script>

<style lang="scss" scoped>
.mr-2 {
  margin-right: 0.5em;
}
</style>
