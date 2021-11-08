import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import "./filters/index";
import "bootstrap/dist/js/bootstrap.bundle.min.js";
import "./app.scss";

Vue.config.productionTip = false;

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount("#app");
