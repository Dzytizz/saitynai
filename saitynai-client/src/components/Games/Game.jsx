import { Box, Button, Grid, Modal, Typography } from "@mui/material"
import { useEffect } from "react"
import { useState } from "react"
import { useParams } from "react-router-dom"
import gameService from "../../services/game.service"
import {Link, useNavigate } from "react-router-dom";
import DeleteIcon from '@mui/icons-material/Delete';

function createData(id, title, description, minPlayers, maxPlayers, rules, difficulty, photos) {
    return {id, title, description, minPlayers, maxPlayers, rules, difficulty, photos}
}

const imageStyle ={
    objectFit: 'contain'
}


const style = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
    p: 4,
  };


export function Game(){
    const navigate = useNavigate()
    const [open, setOpen] = useState(false);
    const handleOpen = () => setOpen(true)
    const handleClose = () => setOpen(false)
    const [game, setGame] = useState(null)
    const [photos, setPhotos] = useState('default.jpg')
    const {id} = useParams()

    const deleteGame = () => {
        gameService.delete(id).then((res) => {
            console.log('game deleted')
            handleClose()
            navigate(`/games`)
        })
    }

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
            <Grid container>
                <Grid item xs={12} md={6}>
                    <Button variant="outlined" component={Link} to={`/games/${id}/advertisements/new`} size="large">Add Advertisement</Button>
                </Grid>
                <Grid item xs={12} md={6}>
                    <Button variant="outlined" component={Link} to={`/games/${id}/advertisements`} size="large">See Game Advertisements</Button>
                </Grid>
                <Grid item xs={12} md={12}>
                    <Button onClick={handleOpen} variant="outlined" startIcon={<DeleteIcon />} size="large">Delete</Button>
                    < Modal  
                    open={open}
                    onClose={handleClose}>
                    <Box sx={style}>
                    <Typography id="modal-modal-title" variant="h6" component="h2">
                        Are you sure you want to delete this Game?
                    </Typography>
                    <Button onClick={deleteGame} variant="outlined">Yes</Button>
                    <Button variant="outlined" onClick={handleClose}>No</Button>
                    </Box>
                </Modal>
                 </Grid>
            </Grid>
           
          
        </Grid>
    </Box> : (null)
}