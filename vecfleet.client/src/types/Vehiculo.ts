 interface VehiculoType {
  anio:                    number;
  cantidadRuedas:          number;
  chasis:                  string;
  fechaRegistro:           Date;
  id:                      number;
  idTipoVehiculo:          number;
  kmsProximoMantenimiento: number;
  kmsRecorrido:            number;
  marca:                   string;
  modelo:                  string;
  patente:                 string;
  tipoVehiculo:            TipoVehiculoType;
 }
 
 interface TipoVehiculoType {
  descripcion: string;
  estado:      boolean;
  id:          number;
 }

 interface VehiculoRequestType{
    marca: string;
    cantidadRuedas: number;
    modelo: string;
    patente: string;
    chasis: string;
    kmsRecorrido: number;
    kmsProximoMantenimiento: number;
    anio: number;
    idTipoVehiculo: number;
 }
 export type {VehiculoType, TipoVehiculoType, VehiculoRequestType}