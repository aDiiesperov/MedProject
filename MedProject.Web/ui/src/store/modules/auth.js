import { getters as $G, actions as $A, mutations as $M } from "../types";
import router from "../../router";
import { JwtParser } from "@helpers";
import { AuthService } from "@services";

function getUserData(token) {
  let payload = JwtParser.parsePayload(token);

  return {
    userName: `${payload.firstName} ${payload.lastName}`,
    roles: payload.role,
  };
}

const accessToken = localStorage.getItem("accessToken");
const refreshToken = localStorage.getItem("refreshToken");
const idToken = localStorage.getItem("idToken");

const user = idToken ? getUserData(idToken) : null;

const state = () => ({
  isAuthenticated: accessToken ? true : false,
  user,
  accessToken,
  refreshToken,
  error: null,
});

const mutations = {
  [$M.AUTH_SUCCESS_LOGIN](state, data) {
    state.isAuthenticated = true;
    state.user = getUserData(data.IdToken);
    state.accessToken = data.AccessToken;
    state.refreshToken = data.RefreshToken;
    state.error = null;

    localStorage.setItem("accessToken", data.AccessToken);
    localStorage.setItem("refreshToken", data.RefreshToken);
    localStorage.setItem("idToken", data.IdToken);
  },
  [$M.AUTH_FAILED_LOGIN](state, error) {
    state.error = error;
  },
  [$M.AUTH_LOGOUT](state) {
    state.isAuthenticated = false;
    state.user = null;
    state.accessToken = null;
    state.refreshToken = null;

    localStorage.removeItem("accessToken");
    localStorage.removeItem("refreshToken");
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
  async [$A.AUTH_SILENT_REFRESH]({ commit, state }) {
    if (!state.refreshToken) throw new Error("Refresh token is empty!");
    const res = await AuthService.refreshToken(state.refreshToken);
    commit($M.AUTH_SUCCESS_LOGIN, res);
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
  [$G.AUTH_REFRESH_TOKEN](state) {
    return state.refreshToken;
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
