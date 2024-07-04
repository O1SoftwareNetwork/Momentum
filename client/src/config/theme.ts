import { createTheme } from '@mui/material/styles';

const createCustomTheme = () => {
	return createTheme({
		palette: {
			mode: 'dark',
			primary: {
				main: '#066868',
				light: '#05afaf',
				dark: '#066868',
			},
		},
	});
};

export default createCustomTheme;
