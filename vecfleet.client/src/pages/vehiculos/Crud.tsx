import { Formik, validateYupSchema } from 'formik'
import { useEffect, useState } from 'react'
import { Button, Container, Form, Spinner } from 'react-bootstrap'
import { useParams } from 'react-router'
import { API_VEHICULO_URL, getVehiculo, postVehiculos, putVehiculos } from '../../api/Api.Client'
import { DialogSuccess, Tipo } from '../../components/dialog/DialogSuccess'
import { TipoVehiculoType, VehiculoRequestType } from '../../types/Vehiculo'

const initial: VehiculoRequestType = {
  anio: 0,
  cantidadRuedas: 0,
  chasis: '',
  idTipoVehiculo: 0,
  kmsProximoMantenimiento: 0,
  kmsRecorrido: 0,
  marca: '',
  modelo: '',
  patente: ''
}

const CrudVehiculo = () => {
  const { id } = useParams()
  const [tiposVehiculo, setTiposVehiculo] = useState<TipoVehiculoType[]>()
  const [showModal, setShowModal] = useState(false)
  const [submitting, setSubmitting] = useState(false)
  const [initialValues, setInitialValues] = useState<VehiculoRequestType>(initial)
  const cargoSelectTipoVehiculo = async () => {
    const res = await globalThis.fetch(`${API_VEHICULO_URL}/TipoVehiculo`)
    if (res.ok) {
      const tipo: TipoVehiculoType[] = await res.json()
      setTiposVehiculo(tipo)
    }
  }
  useEffect(() => { cargoSelectTipoVehiculo() }, [])
  const handleSubmit = async (values: VehiculoRequestType) => {
    setSubmitting(true)
    if (id) {
      try {
        var res = await putVehiculos(values, id)
        if (res) {
          setShowModal(true)
        }

      } catch (error) {
        alert(error)
      }
      setSubmitting(false)
      return
    }
    try {
      debugger
      var res = await postVehiculos(values)
      if (res) {
        setShowModal(true)
      }

    } catch (error) {
      alert(error)
    }
    setSubmitting(false)
    return
  }
  const cargoVehiculo = () => {
    if (!id) return
    getVehiculo(id).then(data => setInitialValues(data)).catch(err => alert(err))
  }
  useEffect(cargoVehiculo, [id])

  return (
    <Container className='pt-3'>
      <DialogSuccess show={showModal} handleClose={() => setShowModal(false)} type={!id ? Tipo.Create : Tipo.Edit} />
      <h1>{!id ? 'Nuevo Vehiculo' : 'Edición de Vehiculo'}</h1>
      <Formik
        initialValues={initialValues}
        enableReinitialize
        validate={values => {
          const errors = {};
          /* @ts-ignore */
          if (values.idTipoVehiculo === 0) errors.idTipoVehiculo = "No funciona"
          return errors;
        }}
        onSubmit={(values, { setSubmitting }) => {
          handleSubmit(values)
          setSubmitting(false)
        }}
      >
        {({
          values,
          errors,
          touched,
          handleChange,
          handleBlur,
          handleSubmit,
          isSubmitting,
          /* and other goodies */
        }) => (
          <Form onSubmit={handleSubmit}>
            <Form.Group>
              <Form.Label>Tipo Vehiculo</Form.Label>
              <Form.Select placeholder="Ingrese Tipo Vehiculo" name='idTipoVehiculo' onChange={handleChange} value={values.idTipoVehiculo} >
                <option value={0}>Seleccione un tipo</option>
                {tiposVehiculo?.map(item => (<option key={item.id} value={item.id}>{item.descripcion}</option>))}
              </Form.Select>
            </Form.Group>
            <Form.Group>
              <Form.Label>Marca</Form.Label>
              <Form.Control placeholder="Ingrese Marca" name='marca' onChange={handleChange} value={values.marca} />
            </Form.Group>
            <Form.Group>
              <Form.Label>Modelo</Form.Label>
              <Form.Control placeholder="Ingrese Modelo" name='modelo' onChange={handleChange} value={values.modelo} />
            </Form.Group>
            <Form.Group>
              <Form.Label>Año</Form.Label>
              <Form.Control placeholder="Ingrese Año" type='number' name='anio' onChange={handleChange} value={values.anio} />
            </Form.Group>
            <Form.Group>
              <Form.Label>Chasis</Form.Label>
              <Form.Control placeholder="Ingrese Chasis" name='chasis' onChange={handleChange} value={values.chasis} />
            </Form.Group>
            <Form.Group>
              <Form.Label>Patente</Form.Label>
              <Form.Control placeholder="Ingrese Patente" name='patente' onChange={handleChange} value={values.patente} />
            </Form.Group>
            <Form.Group>
              <Form.Label>Cantidad de Ruedas</Form.Label>
              <Form.Control placeholder="Ingrese Cantidad de Ruedas" type='number' name='cantidadRuedas' onChange={handleChange} value={values.cantidadRuedas} />
            </Form.Group>
            <Form.Group>
              <Form.Label>Kms Recorridos</Form.Label>
              <Form.Control placeholder="Ingrese Kms Recorridos" type='number' name='kmsRecorrido' onChange={handleChange} value={values.kmsRecorrido} />
            </Form.Group>
            <Form.Group>
              <Form.Label>Kms Prox Mantenimiento</Form.Label>
              <Form.Control placeholder="Ingrese Kms Prox Mantenimiento" type='number' name='kmsProximoMantenimiento' onChange={handleChange} value={values.kmsProximoMantenimiento} />
            </Form.Group>
            <div className='w-full py-3 text-right'>
              <Button type='submit' variant='primary' disabled={submitting} >Guardar</Button>
            </div>
          </Form>

        )}
      </Formik>
    </Container>
  )
}

export { CrudVehiculo }