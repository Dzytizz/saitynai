import { Box, Grid, Typography } from "@mui/material"
import { useEffect } from "react"
import { useState } from "react"
import { useParams } from "react-router-dom"
import gameService from "../../services/game.service"
//import { Link, useNavigate } from "react-router-dom";

function createData(id, title, description, minPlayers, maxPlayers, rules, difficulty, photos) {
    return {id, title, description, minPlayers, maxPlayers, rules, difficulty, photos}
}

const imageStyle ={
    objectFit: 'contain'
}

export function Game(){
    //const navigate = useNavigate();
    const [game, setGame] = useState(null)
    const [photos, setPhotos] = useState('default.jpg')
    const {id} = useParams()

    useEffect(() => {
        gameService.get(id).then((res) => {
            const game = res.data;
            setGame(createData(game.id,game.title,game.description,game.minPlayers,game.maxPlayers,game.rules,game.difficulty,game.photos));
            setPhotos(game.photos.split(';')[0])
            console.log(game)
            //
        })
        // }).catch((error) => {
        //     if(error.response.status == 401) {
        //         navigate('/unauthorized')
        //     }
        // })

    }, []);

    return game !== null ? 
    <Box>
        <Typography variant="h4" component="div" mb={3} align="center">
            {game.title}
        </Typography>
        <Grid container>
            <Grid item xs={12} sm={12} md={6}>
                <img style={imageStyle}
                    width="100%"
                    height="350px"
                    src={`https://saitynaistorage.blob.core.windows.net/images/${photos}`}
                />
            </Grid>
            <Grid item xs={12} sm={12} md={6}>
                <Typography component="h1" variant="h5"> 
                    Description
                    <Typography>
                        {game.description}
                    </Typography>
                </Typography>
                <Grid container>
                    <Grid item xs={6}>
                        <Typography component="h1" variant="h5"> 
                            Min players
                            <Typography>
                                {game.minPlayers}
                            </Typography>
                        </Typography>
                    </Grid>
                    <Grid item xs={6}>
                        <Typography component="h1" variant="h5"> 
                            Max players
                            <Typography>
                                {game.maxPlayers}
                            </Typography>
                        </Typography>
                    </Grid>
                </Grid>
                <Typography component="h1" variant="h5"> 
                    Rules
                    <Typography>
                        {game.rules}
                    </Typography>
                </Typography>
            </Grid>
        </Grid>
    </Box> : (null)
}