USE [BD_ByS]
GO
/****** Object:  Schema [Inventario]    Script Date: 02/13/2016 20:03:09 ******/
CREATE SCHEMA [Inventario] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [RecursosHumanos]    Script Date: 02/13/2016 20:03:09 ******/
CREATE SCHEMA [RecursosHumanos] AUTHORIZATION [dbo]
GO
/****** Object:  Table [Inventario].[DetalleKardex]    Script Date: 02/13/2016 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Inventario].[DetalleKardex](
	[NumeroKardex] [int] NOT NULL,
	[NumeroDocumento] [nchar](10) NOT NULL,
	[TipodeMovimiento] [int] NULL,
	[NumeroNotaIngreso] [nchar](10) NULL,
	[NumeroSalida] [nchar](10) NULL,
	[Fecha] [datetime] NULL,
	[Cantidad] [decimal](18, 2) NULL,
 CONSTRAINT [PK_DetalleKardex] PRIMARY KEY CLUSTERED 
(
	[NumeroKardex] ASC,
	[NumeroDocumento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Inventario].[Almacen]    Script Date: 02/13/2016 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Inventario].[Almacen](
	[IdAlmacen] [int] NOT NULL,
	[NombreAlmacen] [nvarchar](50) NULL,
	[Direccion] [nvarchar](150) NULL,
	[UsuarioRegistro] [nchar](10) NULL,
	[FechaRegsitro] [datetime] NULL,
 CONSTRAINT [PK_Almacen] PRIMARY KEY CLUSTERED 
(
	[IdAlmacen] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Inventario].[Sucursal]    Script Date: 02/13/2016 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Inventario].[Sucursal](
	[idSucursal] [int] NOT NULL,
	[nombreSurcursal] [varchar](50) NULL,
	[direccion] [varchar](50) NULL,
	[ruc] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[responsable] [varchar](50) NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[idSucursal] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Inventario].[Proveedor]    Script Date: 02/13/2016 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Inventario].[Proveedor](
	[idProveedor] [int] NOT NULL,
	[nombreProveedor] [varchar](50) NULL,
	[nRuc] [varchar](15) NULL,
	[direccion] [varchar](50) NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[idProveedor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Inventario].[EstadoPedido]    Script Date: 02/13/2016 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Inventario].[EstadoPedido](
	[codigo] [int] NULL,
	[descripcion] [nvarchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [Inventario].[EstadoNotaIngreso]    Script Date: 02/13/2016 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Inventario].[EstadoNotaIngreso](
	[codigo] [char](1) NULL,
	[descripcion] [nvarchar](20) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [RecursosHumanos].[Empleado]    Script Date: 02/13/2016 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [RecursosHumanos].[Empleado](
	[codEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[codPersona] [int] NOT NULL,
	[codCargo] [int] NOT NULL,
	[codArea] [int] NOT NULL,
	[desNombre] [varchar](40) NOT NULL,
	[desApellido] [varchar](40) NOT NULL,
	[indActivo] [bit] NOT NULL,
	[segUsuarioCrea] [varchar](25) NOT NULL,
	[segUsuarioEdita] [varchar](25) NULL,
	[segFechaCrea] [datetime] NOT NULL,
	[segFechaEdita] [datetime] NULL,
	[segMaquinaOrigen] [varchar](25) NOT NULL,
	[indEliminado] [bit] NOT NULL,
	[desLogin] [varchar](40) NULL,
	[clvPassword] [varchar](250) NULL,
 CONSTRAINT [PK_Empleado_codEmpleado] PRIMARY KEY CLUSTERED 
(
	[codEmpleado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Inventario].[Empleado]    Script Date: 02/13/2016 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Inventario].[Empleado](
	[idEmpleado] [int] NOT NULL,
	[apellidoPaterno] [varchar](50) NULL,
	[apellidoMaterno] [varchar](50) NULL,
	[nDni] [varchar](8) NULL,
	[telefono] [varchar](50) NULL,
	[foto] [varchar](50) NULL,
	[fechaIngreso] [date] NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[idEmpleado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Inventario].[DetalleProgramacionPicking]    Script Date: 02/13/2016 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Inventario].[DetalleProgramacionPicking](
	[idProgramacionPicking] [int] NOT NULL,
	[NumeroPedido] [nchar](10) NOT NULL,
	[idProducto] [int] NOT NULL,
	[idUbicacion] [int] NULL,
	[descripcion] [varchar](50) NULL,
	[cantidadPedido] [int] NULL,
	[cantidadAtendida] [int] NULL,
 CONSTRAINT [PK_DetalleProgramacionPicking] PRIMARY KEY CLUSTERED 
(
	[idProgramacionPicking] ASC,
	[NumeroPedido] ASC,
	[idProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Inventario].[Producto]    Script Date: 02/13/2016 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Inventario].[Producto](
	[idProducto] [int] NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
	[UnidadMedida] [nvarchar](20) NULL,
	[Presentacion] [nvarchar](100) NULL,
	[codigoProducto] [varchar](10) NULL,
	[nombreProducto] [varchar](50) NULL,
	[tipoProducto] [varchar](50) NULL,
	[pesoProducto] [varchar](10) NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[uspSucursalListar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspSucursalListar]
AS
select * from Inventario.Sucursal
order by nombreSurcursal
GO
/****** Object:  StoredProcedure [dbo].[uspProveedorListar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspProveedorListar]
as
select * from Inventario.Proveedor
order by idProveedor
GO
/****** Object:  StoredProcedure [dbo].[uspProductoListarxId]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspProductoListarxId]
@idProducto int
AS
select * from Inventario.Producto
where idProducto = @idProducto
GO
/****** Object:  StoredProcedure [dbo].[uspProductoListar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspProductoListar]
AS
select * from Inventario.Producto
order by Descripcion
GO
/****** Object:  Table [Inventario].[Pedido]    Script Date: 02/13/2016 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Inventario].[Pedido](
	[NumeroPedido] [nchar](10) NOT NULL,
	[Fecha] [datetime] NULL,
	[IdSucursal] [int] NULL,
	[Estado] [int] NULL,
	[FechaRegistro] [datetime] NULL,
	[UsuarioRegistro] [nchar](20) NULL,
	[UsuarioAsignado] [nchar](20) NULL,
	[idProducto] [int] NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[NumeroPedido] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Inventario].[OrdenCompra]    Script Date: 02/13/2016 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Inventario].[OrdenCompra](
	[nOrdenCompra] [varchar](50) NOT NULL,
	[fecha] [date] NULL,
	[transportista] [varchar](50) NULL,
	[direccionEntrega] [varchar](50) NULL,
	[idProducto] [int] NULL,
	[idProveedor] [int] NULL,
	[estado] [nchar](1) NULL,
 CONSTRAINT [PK_OrdenCompra] PRIMARY KEY CLUSTERED 
(
	[nOrdenCompra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Inventario].[ProgramacionPicking]    Script Date: 02/13/2016 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Inventario].[ProgramacionPicking](
	[idProgramacionPicking] [int] NOT NULL,
	[idEmpleado] [int] NULL,
	[descripcion] [varchar](50) NULL,
	[fecha] [date] NULL,
	[turno] [varchar](50) NULL,
 CONSTRAINT [PK_ProgramacionPicking] PRIMARY KEY CLUSTERED 
(
	[idProgramacionPicking] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Inventario].[ProgramacionInventario]    Script Date: 02/13/2016 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Inventario].[ProgramacionInventario](
	[idProgramacionInventario] [int] NOT NULL,
	[idSucursal] [int] NULL,
	[IdAlmacen] [int] NULL,
	[fechaInventario] [date] NULL,
	[descripcionInventario] [varchar](50) NULL,
	[fechaRegistro] [date] NULL,
 CONSTRAINT [PK_ProgramacionInventario] PRIMARY KEY CLUSTERED 
(
	[idProgramacionInventario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[uspDetalleProgramacionPickingInsertar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspDetalleProgramacionPickingInsertar]
@idProgramacionPicking int,
@NumeroPedido nchar(10),
@idProducto int,
@idUbicacion int,
@descripcion varchar(50),
@cantidadPedido int,
@cantidadAtendida int

AS

insert into Inventario.DetalleProgramacionPicking
(
idProgramacionPicking, NumeroPedido, idProducto,idUbicacion,descripcion,cantidadPedido,cantidadAtendida
)
values
(@idProgramacionPicking,@NumeroPedido,@idProducto,@idUbicacion,@descripcion,@cantidadPedido,@cantidadAtendida)
GO
/****** Object:  StoredProcedure [dbo].[uspDetalleProgramacionPickingActualizarCantidad]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspDetalleProgramacionPickingActualizarCantidad]
@idProgramacionPicking int,
@NumeroPedido nchar(10),
@idProducto int,
@cantidadAtendida int
AS
update Inventario.DetalleProgramacionPicking
set cantidadAtendida = @cantidadAtendida
where idProgramacionPicking = @idProgramacionPicking
      and NumeroPedido = @NumeroPedido
      and idProducto = @idProducto
GO
/****** Object:  StoredProcedure [dbo].[uspEmpleadoValidarLogin]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspEmpleadoValidarLogin]
@Usuario varchar(20),
@Clave varchar(32)
As
Select *
From RecursosHumanos.Empleado
Where desLogin=@Usuario And clvPassword=@Clave
GO
/****** Object:  StoredProcedure [dbo].[uspEmpleadoListar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspEmpleadoListar]
AS
select * from RecursosHumanos.Empleado
order by desNombre
GO
/****** Object:  StoredProcedure [dbo].[uspDetalleProgramacionPickingListarxPicking]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspDetalleProgramacionPickingListarxPicking]
@id int
AS
select a.idProgramacionPicking, a.NumeroPedido, a.idProducto, 
		isnull(a.idUbicacion,0) as idUbicacion,
       isnull(a.descripcion,'') as descripcion, 
       isnull(a.cantidadPedido,0) as cantidadPedido, 
       isnull(a.cantidadAtendida,0) as cantidadAtendida,
		isnull(b.Descripcion,'') as NombreProducto
from Inventario.DetalleProgramacionPicking a
left outer join Inventario.Producto b on (a.idProducto = b.idProducto)
where idProgramacionPicking = @id
GO
/****** Object:  StoredProcedure [dbo].[uspDetalleProgramacionPickingListarxPedido]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspDetalleProgramacionPickingListarxPedido]
@NumeroPedido nchar(10)
AS
select a.idProgramacionPicking, a.NumeroPedido, a.idProducto, b.Descripcion as NombreProducto, 
       a.CantidadPedido, isnull(a.CantidadAtendida,0) as CantidadAtendida,
       (isnull(a.CantidadPedido,0) - isnull(a.CantidadAtendida,0)) as Saldo,
       b.UnidadMedida
from Inventario.DetalleProgramacionPicking a 
left outer join Inventario.Producto b on (a.idProducto = b.idProducto)
where a.NumeroPedido = @NumeroPedido
GO
/****** Object:  Table [Inventario].[Ubicacion]    Script Date: 02/13/2016 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Inventario].[Ubicacion](
	[idUbicacion] [int] NOT NULL,
	[IdAlmacen] [int] NULL,
	[Fila] [nchar](10) NULL,
	[Columna] [nchar](10) NULL,
	[Nivel] [nchar](10) NULL,
	[posicion] [nchar](10) NULL,
 CONSTRAINT [PK_Ubicacion] PRIMARY KEY CLUSTERED 
(
	[idUbicacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[uspDetalleKardexInsertar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspDetalleKardexInsertar]
@NumeroKardex int,
@NumeroDocumento nchar(10),
@TipodeMovimiento int,
@NumeroNotaIngreso nchar(10),
@NumeroSalida nchar(10),
@fecha datetime,
@cantidad int

AS
declare @contador int
select @contador = COUNT(NumeroKardex) from [Inventario].[DetalleKardex]
where [NumeroKardex] = @NumeroKardex
      and NumeroDocumento = @NumeroDocumento

if @contador = 0
begin      	
	INSERT INTO [Inventario].[DetalleKardex]
			   (NumeroKardex,NumeroDocumento,TipodeMovimiento,NumeroNotaIngreso
			    ,NumeroSalida, [fecha], Cantidad
			   )
		 VALUES
			   (@NumeroKardex,@NumeroDocumento,@TipodeMovimiento,@NumeroNotaIngreso
			    ,@NumeroSalida, GETDATE(), @Cantidad)
end
else
begin
	update [Inventario].[DetalleKardex]
	set Cantidad = Cantidad + @Cantidad
	where [NumeroKardex] = @NumeroKardex
			and NumeroDocumento = @NumeroDocumento
end
GO
/****** Object:  StoredProcedure [dbo].[uspAlmacenListar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspAlmacenListar]
AS
select * from Inventario.Almacen
order by  IdAlmacen
GO
/****** Object:  Table [Inventario].[UbicacionProducto]    Script Date: 02/13/2016 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Inventario].[UbicacionProducto](
	[idUbicacion] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[idUbicacion] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[uspOrdenCompraActualizarEstado]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspOrdenCompraActualizarEstado]
@nOrdenCompra varchar(50),
@Estado nchar(1)
AS
update Inventario.OrdenCompra
set estado = @Estado
where nOrdenCompra = @nOrdenCompra
GO
/****** Object:  Table [Inventario].[DetallePedido]    Script Date: 02/13/2016 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Inventario].[DetallePedido](
	[Item] [int] NOT NULL,
	[NumeroPedido] [nchar](10) NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [decimal](18, 2) NULL,
 CONSTRAINT [PK_DetallePedido] PRIMARY KEY CLUSTERED 
(
	[Item] ASC,
	[NumeroPedido] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Inventario].[DetalleOrdenCompra]    Script Date: 02/13/2016 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Inventario].[DetalleOrdenCompra](
	[nOrdenCompra] [varchar](50) NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [decimal](18, 2) NULL,
 CONSTRAINT [PK_DetalleOrdenCompra] PRIMARY KEY CLUSTERED 
(
	[nOrdenCompra] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Inventario].[NotaSalida]    Script Date: 02/13/2016 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Inventario].[NotaSalida](
	[NumeroSalida] [int] NOT NULL,
	[NumeroPedido] [nchar](10) NOT NULL,
	[idEmpleado] [int] NULL,
	[idProgramacionPicking] [int] NULL,
	[FechaSalida] [nchar](10) NULL,
	[idAlmacen] [int] NULL,
	[UsuarioPicking] [nchar](20) NULL,
	[Observaciones] [text] NULL,
	[EstadoNotaSalida] [text] NULL,
 CONSTRAINT [PK_NotaSalida] PRIMARY KEY CLUSTERED 
(
	[NumeroSalida] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Inventario].[NotaIngreso]    Script Date: 02/13/2016 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Inventario].[NotaIngreso](
	[NumeroNotaIngreso] [int] NOT NULL,
	[Fecha] [datetime] NULL,
	[NumeroOrdenCompra] [varchar](50) NULL,
	[idEmpleado] [int] NULL,
	[UsuarioRecibo] [nchar](10) NULL,
	[idAlmacen] [int] NULL,
	[GuiaRemsion] [nchar](20) NULL,
	[Observaciones] [text] NULL,
	[EstadoNotaIngreso] [nchar](1) NULL,
	[idProveedor] [int] NULL,
 CONSTRAINT [PK_NotaIngreso] PRIMARY KEY CLUSTERED 
(
	[NumeroNotaIngreso] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[uspPedidoListarxEstado]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspPedidoListarxEstado]
@estado int
AS
select a.*, b.nombreSurcursal 
from Inventario.Pedido a 
left outer join Inventario.Sucursal b on (a.IdSucursal = b.idSucursal)
where a.Estado = @estado
order by a.Fecha
GO
/****** Object:  StoredProcedure [dbo].[uspPedidoListarPickarxPedido]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspPedidoListarPickarxPedido]
@NumeroPedido varchar(10)
AS
declare @fecha datetime
set @fecha = (select top 1 b.fecha 
from Inventario.DetalleProgramacionPicking a, Inventario.ProgramacionPicking b
where a.NumeroPedido = @NumeroPedido and 
a.idProgramacionPicking = b.idProgramacionPicking)


select a.NumeroPedido, a.IdSucursal, b.nombreSurcursal, b.direccion , @fecha as Fecha
from Inventario.Pedido a 
left outer join Inventario.Sucursal b on (a.IdSucursal = b.idSucursal)
where a.NumeroPedido = @NumeroPedido
GO
/****** Object:  StoredProcedure [dbo].[uspPedidoFiltrar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspPedidoFiltrar]
@PedidoInicio nchar(10),
@PedidoFin nchar(10),
@IdSucursal int
AS
if (@IdSucursal = 0)
begin
	select a.*, b.nombreSurcursal 
	from Inventario.Pedido a 
	left outer join Inventario.Sucursal b on (a.IdSucursal = b.idSucursal)
	where a.NumeroPedido between @PedidoInicio and @PedidoFin
	      and a.Estado = 0
end
else
begin
	select a.*, b.nombreSurcursal 
	from Inventario.Pedido a 
	left outer join Inventario.Sucursal b on (a.IdSucursal = b.idSucursal)
	where a.IdSucursal = @IdSucursal
	      and a.Estado = 0
end
GO
/****** Object:  StoredProcedure [dbo].[uspPedidoActualizarEstado]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspPedidoActualizarEstado]
@NumeroPedido nchar(10),
@Estado int
AS
update Inventario.Pedido
set Estado = @estado
where NumeroPedido = @NumeroPedido
GO
/****** Object:  StoredProcedure [dbo].[uspOrdenCompraListarxEstado]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspOrdenCompraListarxEstado]
@estado nchar(1)
AS
select * from Inventario.OrdenCompra
where estado = @estado
GO
/****** Object:  StoredProcedure [dbo].[uspProgramacionInventarioListarxID]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspProgramacionInventarioListarxID]
@idProgramacionInventario int
AS
select a.*, b.nombreSurcursal, c.NombreAlmacen
from Inventario.ProgramacionInventario a
left outer join Inventario.Sucursal b on (a.idSucursal = b.idSucursal)
left outer join Inventario.Almacen c on (a.IdAlmacen = c.IdAlmacen)
where idProgramacionInventario = @idProgramacionInventario
GO
/****** Object:  StoredProcedure [dbo].[uspProgramacionInventarioListar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspProgramacionInventarioListar]
AS
select a.*, b.nombreSurcursal, c.NombreAlmacen
from Inventario.ProgramacionInventario a
left outer join Inventario.Sucursal b on (a.idSucursal = b.idSucursal)
left outer join Inventario.Almacen c on (a.IdAlmacen = c.IdAlmacen)
order by fechaInventario asc
GO
/****** Object:  StoredProcedure [dbo].[uspProgramacionInventarioInsertar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspProgramacionInventarioInsertar]
@idProgramacionInventario int,
@idSucursal int,
@idAlmacen int,
@fechaInventario datetime,
@descripcionInventario varchar(50)
AS

select @idProgramacionInventario = (COUNT(idProgramacionInventario) + 1)
from Inventario.ProgramacionInventario

insert into Inventario.ProgramacionInventario
(idProgramacionInventario,idSucursal,
IdAlmacen,fechaInventario,
descripcionInventario,fechaRegistro)
values
(@idProgramacionInventario,@idSucursal,
@IdAlmacen,@fechaInventario,
@descripcionInventario,GETDATE())
GO
/****** Object:  StoredProcedure [dbo].[uspProgramacionInventarioFiltrar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspProgramacionInventarioFiltrar]
@idSucursal int,
@descripcionInventario varchar(50)
AS

select a.*, b.nombreSurcursal, c.NombreAlmacen
from Inventario.ProgramacionInventario a
left outer join Inventario.Sucursal b on (a.idSucursal = b.idSucursal)
left outer join Inventario.Almacen c on (a.IdAlmacen = c.IdAlmacen)
where (a.idSucursal = @idSucursal or @idSucursal = 0)
      and ( a.descripcionInventario like '%' + @descripcionInventario + '%' or @descripcionInventario = '')
GO
/****** Object:  StoredProcedure [dbo].[uspProgramacionInventarioEliminarxId]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspProgramacionInventarioEliminarxId]
@idProgramacionInventario int
AS

delete from Inventario.ProgramacionInventario
where idProgramacionInventario = @idProgramacionInventario
GO
/****** Object:  StoredProcedure [dbo].[uspProgramacionInventarioActualizar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspProgramacionInventarioActualizar]
@idProgramacionInventario int,
@idSucursal int,
@idAlmacen int,
@fechaInventario datetime,
@descripcionInventario varchar(50)
AS

update Inventario.ProgramacionInventario
set idSucursal = @idSucursal, IdAlmacen = @IdAlmacen,
    fechaInventario = @fechaInventario,
    descripcionInventario = @descripcionInventario
where idProgramacionInventario = @idProgramacionInventario
GO
/****** Object:  StoredProcedure [dbo].[uspProgramacionPickingListarxID]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspProgramacionPickingListarxID]
@id int
AS
select a.*, (b.desNombre + ' ' + b.desApellido) as Responsable 
from Inventario.ProgramacionPicking a
left outer join RecursosHumanos.Empleado b on (a.idEmpleado = b.codEmpleado)
where a.idProgramacionPicking = @id
GO
/****** Object:  StoredProcedure [dbo].[uspProgramacionPickingListarPickarFiltro]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspProgramacionPickingListarPickarFiltro]  
@NumeroPedido nchar(10)  
AS  
 select distinct a.fecha, b.NumeroPedido, c.IdSucursal, c.Estado, d.nombreSurcursal  , (select descripcion from Inventario.EstadoPedido where codigo = c.Estado) as descripcionEstado  
 from  Inventario.ProgramacionPicking a, Inventario.DetalleProgramacionPicking b,   
   Inventario.Pedido c left outer join Inventario.Sucursal d on (d.idSucursal = c.IdSucursal)  
 where a.idProgramacionPicking = b.idProgramacionPicking  
   and b.NumeroPedido = c.NumeroPedido  
   and c.Estado = 1  
   and ( c.NumeroPedido = @NumeroPedido or @NumeroPedido = '')  
 order by a.fecha
GO
/****** Object:  StoredProcedure [dbo].[uspProgramacionPickingListarPickar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspProgramacionPickingListarPickar]  
AS  
select distinct a.fecha, b.NumeroPedido, c.IdSucursal, c.Estado, d.nombreSurcursal, (select descripcion from Inventario.EstadoPedido where codigo = c.Estado) as descripcionEstado  
from  Inventario.ProgramacionPicking a, Inventario.DetalleProgramacionPicking b,   
  Inventario.Pedido c left outer join Inventario.Sucursal d on (d.idSucursal = c.IdSucursal) 
where a.idProgramacionPicking = b.idProgramacionPicking  
     and b.NumeroPedido = c.NumeroPedido  
     and c.Estado = 1  
order by a.fecha
GO
/****** Object:  StoredProcedure [dbo].[uspProgramacionPickingListar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspProgramacionPickingListar]
AS
select a.*, (b.desNombre + ' ' + b.desApellido) as Responsable 
from Inventario.ProgramacionPicking a
left outer join RecursosHumanos.Empleado b on (a.idEmpleado = b.codEmpleado)
order by a.fecha
GO
/****** Object:  StoredProcedure [dbo].[uspProgramacionPickingInsertar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspProgramacionPickingInsertar]
@idProgramacionPicking int,
@idEmpleado int,
@descripcion varchar(50),
@fecha datetime,
@turno varchar(50),
@NumeroPedido nchar(10)

AS

select @idProgramacionPicking = (count(idProgramacionPicking) + 1) 
from Inventario.ProgramacionPicking

insert into Inventario.ProgramacionPicking
(
idProgramacionPicking,idEmpleado,descripcion,fecha,turno
)
values
(@idProgramacionPicking,@idEmpleado,@descripcion,@fecha,@turno)

--INSERTAR DETALLE
declare @IdProducto int
declare @Cantidad int

DECLARE detalle_pedido CURSOR FOR
select IdProducto, Cantidad
from Inventario.DetallePedido
where NumeroPedido = @NumeroPedido

OPEN detalle_pedido
FETCH NEXT FROM detalle_pedido INTO @IdProducto, @Cantidad

WHILE @@FETCH_STATUS = 0
BEGIN
	insert into Inventario.DetalleProgramacionPicking
	(idProgramacionPicking, NumeroPedido, idProducto, cantidadPedido)
	values
	(@idProgramacionPicking, @NumeroPedido, @IdProducto, @Cantidad)
	
	FETCH NEXT FROM detalle_pedido INTO @IdProducto, @Cantidad
END
CLOSE detalle_pedido
DEALLOCATE detalle_pedido
GO
/****** Object:  StoredProcedure [dbo].[uspOrdenCompraListarxAlmacenar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspOrdenCompraListarxAlmacenar]
AS
select a.Fecha, 'Nota Ingreso' as Tipo, cast(a.NumeroNotaIngreso as varchar) as nOrdenCompra, 
   a.EstadoNotaIngreso as estado, 'InternarNI/'+cast(a.NumeroNotaIngreso as varchar) as Sigla,
   e.descripcion as EstadoDescripcion
from Inventario.NotaIngreso a
left outer join Inventario.EstadoNotaIngreso e on e.codigo = a.EstadoNotaIngreso
where EstadoNotaIngreso = 'G'
union
select a.Fecha, 'Orden de Compra', a.nOrdenCompra, a.Estado, 'InternarOC/'+ a.nOrdenCompra,
e.descripcion as EstadoDescripcion
from Inventario.OrdenCompra a
left outer join Inventario.EstadoNotaIngreso e on e.codigo = a.Estado
where Estado = 'G'
order by fecha
GO
/****** Object:  StoredProcedure [dbo].[uspOrdenCompraListarAlmacenar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspOrdenCompraListarAlmacenar]
AS
select Fecha, 'Nota Ingreso' as Tipo, cast(NumeroNotaIngreso as varchar) as NumeroNotaIngreso, EstadoNotaIngreso 
from Inventario.NotaIngreso
where EstadoNotaIngreso = 'G'
union
select Fecha, 'Orden de Compra', nOrdenCompra, Estado
from Inventario.OrdenCompra
where Estado = 'G'
order by fecha
GO
/****** Object:  StoredProcedure [dbo].[uspOrdenCompraFiltrarxAlmacenar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspOrdenCompraFiltrarxAlmacenar]
@FechaInicio varchar(17),  
@FechaFin varchar(17),
@Tipo varchar(12),
@nOrdenCompra varchar(50)  
AS
declare @valor int

set @FechaInicio = @FechaInicio + ' 00:00:00'
set @FechaFin = @FechaFin + ' 23:59:59'

if (@nOrdenCompra <> '')
begin
	BEGIN TRY
		set @valor = cast(@nOrdenCompra as int)
	END TRY
	BEGIN CATCH
		select a.Fecha, 'Orden de Compra', a.nOrdenCompra, a.Estado, 'InternarOC/'+ a.nOrdenCompra,
		e.descripcion as EstadoDescripcion
		from Inventario.OrdenCompra a
		left outer join Inventario.EstadoNotaIngreso e on e.codigo = a.Estado
		where a.Estado = 'G'
			  and a.nOrdenCompra = @nOrdenCompra  
		order by a.fecha
		return
	END CATCH
	select a.Fecha, 'Nota Ingreso' as Tipo, cast(a.NumeroNotaIngreso as varchar) as nOrdenCompra, 
	a.EstadoNotaIngreso as estado, 'InternarNI/'+cast(a.NumeroNotaIngreso as varchar) as Sigla,
	e.descripcion as EstadoDescripcion
	from Inventario.NotaIngreso a
	left outer join Inventario.EstadoNotaIngreso e on e.codigo = a.EstadoNotaIngreso
	where a.EstadoNotaIngreso = 'G'
		  and a.NumeroNotaIngreso = @nOrdenCompra  
	union
	select a.Fecha, 'Orden de Compra', a.nOrdenCompra, a.Estado, 'InternarOC/'+ a.nOrdenCompra,
		   e.descripcion as EstadoDescripcion
	from Inventario.OrdenCompra a
	left outer join Inventario.EstadoNotaIngreso e on e.codigo = a.Estado
	where a.Estado = 'G'
		  and a.nOrdenCompra = @nOrdenCompra  
	order by a.Fecha
end
else
begin
    if (@Tipo = '')
    begin
		select a.Fecha, 'Nota Ingreso' as Tipo, cast(a.NumeroNotaIngreso as varchar) as nOrdenCompra, 
		a.EstadoNotaIngreso as estado, 'InternarNI/'+cast(a.NumeroNotaIngreso as varchar) as Sigla,
		e.descripcion as EstadoDescripcion
		from Inventario.NotaIngreso a
		left outer join Inventario.EstadoNotaIngreso e on e.codigo = a.EstadoNotaIngreso
		where a.EstadoNotaIngreso = 'G'
			  and a.fecha between @FechaInicio and @FechaFin  
		union
		select a.Fecha, 'Orden de Compra', a.nOrdenCompra, a.Estado, 'InternarOC/'+ a.nOrdenCompra,
		e.descripcion as EstadoDescripcion
		from Inventario.OrdenCompra a
		left outer join Inventario.EstadoNotaIngreso e on e.codigo = a.Estado
		where a.Estado = 'G'
			  and a.fecha between @FechaInicio and @FechaFin  
    end
    else
    begin
		if (@Tipo = '01')
		begin
			select a.Fecha, 'Orden de Compra', a.nOrdenCompra, a.Estado, 'InternarOC/'+ a.nOrdenCompra,
			e.descripcion as EstadoDescripcion
			from Inventario.OrdenCompra a
			left outer join Inventario.EstadoNotaIngreso e on e.codigo = a.Estado
			where a.Estado = 'G'
				  and a.fecha between @FechaInicio and @FechaFin
		end
		else
		begin
			select a.Fecha, 'Nota Ingreso' as Tipo, cast(a.NumeroNotaIngreso as varchar) as nOrdenCompra, 
			a.EstadoNotaIngreso as estado, 'InternarNI/'+cast(a.NumeroNotaIngreso as varchar) as Sigla,
			e.descripcion as EstadoDescripcion
			from Inventario.NotaIngreso a
			left outer join Inventario.EstadoNotaIngreso e on e.codigo = a.EstadoNotaIngreso
			where a.EstadoNotaIngreso = 'G'
				  and a.fecha between @FechaInicio and @FechaFin
		end
    end
end
GO
/****** Object:  Table [Inventario].[Kardex]    Script Date: 02/13/2016 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Inventario].[Kardex](
	[NumeroKardex] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[IdAlmacen] [int] NOT NULL,
	[Observaciones] [text] NULL,
	[SaldoActual] [decimal](18, 2) NULL,
	[idNotaIngreso] [int] NULL,
	[idNotaSalida] [int] NULL,
	[fecha] [datetime] NULL,
	[ingreso] [int] NULL,
	[salidas] [int] NULL,
	[codigoCompra] [varchar](10) NULL,
	[cantidad] [int] NULL,
	[costo] [decimal](12, 2) NULL,
 CONSTRAINT [PK_Kardex] PRIMARY KEY CLUSTERED 
(
	[NumeroKardex] ASC,
	[IdProducto] ASC,
	[IdAlmacen] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Inventario].[DetalleNotaSalida]    Script Date: 02/13/2016 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Inventario].[DetalleNotaSalida](
	[NumeroSalida] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [decimal](18, 2) NULL,
 CONSTRAINT [PK_DetalleNotaSalida] PRIMARY KEY CLUSTERED 
(
	[NumeroSalida] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Inventario].[DetalleNotaIngreso]    Script Date: 02/13/2016 20:03:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Inventario].[DetalleNotaIngreso](
	[NumeroNotaIngreso] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [decimal](18, 2) NULL,
 CONSTRAINT [PK_DetalleNotaIngreso] PRIMARY KEY CLUSTERED 
(
	[NumeroNotaIngreso] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[uspDetalleOrdenCompraListarxOrden]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspDetalleOrdenCompraListarxOrden]
@nOrdenCompra varchar(50)
AS
select a.nOrdenCompra, a.IdProducto, b.Descripcion, a.Cantidad 
from Inventario.DetalleOrdenCompra a
left outer join Inventario.Producto b on a.IdProducto = b.IdProducto
where nOrdenCompra = @nOrdenCompra
GO
/****** Object:  StoredProcedure [dbo].[uspNotaIngresoListarxID]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspNotaIngresoListarxID]
@id int
AS
select a.*, b.NombreAlmacen 
from Inventario.NotaIngreso a
left outer join Inventario.Almacen b on a.idAlmacen = b.IdAlmacen
where NumeroNotaIngreso = @id
GO
/****** Object:  StoredProcedure [dbo].[uspNotaIngresoListarxEstado]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspNotaIngresoListarxEstado]  
@estado nchar(1)  
AS  
select a.*, b.NombreAlmacen 
from Inventario.NotaIngreso a
left outer join Inventario.Almacen b on a.idAlmacen = b.IdAlmacen
where EstadoNotaIngreso = @estado  
order by NumeroNotaIngreso desc
GO
/****** Object:  StoredProcedure [dbo].[uspNotaIngresoListar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspNotaIngresoListar]
AS
select a.*, b.nombreProveedor, isnull(e.descripcion,a.EstadoNotaIngreso) as EstadoDescripcion 
from Inventario.NotaIngreso a
left outer join Inventario.Proveedor b on a.idProveedor = b.idProveedor
left outer join Inventario.EstadoNotaIngreso e on e.codigo = a.EstadoNotaIngreso
where a.EstadoNotaIngreso <> 'A'
order by NumeroNotaIngreso desc
GO
/****** Object:  StoredProcedure [dbo].[uspNotaIngresoInsertar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspNotaIngresoInsertar]
@NumeroNotaIngreso int output,
@Fecha datetime,
@NumeroOrdenCompra varchar(50),
@IdEmpleado int,
/*@UsuarioRecibo nchar(10),*/
@idAlmacen int,
@GuiaRemision nchar(20),
@Observaciones text,
@EstadoNotaIngreso text,
@IdProveedor int
AS
declare @Usuario nchar(10)
select @Usuario = desLogin 
from RecursosHumanos.Empleado where codEmpleado = @IdEmpleado

