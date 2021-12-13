import { queryEndpoint } from "./helper";

export default {
  getList() {
    return queryEndpoint("GET", "/pharmacy");
  },
};
