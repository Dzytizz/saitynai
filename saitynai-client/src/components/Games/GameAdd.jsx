import {
    Box,
    Button,
    FormControl,
    Grid,
    InputLabel,
    MenuItem,
    Select,
    TextField,
    Typography
  } from '@mui/material';
import React, { useState } from 'react';
import InsertPhotoRoundedIcon from '@mui/icons-material/InsertPhotoRounded';
import gameService from "../../services/game.service";
import fileService from '../../services/file.service';
import {useNavigate } from "react-router-dom";
import { useEffect } from 'react';
import { useCurrentUser } from '../../CurrentUserContext';
import { Role } from "../roles";

export function GameAdd(){
    const {containsRoles} = useCurrentUser();
    const navigate = useNavigate();
    const [photos, setPhotos] = useState('');
    const [minPlayers, setMinPlayers] = useState(1);
    const [maxPlayers, setMaxPlayers] = useState(1);
    const [difficulty, setDifficulty] = useState(3);

    const handlePhotoChange = (event) => {
        setPhotos(event.target.files[0]);
    };

    const handleMinPlayersChange = (e) => {
        setMinPlayers(e.target.value);
    }

    const handleMaxPlayersChange = (e) => {
        setMaxPlayers(e.target.value);
    }

    const handleDifficultyChange = (e) => {
      setDifficulty(e.target.value)
    }

    const updateMinPlayers = (e) => {
      if(parseInt(e.target.value, 10) > parseInt(maxPlayers, 10)){
        setMaxPlayers(e.target.value)
      } 
      if(parseInt(e.target.value,10) <= 0) {
        setMinPlayers(1)
      } else {
        setMinPlayers(e.target.value)
      }
    }

    const updateMaxPlayers = (e) => {
        if(parseInt(minPlayers, 10) > parseInt(e.target.value, 10)) {
            setMaxPlayers(minPlayers)
        }
        else {
          setMaxPlayers(e.target.value)
        }
    }

    const updateDifficulty = (e) => {
      if (parseInt(e.target.value, 10) > 0 && parseInt(e.target.value, 10) < 6) {
        setDifficulty(e.target.value);
      }
      else {
        setDifficulty(3);
      }
    }

    const submit = (event) => {
        event.preventDefault();
        const data = new FormData(event.currentTarget);
        const game = {
          Title: data.get('title'),
          Description: data.get('description'),
          MinPlayers: data.get('minPlayers'),
          MaxPlayers: data.get('maxPlayers'),
          Rules: data.get('rules'),
          Difficulty: data.get('difficulty'),
          Photos: "default.jpg"
        };
    
        const formData = new FormData();
        if(photos !== null && photos !== "") {
          formData.append('files', photos)
        }

        fileService.uploadImages(formData).then((res) => {
          if(res.data !== '') console.log('files uploaded succesfully')

          if(photos !== "") {
            console.log(photos)
            game.Photos = res.data
          }
          console.log(game)

          gameService.create(game).then((res) => {
            console.log('game created successfully')
            console.log(res.data)
            navigate('/games')
          }).catch((error) => {
            console.error(error)
            if(error.response.status == 401 || error.response.status == 403) {
              navigate('/unauthorized')
            }
        })
        }).catch((error) => {
          console.error(error)
          if(error.response.status == 401 || error.response.status == 403) {
            navigate('/unauthorized')
          }
      })
      };

      useEffect(() => {
        if(!containsRoles([Role.Admin])) navigate('/unauthorized')
      }, [])
      

    return (
<Box marginLeft={"50px"} marginRight="50px">
      <Typography variant="h4" component="div" mb={3} align="center" marginTop={'20px'}>
        Add Game
      </Typography>
      <Box component="form" onSubmit={submit}>
        <Box display="flex" flexDirection={{ md: 'row', sm: 'column', xs: 'column' }}>
          <Box width={{ md: '70%', sm: '100%', xs: '100%' }} mr={5} mb={2}>
            <Grid container spacing={2}>
              <Grid item xs={12}>
                <TextField
                  id="title"
                  name="title"
                  label="Title"
                  variant="outlined"
                  fullWidth
                  required
                  autoFocus
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  id="description"
                  name="description"
                  label="Description"
                  variant="outlined"
                  fullWidth
                  multiline
                  rows={4}
                  required
                />
              </Grid>
              <Grid item xs={6}>
                <TextField
                  id="minPlayers"
                  name="minPlayers"
                  label="Minimum Players"
                  variant="outlined"
                  fullWidth
                  onChange={handleMinPlayersChange}
                  onBlur={updateMinPlayers}
                  value={minPlayers}
                  type="number"
                  required
                />
              </Grid>
              <Grid item xs={6}>
                <TextField
                  id="maxPlayers"
                  name="maxPlayers"
                  label="Maximum Players"
                  variant="outlined"
                  fullWidth
                  onChange={handleMaxPlayersChange}
                  onBlur={updateMaxPlayers}
                  value={maxPlayers}
                  type="number"
                  required
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  id="rules"
                  name="rules"
                  label="Rules"
                  variant="outlined"
                  fullWidth
                  multiline
                  rows={4}
                  required
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  id="difficulty"
                  name="difficulty"
                  label="Difficulty (1-5)"
                  onChange={handleDifficultyChange}
                  onBlur={updateDifficulty}
                  value={difficulty}
                  variant="outlined"
                  fullWidth
                 
                  type="number"
                  required
                />
              </Grid>
            </Grid>
          </Box>
          <Box width={{ md: '30%', sm: '100%', xs: '100%' }} flexDirection="column">
            <Grid container spacing={2}>
              <Grid item xs={12}>
                <TextField
                  id="photo"
                  label="Photos"
                  name="upload-photo"
                  type="file"
                  fullWidth
                  InputLabelProps={{
                    shrink: true
                  }}
                  variant="outlined"
                  onChange={handlePhotoChange}
                />
              </Grid>
              {photos ? (
                <Grid item xs={12}>
                  <img src={URL.createObjectURL(photos)} width="100%" />
                </Grid>
              ) : (
                <Grid item xs={12} sx={{ display: 'flex', justifyContent: 'center' }}>
                  <InsertPhotoRoundedIcon color="primary" sx={{ fontSize: '300px' }} />
                </Grid>
              )}
            </Grid>
          </Box>
        </Box>
        <br />
        <Box display={'flex'}>
          <Button type="submit" color="primary" variant="contained" sx={{ marginLeft: 'auto' }}>
            Add
          </Button>
        </Box>
      </Box>
    </Box>
    );
}