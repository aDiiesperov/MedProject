import { TYPE_FILTER } from "../constants/type-filter";

export class QueryBarHelper {
  static filterData(data, filters) {
    if (filters.length) {
      var filteredData = data;

      for (var filter of filters) {
        filteredData = filterDataByFilter(filteredData, filter);
      }

      return filteredData;
    }
    return data;
  }
}

function filterDataByFilter(data, filter) {
  if (filter.manualHandling) return data;

  switch (filter.type) {
    case TYPE_FILTER.INPUT:
      return filterInput(data, filter);
    case TYPE_FILTER.DROPDOWN:
      return filterDropdown(data, filter);
    default:
      return data;
  }
}

function filterInput(data, filter) {
  const filterValue = filter.value.toLowerCase();
  return data.filter((d) =>
    d[filter.filterKey].toLowerCase().includes(filterValue)
  );
}

// Drodpowns has manual handling now. It's for future filters.
function filterDropdown(data) {
  return data;
}
