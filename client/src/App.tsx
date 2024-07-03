import { useEffect } from "react";
import { useActions, useAppState } from "./store";

function App() {

	const state = useAppState();
	const actions = useActions();
	useEffect(() => {
		actions.sample.changeMessage();	
	},[])
	
	
	return (
		<>
			<h1>{state.sample.message}</h1>
		</>
	);
}

export default App;
