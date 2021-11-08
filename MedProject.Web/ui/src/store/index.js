import Vue from "vue";
import Vuex from "vuex";
import queryBarStore from "../components/query-bar/query-bar.store";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    queryBarStore,
  },
});
