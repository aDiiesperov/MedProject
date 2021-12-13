import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";

import "./filters";
import "./directives";
import "bootstrap/dist/js/bootstrap.bundle.min.js";
import "./index.scss";

Vue.config.productionTip = false;

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount("#app");
