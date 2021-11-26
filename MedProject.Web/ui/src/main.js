import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import { setupInterceptors } from "./services/setupInterceptors";

import "./filters";
import "./directives";
import "bootstrap/dist/js/bootstrap.bundle.min.js";
import "./index.scss";

setupInterceptors(store);

Vue.config.productionTip = false;

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount("#app");
