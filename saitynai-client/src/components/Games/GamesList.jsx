import { InsertEmoticon, } from "@mui/icons-material";
import { Grid, ImageList, ImageListItem, ImageListItemBar, Typography, Container } from "@mui/material";
import React, { useEffect, useState } from "react";
import gameService from "../../services/game.service";
import { Game } from "./Game";
import { Link, useNavigate } from "react-router-dom";
import Box from "@mui/material/Box";
import CssBaseline from "@mui/material/CssBaseline";

import { createTheme, ThemeProvider } from "@mui/material/styles";



const imageStyle ={
    objectFit: 'contain',
}

function createData(id, title, description, minPlayers, maxPlayers, rules, difficulty, photos) {
    return {id, title, description, minPlayers, maxPlayers, rules, difficulty, photos}
}

export function GamesList(){
    const navigate = useNavigate();
    const [games, setGames] = useState([])
    const [apiHappened, setApiHappened] = useState(false)

    useEffect(() => {
        gameService.getAll().then((res) => {
            const gamesList = res.data;
            setGames(
                gamesList.map((game) =>
                    createData(game.id, game.title, game.description, game.minPlayers, game.maxPlayers, game.rules, game.difficulty, game.photos)
                )
            );
            setApiHappened(true)
            console.log(games)
        });
    }, []);

    return (
    <Box marginTop="20px">
        <Grid container spacing={{ xs: 0, md: 1 }}>
            {
                games.length > 0 ?
                games.map((game, index) => (
                    <Grid item xs={12} sm={6} md={4} lg={3} key={index} height="auto"  onClick = {() => navigate(`/games/${game.id}`)}>
                        <img style={imageStyle}
                            width="100%"
                            height='250px'
                            src={`https://saitynaistorage.blob.core.windows.net/images/${game.photos.split(';')[0]}`}
                            //srcSet={`https://saitynaistorage.blob.core.windows.net/images/${game.photos.split(';')[0]}`}
                            alt={game.title}
                            loading="lazy"
                           
                        />
                        <Typography variant="h5">{game.title}</Typography>
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