import { MedicationService } from "@services";
import { getters as $G, actions as $A, mutations as $M } from "../types";

const state = () => ({
  medsInfo: [],
  medsToOrder: [],
});

const mutations = {
  [$M.MED_SET_MEDS_TO_ORDER](state, medsToOrder) {
    state.medsToOrder = medsToOrder;
  },
};

const actions = {
  async [$A.MED_LOAD_MEDS_TO_ORDER]({ commit }) {
    const medsToOrder = await MedicationService.getMedicationsToOrder();
    commit($M.MED_SET_MEDS_TO_ORDER, medsToOrder);
  },
  async [$A.MED_ACTION_REQUEST](_, data) {
    await MedicationService.requestMedications(data);
    // TODO: refresh model
  },
};

const getters = {
  [$G.MED_MEDS_TO_ORDER](state) {
    return state.medsToOrder;
  },
};

export default {
  state,
  getters,
  mutations,
  actions,
};
