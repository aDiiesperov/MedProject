import { AuthService } from "@services";
import { getters as $G, actions as $A, mutations as $M } from "../types";
import router from "../../router";
import { JwtParser } from "@helpers";

function getUserData(token) {
  let payload = JwtParser.parsePayload(token);

  return {
    id: payload.id,
    userName: `${payload.firstName} ${payload.lastName}`,
    roles: JSON.parse(payload.roles),
  };
}

const accessToken = localStorage.getItem("accessToken");
const idToken = localStorage.getItem("idToken");
const user = idToken ? getUserData(idToken) : null;

const state = () => ({
  isAuthenticated: accessToken ? true : false,
  user,
  accessToken,
  refreshToken: null,
  error: null,
});

const mutations = {
  [$M.AUTH_SUCCESS_LOGIN](state, data) {
    state.isAuthenticated = true;
    state.accessToken = data.AccessToken;
    state.user = getUserData(data.IdToken);
    state.error = null;

    localStorage.setItem("accessToken", data.AccessToken);
    localStorage.setItem("idToken", data.IdToken);
  },
  [$M.AUTH_FAILED_LOGIN](state, error) {
    state.error = error;
  },
  [$M.AUTH_LOGOUT](state) {
    state.isAuthenticated = false;
    state.user = null;
    state.accessToken = null;

    localStorage.removeItem("accessToken");
    localStorage.removeItem("idToken");
  },
};

const actions = {
  async [$A.AUTH_LOGIN]({ commit, state }, data) {
    if (state.accessToken) return;
    try {
      const res = await AuthService.login(data);
      commit($M.AUTH_SUCCESS_LOGIN, res);
      router.push({ path: "/" });
    } catch (e) {
      const status = e.response.status;
      if (status >= 400 && status < 500) {
        const msg = e.response.data.Message;
        if (msg) {
          commit($M.AUTH_FAILED_LOGIN, msg);
        }
      }
    }
  },
  [$A.AUTH_LOGOUT]({ commit, state }) {
    if (!state.accessToken) return;
    commit($M.AUTH_LOGOUT);
    router.push({ path: "/login" });
  },
};

const getters = {
  [$G.AUTH_IS_AUTHENTICATED](state) {
    return state.isAuthenticated;
  },
  [$G.AUTH_USER](state) {
    return state.user;
  },
  [$G.AUTH_ACCESS_TOKEN](state) {
    return state.accessToken;
  },
  [$G.AUTH_ERROR](state) {
    return state.error;
  },
};

export default {
  state,
  getters,
  mutations,
  actions,
};
