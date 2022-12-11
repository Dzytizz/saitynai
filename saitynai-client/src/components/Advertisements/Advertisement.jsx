import { Box, Button, Grid, Modal, TextField, Typography } from "@mui/material"
import { useEffect } from "react"
import { useState } from "react"
import { useParams } from "react-router-dom"
import advertisementService from "../../services/advertisement.service"
import {Link, useNavigate } from "react-router-dom";
import { format } from "date-fns";
import DeleteIcon from '@mui/icons-material/Delete';
import commentService from "../../services/comment.service"
import { RolesProvider } from "../../RolesContext"
import { Role } from "../roles"
import { useCurrentUser } from "../../CurrentUserContext"

function createData(id, title, editDate, description, condition, price, photos) {
    return {id, title, editDate, description, condition, price, photos}
}

function createComment(id, editDate, description) {
    return {id, editDate, description}
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

export function Advertisement(){
    const navigate = useNavigate()
    const [open, setOpen] = useState(false);
    const handleOpen = () => setOpen(true)
    const handleClose = () => setOpen(false)
    const [advertisement, setAdvertisement] = useState(null)
    const [comments, setComments] = useState([])
    const [photos, setPhotos] = useState('default.jpg')
    const {gameId, id} = useParams()
    const [comment, setComment] = useState("");

    function shouldShow(){

    }

    const handleCommentChange = (event) => {
        setComment(event.target.value)
    }

    const updateComment = (event) => {
        setComment(event.target.value);
    }

    const deleteAdvertisement = () => {
        advertisementService.delete(gameId, id).then((res) => {
            console.log('advertisement deleted')
            handleClose()
            navigate(`/games/${gameId}/advertisements`)
        }).catch((error) => {
            if(error.response.status == 401 || error.response.status == 403) {
              navigate('/unauthorized')
            }
        })
    }

    const addComment = () => {
        const commentObj = {
          Description: comment,
        };

        console.log(commentObj)
    
        if(comment !== "") {
            commentService.create(gameId, id, commentObj).then((res) => {
                console.log("comment created")
                window.location.reload();
            }).catch((error) => {
                if(error.response.status == 401 || error.response.status == 403) {
                  navigate('/unauthorized')
                }
            })
        }
    }

    const deleteComment = (commentId) => {
        commentService.delete(gameId, id, commentId).then((res) => {
            console.log('comment deleted')
            handleClose()
            window.location.reload();
        }).catch((error) => {
            if(error.response.status == 401 || error.response.status == 403) {
              navigate('/unauthorized')
            }
        })
    }

    useEffect(() => {
        advertisementService.get(gameId,id).then((res) => {
            const advertisement = res.data;
            setAdvertisement(createData(advertisement.id, advertisement.title, advertisement.editDate, advertisement.description, advertisement.condition, advertisement.price, advertisement.photos));
            setPhotos(advertisement.photos.split(';')[0])
            console.log(advertisement)
            //
        }).catch((error) => {
            if(error.response.status == 401 || error.response.status == 403) {
                navigate('/unauthorized')
              }
        });

        commentService.getAll(gameId,id).then((res) => {
            const commentsList = res.data;
            setComments(
                commentsList.map((comment) =>
                    createComment(comment.id, comment.editDate, comment.description)
                )
            );
            console.log(comments)
        }).catch((error) => {
            if(error.response.status == 401 || error.response.status == 403) {
                navigate('/unauthorized')
              }
        });
    }, []);

    return advertisement !== null ? 
    <Box>
        <Typography variant="h4" component="div" mb={3} align="center"  style={{ marginTop:'10px'}}>
            {advertisement.title}
        </Typography>
        <hr/>
        <Grid container >
            <Grid item xs={12} sm={12} md={6} style={{border:"1px dashed #4c768d", borderRadius:"25px"}} >
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
                        {advertisement.description}
                    </Typography>
                    <hr/>
                </Typography>
                <Grid container>
                    <Grid item xs={6}>
                        <Typography component="h1" variant="h5"> 
                            Condition
                            <Typography>
                                {advertisement.condition}
                            </Typography>
                        </Typography>
                    </Grid>
                    <Grid item xs={6}>
                        <Typography component="h1" variant="h5"> 
                            Price
                            <Typography>
                                {advertisement.price + "€"}
                            </Typography>
                        </Typography>
                    </Grid>
                </Grid>
                <hr/>
                <Typography component="h1" variant="h5"> 
                    Edit Date
                    <Typography>
                        {format(new Date(advertisement.editDate), "MMMM do, yyyy H:mma")}
                    </Typography>
                </Typography>
                <hr/>

            </Grid>
            <Grid item xs={12}>
                <hr/>
            </Grid>
          
        </Grid>
        <Grid container style={{ marginTop:'50px'}}>
        
            <Grid item xs={12} md={6}>
                <RolesProvider allowedRoles={[Role.User]}>
                    <Button variant="outlined" component={Link} to={`/games/${gameId}/advertisements/${id}/update`} size="large">Update Advertisement</Button>
                </RolesProvider>
            </Grid>
            <Grid item xs={12} md={6}>
                <Button onClick={handleOpen} variant="outlined" startIcon={<DeleteIcon />} size="large">Delete</Button> 
                < Modal  
                    open={open}
                    onClose={handleClose}>
                    <Box sx={style}>
                    <Typography id="modal-modal-title" variant="h6" component="h2">
                        Are you sure you want to delete this Advertisement?
                    </Typography>
                    <Button onClick={deleteAdvertisement} variant="outlined">Yes</Button>
                    <Button variant="outlined" onClick={handleClose}>No</Button>
                    </Box>
                </Modal>
            </Grid>
        </Grid>
        <Grid container spacing={{ xs: 1 }}>
            
            <Grid item xs={12} >
                <Typography variant ="h5" style={{ marginTop:'50px'}}>Comments</Typography>
                <hr/>
            </Grid>
            <Grid item xs={6} >
                <TextField 
                    id="comment"
                    name="comment"
                    label="Comment"
                    variant="outlined"
                    onChange={handleCommentChange}
                    onBlur={updateComment}
                    value={comment}
                    fullWidth
                    autoFocus
                />
            </Grid>
            <Grid item xs={6}>
                <Button onClick={()=>{addComment()}} variant="outlined" size="large">Add Comment</Button>
            </Grid>
            <Grid container>
                <Grid item xs={12}>
                    <hr/>
                </Grid>
            {comments.map((comment, index) => (
            <Grid item xs={12} sm={6} md={4} key={index} height="auto" style={{ marginTop:'20px', border: '1px solid gray'}}>
                
                <Grid container>
                    <Grid item xs={12} md={8}>
                        <Typography variant="h6">{comment.description}</Typography>
                        <Typography>{format(new Date(comment.editDate), "MMMM do, yyyy H:mma")}</Typography>
                    </Grid>

                    <Grid item xs={12} md={4}>
                        <Button onClick={handleOpen} variant="outlined" startIcon={<DeleteIcon />}>Delete</Button>
                        < Modal  
                        open={open}
                        onClose={handleClose}>
                        <Box sx={style}>
                        <Typography id="modal-modal-title" variant="h6" component="h2">
                            Are you sure you want to delete this Comment?
                        </Typography>
                        <Button onClick={() => {deleteComment(comment.id)}} variant="outlined">Yes</Button>
                        <Button variant="outlined" onClick={handleClose}>No</Button>
                        </Box>
                        </Modal>
                    </Grid>
                </Grid>
            
            </Grid>
            ))}
            </Grid>
           
        </Grid>
    </Box> : (null)
}