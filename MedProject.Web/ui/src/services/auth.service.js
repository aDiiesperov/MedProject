import axios from "axios";

// TODO: change from static to instance
export class AuthService {
  static login(data) {
    return axios
      .get(`${process.env.VUE_APP_API_URL}/auth/login`, {
        params: data,
      })
      .then((response) => response.data);
  }

  static refreshToken(token) {
    return axios
      .get(`${process.env.VUE_APP_API_URL}/auth/refresh-token`, {
        params: { token },
      })
      .then((response) => response.data);
  }
}
