import { MedicationService, OrderService } from "@services";
import { getters as $G, actions as $A, mutations as $M } from "../types";

const state = () => ({
  medsInfo: [],
  medsToOrder: [],
});

const mutations = {
  [$M.MED_SET_MEDS_TO_ORDER](state, medsToOrder) {
    state.medsToOrder = medsToOrder;
  },
  [$M.MED_SET_MEDS_INFO](state, medsInfo) {
    state.medsInfo = medsInfo;
  },
  [$M.MED_CHANGE_STATUS](state, data) {
    const model = state.medsToOrder.find(
      (m) =>
        m.PharmacyId === data.PharmacyId && m.MedicationId === data.MedicationId
    );
    model.Status = data.status;
    model.OrderedQuantity = data.Quantity ?? model.OrderedQuantity;
  },
  [$M.MED_REMOVE_ORDER](state, orderId) {
    console.dir(orderId);
    for (var medInfo of state.medsInfo) {
      var orderIndex = medInfo.ItemOrders.findIndex(
        (order) => order.Id === orderId
      );
      if (orderIndex != -1) {
        medInfo.ItemOrders.splice(orderIndex, 1);
        break;
      }
    }
  },
};

const actions = {
  async [$A.MED_LOAD_MEDS_TO_ORDER]({ commit }) {
    const medsToOrder = await MedicationService.getMedicationsToOrder();
    commit($M.MED_SET_MEDS_TO_ORDER, medsToOrder);
  },
  async [$A.MED_LOAD_MEDS_INFO]({ commit }) {
    const medsInfo = await MedicationService.getMedicationsInfo();
    commit($M.MED_SET_MEDS_INFO, medsInfo);
  },
  [$A.MED_RESET]({ commit }) {
    commit($M.MED_SET_MEDS_TO_ORDER, []);
    commit($M.MED_SET_MEDS_INFO, []);
  },
  async [$A.MED_ACTION_USER_REQUEST]({ commit }, data) {
    await OrderService.requestByUser(data);
    commit($M.MED_CHANGE_STATUS, { ...data, status: "Requested" }); // TODO: add enum and change model on back-end
  },
  async [$A.MED_ACTION_USER_CANCEL]({ commit }, data) {
    await OrderService.cancelByUser(data);
    commit($M.MED_CHANGE_STATUS, { ...data, status: "Canceled" }); // TODO: add enum and change model on back-end
  },
  async [$A.MED_ACTION_ACCEPT]({ commit }, orderId) {
    await OrderService.accept(orderId);
    commit($M.MED_REMOVE_ORDER, orderId);
  },
  async [$A.MED_ACTION_CANCEL]({ commit }, orderId) {
    await OrderService.cancel(orderId);
    commit($M.MED_REMOVE_ORDER, orderId);
  },
  async [$A.MED_ACTION_NOTIFY]({ commit }, data) {
    await OrderService.notify(data.orderId, data.quantity);
    commit($M.MED_REMOVE_ORDER, data.orderId);
  },
};

const getters = {
  [$G.MED_MEDS_TO_ORDER](state) {
    return state.medsToOrder;
  },
  [$G.MED_MEDS_INFO](state) {
    return state.medsInfo;
  },
};

export default {
  state,
  getters,
  mutations,
  actions,
};
