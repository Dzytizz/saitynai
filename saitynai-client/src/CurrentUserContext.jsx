import React, { useEffect } from "react";
import authService from "./services/auth.service";
import { Link, useNavigate } from "react-router-dom";
import { useLocation } from 'react-router-dom'

function createUserData(access_token, roles) {
  return {access_token, roles}
}

export const CurrentUserContext = React.createContext();

export const CurrentUserProvider = ({ children }) => {
  const navigate = useNavigate();

  const [currentUser, setCurrentUser] = React.useState(null);
  const [error, setError] = React.useState("");

  function checkIfExists(){
    let token = sessionStorage.getItem("access_token");
    let roles = sessionStorage.getItem("roles");
    if(token !== null && roles !== null) {
      setCurrentUser(createUserData(token, roles))
    }
  }

  function containsRoles(allowedRoles) {
    checkIfExists()
    if(currentUser === null) return false;
    if(allowedRoles.some(r => currentUser.roles.includes(r))) return true;
  }

  useEffect(() => {
    checkIfExists()
  }, []);

  const login = (data) => {
    setError("")
    const loginInfo = {
      UserName: data.get('username'),
      Password: data.get('password')
    }
    authService.login(loginInfo).then((res) => {
      sessionStorage.setItem("access_token", res.data.accessToken);
      sessionStorage.setItem("roles", res.data.roles);
      setCurrentUser(createUserData(res.data.accessToken, res.data.roles))
      navigate('/')
      //setError("");
      //console.log(res.data)
    }).catch((error) => {
      setCurrentUser(null)
      setError("Wrong username or password. Try again")
      console.error(error);
    });
  }

  const logout = () => {
    sessionStorage.removeItem("access_token")
    sessionStorage.removeItem("roles")
    setCurrentUser(null)
    navigate('/login')
  }

  return (
    <CurrentUserContext.Provider value={{currentUser, error, login, logout, containsRoles}}>
      {children}
    </CurrentUserContext.Provider>
  );
};

export const useCurrentUser = () => React.useContext(CurrentUserContext);
