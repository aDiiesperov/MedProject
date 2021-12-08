export const getters = {
  PATIENT_LIST: "PATIENT_LIST",

  PHARMACY_LIST: "PHARMACY_LIST",

  QUERY_BAR_FILTER_DATA: "QUERY_BAR_FILTER_DATA",
  QUERY_BAR_LIST: "QUERY_BAR_FILTER_LIST",

  AUTH_IS_AUTHENTICATED: "AUTH_IS_AUTHENTICATED",
  AUTH_ACCESS_TOKEN: "AUTH_ACCESS_TOKEN",
  AUTH_REFRESH_TOKEN: "AUTH_REFRESH_TOKEN",
  AUTH_USER: "AUTH_USER",
  AUTH_ERROR: "AUTH_ERROR",

  MED_MEDS_TO_ORDER: "MED_MEDS_TO_ORDER",
  MED_MEDS_INFO: "MED_MEDS_INFO",
};

export const actions = {
  PATIENT_LOAD_LIST: "PATIENT_LOAD_LIST",
  PATIENT_RESET: "PATIENT_RESET",

  PHARMACY_LOAD_LIST: "PHARMACY_LOAD_LIST",
  PHARMACY_RESET: "PHARMACY_RESET",

  QUERY_BAR_APPLY_FILTER: "QUERY_BAR_APPLY_FILTER",
  QUERY_BAR_RESET_FILTERS: "QUERY_BAR_RESET_FILTERS",

  AUTH_LOGIN: "AUTH_LOGIN",
  AUTH_SILENT_REFRESH: "AUTH_SILENT_REFRESH",
  AUTH_LOGOUT: "AUTH_LOGOUT",

  MED_LOAD_MEDS_TO_ORDER: "MED_LOAD_MEDS_TO_ORDER",
  MED_LOAD_MEDS_INFO: "MED_LOAD_MEDS_INFO",
  MED_RESET: "MED_RESET",
  MED_ACTION_REQUEST: "MED_ACTION_REQUEST",
  MED_ACTION_CANCEL: "MED_ACTION_CANCEL",
};

export const mutations = {
  PATIENT_SET_LIST: "PATIENT_SET_LIST",

  PHARMACY_SET_LIST: "PHARMACY_SET_LIST",

  QUERY_BAR_UPDATE_FILTER: "QUERY_BAR_UPDATE_FILTER",
  QUERY_BAR_RESET_FILTERS: "QUERY_BAR_RESET_FILTERS",

  AUTH_SUCCESS_LOGIN: "AUTH_SUCCESS_LOGIN",
  AUTH_FAILED_LOGIN: "AUTH_FAILED_LOGIN",
  AUTH_LOGOUT: "AUTH_LOGOUT",

  MED_SET_MEDS_TO_ORDER: "MED_SET_MEDS_TO_ORDER",
  MED_SET_MEDS_INFO: "MED_SET_MEDS_INFO",
  MED_CHANGE_STATUS: "MED_CHANGE_STATUS",
};
