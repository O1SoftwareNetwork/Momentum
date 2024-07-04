import { Box } from '@mui/material';
import Footer from './components/common/Footer';
import MainView from './components/common/MainView';
import Navbar from './components/common/Navbar';

function App() {
	return (
		<Box
			sx={{
				display: 'flex',
				minHeight: '100vh',
				flexDirection: 'column',
			}}
		>
			<Navbar />
			<MainView />
			<Footer />
		</Box>
	);
}

export default App;
