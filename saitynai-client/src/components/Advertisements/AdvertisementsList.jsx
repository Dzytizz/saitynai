import { DisplaySettings, InsertEmoticon, } from "@mui/icons-material";
import { Grid, ImageList, ImageListItem, ImageListItemBar, Typography, Container } from "@mui/material";
import React, { useEffect, useState } from "react";
import advertisementService from "../../services/advertisement.service";
import { Link, useNavigate, useParams } from "react-router-dom";
import Box from "@mui/material/Box";
import CssBaseline from "@mui/material/CssBaseline";

import { createTheme, ThemeProvider } from "@mui/material/styles";
import { Role } from "../roles";
import { useCurrentUser } from "../../CurrentUserContext";

const theme = createTheme();

const imageStyle ={
    objectFit: 'contain'
}

function createData(id, title, editDate, description, condition, price, photos) {
    return {id, title, editDate, description, condition, price, photos}
}

export function AdvertisemensList(){
    const navigate = useNavigate();
    const [advertisements, setAdvertisements] = useState([])
    const [apiHappened, setApiHappened] = useState(false)
    const {gameId} = useParams()
    const {currentUser} = useCurrentUser()

    function shouldShow(allowedRoles){
        if(allowedRoles === null) {
            return true;
        }
        else if(allowedRoles !== null && currentUser === null) {
            return false;
        }

        return allowedRoles.some(r => currentUser.roles.includes(r))
    }

    const onImageClick = (advertisement) => {
        if(shouldShow([Role.User, Role.Admin])) {
            navigate(`/games/${gameId}/advertisements/${advertisement.id}`)
        }
    }

    useEffect(() => {
        advertisementService.getAll(gameId).then((res) => {
            const advertisementsList = res.data;
            setAdvertisements(
                advertisementsList.map((advertisement) =>
                    createData(advertisement.id, advertisement.title, advertisement.editDate, advertisement.description, advertisement.condition, advertisement.price, advertisement.photos)
                )
            );
            setApiHappened(true)
            console.log(advertisements)
        });
    }, []);

    return (
    <Box marginTop="20px">
        <Grid container spacing={{ xs: 0, md: 1 }} >
            {
                advertisements.length > 0 ?
                advertisements.map((advertisement, index) => (
                    <Grid item xs={12} sm={6} md={4} lg={3} key={index} height="auto"  onClick = {() => {onImageClick(advertisement)}}>
                        <img style={imageStyle}
                            width="100%"
                            height='250px'
                            src={`https://saitynaistorage.blob.core.windows.net/images/${advertisement.photos.split(';')[0]}`}
                            alt={advertisement.title}
                            loading="lazy"
                           
                        />
                        <Typography variant="h5">{advertisement.title}</Typography>
                        <Typography variant="h7">{advertisement.price + "€"}</Typography>
                    </Grid>
                    )) : apiHappened ? 
                    <Grid item xs={12}>
                        <Typography variant="h5">
                            No Resources
                        </Typography>
                        <img 
                            src="https://i.pinimg.com/originals/b7/2d/d0/b72dd05180817700dd6d7558ca653138.gif"
                        />
                    </Grid> : null
            }
        </Grid>
    </Box>
    )
}