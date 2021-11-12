import { TYPE_FILTER } from "./constants/type-filter";

export class QueryBarHelper {
  static filterData(data, filters) {
    if (filters.length) {
      var filteredData = data;

      for (var filter of filters) {
        filteredData = InnerHelper.filterData(filteredData, filter);
      }

      return filteredData;
    }
    return data;
  }
}

class InnerHelper {
  static filterData(data, filter) {
    if (filter.manualHandling) return data;

    switch (filter.type) {
      case TYPE_FILTER.INPUT:
        return InnerHelper.filterInput(data, filter);
      case TYPE_FILTER.DROPDOWN:
        return InnerHelper.filterDropdown(data, filter);
      default:
        return data;
    }
  }

  static filterInput(data, filter) {
    const filterValue = filter.value.toLowerCase();
    return data.filter((d) =>
      d[filter.filterKey].toLowerCase().includes(filterValue)
    );
  }

  // Drodpowns has manual handling now. It's for future filters.
  static filterDropdown(data) {
    return data;
  }
}
