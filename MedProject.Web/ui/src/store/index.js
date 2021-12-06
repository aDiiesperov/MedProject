import Vue from "vue";
import Vuex from "vuex";
import queryBar from "./modules/query-bar";
import pharmacies from "./modules/pharmacies";
import patients from "./modules/patients";
import auth from "./modules/auth";
import medication from "./modules/medication";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    queryBar,
    pharmacies,
    patients,
    auth,
    medication,
  },
});
