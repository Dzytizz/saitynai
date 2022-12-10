import { SettingsInputHdmiTwoTone } from "@mui/icons-material";
import React, { useEffect } from "react";
import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useLocation } from 'react-router-dom'
import { useCurrentUser } from "./CurrentUserContext";

export const RolesContext = React.createContext();

export const RolesProvider = ({children, allowedRoles}) => {
    const {currentUser} = useCurrentUser();
    const [show, setShow] = useState(false);


    function shouldShow(){
        if(allowedRoles === null) {
            return true;
        }
        else if(allowedRoles !== null && currentUser === null) {
            return false;
        }
        else {
            return allowedRoles.some(r => currentUser.roles.includes(r))
        } 
    }

    useEffect(() => {
      if(shouldShow()) {
        setShow(true)
      }
      else {
        setShow(false)
      }
    }, [])

    return (
        <RolesContext.Provider value={{}}>
            {show?
            children : null
            }
        </RolesContext.Provider>
    )
}

export const useRoles = () => React.useContext(RolesContext)