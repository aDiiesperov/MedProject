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
  [$M.MED_CHANGE_STATUS](state, data) {
    const model = state.medsToOrder.find(
      (m) =>
        m.PharmacyId === data.PharmacyId && m.MedicationId === data.MedicationId
    );
    model.Status = data.status;
    model.OrderedQuantity = data.Quantity ?? model.OrderedQuantity;
  },
};

const actions = {
  async [$A.MED_LOAD_MEDS_TO_ORDER]({ commit }) {
    const medsToOrder = await MedicationService.getMedicationsToOrder();
    commit($M.MED_SET_MEDS_TO_ORDER, medsToOrder);
  },
  async [$A.MED_ACTION_REQUEST]({ commit }, data) {
    await MedicationService.requestMedications(data);
    commit($M.MED_CHANGE_STATUS, { ...data, status: "Requested" }); // TODO: add enum and change model on back-end
  },
  async [$A.MED_ACTION_CANCEL]({ commit }, data) {
    await MedicationService.cancelMedications(data);
    commit($M.MED_CHANGE_STATUS, { ...data, status: "Canceled" }); // TODO: add enum and change model on back-end
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
