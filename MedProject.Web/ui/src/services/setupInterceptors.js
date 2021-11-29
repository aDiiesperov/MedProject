import axios from "axios";
import { getters as $G, actions as $A } from "../store/types";

export const setupInterceptors = (store) => {
  axios.interceptors.request.use(
    (request) => {
      const token = store.getters[$G.AUTH_ACCESS_TOKEN];
      const isApiUrl = request.url.startsWith(process.env.VUE_APP_API_URL);

      if (token && isApiUrl) {
        request.headers["Authorization"] = `Bearer ${token}`;
      }
      return request;
    },
    (error) => {
      return Promise.reject(error);
    }
  );

  axios.interceptors.response.use(
    (res) => res,
    async (err) => {
      const originalConfig = err.config;

      if (err.response.status === 401 && !originalConfig._retry) {
        originalConfig._retry = true;

        try {
          await store.dispatch($A.AUTH_SILENT_REFRESH);

          return axios(originalConfig);
        } catch (_error) {
          store.dispatch($A.AUTH_LOGOUT);
          return Promise.reject(_error);
        }
      }

      return Promise.reject(err);
    }
  );
};
