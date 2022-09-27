import { NavBarSimple } from './components/navBar/NavBarSimple'
import ListadoVehiculos from './pages/vehiculos/ListadoVehiculos'
import { Route, Routes } from 'react-router-dom'
import { CrudVehiculo } from './pages/vehiculos/Crud'

function App() {
  return (<>
    <NavBarSimple />
    <Routes>
      <Route
        path='/'
        element={<ListadoVehiculos />}
      />
      <Route
        path='/Editar/:id'
        element={<CrudVehiculo />}
      />
      <Route
        path='/Nuevo'
        element={<CrudVehiculo />}
      />
    </Routes>
  </>
  )
}

export default App
