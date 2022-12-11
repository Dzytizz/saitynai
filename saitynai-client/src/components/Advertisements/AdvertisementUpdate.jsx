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
import { useEffect } from "react"
import { useCurrentUser } from '../../CurrentUserContext';
import { Role } from '../roles';

function createData(id, title, editDate, description, condition, price, photos) {
    return {id, title, editDate, description, condition, price, photos}
}

export function AdvertisementUpdate(){
    const {containsRoles} = useCurrentUser()
    const navigate = useNavigate();
    const [advertisement, setAdvertisement] = useState(null)
    const [photos, setPhotos] = useState('');
    const [condition, setCondition] = useState(5);
    const {gameId,id} = useParams()

    const handlePhotoChange = (event) => {
        setPhotos(event.target.files[0]);
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
        let advertisementData = {
          Title: data.get('title'),
          Description: data.get('description'),
          Condition: data.get('condition'),
          Price: data.get('price'),
          Photos: "default.jpg"
        };
    
        const formData = new FormData();
        if(typeof photos !== 'string') {
          formData.append('files', photos)
        }
        fileService.uploadImages(formData).then((res) => {
          if(res.data !== "") console.log('files uploaded succesfully')

          if(typeof photos !== 'string') {
            advertisementData.Photos = res.data
          } else {
            advertisementData.Photos = advertisement.photos
          }

          advertisementService.update(gameId, id, advertisementData).then((res) => {
            console.log('advertisement updated successfully')
            navigate(`/games/${gameId}/advertisements`)
          }).catch((error) => {
            if(error.response.status == 401  || error.response.status == 403) {
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

      advertisementService.get(gameId, id).then((res) => {
        const advertisement = res.data;
        setAdvertisement(createData(advertisement.id, advertisement.title, advertisement.editDate, advertisement.description, advertisement.condition, advertisement.price, advertisement.photos));
        setPhotos(advertisement.photos.split(';')[0])
        setCondition(advertisement.condition)
      })
      
    }, [])
    

    return ( advertisement ? 
<Box marginLeft={"50px"} marginRight="50px">
      <Typography variant="h4" component="div" mb={3} align="center" marginTop="20px">
        Update Advertisement
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
                  value={advertisement.title}
                  fullWidth
                  required
                  autoFocus
                  onChange={(event) =>
                    setAdvertisement({ ...advertisement, title: event.target.value })
                  }
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  id="description"
                  name="description"
                  label="Description"
                  variant="outlined"
                  value={advertisement.description}
                  fullWidth
                  multiline
                  rows={4}
                  required
                  onChange={(event) =>
                    setAdvertisement({ ...advertisement, description: event.target.value })
                  }
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
                <TextField
                  id="price"
                  name="price"
                  label="Price"
                  variant="outlined"
                  value={advertisement.price}
                  fullWidth
                  type="number"
                  required
                  onChange={(event) =>
                    setAdvertisement({ ...advertisement, price: event.target.value })
                  }
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
                  {typeof photos === 'string' ?
                  <img src={`https://saitynaistorage.blob.core.windows.net/images/${photos}`} width="100%" /> :
                  <img src={URL.createObjectURL(photos)} width="100%" /> 
                  }
                  
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
            Update
          </Button>
        </Box>
      </Box>
    </Box> : null
    );
}