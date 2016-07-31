use bereSystem

go

--***** store procedure Inserta Categoria
create procedure sp_inserta_categoria
	@pNombre  varchar(50), @pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
 
         insert into Categoria(
                               nombre,
                               estado) 
      values ( @pNombre,
               @pEstado ); 
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de incluir un nuevo Categoria.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch
   go



  --****Store procedure sp_modifica_categoria*****--

  create procedure sp_modifica_categoria
	@pCodigo int,@pNombre varchar(50) , @pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Categoria set nombre=@pNombre,estado=@pEstado
	where codigo=@pCodigo;
         
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de modificar la categoria.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go


--***** elimina categoria*
create procedure sp_eliminar_categoria
	@pCodigo int,@pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Categoria set estado=0
	where codigo=@pCodigo;
         
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de eliminar la Categoria.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go

--*****sp_lista_categorias *******--
create procedure sp_lista_categorias
as
   begin try      -- Declarar el Inicio del try catch 			
	select codigo,nombre,estado from Categoria;
         
   end try  
   begin catch        -- Declaración del Inicio del Catch
       raiserror('Error al tratar de listar las Categorias.', 16, 1);    
   end catch
go


--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++--
--*********sp_inserta_cita********--
create procedure sp_inserta_cita
	@pDia datetime, @pHorario int,@pHoraInicio int ,
	@pHoraFin int, @pMinutosDisponibles int,
	@pCantidadTotalMin int, @pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
 
         insert into Cita(dia,horario,horaInicio,horaFin,minutosDisponibles,cantidadTotalMin,estado)
         values ( @pDia,
                  @pHorario,
                  @pHoraInicio,
                  @pHoraFin,
			      @pMinutosDisponibles,
			      @pCantidadTotalMin,
                  @pEstado ); 
         
   commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de incluir un nueva Cita.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go


--******sp_modifica_cita***
create procedure sp_modifica_cita
	@pNumCita int,@pDia datetime, 
	@pHorario int,@pHoraInicio int ,
	@pHoraFin int, @pMinutosDisponibles int,
	@pCantidadTotalMin int, @pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Cita set dia=@pDia,horario=@pHorario,horaInicio=@pHoraInicio,
	horaFin=@pHoraFin,minutosDisponibles=@pMinutosDisponibles,
	cantidadTotalMin=@pCantidadTotalMin,estado=@pEstado
	where numCita=@pNumCita and dia=@pDia and horario=@pHorario;
         
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de modificar la Cita.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go

--***** sp_eliminar_cita**
create procedure sp_eliminar_cita
	@pNumCita int,@pDia datetime,@pHorario int,
	@pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Cita set estado=0
	where numCita=@pNumCita and  dia=@pDia and horario=@pHorario;
         
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de eliminar la Cita .', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go


--***** sp_lista_citas***
create procedure sp_lista_citas
as
   begin try      -- Declarar el Inicio del try catch 			
	select numCita,dia,horario,horaInicio,horaFin,minutosDisponibles,cantidadTotalMin, estado from Cita;
         
   end try  
   begin catch        -- Declaración del Inicio del Catch
       raiserror('Error al tratar de listar las Citas.', 16, 1);    
   end catch
go

--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++--
--***********sp_inserta_citaServicio************--
create procedure sp_inserta_cita_servicio
	@pNumCita int, @pUsuario uniqueidentifier ,@pServicio int,
	@pHora int, @pDuracionMinutos int, @pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
 
         insert into Cita_Servicio(numCita, 
								   usuario,
								   servicio,
								    hora,
								   duracionMinutos,
								   estado) 
      values ( @pNumCita,
		       @pUsuario,
	           @pServicio,
			   @pHora,
			   @pDuracionMinutos, 
			   @pEstado); 
				 
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de incluir un registro en Cita Servicio.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go


--******sp_modifica_citaServicio****

create procedure sp_modifica_cita_servicio
	@pNumCita int, @pUsuario uniqueidentifier ,@pServicio int,
	@pHora int, @pDuracionMinutos int, @pEstado int
as    
   begin try -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Cita_Servicio set numCita=@pNumCita, usuario=@pUsuario,servicio=@pServicio,hora=@pHora,duracionMinutos= @pDuracionMinutos,estado=@pEstado
		where numCita=@pNumCita and usuario=@pUsuario and servicio=@pServicio and estado=@pEstado ;
         
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de modificar Cita Servicio.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go



--***** elimina sp_eliminar_cita_servicio*****
create procedure sp_eliminar_cita_servicio
     @pNumCita int, @pUsuario uniqueidentifier ,@pServicio int, @pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Cita_Servicio set estado=0
	where numCita=@pNumCita and usuario=@pUsuario and servicio=@pServicio;
         
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de eliminar la cita servicio.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go

