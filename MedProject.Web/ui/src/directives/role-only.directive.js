import Vue from "vue";
import store from "../store";
import { getters as $G } from "../store/types";

Vue.directive("role-only", {
  bind: function (el, binding) {
    const role = binding.value.toLowerCase();
    const userRoles = store.getters[$G.AUTH_USER].roles;

    if (
      userRoles === role ||
      (userRoles instanceof Array &&
        !userRoles.some((r) => r.toLowerCase() === role))
    ) {
      el.style.display = "none";
    }
  },
});
