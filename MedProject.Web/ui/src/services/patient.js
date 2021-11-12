import axios from "axios";

export class Patient {
  static getList() {
    return axios
      .get(`${process.env.VUE_APP_API_URL}/patient`)
      .then((response) => response.data);
  }
}
