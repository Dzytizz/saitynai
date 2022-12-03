import { InsertEmoticon } from "@mui/icons-material";
import { Grid, ImageList, ImageListItem, ImageListItemBar, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import gameService from "../../services/game.service";
import { Game } from "./Game";
import { styled } from '@mui/material/styles';
import { Link, useNavigate } from "react-router-dom";

function createData(Id, Title, Description, MinPlayers, MaxPlayers, Rules, Difficulty, Photos) {
    return {Id, Title, Description, MinPlayers, MaxPlayers, Rules, Difficulty, Photos}
}

export function GamesList(){
    const navigate = useNavigate();
    const [games, setGames] = useState([])

    useEffect(() => {
        gameService.getAll().then((res) => {
            const gamesList = res.data;
            setGames(
                gamesList.map((game) =>
                    createData(game.Id, game.Title, game.Description, game.MinPlayers, game.MaxPlayers, game.Rules, game.Difficulty, game.Photos)
                )
            );
        });
    }, []);

    
const itemData = [
    {
      img: 'https://images.unsplash.com/photo-1551963831-b3b1ca40c98e',
      title: 'Breakfast',
      author: '@bkristastucchio',
    },
    {
      img: 'https://images.unsplash.com/photo-1551782450-a2132b4ba21d',
      title: 'Burger',
      author: '@rollelflex_graphy726',
    },
    {
      img: 'https://images.unsplash.com/photo-1522770179533-24471fcdba45',
      title: 'Camera',
      author: '@helloimnik',
    },
    {
      img: 'https://images.unsplash.com/photo-1444418776041-9c7e33cc5a9c',
      title: 'Coffee',
      author: '@nolanissac',
    },
    {
      img: 'https://images.unsplash.com/photo-1533827432537-70133748f5c8',
      title: 'Hats',
      author: '@hjrc33',
    },
    {
      img: 'https://images.unsplash.com/photo-1558642452-9d2a7deb7f62',
      title: 'Honey',
      author: '@arwinneil',
    },
    {
      img: 'https://images.unsplash.com/photo-1516802273409-68526ee1bdd6',
      title: 'Basketball',
      author: '@tjdragotta',
    },
    {
      img: 'https://images.unsplash.com/photo-1518756131217-31eb79b20e8f',
      title: 'Fern',
      author: '@katie_wasserman',
    },
    {
      img: 'https://images.unsplash.com/photo-1597645587822-e99fa5d45d25',
      title: 'Mushrooms',
      author: '@silverdalex',
    },
    {
      img: 'https://images.unsplash.com/photo-1567306301408-9b74779a11af',
      title: 'Tomato basil',
      author: '@shelleypauls',
    },
    {
      img: 'https://images.unsplash.com/photo-1471357674240-e1a485acb3e1',
      title: 'Sea star',
      author: '@peterlaster',
    },
    {
      img: 'https://images.unsplash.com/photo-1589118949245-7d38baf380d6',
      title: 'Bike',
      author: '@southside_customs',
    },
  ];

  const ImageGalleryList = styled('ul')(({ theme }) => ({
    display: 'grid',
    padding: 0,
    margin: theme.spacing(2,2),
    gap: 8,
    rowGap: 70,
    [theme.breakpoints.up('sm')]: {
        gridTemplateColumns: 'repeat(2, 1fr)'
    },
    [theme.breakpoints.up('md')]: {
        gridTemplateColumns: 'repeat(3, 1fr)'
    },
    [theme.breakpoints.up('lg')]: {
        gridTemplateColumns: 'repeat(4, 1fr)'
    },
}));
  

    return (
        // <Grid container spacing={{ xs: 2, md: 3 }}>
        //     {Array.from(Array(6)).map((_, index) => (
        //         <Grid item xs={12} sm={6} md={4} lg={3} key={index}>
        //             <h1>dasdas</h1>
        //         </Grid>
        //     ))}
        // </Grid>
        <ImageGalleryList>
            {itemData.map((item) => (
                <ImageListItem key={item.img}>
                    <img
                        src={`${item.img}?w=248&fit=crop&auto=format`}
                        srcSet={`${item.img}?w=248&fit=crop&auto=format&dpr=2 2x`}
                        alt={item.title}
                        loading="lazy"
                        onClick = {() => navigate(`/games/${item.title}`)}
                    />
                    <ImageListItemBar
                        title={item.title}
                        subtitle={item.author}
                        position="below"
                    />
                </ImageListItem>
            ))}
        </ImageGalleryList>
    )
}