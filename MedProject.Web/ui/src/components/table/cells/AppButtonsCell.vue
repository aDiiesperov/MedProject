<template>
  <div>
    <app-loader v-if="isLoading" />
    <div v-else>
      <button
        v-for="btnConfig in btnConfigs"
        :key="btnConfig.name"
        :class="btnConfig.cssClass"
        @click="onClick(btnConfig)"
      >
        {{ btnConfig.name }}
      </button>
    </div>
  </div>
</template>

<script>
import AppLoader from "../../AppLoader.vue";

export default {
  components: {
    AppLoader,
  },
  props: {
    config: {
      typeof: Object,
      required: true,
    },
    item: {
      typeof: Object,
      required: true,
    },
  },
  data: () => ({
    btnConfigs: null,
    isLoading: false,
  }),
  created() {
    this.btnConfigs = this.config.buttonsResolver(this.item);
  },
  methods: {
    onClick(btnConfig) {
      this.isLoading = true;
      btnConfig.onClick().finally(() => (this.isLoading = false));
    },
  },
};
</script>
