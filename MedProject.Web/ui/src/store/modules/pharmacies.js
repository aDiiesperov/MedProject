import { PharmacyService } from "@services";
import { getters as $G, actions as $A, mutations as $M } from "../types";

const state = () => ({
  pharmacies: [],
});

const mutations = {
  [$M.PHARMACY_SET_LIST](state, pharmacies) {
    state.pharmacies = pharmacies;
  },
};

const actions = {
  async [$A.PHARMACY_LOAD_LIST]({ commit }) {
    const patients = await PharmacyService.getList();
    commit($M.PHARMACY_SET_LIST, patients);
  },
  [$A.PHARMACY_RESET]({ commit }) {
    commit($M.PHARMACY_SET_LIST, []);
  },
};

const getters = {
  [$G.PHARMACY_LIST](state) {
    return state.pharmacies;
  },
};

export default {
  state,
  getters,
  mutations,
  actions,
};
