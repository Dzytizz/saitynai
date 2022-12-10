import axios from "axios";
axios.defaults.baseURL = "https://localhost:7021/api/v1";
axios.defaults.headers.common = {
  "Content-type": "application/json",
  Authorization: `Bearer ${sessionStorage.getItem("access_token")}`,
};
axios.interceptors.request.use(
  (config) => {
    config.headers["Authorization"] = `Bearer ${sessionStorage.getItem(
      "access_token"
    )}`;
    return config;
  },
  (error) => {
    Promise.reject(error);
  }
);
export default axios;

// import axios from "axios";
// export default axios.create({
//   baseURL: "https://localhost:7021/api/v1",
//   headers: {
//     "Content-type": "application/json",
//     Authorizatio: `Bearer ${sessionStorage.getItem("access_token")}`,
//   },
// });
