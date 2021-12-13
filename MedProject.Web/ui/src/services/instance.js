import axios from "axios";
import setupInterceptors from "./setupInterceptors";

const instance = axios.create({
  baseURL: process.env.VUE_APP_API_URL,
});

setupInterceptors(instance);

export default instance;
