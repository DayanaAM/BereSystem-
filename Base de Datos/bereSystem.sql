
USE bereSystem
go

                                       /*Creacion de tablas*/ 

IF OBJECT_ID('dbo.Estado') IS NULL
BEGIN
create table Estado (
codigo int not null,
estado varchar(15)
)
END


go

IF OBJECT_ID('dbo.Producto') IS NULL
BEGIN
create table Producto (
codigo int identity not null,
nombre varchar(50),
stock int,
categoria int, /*fk*/
precio money,
estado int
)
END


go

IF OBJECT_ID('dbo.Categoria') IS NULL
BEGIN
create table Categoria(
codigo int identity not null,
nombre varchar(50),
estado int
)
END

go

IF OBJECT_ID('dbo.Zona_Tratamiento') IS NULL
BEGIN
create table Zona_Tratamiento(
codigo int identity not null,
nombre varchar(50),
estado int
)
END
go

IF OBJECT_ID('dbo.Tipo_Servicio') IS NULL
BEGIN
create table Tipo_Servicio(
codigo int identity not null,
nombre varchar(50),
estado int
)
END
go

IF OBJECT_ID('dbo.Servicio') IS NULL
BEGIN
create table Servicio(
codigo int identity not null,
nombre varchar(50),
categoria int,  /*fk*/
zona int, /*fk*/
precio money,
tipoServicio int,  /*fk*/
duracionMinutos int, 
estado int
) 
END
go

IF OBJECT_ID('dbo.Horario') IS NULL
BEGIN
create table Horario(
codigo int not null identity,
nombre varchar(30),
estado int
)
END
go

IF OBJECT_ID('dbo.Dia_Hora') IS NULL
BEGIN
create table Dia_Hora(
dia datetime not null,
hora int not null, 
estado int
)
END
go

IF OBJECT_ID('dbo.Cita') IS NULL
BEGIN
create table Cita(      
numCita int identity not null, /*pk*/
dia datetime not null, /*pk*/
horario int,  /*fk*/
horaInicio int,
horaFin int,
minutosDisponibles int,
cantidadTotalMin int,
estado int
)
END
go


IF OBJECT_ID('dbo.Cita_Servicio') IS NULL
BEGIN
create table Cita_Servicio(     
numCita int not null,/*fk*/
usuario uniqueidentifier  not null,  /*fk, pk*/ 
servicio int not null, /*fk, pk*/
hora int not null,
duracionMinutos int not null, 
estado int 
)
END
go

IF OBJECT_ID('dbo.Factura') IS NULL
	CREATE TABLE Factura(
	numFactura int identity not null,/*pk*/ 
	fecha datetime not null,
	cliente uniqueidentifier not null,/*fk*/
	descuento int not null,
	montototal int not null,
	estado int not null
)
END
go


IF OBJECT_ID('dbo.Detalle_Factura') IS NULL
CREATE TABLE Detalle_Factura(
   numFactura int not null,/*fk*/ 
   producto int ,/*fk*/ 
   servicio int , /*fk*/ 
   precio money not null,
   cantidad int not null,
   total money not null
)
END
go


                                         /*Creacion de llaves primarias*/
 IF OBJECT_ID('dbo.pk_Estado') IS NULL
BEGIN
Alter table Estado add constraint pk_Estado Primary key (codigo)
END
IF OBJECT_ID('dbo.pk_CodProducto') IS NULL
BEGIN
Alter table Producto add constraint pk_CodProducto Primary key (codigo)
END
IF OBJECT_ID('dbo.pk_CodCategoria') IS NULL
BEGIN
Alter table Categoria add constraint pk_CodCategoria Primary key (codigo)
END
IF OBJECT_ID('dbo.pk_ZonaTratamiento') IS NULL
BEGIN
Alter table Zona_Tratamiento add constraint pk_ZonaTratamiento Primary key (codigo)
END
IF OBJECT_ID('dbo.pk_TipoServicio') IS NULL
BEGIN
Alter table Tipo_Servicio add constraint pk_TipoServicio Primary key (codigo)
END
IF OBJECT_ID('dbo.pk_Servicio') IS NULL
BEGIN
Alter table Servicio add constraint pk_Servicio Primary key (codigo)
END
IF OBJECT_ID('dbo.pk_Cita') IS NULL
BEGIN
Alter table Cita add constraint pk_Cita Primary key (numCita,dia)
END
IF OBJECT_ID('dbo.pk_Horario') IS NULL
BEGIN
Alter table Horario add constraint pk_Horario Primary key (codigo)
END
IF OBJECT_ID('dbo.pk_Cita_Servicio') IS NULL
BEGIN
Alter table Cita_Servicio add constraint pk_Cita_Servicio Primary key (numCita,usuario, servicio)
END
IF OBJECT_ID('dbo.pk_Factura') IS NULL
BEGIN
Alter table Factura add constraint pk_Factura Primary key (numFactura)
END


                                   /*Creacion de llaves foraneas*/ 

