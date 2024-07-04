import { PaletteMode } from '@mui/material';
import { createTheme, ThemeOptions } from '@mui/material/styles';

const getDesignTokens = (mode: PaletteMode): ThemeOptions => ({
	palette: {
		mode,
		...(mode === 'light'
			? {
					// palette values for light mode
					primary: { main: '#066868' },
			  }
			: {
					// palette values for dark mode
					primary: { main: '#05afaf' },
			  }),
	},
});

const createCustomTheme = () => {
	return createTheme(getDesignTokens('light'));
};

export default createCustomTheme;