select @NumeroNotaIngreso = ( max(NumeroNotaIngreso)  + 1 )
from Inventario.NotaIngreso

insert into Inventario.NotaIngreso
(NumeroNotaIngreso,Fecha, NumeroOrdenCompra, IdEmpleado,
UsuarioRecibo,idAlmacen,GuiaRemsion,Observaciones,EstadoNotaIngreso, IdProveedor)
values
(@NumeroNotaIngreso,@Fecha, @NumeroOrdenCompra, @IdEmpleado,
@Usuario,@idAlmacen,@GuiaRemision,@Observaciones,@EstadoNotaIngreso, @IdProveedor)


select @NumeroNotaIngreso
GO
/****** Object:  StoredProcedure [dbo].[uspNotaIngresoFiltrar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspNotaIngresoFiltrar]  
@FechaInicio varchar(8),  
@FechaFin varchar(8),
@NumeroNotaIngreso int,
@IdProveedor int  
AS  
if (@NumeroNotaIngreso = 0)
begin
	if (@IdProveedor = 0)
	begin
		select a.*, b.nombreProveedor, isnull(e.descripcion,a.EstadoNotaIngreso) as EstadoDescripcion  
		from Inventario.NotaIngreso a  
		left outer join Inventario.Proveedor b on a.idProveedor = b.idProveedor
		left outer join Inventario.EstadoNotaIngreso e on e.codigo = a.EstadoNotaIngreso
		where a.Fecha between @FechaInicio and @FechaFin
		      and a.EstadoNotaIngreso <> 'A'  
	end
	else
	begin
		select a.*, b.nombreProveedor, isnull(e.descripcion,a.EstadoNotaIngreso) as EstadoDescripcion  
		from Inventario.NotaIngreso a  
		left outer join Inventario.Proveedor b on a.idProveedor = b.idProveedor
		left outer join Inventario.EstadoNotaIngreso e on e.codigo = a.EstadoNotaIngreso
		where a.Fecha between @FechaInicio and @FechaFin
		      and a.IdAlmacen = @IdProveedor
		      and a.EstadoNotaIngreso <> 'A'  
	end
end
else
begin
	select a.*, b.nombreProveedor, isnull(e.descripcion,a.EstadoNotaIngreso) as EstadoDescripcion   
	from Inventario.NotaIngreso a  
	left outer join Inventario.Proveedor b on a.idProveedor = b.idProveedor
	left outer join Inventario.EstadoNotaIngreso e on e.codigo = a.EstadoNotaIngreso
	where a.NumeroNotaIngreso = @NumeroNotaIngreso
	      and a.EstadoNotaIngreso <> 'A'  
end
GO
/****** Object:  StoredProcedure [dbo].[uspNotaIngresoEliminarxId]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspNotaIngresoEliminarxId]
@NumeroNotaIngreso int
AS
update Inventario.NotaIngreso
set EstadoNotaIngreso = 'A'
where NumeroNotaIngreso = @NumeroNotaIngreso
GO
/****** Object:  StoredProcedure [dbo].[uspNotaIngresoActualizarEstado]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspNotaIngresoActualizarEstado]
@NumeroNotaIngreso int,
@EstadoNotaIngreso text
AS
update Inventario.NotaIngreso
set EstadoNotaIngreso = @EstadoNotaIngreso
where NumeroNotaIngreso = @NumeroNotaIngreso
GO
/****** Object:  StoredProcedure [dbo].[uspNotaIngresoActualizar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspNotaIngresoActualizar]
@NumeroNotaIngreso int,
@Fecha datetime,
@NumeroOrdenCompra varchar(50),
@IdEmpleado int,
/*@UsuarioRecibo nchar(10),*/
@idAlmacen int,
@GuiaRemision nchar(20),
@Observaciones text,
@EstadoNotaIngreso text,
@IdProveedor int
AS
declare @Usuario nchar(10)
select @Usuario = desLogin 
from RecursosHumanos.Empleado where codEmpleado = @IdEmpleado

