import axios from "axios";

export default {
  requestByUser(data) {
    return axios
      .post(`${process.env.VUE_APP_API_URL}/order/request`, {
        ...data,
      })
      .then((response) => response.data);
  },
  cancelByUser(data) {
    return axios
      .patch(`${process.env.VUE_APP_API_URL}/order/cancel`, {
        ...data,
      })
      .then((response) => response.data);
  },
  accept(orderId) {
    return axios
      .patch(`${process.env.VUE_APP_API_URL}/order/accept/${orderId}`)
      .then((response) => response.data);
  },
  cancel(orderId) {
    return axios
      .patch(`${process.env.VUE_APP_API_URL}/order/cancel/${orderId}`)
      .then((response) => response.data);
  },
  notify(orderId, quantity) {
    return axios
      .patch(
        `${process.env.VUE_APP_API_URL}/order/notify/${orderId}`,
        quantity,
        {
          headers: { "Content-Type": "application/json" },
        }
      )
      .then((response) => response.data);
  },
};
