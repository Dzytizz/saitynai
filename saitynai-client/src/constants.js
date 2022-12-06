import { Role } from "./components/roles";

export const pages = [
  {
    name: "Games",
    url: "/games",
    roles: [null, Role.User, Role.Admin],
  },
  {
    name: "Add Game",
    url: "/games/new",
    roles: [Role.Admin],
  },
  {
    name: "Login",
    url: "/login",
    roles: null,
  },
  {
    name: "Register",
    url: "/register",
    roles: null,
  },
];
