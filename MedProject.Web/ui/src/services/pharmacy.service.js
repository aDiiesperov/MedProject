import axios from "axios";

export class PharmacyService {
  static getList() {
    return axios
      .get(`${process.env.VUE_APP_API_URL}/pharmacy`)
      .then((response) => response.data);
  }
}
