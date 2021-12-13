import { queryEndpoint } from "./helper";

export default {
  requestByUser(data) {
    const options = { data };
    return queryEndpoint("POST", "/order/request", options);
  },
  cancelByUser(data) {
    const options = { data };
    return queryEndpoint("PATCH", "/order/cancel", options);
  },
  accept(orderId) {
    return queryEndpoint("PATCH", `/order/accept/${orderId}`);
  },
  cancel(orderId) {
    return queryEndpoint("PATCH", `/order/cancel/${orderId}`);
  },
  notify(orderId, quantity) {
    const options = {
      data: quantity,
      headers: { "Content-Type": "application/json" },
    };
    return queryEndpoint("PATCH", `/order/notify/${orderId}`, options);
  },
};
