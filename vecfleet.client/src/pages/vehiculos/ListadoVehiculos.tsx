import { Button, Container } from 'react-bootstrap';
import Table from 'react-bootstrap/Table';
import { useEffect, useState } from 'react';
import { VehiculoType } from '../../types/Vehiculo';
import { Tbody } from '../../components/table/Tbody';
import { Link } from 'react-router-dom';
import { getVehiculos } from '../../api/Api.Client';


export default function ListadoVehiculos() {
  const [vehiculos, setVehiculos] = useState<VehiculoType[]>([]);
  const loadVehiculos = () => {
    getVehiculos().then(data => {
      setVehiculos(data)
    }).catch(err => console.log(err))
  }
  useEffect(() => {
    loadVehiculos()
  }, []);
  return (
    <Container fluid className='mt-10'>
      <div className='w-full flex items-end justify-end p-2'>
        <Link to={'/Nuevo'}>

          <Button
            size='sm'
            variant='primary'
          >
            Nuevo Vehiculo
          </Button>
        </Link>
      </div>
      <Table striped bordered hover responsive>
        <thead>
          <tr>
            <th>Marca</th>
            <th>Modelo</th>
            <th>Patente</th>
            <th>Chasis</th>
            <th>Año</th>
            <th>Fecha Registro</th>
            <th>Tipo Vehiculo</th>
            <th>Cantidad Ruedas</th>
            <th>Kms Recorridos</th>
            <th>Kms Prox. Mantenimiento</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          <Tbody vehiculos={vehiculos} reload={loadVehiculos} />
        </tbody>
      </Table>

    </Container>

  )
}