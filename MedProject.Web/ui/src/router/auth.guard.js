import store from "../store";
import { getters as $G } from "../store/types";

export default (to, from, next) => {
  const isAuthenticated = store.getters[$G.AUTH_IS_AUTHENTICATED];
  const requiresAuth = to.matched.some((record) => record.meta.requiresAuth);

  if (!isAuthenticated && requiresAuth) {
    next({ name: "Login" });
  } else {
    next();
  }
};
