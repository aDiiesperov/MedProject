import { PatientService } from "@services";
import { getters as $G, actions as $A, mutations as $M } from "../types";

const state = () => ({
  patients: [],
});

const mutations = {
  [$M.PATIENT_SET_LIST](state, patients) {
    state.patients = patients;
  },
};

const actions = {
  async [$A.PATIENT_LOAD_LIST]({ commit }) {
    const patients = await PatientService.getList();
    commit($M.PATIENT_SET_LIST, patients);
  },
};

const getters = {
  [$G.PATIENT_LIST](state) {
    return state.patients;
  },
};

export default {
  state,
  getters,
  mutations,
  actions,
};
