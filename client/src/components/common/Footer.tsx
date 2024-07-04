import { Facebook, X, GitHub } from '@mui/icons-material';
import {
	Box,
	Container,
	Typography,
	IconButton,
	useTheme,
} from '@mui/material';

function Footer() {
	const theme = useTheme();
	return (
		<Box
			sx={{
				backgroundColor: theme.palette.divider,
			}}
		>
			<Container maxWidth='lg'>
				<Box
					sx={{
						display: 'flex',
						justifyContent: 'center',
						alignItems: 'center',
					}}
				>
					<Typography variant='body2'>
						&copy; {new Date().getFullYear()} Momentum. All rights reserved.
					</Typography>
					<IconButton
						size='small'
						color='inherit'
						href='https://facebook.com'
						target='_blank'
					>
						<Facebook />
					</IconButton>
					<IconButton
						size='small'
						color='inherit'
						href='https://twitter.com'
						target='_blank'
					>
						<X />
					</IconButton>

					<IconButton color='inherit' href='https://github.com' target='_blank'>
						<GitHub />
					</IconButton>
				</Box>
			</Container>
		</Box>
	);
}

export default Footer;
