import { Typography } from "@mui/material";
import { Box } from "@mui/system";

export function Unauthorized() {
    return (<Box>
        <Typography variant="h2" color={"darkred"}>
            UNAUTHORIZED
        </Typography>
        <Typography variant="h5">
            The resource or action you are trying to access requires additional permissions.
        </Typography>
    </Box>)

}