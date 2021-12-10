import axios from "axios";

// TODO: change from static to instance
export class MedicationService {
  static getMedicationsToOrder(data) {
    return axios
      .get(`${process.env.VUE_APP_API_URL}/medication/medications-to-order`, {
        params: data,
      })
      .then((response) => response.data);
  }

  static getMedicationsInfo() {
    return axios
      .get(`${process.env.VUE_APP_API_URL}/medication/medications-info`)
      .then((response) => response.data);
  }
}
