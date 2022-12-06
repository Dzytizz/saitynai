import * as React from "react";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import IconButton from "@mui/material/IconButton";
import Typography from "@mui/material/Typography";
import Menu from "@mui/material/Menu";
import MenuIcon from "@mui/icons-material/Menu";
import Container from "@mui/material/Container";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import Tooltip from "@mui/material/Tooltip";
import MenuItem from "@mui/material/MenuItem";
import { Link, useNavigate } from "react-router-dom";
import { Role } from "./roles";
import { useState } from "react";
import { useEffect } from "react";
import { useCurrentUser } from "../CurrentUserContext";
import { pages } from "../constants";

//const settings = ["Log in", "Log out"];

const MainNavigation = () => {
  const {currentUser, logout} = useCurrentUser();
  const [anchorElNav, setAnchorElNav] = useState(null);
  const [anchorElUser, setAnchorElUser] = useState(null);

  const navigate = useNavigate();

  const handleOpenNavMenu = (event) => {
    setAnchorElNav(event.currentTarget);
  };
  const handleOpenUserMenu = (event) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseNavMenu = () => {
    setAnchorElNav(null);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };

  const logOut = () => {
    handleCloseUserMenu();
    logout();
    //navigate("/games");
  }

  function rolesNotNullAndContain (page) {
    if(page.roles === null && currentUser === null) {
      return true;
    }
    else if (page.roles === null && currentUser !== null){
      return false;
    }
    if(page.roles.includes(null) && currentUser === null) {
      return true;
    }
    if(currentUser === null) {
      return false;
    }
    else {
      return page.roles.some(r => currentUser.roles.includes(r))
    }
  }

  function userRolesNotNull(){
    if(currentUser === null) {
      return false;
    }
    else {
      return true;
    }
  }

  return (
    <AppBar position="static">
      <Container maxWidth="false">
        <Toolbar disableGutters>
          <Typography
            variant="h6"
            noWrap
            component="div"
            sx={{ mr: 2, display: { xs: "none", md: "flex" } }}
          >
            STALIUS
          </Typography>

          <Box sx={{ flexGrow: 1, display: { xs: "flex", md: "none" } }}>
            <IconButton
              size="large"
              aria-label="account of current user"
              aria-controls="menu-appbar"
              aria-haspopup="true"
              onClick={handleOpenNavMenu}
              color="inherit"
            >
              <MenuIcon />
            </IconButton>
            <Menu
              id="menu-appbar"
              anchorEl={anchorElNav}
              anchorOrigin={{
                vertical: "bottom",
                horizontal: "left",
              }}
              keepMounted
              transformOrigin={{
                vertical: "top",
                horizontal: "left",
              }}
              open={Boolean(anchorElNav)}
              onClose={handleCloseNavMenu}
              sx={{
                display: { xs: "block", md: "none" },
              }}
            >
              {pages.map((page) => (
                rolesNotNullAndContain(page) ?
                <MenuItem
                  key={page.name}
                  onClick={() => {
                    handleCloseNavMenu();
                    navigate(page.url);
                  }}
                >
                  <Typography textAlign="center">{page.name}</Typography>
                </MenuItem>
                : null
              ))}
            </Menu>
          </Box>
          <Typography
            variant="h6"
            noWrap
            component="div"
            sx={{ flexGrow: 1, display: { xs: "flex", md: "none" } }}
          >
            STALIUS
          </Typography>
          <Box sx={{ flexGrow: 1, display: { xs: "none", md: "flex" } }}>
            {pages.map((page) => (
              rolesNotNullAndContain(page) ?
              (<Button
                key={page.name}
                onClick={() => navigate(page.url)}
                sx={{ my: 2, color: "white", display: "block" }}
              >
                {page.name}
              </Button>)
              : null
            ))}
          </Box>

          <Box sx={{ flexGrow: 0 }}>
            {userRolesNotNull() ? 
            (<Tooltip title="Open settings">
              <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                <Avatar alt="Profile" />
              </IconButton>
            </Tooltip>) 
            : null}
            <Menu
              sx={{ mt: "45px" }}
              id="menu-appbar"
              anchorEl={anchorElUser}
              anchorOrigin={{
                vertical: "top",
                horizontal: "right",
              }}
              keepMounted
              transformOrigin={{
                vertical: "top",
                horizontal: "right",
              }}
              open={Boolean(anchorElUser)}
              onClose={handleCloseUserMenu}
            >
              {/* {settings.map((setting) => (
                <MenuItem key={setting.name} onClick={function(){handleCloseUserMenu,navigate(setting.url)}}>
                  <Typography textAlign="center">{setting.name}</Typography>
                </MenuItem>
              ))} */}
              <MenuItem key="Log out" onClick={logOut}>
                  <Typography textAlign="center">Log out</Typography>
                </MenuItem>
            </Menu>
          </Box>
        </Toolbar>
      </Container>
    </AppBar>
  );
};
export default MainNavigation;
