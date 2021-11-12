import { QueryBarHelper } from "@/components/query-bar";
import { getters as $G, actions as $A, mutations as $M } from "../types";

const state = () => ({
  filters: [],
});

const mutations = {
  [$M.QUERY_BAR_UPDATE_FILTER](state, filter) {
    for (let f of state.filters) {
      if (f.filterKey === filter.filterKey) {
        f.value = filter.value;
        return;
      }
    }
    state.filters.push(filter);
  },
  [$M.QUERY_BAR_RESET_FILTERS](state) {
    state.filters.length = 0;
  },
};

const actions = {
  [$A.QUERY_BAR_APPLY_FILTER]({ commit }, filter) {
    commit($M.QUERY_BAR_UPDATE_FILTER, filter);
  },
  [$A.QUERY_BAR_RESET_FILTERS]({ commit }) {
    commit($M.QUERY_BAR_RESET_FILTERS);
  },
};

const getters = {
  [$G.QUERY_BAR_LIST](state) {
    return state.filters;
  },
  [$G.QUERY_BAR_FILTER_DATA](state) {
    return (data) => QueryBarHelper.filterData(data, state.filters);
  },
};

export default {
  state,
  getters,
  mutations,
  actions,
};