--***** sp_lista_cita_servicios***
create procedure sp_lista_cita_servicios
as
   begin try      -- Declarar el Inicio del try catch 			
	select numCita,usuario,servicio,hora,duracionMinutos, estado from Cita_Servicio;
         
   end try  
   begin catch        -- Declaración del Inicio del Catch
       raiserror('Error al tratar de listar detalles de Cita Servicio .', 16, 1);    
   end catch
go


--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++--

--***********sp_inserta_detalle_factura************--
create procedure sp_inserta_detalle_factura
	@pNumFactura int, @pProducto int ,@pServicio int,
	@pPrecio int, @pCantidad int, @pTotal int, @pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
 
         insert into Detalle_Factura(numFactura,
										producto,
										servicio,
										precio,
										cantidad,
										total,
										estado) 
      values ( 	@pNumFactura ,
				@pProducto,
				@pServicio,
				@pPrecio ,
				@pCantidad ,
				@pTotal ,
			    @pEstado ); 
				 
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de incluir un registro en Detalle de Factura.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go


--******sp_modifica_detalle_factura****

create procedure sp_modifica_detalle_factura
	@pNumFactura int, @pProducto int ,@pServicio int,
	@pPrecio int, @pCantidad int, @pTotal int, @pEstado int
as    
   begin try -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Detalle_Factura set numFactura= @pNumFactura,producto= @pProducto,servicio =@pServicio, precio=@pPrecio,cantidad=@pCantidad,total= @pTotal,estado= @pEstado
		where numFactura =@pNumFactura and producto=@pProducto and servicio=@pServicio and estado=@pEstado ;
         
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de modificar Detalle Factura ', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go



--***** sp_eliminar_detalle_factura*****
create procedure sp_eliminar_detalle_factura
     @pNumFactura int, @pProducto int ,@pServicio int, @pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Detalle_Factura set estado=0
	where numFactura =@pNumFactura and producto=@pProducto and servicio=@pServicio and estado=@pEstado;         
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de eliminar Detalle Factura.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go

--*****sp_lista_detalles_factura***
create procedure sp_lista_detalles_factura
as
   begin try      -- Declarar el Inicio del try catch 			
	select numFactura,producto,servicio, precio,cantidad,total, estado from Detalle_Factura;
         
   end try  
   begin catch        -- Declaración del Inicio del Catch
       raiserror('Error al tratar de listar detalles de Detalle Factura .', 16, 1);    
   end catch
go


--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++--


--***********sp_inserta_horaDia***********--
create procedure sp_inserta_horaDia
	@pDia datetime, @pHora int,@pEstado int  
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
 
         insert into Dia_Hora(dia,
							  hora,
							  estado) 
      values ( 	@pDia ,
	            @pHora ,
			    @pEstado); 
				 
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de incluir un registro en Dia Hora.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go


--******sp_modifica_dia_hora****

create procedure sp_modifica_dia_hora
	@pDia datetime, @pHora int,@pEstado int  
as    
   begin try -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Dia_Hora set dia =@pDia, hora= @pHora, estado=@pEstado
		where dia=@pDia and hora=@pHora;
         
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de modificar Dia Hora ', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go



--***** sp_eliminar_dia_hora*****
create procedure sp_eliminar_dia_hora
     @pDia datetime, @pHora int,@pEstado int  
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Dia_Hora set estado=0
	where dia=@pDia and hora=@pHora;     
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de eliminar Dia Hora.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go

--*****sp_lista_dia_horas********
create procedure sp_lista_dia_horas
as
   begin try      -- Declarar el Inicio del try catch 			
	select dia,hora,estado from Dia_Hora;
         
   end try  
   begin catch        -- Declaración del Inicio del Catch
       raiserror('Error al tratar de listar Dias Horas .', 16, 1);    
   end catch
go


--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++--



--***********sp_inserta_estado***********--
create procedure sp_inserta_estado
	@pCodigo int, @pEstado varchar(15)  
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
 
         insert into Estado(codigo,estado) 
      values ( 	@pCodigo,
				@pEstado); 
				 
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de incluir un registro en Estado.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go


--******sp_modifica_estado****

create procedure sp_modifica_estado
	@pCodigo int, @pEstado varchar(15) 
as    
   begin try -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Estado set estado= @pEstado
		where codigo=@pCodigo;    
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de modificar Estado ', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go



--***** sp_eliminar_estado*****
create procedure sp_eliminar_estado
     @pCodigo int, @pEstado varchar(15)  
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Estado set estado=0
	where codigo=@pCodigo;    
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de eliminar Estado.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go