update Inventario.NotaIngreso
set Fecha = @Fecha,
	NumeroOrdenCompra = @NumeroOrdenCompra,
	IdEmpleado = @IdEmpleado,
	UsuarioRecibo = @Usuario,
	idAlmacen = @idAlmacen,
	GuiaRemsion = @GuiaRemision,
	Observaciones = @Observaciones,
	EstadoNotaIngreso = @EstadoNotaIngreso,
	IdProveedor = @IdProveedor
where NumeroNotaIngreso = @NumeroNotaIngreso
GO
/****** Object:  StoredProcedure [dbo].[uspKardexInsertar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspKardexInsertar]
@NumeroKardex int,
@IdProducto int,
@IdAlmacen int,
@Observaciones text,
@SaldoActual decimal,
@idNotaIngreso int,
@idNotaSalida int,
@fecha datetime,
@ingreso int,
@salidas int,
@codigoCompra varchar(10),
@cantidad int,
@costo decimal

AS
declare @contador int
select @contador = COUNT(NumeroKardex) from [Inventario].[Kardex]
where [NumeroKardex] = @NumeroKardex
      and [IdProducto] = @IdProducto
      and [IdAlmacen] = @IdAlmacen
--select @NumeroKardex = (max(NumeroKardex)+1) from [Inventario].[Kardex] 

if @contador = 0
begin
	if @idNotaIngreso = 0 
		set @idNotaIngreso = NULL
	if @idNotaSalida = 0 
		set @idNotaSalida = NULL
	set @SaldoActual = @cantidad
	
	INSERT INTO [Inventario].[Kardex]
			   ([NumeroKardex],[IdProducto],[IdAlmacen],[Observaciones]
			   ,[SaldoActual],[idNotaIngreso],[idNotaSalida],[fecha]
			   ,[ingreso],[salidas],[codigoCompra],[cantidad]
			   ,[costo])
		 VALUES
			   (@NumeroKardex,@IdProducto,@IdAlmacen,@Observaciones
			   ,@SaldoActual,@idNotaIngreso,@idNotaSalida,GETDATE()
			   ,@ingreso,@salidas,@codigoCompra,@cantidad
			   ,@costo)
end
else
begin
	update [Inventario].[Kardex]
	set [Observaciones] = @Observaciones,
		SaldoActual = SaldoActual + @SaldoActual,
		[fecha] = @fecha,
		[ingreso] = @ingreso,
		[salidas] = @salidas,
		[codigoCompra] = @codigoCompra,
		cantidad = cantidad + @cantidad,
		[costo] = @costo
	where [NumeroKardex] = @NumeroKardex
		  and [IdProducto] = @IdProducto
		  and [IdAlmacen] = @IdAlmacen
end
GO
/****** Object:  StoredProcedure [dbo].[uspKardexActualizar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspKardexActualizar]
@NumeroKardex int,
@IdProducto int,
@IdAlmacen int,
@Observaciones text,
@SaldoActual decimal,
@idNotaIngreso int,
@idNotaSalida int,
@fecha datetime,
@ingreso int,
@salidas int,
@codigoCompra varchar(10),
@cantidad int,
@costo decimal

AS

update [Inventario].[Kardex]
set [Observaciones] = @Observaciones,
    [SaldoActual] = @SaldoActual,
    [idNotaIngreso] = @idNotaIngreso,
    [idNotaSalida] = @idNotaSalida,
    [fecha] = @fecha,
    [ingreso] = @ingreso,
    [salidas] = @salidas,
    [codigoCompra] = @codigoCompra,
    [cantidad] = @cantidad,
    [costo] = @costo
where [NumeroKardex] = @NumeroKardex
      and [IdProducto] = @IdProducto
      and [IdAlmacen] = @IdAlmacen
GO
/****** Object:  StoredProcedure [dbo].[uspDetalleProgramacionPickingListarxID]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspDetalleProgramacionPickingListarxID]
@idProgramacionPicking int,
@NumeroPedido nchar(10),
@idProducto int
AS
declare @stock int
select @stock = SUM(SaldoActual) from Inventario.Kardex where IdProducto = @idProducto

select a.idProgramacionPicking, a.NumeroPedido, a.idProducto, b.Descripcion as NombreProducto, 
       a.CantidadPedido, isnull(a.CantidadAtendida,0) as CantidadAtendida,
       (isnull(a.CantidadPedido,0) - isnull(a.CantidadAtendida,0)) as Saldo,
       b.UnidadMedida, @stock as Stock
from Inventario.DetalleProgramacionPicking a 
left outer join Inventario.Producto b on (a.idProducto = b.idProducto)
where a.idProgramacionPicking = @idProgramacionPicking
	  and a.NumeroPedido = @NumeroPedido
	  and a.idProducto = @idProducto
GO
/****** Object:  StoredProcedure [dbo].[uspDetalleNotaIngresoListarxNotaProducto]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspDetalleNotaIngresoListarxNotaProducto]
@NumeroNotaIngreso int,
@IdProducto int
AS
select a.NumeroNotaIngreso, a.IdProducto, b.Descripcion, a.Cantidad 
from Inventario.DetalleNotaIngreso a
left outer join Inventario.Producto b on a.IdProducto = b.IdProducto
where NumeroNotaIngreso = @NumeroNotaIngreso
      and a.IdProducto = @IdProducto
GO
/****** Object:  StoredProcedure [dbo].[uspDetalleNotaIngresoListarxNota]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspDetalleNotaIngresoListarxNota]
@NumeroNotaIngreso int
AS
select a.NumeroNotaIngreso, a.IdProducto, b.Descripcion, a.Cantidad 
from Inventario.DetalleNotaIngreso a
left outer join Inventario.Producto b on a.IdProducto = b.IdProducto
where NumeroNotaIngreso = @NumeroNotaIngreso
GO
/****** Object:  StoredProcedure [dbo].[uspDetalleNotaIngresoInsertar]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspDetalleNotaIngresoInsertar]
@NumeroNotaIngreso int,
@IdProducto int,
@Cantidad decimal
AS
insert Inventario.DetalleNotaIngreso
(NumeroNotaIngreso,	IdProducto, Cantidad )
values
(@NumeroNotaIngreso, @IdProducto, @Cantidad)
GO
/****** Object:  StoredProcedure [dbo].[uspDetalleNotaIngresoEliminarProducto]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspDetalleNotaIngresoEliminarProducto]
@NumeroNotaIngreso int,
@IdProducto int
AS
delete from Inventario.DetalleNotaIngreso
where NumeroNotaIngreso = @NumeroNotaIngreso and
	  IdProducto = @IdProducto
GO
/****** Object:  StoredProcedure [dbo].[uspDetalleNotaIngresoActualizarCantidad]    Script Date: 02/13/2016 20:03:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspDetalleNotaIngresoActualizarCantidad]
@NumeroNotaIngreso int,
@IdProducto int,
@Cantidad decimal
AS
declare @contador int
select @contador = COUNT(*) 
from Inventario.DetalleNotaIngreso
where NumeroNotaIngreso = @NumeroNotaIngreso and
	  IdProducto = @IdProducto

if (@contador = 0)
begin
	insert into Inventario.DetalleNotaIngreso
	(NumeroNotaIngreso,IdProducto,Cantidad)
	values
	(@NumeroNotaIngreso,@IdProducto,@Cantidad)
end
else
begin
	update Inventario.DetalleNotaIngreso
	set Cantidad = @Cantidad
	where NumeroNotaIngreso = @NumeroNotaIngreso and
		  IdProducto = @IdProducto
end
GO
/****** Object:  ForeignKey [FK_DetalleNotaIngreso_NotaIngreso]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[DetalleNotaIngreso]  WITH CHECK ADD  CONSTRAINT [FK_DetalleNotaIngreso_NotaIngreso] FOREIGN KEY([NumeroNotaIngreso])
REFERENCES [Inventario].[NotaIngreso] ([NumeroNotaIngreso])
GO
ALTER TABLE [Inventario].[DetalleNotaIngreso] CHECK CONSTRAINT [FK_DetalleNotaIngreso_NotaIngreso]
GO
/****** Object:  ForeignKey [FK_DetalleNotaSalida_NotaSalida]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[DetalleNotaSalida]  WITH CHECK ADD  CONSTRAINT [FK_DetalleNotaSalida_NotaSalida] FOREIGN KEY([NumeroSalida])
REFERENCES [Inventario].[NotaSalida] ([NumeroSalida])
GO
ALTER TABLE [Inventario].[DetalleNotaSalida] CHECK CONSTRAINT [FK_DetalleNotaSalida_NotaSalida]
GO
/****** Object:  ForeignKey [FK_DetalleOrdenCompra_Numero]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[DetalleOrdenCompra]  WITH CHECK ADD  CONSTRAINT [FK_DetalleOrdenCompra_Numero] FOREIGN KEY([nOrdenCompra])
REFERENCES [Inventario].[OrdenCompra] ([nOrdenCompra])
GO
ALTER TABLE [Inventario].[DetalleOrdenCompra] CHECK CONSTRAINT [FK_DetalleOrdenCompra_Numero]
GO
/****** Object:  ForeignKey [FK__DetallePe__Numer__300424B4]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[DetallePedido]  WITH CHECK ADD FOREIGN KEY([NumeroPedido])
REFERENCES [Inventario].[Pedido] ([NumeroPedido])
GO
/****** Object:  ForeignKey [FK__Kardex__idNotaIng]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[Kardex]  WITH CHECK ADD  CONSTRAINT [FK__Kardex__idNotaIng] FOREIGN KEY([idNotaIngreso])
REFERENCES [Inventario].[NotaIngreso] ([NumeroNotaIngreso])
GO
ALTER TABLE [Inventario].[Kardex] CHECK CONSTRAINT [FK__Kardex__idNotaIng]
GO
/****** Object:  ForeignKey [FK__Kardex__idNotaSal]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[Kardex]  WITH CHECK ADD  CONSTRAINT [FK__Kardex__idNotaSal] FOREIGN KEY([idNotaSalida])
REFERENCES [Inventario].[NotaSalida] ([NumeroSalida])
GO
ALTER TABLE [Inventario].[Kardex] CHECK CONSTRAINT [FK__Kardex__idNotaSal]
GO
/****** Object:  ForeignKey [FK__NotaIngre__idEmp__5AEE82B9]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[NotaIngreso]  WITH CHECK ADD FOREIGN KEY([idEmpleado])
REFERENCES [RecursosHumanos].[Empleado] ([codEmpleado])
GO
/****** Object:  ForeignKey [FK__NotaIngre__idPro__5165187F]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[NotaIngreso]  WITH CHECK ADD FOREIGN KEY([idProveedor])
REFERENCES [Inventario].[Proveedor] ([idProveedor])
GO
/****** Object:  ForeignKey [FK_NotaIngreso_Almacen]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[NotaIngreso]  WITH CHECK ADD  CONSTRAINT [FK_NotaIngreso_Almacen] FOREIGN KEY([idAlmacen])
REFERENCES [Inventario].[Almacen] ([IdAlmacen])
GO
ALTER TABLE [Inventario].[NotaIngreso] CHECK CONSTRAINT [FK_NotaIngreso_Almacen]
GO
/****** Object:  ForeignKey [FK_NotaIngreso_OrdenCompra]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[NotaIngreso]  WITH CHECK ADD  CONSTRAINT [FK_NotaIngreso_OrdenCompra] FOREIGN KEY([NumeroOrdenCompra])
REFERENCES [Inventario].[OrdenCompra] ([nOrdenCompra])
GO
ALTER TABLE [Inventario].[NotaIngreso] CHECK CONSTRAINT [FK_NotaIngreso_OrdenCompra]
GO
/****** Object:  ForeignKey [FK_NotaSalida_Almacen]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[NotaSalida]  WITH CHECK ADD  CONSTRAINT [FK_NotaSalida_Almacen] FOREIGN KEY([idAlmacen])
REFERENCES [Inventario].[Almacen] ([IdAlmacen])
GO
ALTER TABLE [Inventario].[NotaSalida] CHECK CONSTRAINT [FK_NotaSalida_Almacen]
GO
/****** Object:  ForeignKey [FK_NotaSalida_Empleado]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[NotaSalida]  WITH CHECK ADD  CONSTRAINT [FK_NotaSalida_Empleado] FOREIGN KEY([idEmpleado])
REFERENCES [Inventario].[Empleado] ([idEmpleado])
GO
ALTER TABLE [Inventario].[NotaSalida] CHECK CONSTRAINT [FK_NotaSalida_Empleado]
GO
/****** Object:  ForeignKey [FK_NotaSalida_Pedido]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[NotaSalida]  WITH CHECK ADD  CONSTRAINT [FK_NotaSalida_Pedido] FOREIGN KEY([NumeroPedido])
REFERENCES [Inventario].[Pedido] ([NumeroPedido])
GO
ALTER TABLE [Inventario].[NotaSalida] CHECK CONSTRAINT [FK_NotaSalida_Pedido]
GO
/****** Object:  ForeignKey [FK_NotaSalida_ProgPicking]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[NotaSalida]  WITH CHECK ADD  CONSTRAINT [FK_NotaSalida_ProgPicking] FOREIGN KEY([idProgramacionPicking])
REFERENCES [Inventario].[ProgramacionPicking] ([idProgramacionPicking])
GO
ALTER TABLE [Inventario].[NotaSalida] CHECK CONSTRAINT [FK_NotaSalida_ProgPicking]
GO
/****** Object:  ForeignKey [FK_OrdenCompra_OrdenCompra]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[OrdenCompra]  WITH CHECK ADD  CONSTRAINT [FK_OrdenCompra_OrdenCompra] FOREIGN KEY([idProveedor])
REFERENCES [Inventario].[Proveedor] ([idProveedor])
GO
ALTER TABLE [Inventario].[OrdenCompra] CHECK CONSTRAINT [FK_OrdenCompra_OrdenCompra]
GO
/****** Object:  ForeignKey [FK_OrdenCompra_Producto]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[OrdenCompra]  WITH CHECK ADD  CONSTRAINT [FK_OrdenCompra_Producto] FOREIGN KEY([idProducto])
REFERENCES [Inventario].[Producto] ([idProducto])
GO
ALTER TABLE [Inventario].[OrdenCompra] CHECK CONSTRAINT [FK_OrdenCompra_Producto]
GO
/****** Object:  ForeignKey [FK_Pedido_Producto]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Producto] FOREIGN KEY([idProducto])
REFERENCES [Inventario].[Producto] ([idProducto])
GO
ALTER TABLE [Inventario].[Pedido] CHECK CONSTRAINT [FK_Pedido_Producto]
GO
/****** Object:  ForeignKey [FK_Pedido_Sucursal]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Sucursal] FOREIGN KEY([IdSucursal])
REFERENCES [Inventario].[Sucursal] ([idSucursal])
GO
ALTER TABLE [Inventario].[Pedido] CHECK CONSTRAINT [FK_Pedido_Sucursal]
GO
/****** Object:  ForeignKey [FK_ProgramacionInventario_ProgramacionInventario]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[ProgramacionInventario]  WITH CHECK ADD  CONSTRAINT [FK_ProgramacionInventario_ProgramacionInventario] FOREIGN KEY([IdAlmacen])
REFERENCES [Inventario].[Almacen] ([IdAlmacen])
GO
ALTER TABLE [Inventario].[ProgramacionInventario] CHECK CONSTRAINT [FK_ProgramacionInventario_ProgramacionInventario]
GO
/****** Object:  ForeignKey [FK_ProgramacionInventario_Sucursal]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[ProgramacionInventario]  WITH CHECK ADD  CONSTRAINT [FK_ProgramacionInventario_Sucursal] FOREIGN KEY([idSucursal])
REFERENCES [Inventario].[Sucursal] ([idSucursal])
GO
ALTER TABLE [Inventario].[ProgramacionInventario] CHECK CONSTRAINT [FK_ProgramacionInventario_Sucursal]
GO
/****** Object:  ForeignKey [FK_ProgramacionPicking_Empleado]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[ProgramacionPicking]  WITH CHECK ADD  CONSTRAINT [FK_ProgramacionPicking_Empleado] FOREIGN KEY([idEmpleado])
REFERENCES [RecursosHumanos].[Empleado] ([codEmpleado])
GO
ALTER TABLE [Inventario].[ProgramacionPicking] CHECK CONSTRAINT [FK_ProgramacionPicking_Empleado]
GO
/****** Object:  ForeignKey [FK_Ubicacion_Almacen]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[Ubicacion]  WITH CHECK ADD  CONSTRAINT [FK_Ubicacion_Almacen] FOREIGN KEY([IdAlmacen])
REFERENCES [Inventario].[Almacen] ([IdAlmacen])
GO
ALTER TABLE [Inventario].[Ubicacion] CHECK CONSTRAINT [FK_Ubicacion_Almacen]
GO
/****** Object:  ForeignKey [FK_UbicacionProducto_Producto]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[UbicacionProducto]  WITH CHECK ADD  CONSTRAINT [FK_UbicacionProducto_Producto] FOREIGN KEY([IdProducto])
REFERENCES [Inventario].[Producto] ([idProducto])
GO
ALTER TABLE [Inventario].[UbicacionProducto] CHECK CONSTRAINT [FK_UbicacionProducto_Producto]
GO
/****** Object:  ForeignKey [FK_UbicacionProducto_Ubicacion]    Script Date: 02/13/2016 20:03:06 ******/
ALTER TABLE [Inventario].[UbicacionProducto]  WITH CHECK ADD  CONSTRAINT [FK_UbicacionProducto_Ubicacion] FOREIGN KEY([idUbicacion])
REFERENCES [Inventario].[Ubicacion] ([idUbicacion])
GO
ALTER TABLE [Inventario].[UbicacionProducto] CHECK CONSTRAINT [FK_UbicacionProducto_Ubicacion]
GO
