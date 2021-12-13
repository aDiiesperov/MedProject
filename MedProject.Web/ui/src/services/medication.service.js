import { queryEndpoint } from "./helper";

export default {
  getMedicationsToOrder(data) {
    const options = { data };
    return queryEndpoint("GET", "/medication/medications-to-order", options);
  },
  getMedicationsInfo() {
    return queryEndpoint("GET", "/medication/medications-info");
  },
};
