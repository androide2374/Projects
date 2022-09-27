import { Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { deleteVehiculos } from '../../api/Api.Client';
import { VehiculoType } from '../../types/Vehiculo';

const formatDate = (date: string) => {
  return new Date(date).toLocaleDateString()
}
interface Props {
  vehiculos: VehiculoType[]
  reload: VoidFunction
}
const Tbody = ({ vehiculos, reload }: Props) => {
  const handleDelete = async (id: number) => {
    const res = deleteVehiculos(id).then(() => reload()).catch((err) => alert(err))
  }
  return (
    <>
      {vehiculos.map((vehiculo) => (
        <tr key={vehiculo.id}>
          <td>{vehiculo.marca}</td>
          <td>{vehiculo.modelo}</td>
          <td>{vehiculo.patente}</td>
          <td>{vehiculo.chasis}</td>
          <td>{vehiculo.anio}</td>
          <td>{formatDate(vehiculo.fechaRegistro.toString())}</td>
          <td>{vehiculo.tipoVehiculo.descripcion}</td>
          <td>{vehiculo.cantidadRuedas}</td>
          <td>{vehiculo.kmsRecorrido}</td>
          <td>{vehiculo.kmsProximoMantenimiento}</td>
          <td className='flex gap-1 justify-center'>
            <Link to={`/editar/${vehiculo.id}`}>
              <Button variant='primary'>Editar</Button>
            </Link>
            <Button variant='danger' onClick={() => handleDelete(vehiculo.id)}>Eliminar</Button> </td>
        </tr>
      ))}
    </>
  )
}
export { Tbody }