IF OBJECT_ID('dbo.fk_ProdCategoria') IS NULL
BEGIN
Alter table Producto add constraint fk_ProdCategoria foreign key (categoria) references Categoria(codigo)
END
IF OBJECT_ID('dbo.fk_ProdEstado') IS NULL
BEGIN
Alter table Producto add constraint fk_ProdEstado foreign key (estado) references Estado(codigo)
END
IF OBJECT_ID('dbo.fk_ServCategoria') IS NULL
BEGIN
Alter table Servicio add constraint fk_ServCategoria foreign key (categoria) references Categoria(codigo)
END
IF OBJECT_ID('dbo.fk_ServZona') IS NULL
BEGIN
Alter table Servicio add constraint fk_ServZona foreign key (zona) references Zona_Tratamiento(codigo)
END
IF OBJECT_ID('dbo.fk_ServTipo') IS NULL
BEGIN
Alter table Servicio add constraint fk_ServTipo foreign key (tipoServicio) references Tipo_Servicio(codigo)
END
IF OBJECT_ID('dbo.fk_ServEstado') IS NULL
BEGIN
Alter table Servicio add constraint fk_ServEstado foreign key (estado) references Estado(codigo)
END
IF OBJECT_ID('dbo.fk_CitEstado') IS NULL
BEGIN
Alter table Cita add constraint fk_CitEstado foreign key (estado) references Estado(codigo)
END
IF OBJECT_ID('dbo.fk_CitHorario') IS NULL
BEGIN
Alter table Cita add constraint fk_CitHorario foreign key (horario) references Horario(codigo)
END
IF OBJECT_ID('dbo.fk_HorEstado') IS NULL
BEGIN
Alter table Horario add constraint fk_HorEstado foreign key (estado) references Estado(codigo)
END
IF OBJECT_ID('dbo.fk_CatEstado') IS NULL
BEGIN
Alter table Categoria add constraint fk_CatEstado foreign key (estado) references Estado(codigo)
END
IF OBJECT_ID('dbo.fk_ZonTraEstado') IS NULL
BEGIN
Alter table Zona_Tratamiento add constraint fk_ZonTraEstado foreign key (estado) references Estado(codigo)
END
IF OBJECT_ID('dbo.fk_TipServEstado') IS NULL
BEGIN
Alter table Tipo_Servicio add constraint fk_TipServEstado foreign key (estado) references Estado(codigo)
END
IF OBJECT_ID('dbo.fk_DiaHoraEstado') IS NULL
BEGIN
Alter table Dia_Hora add constraint fk_DiaHoraEstado foreign key (estado) references Estado(codigo)
END
IF OBJECT_ID('dbo.fk_CitaServNumCita') IS NULL
BEGIN
Alter table Cita_Servicio add constraint fk_CitaServNumCita foreign key (numCita) references Cita(numCita) 
END
IF OBJECT_ID('dbo.fk_CitaServUsuario') IS NULL
BEGIN
Alter table Cita_Servicio add constraint fk_CitaServUsuario foreign key (usuario) references aspnet_Users(UserId) 
END
IF OBJECT_ID('dbo.fk_CitaServServicio') IS NULL
BEGIN
Alter table Cita_Servicio add constraint fk_CitaServServicio foreign key (servicio) references Servicio(codigo)
END
IF OBJECT_ID('dbo.fk_CitaServEstado') IS NULL
BEGIN
Alter table Cita_Servicio add constraint fk_CitaServEstado foreign key (estado) references Estado(codigo)
END
IF OBJECT_ID('dbo.fk_FactUsuario') IS NULL
BEGIN
Alter table Factura add constraint fk_FactUsuario foreign key (usuario) references aspnet_Users(UserId) 
END
IF OBJECT_ID('dbo.fk_FactEstado') IS NULL
BEGIN
Alter table Factura add constraint fk_FactEstado foreign key (estado) references Estado(codigo)
END

IF OBJECT_ID('dbo.fk_DetFactNumFactura') IS NULL
BEGIN
Alter table Detalle_Factura add constraint fk_DetFactNumFactura foreign key (numFactura) references Factura(numFactura)
END 
IF OBJECT_ID('dbo.fk_DetFactProducto') IS NULL
BEGIN
Alter table Detalle_Factura add constraint fk_DetFactProducto foreign key (producto) references Producto(codigo)
END
IF OBJECT_ID('dbo.fk_DetFactServicio') IS NULL
BEGIN
Alter table Detalle_Factura add constraint fk_DetFactServicio foreign key (servicio) references Servicio(codigo)
END
IF OBJECT_ID('dbo.fk_DetFactEstado') IS NULL
BEGIN
Alter table Detalle_Factura add constraint fk_DetFactEstado foreign key (estado) references Estado(codigo)
END

------------------------------------------------------------------------------------------------------------------


/*POR AQUELLO QUE SE OCUPE DESPUES */


create table cierre_Caja(
cod numeric(9,0) identity (1,1) primary key,
fecha datetime not null,
monto money,
usuario varchar(15)
)

create table cierre_Diario
(montoDigitado money,
montoRegistrado money,
sobrante money,
faltante money,
fecha datetime
)