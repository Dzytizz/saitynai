import axios from "axios";
axios.defaults.baseURL = "https://localhost:7021/api/v1";
axios.defaults.headers.common = {
  "Content-type": "application/json",
  Authorization: `Bearer ${sessionStorage.getItem("access_token")}`,
};
export default axios;

// import axios from "axios";
// export default axios.create({
//   baseURL: "https://localhost:7021/api/v1",
//   headers: {
//     "Content-type": "application/json",
//     Authorizatio: `Bearer ${sessionStorage.getItem("access_token")}`,
//   },
// });
