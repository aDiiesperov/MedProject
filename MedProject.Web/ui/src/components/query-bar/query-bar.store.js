const UPDATE_FILTER = "UPDATE_FILTER";
const RESET_FILTERS = "RESET_FILTERS";

const state = () => ({
  filters: [],
});

const mutations = {
  [UPDATE_FILTER](state, filter) {
    for (let f of state.filters) {
      if (f.filterKey === filter.filterKey) {
        f.value = filter.value;
        return;
      }
    }
    state.filters.push(filter);
  },
  [RESET_FILTERS](state) {
    state.filters.length = 0;
  },
};

const actions = {
  applyFilter({ commit }, filter) {
    commit(UPDATE_FILTER, filter);
  },
  resetFilters({ commit }) {
    commit(RESET_FILTERS);
  },
};

const getters = {
  filterData: (state) => (data) => {
    if (state.filters.length > 0) {
      var filteredData = data;

      for (var filter of state.filters) {
        const filterValue = filter.value.toLowerCase();
        filteredData = filteredData.filter((d) =>
          d[filter.filterKey].toLowerCase().includes(filterValue)
        );
      }

      return filteredData;
    }
    return data;
  },
};

export default {
  namespaced: true,
  state,
  getters,
  mutations,
  actions,
};
