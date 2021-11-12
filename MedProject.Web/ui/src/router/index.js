import Vue from "vue";
import VueRouter from "vue-router";
import Home from "@views/Home.vue";

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
        // alias: "",
        component: () => import("@/views/patients/PatientList.vue"),
      },
      {
        path: "pharmacies",
        component: () => import("@/views/pharmacies/PharmacyList.vue"),
      },
    ],
  },
  // TODO: future features: we can add other pages here like error, no-access and so on
  // {
  //   path: '/:catchAll(.*)',
  //   redirect: { path: "error" },
  // }
  // {
  //   path: "error",
  //   name: "Error",
  //   component: () => import("../views/Error.vue"),
  // },
];

const router = new VueRouter({
  mode: "history",
  base: "/",
  routes,
});

export default router;
