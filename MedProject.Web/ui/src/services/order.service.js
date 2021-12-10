import axios from "axios";

// TODO: change from static to instance
export class OrderService {
  static requestByUser(data) {
    return axios
      .post(`${process.env.VUE_APP_API_URL}/order/request`, {
        ...data,
      })
      .then((response) => response.data);
  }

  static cancelByUser(data) {
    return axios
      .patch(`${process.env.VUE_APP_API_URL}/order/cancel`, {
        ...data,
      })
      .then((response) => response.data);
  }

  static accept(orderId) {
    return axios
      .patch(`${process.env.VUE_APP_API_URL}/order/accept/${orderId}`)
      .then((response) => response.data);
  }

  static cancel(orderId) {
    return axios
      .patch(`${process.env.VUE_APP_API_URL}/order/cancel/${orderId}`)
      .then((response) => response.data);
  }

  static notify(orderId, quantity) {
    return axios
      .patch(
        `${process.env.VUE_APP_API_URL}/order/notify/${orderId}`,
        quantity,
        {
          headers: { "Content-Type": "application/json" },
        }
      )
      .then((response) => response.data);
  }
}
