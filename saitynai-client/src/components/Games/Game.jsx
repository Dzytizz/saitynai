import { Box, Button, Grid, Modal, Typography } from "@mui/material"
import { useEffect } from "react"
import { useState } from "react"
import { useParams } from "react-router-dom"
import gameService from "../../services/game.service"
import {Link, useNavigate } from "react-router-dom";
import DeleteIcon from '@mui/icons-material/Delete';
import { RolesContext, RolesProvider } from "../../RolesContext"
import { Role } from "../roles"

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
        <Typography variant="h4" component="div" mb={3} align="center" marginTop = "20px">
            {game.title}
        </Typography>
        <hr/>
        <Grid container>
            <Grid item xs={12} sm={12} md={6} style={{border:"1px dashed #4c768d", borderRadius:"25px"}}>
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
                <hr/>
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
                <hr/>
                <Typography component="h1" variant="h5"> 
                    Rules
                    <Typography>
                        {game.rules}
                    </Typography>
                </Typography>
                <hr/>

            </Grid>
            
            <Grid container>
            <Grid item xs={12}>
                <hr/>
            </Grid>
                <RolesProvider allowedRoles={[Role.User]}>
                    <Grid item xs={12} md={6} marginTop="20px">
                        <Button className="button" variant="outlined" component={Link} to={`/games/${id}/advertisements/new`} size="large">Add Advertisement</Button>
                    </Grid>
                </RolesProvider>
                
                    <Grid item xs={12} md={6} marginTop="20px">
                        <Button variant="outlined" component={Link} to={`/games/${id}/advertisements`} size="large">See Game Advertisements</Button>
                    </Grid>
                
          
                <Grid item xs={12} md={12} marginTop="20px">
                    <RolesProvider allowedRoles={[Role.Admin]}>
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
                    </RolesProvider>
                
                 </Grid>
                 <RolesProvider allowedRoles={[Role.Admin]}>
                    <Grid item xs={12}>
                        <Button variant="outlined" component={Link} to={`/games/${id}/update`} size="large">Update Game</Button>
                    </Grid>
                 </RolesProvider>
               
            </Grid>
           
          
        </Grid>
    </Box> : (null)
}