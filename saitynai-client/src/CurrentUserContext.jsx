import React, { useEffect } from "react";
import authService from "./services/auth.service";

function createUserData(access_token, roles) {
  return {access_token, roles}
}

export const CurrentUserContext = React.createContext();

export const CurrentUserProvider = ({ children }) => {
  const [currentUser, setCurrentUser] = React.useState(null);
  
  function checkIfExists(){
    let token = sessionStorage.getItem("access_token");
    let roles = sessionStorage.getItem("roles");
    if(token !== null && roles !== null) {
      setCurrentUser(createUserData(token,roles))
    }
  }

  useEffect(() => {
    checkIfExists()
  }, []);

  const login = (data) => {
    const loginInfo = {
      UserName: data.get('username'),
      Password: data.get('password')
    }
    authService.login(loginInfo).then((res) => {
      sessionStorage.setItem("access_token", res.data.accessToken);
      sessionStorage.setItem("roles", res.data.roles);
      setCurrentUser(createUserData(res.data.accessToken, res.data.roles))
      //console.log(res.data)
    }).catch((error) => {
      setCurrentUser(null)
      //console.error(error);
    });
  }

  const logout = () => {
    sessionStorage.removeItem("access_token")
    sessionStorage.removeItem("roles")
    setCurrentUser(null)
  }

  return (
    <CurrentUserContext.Provider value={{currentUser, login, logout}}>
      {children}
    </CurrentUserContext.Provider>
  );
};

export const useCurrentUser = () => React.useContext(CurrentUserContext);
