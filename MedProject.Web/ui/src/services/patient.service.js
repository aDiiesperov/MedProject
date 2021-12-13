import axios from "axios";

export default {
  getList() {
    return axios
      .get(`${process.env.VUE_APP_API_URL}/patient`)
      .then((response) => response.data);
  },
};
