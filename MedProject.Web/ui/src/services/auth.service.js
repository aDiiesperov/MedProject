import axios from "axios";

export default {
  login(data) {
    return axios
      .get(`${process.env.VUE_APP_API_URL}/auth/login`, {
        params: data,
      })
      .then((response) => response.data);
  },
  refreshToken(token) {
    return axios
      .get(`${process.env.VUE_APP_API_URL}/auth/refresh-token`, {
        params: { token },
      })
      .then((response) => response.data);
  },
};
