import axios from "axios";

export default {
  getMedicationsToOrder(data) {
    return axios
      .get(`${process.env.VUE_APP_API_URL}/medication/medications-to-order`, {
        params: data,
      })
      .then((response) => response.data);
  },
  getMedicationsInfo() {
    return axios
      .get(`${process.env.VUE_APP_API_URL}/medication/medications-info`)
      .then((response) => response.data);
  },
};
