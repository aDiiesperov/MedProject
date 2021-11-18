import Vue from "vue";
import VueRouter from "vue-router";
import Home from "@views/Home.vue";

Vue.use(VueRouter);

const routes = [
  // TODO: future features: add some auth guard
  {
    path: "/",
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
    ],
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

export default router;
