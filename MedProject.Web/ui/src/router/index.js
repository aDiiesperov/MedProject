import Vue from "vue";
import VueRouter from "vue-router";
import Home from "@views/Home.vue";
import authGuard from "./auth.guard";

Vue.use(VueRouter);

const routes = [
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
        component: () => import("@views/medications/Home"),
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

router.beforeEach(authGuard);

export default router;
