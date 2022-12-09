import { InsertEmoticon, } from "@mui/icons-material";
import { Grid, ImageList, ImageListItem, ImageListItemBar, Typography, Container } from "@mui/material";
import React, { useEffect, useState } from "react";
import advertisementService from "../../services/advertisement.service";
import { Link, useNavigate, useParams } from "react-router-dom";
import Box from "@mui/material/Box";
import CssBaseline from "@mui/material/CssBaseline";

import { createTheme, ThemeProvider } from "@mui/material/styles";

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
    const {gameId} = useParams()

    useEffect(() => {
        advertisementService.getAll(gameId).then((res) => {
            const advertisementsList = res.data;
            setAdvertisements(
                advertisementsList.map((advertisement) =>
                    createData(advertisement.id, advertisement.title, advertisement.editDate, advertisement.description, advertisement.condition, advertisement.price, advertisement.photos)
                )
            );
            console.log(advertisements)
        });
    }, []);

    return (
    <Box>
        <Grid container spacing={{ xs: 0, md: 1 }} >
            {advertisements.map((advertisement, index) => (
            <Grid item xs={12} sm={6} md={4} lg={3} key={index} height="auto"  onClick = {() => navigate(`/games/${gameId}/advertisements/${advertisement.id}`)}>
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
            ))}
        </Grid>
    </Box>
    )
}