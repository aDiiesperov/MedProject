import axios from "axios";

// TODO: change from static to instance
export class AuthService {
  static login(data) {
    return axios
      .post(`${process.env.VUE_APP_API_URL}/auth/login`, data)
      .then((response) => response.data);
  }
}
