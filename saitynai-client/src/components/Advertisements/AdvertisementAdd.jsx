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
import advertisementService from '../../services/advertisement.service';
import fileService from '../../services/file.service';
import { useParams } from "react-router-dom"
import {useNavigate } from "react-router-dom";
import { useEffect } from 'react';
import { useCurrentUser } from '../../CurrentUserContext';
import { Role } from '../roles';

export function AdvertisementAdd(){
    const {containsRoles} = useCurrentUser()
    const navigate = useNavigate();
    const [photos, setPhotos] = useState('');
    const [condition, setCondition] = useState(5);
    const {gameId} = useParams()

    const handlePhotoChange = (event) => {
        setPhotos(event.target.files[0]);
        console.log(photos)
    };

    const handleConditionChange = (e) => {
        setCondition(e.target.value)
    };

    const updateCondition = (e) => {
        if(parseInt(e.target.value, 10) > 0 && parseInt(e.target.value, 10) <= 10){
          setCondition(e.target.value)
        } 
        else {
            setCondition(5);
        }
      }  

    const submit = (event) => {
        event.preventDefault();
        const data = new FormData(event.currentTarget);
        const advertisement = {
          Title: data.get('title'),
          Description: data.get('description'),
          Condition: data.get('condition'),
          Price: data.get('price'),
          Rules: data.get('rules'),
          Photos: "default.jpg"
        };
    
        const formData = new FormData();
        if(photos !== null && photos !== "") {
          formData.append('files', photos)
        }
        fileService.uploadImages(formData).then((res) => {
          console.log('files uploaded succesfully')
          console.log(res.data)
          if(photos !== "") {
            advertisement.Photos = res.data
          }
      
          console.log(advertisement)
          advertisementService.create(gameId, advertisement).then((res) => {
            console.log('advertisement created successfully')
            console.log(res.data)
            navigate(`/games/${gameId}/advertisements`)
          }).catch((error) => {
            if(error.response.status == 401 || error.response.status == 403) {
              navigate('/unauthorized')
            }
        })
        }).catch((error) => {
          if(error.response.status == 401 || error.response.status == 403) {
            navigate('/unauthorized')
          }
      })
      };

      useEffect(() => {
        if(!containsRoles([Role.Admin, Role.User])) navigate('/unauthorized')
      
      }, [])
      

    return (
<Box marginLeft={"50px"} marginRight="50px">
      <Typography variant="h4" component="div" mb={3} align="center" marginTop="20px">
        Add Advertisement
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
                  id="condition"
                  name="condition"
                  label="Condition (1-10)"
                  variant="outlined"
                  onChange={handleConditionChange}
                  onBlur={updateCondition}
                  value={condition}
                  fullWidth
                  type="number"
                  required
                />
              </Grid>
              <Grid item xs={6}>
                <TextField inputProps={{min:"0", step:"0.01"}}
                  type="number"
                  id="price"
                  name="price"
                  step={0.01}
                  label="Price"
                  variant="outlined"
                  fullWidth
      
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