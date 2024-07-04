import { useLayoutEffect } from 'react';
import { useActions, useAppState } from './store';
import Logo from './assets/Logo';

function App() {
	const state = useAppState();
	const actions = useActions();
	useLayoutEffect(() => {
		actions.sample.changeMessage();
	}, []);

	return (
		<>
			<div style={{ width: '150px', height: '150px' }}>
				<Logo useAsLoader />
			</div>
			<h1>Backend Test message: {state.sample.message}</h1>
		</>
	);
}

export default App;
