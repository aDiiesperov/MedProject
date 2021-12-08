<template>
  <div>
    <medication-info-list v-if="isPharmaciest" />
    <medication-to-order-list v-else />
  </div>
</template>

<script>
import { UserHelper } from "@/helpers";
import { getters as $G, actions as $A } from "@/store/types";
import MedicationInfoList from "./medication-info/MedicationInfoList.vue";
import MedicationToOrderList from "./medication-to-order/MedicationToOrderList.vue";

export default {
  components: { MedicationInfoList, MedicationToOrderList },
  data: () => ({
    isPharmaciest: false,
  }),
  created() {
    const user = this.$store.getters[$G.AUTH_USER];
    this.isPharmaciest = UserHelper.IsInRole(user, "pharmacist");
  },
  destroyed() {
    this.$store.dispatch($A.MED_RESET);
  },
};
</script>
