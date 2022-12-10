import * as React from 'react';
import CssBaseline from '@mui/material/CssBaseline';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import Link from '@mui/material/Link';

function Copyright() {
    return (
      <Typography variant="body2" color="text.secondary">
        {'Copyright © STALIUS'}
        {new Date().getFullYear()}
        {'.'}
      </Typography>
    );
  }

export function Footer() {
    return (
        <Box
          sx={{
            display: 'flex',
            flexDirection: 'column',
            minHeight: '100vh',
          }}
        >
          <CssBaseline />
          
          <Box
            component="footer"
            sx={{
              py: 3,
              px: 2,
              mt: 'auto',
            }}
            className="footer"
          >
            <Container maxWidth="sm">
              <Typography variant="body1">
                {new Date().toJSON().slice(0,10).replace(/-/g,'/')}
              </Typography>
              <Copyright />
            </Container>
          </Box>
        </Box>
      );
}