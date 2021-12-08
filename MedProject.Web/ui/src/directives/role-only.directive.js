import { UserHelper } from "@/helpers";
import Vue from "vue";
import store from "../store";
import { getters as $G } from "../store/types";

Vue.directive("role-only", {
  bind: function (el, binding) {
    const role = binding.value.toLowerCase();
    const user = store.getters[$G.AUTH_USER];

    if (!UserHelper.IsInRole(user, role)) {
      el.style.display = "none";
    }
  },
});
