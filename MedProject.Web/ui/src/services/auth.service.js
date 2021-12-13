import { queryEndpoint } from "./utils/helper";

export default {
  login(data) {
    const options = { data: data };
    return queryEndpoint("POST", "/auth/login", options);
  },
  refreshToken(token) {
    const options = { params: { token } };
    return queryEndpoint("POST", "/auth/refresh-token", options);
  },
};
