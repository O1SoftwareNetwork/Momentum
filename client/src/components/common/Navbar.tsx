import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import Logo from '../../assets/Logo';
import { Link } from '@mui/material';

export default function Navbar() {
	return (
		<AppBar color='default' position='static'>
			<Toolbar sx={{ display: 'flex', gap: '1rem' }}>
				<Link
					href='/'
					underline='none'
					sx={{
						display: 'flex',
						gap: '.5rem',
						justifyContent: 'center',
						alignItems: 'center',
					}}
				>
					<Box sx={{ width: '40px' }}>
						<Logo />
					</Box>
					<Typography
						variant='h6'
						component='div'
						sx={{ flexGrow: 1, fontWeight: 'bold' }}
					>
						Momentum
					</Typography>
				</Link>
			</Toolbar>
		</AppBar>
	);
}
