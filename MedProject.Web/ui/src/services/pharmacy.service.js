import axios from "axios";

export default {
  getList() {
    return axios
      .get(`${process.env.VUE_APP_API_URL}/pharmacy`)
      .then((response) => response.data);
  },
};