--*****sp_lista_estados********
create procedure sp_lista_estados
as
   begin try      -- Declarar el Inicio del try catch 			
	select codigo,estado from Estado;
         
   end try  
   begin catch        -- Declaración del Inicio del Catch
       raiserror('Error al tratar de listar Estados .', 16, 1);    
   end catch
go

--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++--

--***********sp_inserta_factura************--
create procedure sp_inserta_factura
	@pNumFactura int, @pFecha datetime,@pCliente uniqueidentifier,
	@pDescuento  int, @pMontoTotal int, @pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
 
         insert into Factura(numFactura,
							 fecha,
							 cliente,
							 descuento,
							 montototal,
							 estado) 
      values ( @pNumFactura,
			   @pFecha,
			   @pCliente,
	           @pDescuento, 
			   @pMontoTotal, 
			   @pEstado); 
				 
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de incluir un registro en Factura.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go


--******sp_modifica_factura****

create procedure sp_modifica_factura
	@pNumFactura int, @pFecha datetime,@pCliente uniqueidentifier,
	@pDescuento  int, @pMontoTotal int, @pEstado int
as    
   begin try -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Factura set numFactura=@pNumFactura,fecha=@pFecha,cliente=@pCliente,descuento=@pDescuento,montototal=@pMontoTotal, estado=@pEstado
		where numFactura =@pNumFactura;
         
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de modificar Factura ', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go



--***** sp_eliminar_factura*****
create procedure sp_eliminar_factura
     @pNumFactura int, @pCliente uniqueidentifier, @pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Factura set estado=0
	where numFactura =@pNumFactura;        
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de eliminar Factura.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go

--*****sp_lista_facturas***
create procedure sp_lista_facturas
as
   begin try      -- Declarar el Inicio del try catch 			
	select numFactura,fecha,cliente,descuento,montototal,estado from Factura;
         
   end try  
   begin catch        -- Declaración del Inicio del Catch
       raiserror('Error al tratar de listar detalles de Detalle Factura .', 16, 1);    
   end catch
go

--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++--

--***** sp_inserta_horario*************
create procedure sp_inserta_horario
	@pNombre  varchar(30), @pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
 
         insert into Horario(nombre,
                             estado) 
      values ( @pNombre,
               @pEstado ); 
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de incluir un nuevo	Horario.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch
   go



  --****Store procedure sp_modifica_horario*****--

  create procedure sp_modifica_horario
	@pCodigo int,@pNombre varchar(50) , @pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Horario set nombre=@pNombre,estado=@pEstado
	where codigo=@pCodigo;
         
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de modificar el Horario.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go


--***** sp_eliminar_horario*
create procedure sp_eliminar_horario
	@pCodigo int,@pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Horario set estado=0
	where codigo=@pCodigo;
         
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de eliminar el Horario.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go

--*****sp_lista_horarios *******--
create procedure sp_lista_horarios
as
   begin try      -- Declarar el Inicio del try catch 			
	select codigo,nombre,estado from Horario;
         
   end try  
   begin catch        -- Declaración del Inicio del Catch
       raiserror('Error al tratar de listar los Horarios.', 16, 1);    
   end catch
go

--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++--


--***********sp_inserta_producto************--
create procedure sp_inserta_producto
	@pNombre varchar(50), @pStock int  ,@pCategoria int,
	@pPrecio money, @pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
 
         insert into Producto (nombre,
							   stock,
							   categoria,
							   precio,
							   estado) 
      values (@pNombre,
	          @pStock,
			  @pCategoria,
	          @pPrecio,
			  @pEstado); 
				 
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de incluir un registro en Producto.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go


--******sp_modifica_producto****

create procedure sp_modifica_producto
	@pCodigo INT ,@pNombre varchar(50), @pStock int  ,@pCategoria int,
	@pPrecio money, @pEstado int
as    
   begin try -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Producto set nombre=@pNombre, stock=@pStock,categoria=@pCategoria,precio=@pPrecio,estado=@pEstado
		where codigo=@pCodigo ;
         
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de modificar un Producto.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go



--***** sp_eliminar_producto*****
create procedure sp_eliminar_producto
     @pCodigo INT , @pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Producto set estado=0
     where codigo=@pCodigo ;
         
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de eliminar el Producto.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go

--***** sp_lista_productos***
create procedure sp_lista_productos
as
   begin try      -- Declarar el Inicio del try catch 			
	select codigo,nombre,stock,categoria,precio,estado from Producto;

   end try  
   begin catch        -- Declaración del Inicio del Catch
       raiserror('Error al tratar de listar Productos .', 16, 1);    
   end catch
go

--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++--


