import instance from "./instance";

export const queryEndpoint = async (method, endpoint, options) => {
  const { data } = await instance.request({
    url: endpoint,
    method: method,
    ...options,
  });

  return data;
};
