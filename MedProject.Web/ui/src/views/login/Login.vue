<template>
  <div class="wrapper-signin">
    <form class="form-signin" @submit.prevent="onSubmit()">
      <h1 class="h3 mb-3 fw-normal">Please sign in</h1>

      <app-loader class="mb-2" v-if="isLoading" />
      <p v-if="error && error.length && !isLoading" class="text-danger">
        {{ error }}
      </p>
      <div class="form-floating">
        <input
          type="text"
          class="form-control"
          id="floatingInput"
          placeholder="name@example.com"
          v-model="login"
        />
        <label for="floatingInput">Login</label>
      </div>

      <div class="form-floating">
        <input
          type="password"
          class="form-control"
          id="floatingPassword"
          placeholder="Password"
          v-model="password"
        />
        <label for="floatingPassword">Password</label>
      </div>
      <button
        class="w-100 btn btn-lg btn-primary mt-1"
        type="submit"
        :disabled="!isValidForm"
      >
        Sign in
      </button>
      <p class="mt-5 mb-3 text-muted">&copy; 2021</p>
    </form>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
import { actions as $A, getters as $G } from "@store/types";
import AppLoader from "@components/AppLoader.vue";

export default {
  components: { AppLoader },
  data: () => ({
    login: "",
    password: "",
    isLoading: false,
  }),
  computed: {
    ...mapGetters({
      error: $G.AUTH_ERROR,
    }),
    isValidForm() {
      return this.login.length && this.password.length;
    },
  },
  methods: {
    onSubmit() {
      if (this.isValidForm) {
        var data = {
          loginName: this.login,
          password: this.password,
        };
        this.isLoading = true;
        this.$store
          .dispatch($A.AUTH_LOGIN, data)
          .finally(() => (this.isLoading = false));
      }
    },
  },
};
</script>

<style lang="scss" scoped>
@import "Login";
</style>
