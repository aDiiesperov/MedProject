<template>
  <div>
    <nav-bar />
    <div class="container pt-3">
      <router-view />
    </div>
  </div>
</template>

<script>
import NavBar from "@/core/NavBar.vue";

export default {
  name: "Home",
  components: {
    NavBar,
  },
};
</script>