--***********sp_inserta_servicio************--
create procedure sp_inserta_servicio
	@pNombre varchar(50),@pCategoria int, @pZona int ,
	@pPrecio money, @pTipoServicio int,@pDuracionMinutos int,@pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
 
         insert into Servicio(nombre,
							  categoria,
							  zona,
							  precio,
							  tipoServicio,
							  duracionMinutos,
							  estado) 
      values (	@pNombre,
	            @pCategoria,
				@pZona ,
				@pPrecio,
				@pTipoServicio,
				@pDuracionMinutos,
				@pEstado); 
				 
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de incluir un registro en Servicio.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go


--******sp_modifica_servicio****

create procedure sp_modifica_servicio
	@pCodigo int ,@pNombre varchar(50),@pCategoria int, @pZona int ,
	@pPrecio money, @pTipoServicio int,@pDuracionMinutos int,@pEstado int
as    
   begin try -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Servicio set nombre=@pNombre,categoria=@pCategoria,zona=@pZona, precio=@pPrecio,tipoServicio=@pTipoServicio,
	                     duracionMinutos =@pDuracionMinutos,estado=@pEstado
		where codigo=@pCodigo ;
         
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de modificar un Servicio.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go



--***** sp_eliminar_servicio*****
create procedure sp_eliminar_servicio
     @pCodigo INT , @pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Servicio set estado=0
     where codigo=@pCodigo ;
         
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de eliminar el Servicio.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go

--*****sp_lista_servicios***
create procedure sp_lista_servicios
as
   begin try      -- Declarar el Inicio del try catch 			
	select codigo,nombre,categoria,zona,precio,tipoServicio,duracionMinutos,estado from Servicio;

   end try  
   begin catch        -- Declaración del Inicio del Catch
       raiserror('Error al tratar de listar Servicios .', 16, 1);    
   end catch
go

--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++--
--***** store procedure sp_inserta_tipo_servicio
create procedure sp_inserta_tipo_servicio
	@pNombre  varchar(50), @pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
 
         insert into Tipo_Servicio(
                               nombre,
                               estado) 
      values ( @pNombre,
               @pEstado ); 
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de incluir un nuevo Tipo Servicio .', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch
   go



  --****Store procedure sp_modifica_tipo_servicio*****--

  create procedure sp_modifica_tipo_servicio
	@pCodigo int,@pNombre varchar(50) , @pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Tipo_Servicio set nombre=@pNombre,estado=@pEstado
	where codigo=@pCodigo;
         
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de modificar el Tipo Servicio.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go


--***** sp_eliminar_tipo_servicio****
create procedure sp_eliminar_tipo_servicio
	@pCodigo int,@pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Tipo_Servicio set estado=0
	where codigo=@pCodigo;
         
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de eliminar la Categoria.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go


--*****sp_lista_tipo_servicios *******--
create procedure sp_lista_tipo_servicios
as
   begin try      -- Declarar el Inicio del try catch 			
	select codigo,nombre,estado from Tipo_Servicio;
         
   end try  
   begin catch        -- Declaración del Inicio del Catch
       raiserror('Error al tratar de listar los Tipos de Servicio.', 16, 1);    
   end catch
go

--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++--


--***** store procedure sp_inserta_zona_tratamiento
create procedure sp_inserta_zona_tratamiento
	@pNombre  varchar(50), @pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
 
         insert into Zona_Tratamiento(
                               nombre,
                               estado) 
      values ( @pNombre,
               @pEstado ); 
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de incluir una nueva Zona Tratamiento.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch
   go



  --****Store procedure sp_modifica_zona_tratamiento*****--

  create procedure sp_modifica_zona_tratamiento
	@pCodigo int,@pNombre varchar(50) , @pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Zona_Tratamiento set nombre=@pNombre,estado=@pEstado
	where codigo=@pCodigo;
         
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de modificar Zona Tratamiento.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go


--***** sp_eliminar_zona_tratamiento****
create procedure sp_eliminar_zona_tratamiento
	@pCodigo int,@pEstado int
as    
   begin try      -- Declarar el Inicio del try catch 
      begin transaction;  -- Declara el Inicio de la Transacción    
				
	update Zona_Tratamiento set estado=0
	where codigo=@pCodigo;
         
      commit transaction;  -- salvar la Transacción
   end try  
   begin catch        -- Declaración del Inicio del Catch
    raiserror('Error al tratar de eliminar Zona Tratamiento.', 16, 1);
      -- Realizar el Rollback de la Transacción     
      rollback transaction; 
   end catch

go


--*****sp_lista_zonas_tratamientos*******--
create procedure sp_lista_zonas_tratamientos
as
   begin try      -- Declarar el Inicio del try catch 			
	select codigo,nombre,estado from Zona_Tratamiento;
         
   end try  
   begin catch        -- Declaración del Inicio del Catch
       raiserror('Error al tratar de listar las Zonas Tratamiento.', 16, 1);    
   end catch
go

--++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++--
