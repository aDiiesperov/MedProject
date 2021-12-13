import { queryEndpoint } from "./utils/helper";

export default {
  getList() {
    return queryEndpoint("GET", "/pharmacy");
  },
};
