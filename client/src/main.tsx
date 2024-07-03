import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css'
import { createOvermind } from 'overmind'
import { overmindConfig } from './store'
import { Provider } from 'overmind-react'


const overmind = createOvermind(overmindConfig, {
  devtools: process.env.NODE_ENV === 'development' ? 'localhost:3031' : undefined,
  name: 'Momentum'
})



ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <Provider value={overmind}>
      <App />
    </Provider>
  </React.StrictMode>,
)
