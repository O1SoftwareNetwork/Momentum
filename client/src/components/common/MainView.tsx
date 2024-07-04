import styled from '@emotion/styled';
import { Typography } from '@mui/material';

function MainView() {
	return (
		<View>
			<img src='/traveling.svg' alt='traveling placeholder' />
			<Typography variant='h4'>
				We currently don't have much to show, please come back
			</Typography>
		</View>
	);
}

export default MainView;

const View = styled.div`
	flex: 1;
	display: flex;
	flex-direction: column;
	justify-content: center;
	gap: 1rem;
	align-items: center;
	> img {
		max-width: 800px;
	}
`;
