import Vue from "vue";
import VueRouter from "vue-router";
import Home from "@views/Home.vue";
import store from "../store";
import { getters as $G } from "../store/types";

Vue.use(VueRouter);

const routes = [
  // TODO: future features: add some auth guard
  {
    path: "/",
    name: "Home",
    component: Home,
    children: [
      {
        path: "",
        redirect: { path: "pharmacies" },
      },
      {
        path: "patients",
        component: () => import("@views/patients/PatientList"),
      },
      {
        path: "pharmacies",
        component: () => import("@views/pharmacies/PharmacyList"),
      },
      {
        path: "medications",
        component: () => import("@views/medications/MedicationRoot"),
      },
    ],
    meta: {
      requiresAuth: true,
    },
  },
  {
    name: "Login",
    path: "/login",
    component: () => import("@views/login/Login"),
  },
  {
    path: "/error",
    component: () => import("@views/Error"),
  },
  {
    path: "/:catchAll(.*)",
    redirect: { path: "error" },
  },
];

const router = new VueRouter({
  mode: "history",
  base: "/",
  routes,
});

router.beforeEach((to, from, next) => {
  const isAuthenticated = store.getters[$G.AUTH_IS_AUTHENTICATED];
  const requiresAuth = to.matched.some((record) => record.meta.requiresAuth);

  if (!isAuthenticated && requiresAuth) {
    next({ name: "Login" });
  } else {
    next();
  }
});

export default router;
