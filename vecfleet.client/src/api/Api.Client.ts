import axios from 'axios'
import { VehiculoRequestType } from '../types/Vehiculo'
const API_VEHICULO_URL='http://localhost:5001/api'

const getVehiculos=  async ()=>{
  try {
    const res = await axios.get(`${API_VEHICULO_URL}/vehiculo`)
    return res.data
  } catch (error) {
    console.log(error)
    Promise.reject(error)
  }
}
const getVehiculo=  async (id:string)=>{
  try {
    const res = await axios.get(`${API_VEHICULO_URL}/vehiculo/${id}`)
    return res.data
  } catch (error) {
    console.log(error)
    Promise.reject(error)
  }
}
const deleteVehiculos=async (id:string)=>{
  const res = await axios.delete(`${API_VEHICULO_URL}/vehiculo/${id}`)
  if (res.status === 200) {
    return true
  }
  return Promise.reject('Error al borrar el vehiculo intente de nuevo mas tarde')
}
const postVehiculos=async(values:VehiculoRequestType)=>{
  try {
    
    const res = await fetch(`${API_VEHICULO_URL}/vehiculo`, {
      body: JSON.stringify(values),
      headers: {
        'Content-Type': 'application/json'
      },
      method:'POST'
    })
    if(res.status===201) return true
  } catch (error) {
    Promise.reject(error)  
  }
}
const putVehiculos=async(values:VehiculoRequestType, id:string)=>{
  try {
    const res = await globalThis.fetch(`${API_VEHICULO_URL}/Vehiculo?id=${id}`, {
      body: JSON.stringify(values),
      headers: {
        'Content-Type': 'application/json'
      },
      method:'PUT'
    })
    if(res.status===200) return true
    throw new Error(res.status.toString())
  } catch (error) {
    Promise.reject(error)  
  }
}
export {API_VEHICULO_URL, getVehiculos,deleteVehiculos,getVehiculo,postVehiculos,putVehiculos}