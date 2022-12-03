// import axios from "axios";
// axios.defaults.baseURL = "https://localhost:7021/api/v1"
// axios.defaults.headers.common = {"Content-type": "application/json", "Authorization": `Bearer ${"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidXNlcjEiLCJqdGkiOiI3N2ViNGQ1Ni0zZjUxLTQzN2MtOWUxMy1hOTQwYjk3ZmU4M2UiLCJzdWIiOiI5MmY0NDdiOC0wOWRiLTRlMjQtOGFhZi00MGRlZjhlMDNlYjEiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VyIiwiZXhwIjoxNjY5OTkzMTE3LCJpc3MiOiJWYWxpZElzc3VlciIsImF1ZCI6IlRydXN0ZWRDbGllbnQifQ.7hiydvkyjP82cp5ygAsiYSEe_c4-xBFDk5rDp0ZE1eU"}`}
// export default axios;

import axios from "axios";

export default axios.create({
  baseURL: "https://localhost:7021/api/v1",
  headers: {
    "Content-type": "application/json",
    "Authorization": `Bearer ${sessionStorage.getItem("access_token")}`,
  }
});
