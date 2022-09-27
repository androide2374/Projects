import { Button, Modal } from 'react-bootstrap'
import { AiOutlineCheckCircle } from 'react-icons/ai'
import { Link } from 'react-router-dom'
interface Props {
  show: boolean
  handleClose: () => void
  type: Tipo
}
export enum Tipo {
  Create = "creado",
  Edit = "editado"
}

const DialogSuccess = ({ show, handleClose, type }: Props) => {

  return (
    <Modal show={show} backdrop='static' keyboard={false}>
      <Modal.Header>
        <Modal.Title>Vehiculo {type} con exito </Modal.Title>
      </Modal.Header>
      <Modal.Body className='flex justify-center items-center'><AiOutlineCheckCircle color='green' className='text-9xl' /></Modal.Body>
      <Modal.Footer>
        <Link to={'/'}>
          <Button variant="primary">
            Continuar
          </Button>
        </Link>
      </Modal.Footer>
    </Modal>
  )
}
export { DialogSuccess }