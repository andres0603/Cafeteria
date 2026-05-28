CREATE DATABASE db_cafeteria
GO

USE db_cafeteria
GO

CREATE TABLE sedes (
    [id] INT PRIMARY KEY IDENTITY(1,1),
    [nombre] VARCHAR(100),
    [fecha_fundacion] DATETIME,
    [direccion] VARCHAR(255),
    [activo] BIT
);
GO


CREATE TABLE roles (
    [id] INT PRIMARY KEY IDENTITY(1,1),
    [nombre] VARCHAR(100),
    [salarioBase] DECIMAL(18,2),
    [valor_dia] DECIMAL(18,2),
    [descripcion] TEXT,
    [activo] BIT
);
GO
CREATE TABLE horarios (
    [id] INT PRIMARY KEY IDENTITY(1,1),
    [dia] VARCHAR(20),
    [horaEntrada] VARCHAR(10),
    [horaSalida] VARCHAR(10),
    [minutosDescanso] INT,
    [activo] BIT
);
GO
CREATE TABLE estadoReserva (
    [id] INT PRIMARY KEY IDENTITY(1,1),
    [nombre] VARCHAR(50)
);
GO
CREATE TABLE estadosPedido (
    [id] INT PRIMARY KEY IDENTITY(1,1),
    [nombre] VARCHAR(50)
);
GO

SELECT * from estadosPedido
CREATE TABLE metodoPago (
    [id] INT PRIMARY KEY IDENTITY(1,1),
    [metodo] VARCHAR(50),
    [comisionPorcentual] DECIMAL(5,2),
    [requiereCodigo] BIT,
    [referenciaAprobacion] VARCHAR(100),
    [activo] BIT
);
GO
CREATE TABLE estadosMesa (
    [id] INT PRIMARY KEY IDENTITY(1,1),
    [nombre] VARCHAR(50),
    [descripcion] TEXT,
    [PermiteAsignarPedido] BIT,
    [activo] BIT
);
GO
CREATE TABLE producto_Extra (
    [id] INT PRIMARY KEY IDENTITY(1,1),
    [nombre] VARCHAR(150),
    [precioAdicional] DECIMAL(18,2),
    [activo] BIT,
    [cantidad] INT
);
GO
CREATE TABLE proveedores (
    [id] INT PRIMARY KEY IDENTITY(1,1),
    [nit] VARCHAR(20),
    [nombre] VARCHAR(100),
    [telefono] VARCHAR(20),
    [direccion] VARCHAR(255),
    [activo] BIT
);
GO
CREATE TABLE categorias (
    [id] INT PRIMARY KEY IDENTITY(1,1),
    [nombre] VARCHAR(100)
);
GO
CREATE TABLE personas (
    [id] INT PRIMARY KEY IDENTITY(1,1),
    [cedula] VARCHAR(20) UNIQUE,
    [nombre] VARCHAR(150),
    [correo] VARCHAR(100),
    [telefono] VARCHAR(20),
    [direccion] VARCHAR(255),
    [activo] BIT
);
GO
CREATE TABLE clientes (
    [id] INT PRIMARY KEY, 
    [fechaRegistro] DATETIME,
    [sedes] INT NOT NULL REFERENCES sedes(id),
	FOREIGN KEY (id) REFERENCES personas(id)
);
GO
CREATE TABLE empleados (
    [id] INT PRIMARY KEY, 
    [salario] DECIMAL(18,2),
    [fechaIngreso] DATETIME,
    [rol] INT NOT NULL REFERENCES roles(id),
    [horarios] INT NOT NULL REFERENCES horarios(id),
	FOREIGN KEY (id) REFERENCES personas(id)    
);
GO
CREATE TABLE tareas (
    [id] INT PRIMARY KEY IDENTITY(1,1),
    [nombre] VARCHAR(150),
    [fechaAsignacion] DATETIME,
    [observaciones] TEXT,
    [activo] BIT,
    [empleados] INT NOT NULL REFERENCES empleados(id) 
);
GO

CREATE TABLE productos (
    [id] INT PRIMARY KEY IDENTITY(1,1),
    [nombre] VARCHAR(150),
    [precio] DECIMAL(18,2),
    [descripcion] TEXT,
    [categoria] INT NOT NULL REFERENCES categorias(id),
    [cantidad] INT
);
GO
CREATE TABLE mesas (
    [id] INT PRIMARY KEY IDENTITY(1,1),
    [nro_mesa] INT,
    [capacidad] INT,
    [activo] BIT,
    [estadoMesa] INT NOT NULL REFERENCES estadosMesa(id),
    [sedes] INT NOT NULL REFERENCES sedes(id)
);
GO


CREATE TABLE reservas (
    [id] INT PRIMARY KEY IDENTITY(1,1),
    [fechaHoraReserva] DATETIME,
    [numeroPersonas] INT,
    [requerimientosEspeciales] TEXT,
    [estadoReserva] INT NOT NULL REFERENCES estadoReserva(id),
    [clientes] INT NOT NULL REFERENCES clientes(id)
);
GO
CREATE TABLE pedidos (
    [id] INT PRIMARY KEY IDENTITY(1,1),
    [total] DECIMAL(18,2),
    [notasParaCocina] TEXT,
    [clientes] INT NOT NULL REFERENCES clientes(id),
    [estadosPedido] INT NOT NULL REFERENCES estadosPedido(id)
);
GO
CREATE TABLE pagos (
    [id] INT PRIMARY KEY IDENTITY(1,1),
    [pedido] INT NOT NULL REFERENCES pedidos(id),
    [metodoPago] INT NOT NULL REFERENCES metodoPago(id),
    [montoPagado] DECIMAL(18,2),
    [devuelta] DECIMAL(18,2),
    [propina] DECIMAL(18,2)
);
GO
select * from producto_proveedor
CREATE TABLE producto_proveedor (
    [id] INT PRIMARY KEY IDENTITY(1,1),
    [idProducto] INT FOREIGN KEY REFERENCES productos(id),
    [idProveedor] INT FOREIGN KEY REFERENCES proveedores(id),
    [codigoProveedor] VARCHAR(50),
    [precio] DECIMAL(18,2)
);
GO
CREATE TABLE detallesPedido (
    [id] INT PRIMARY KEY IDENTITY(1,1),
    [producto] INT NOT NULL REFERENCES productos(id),
    [producto_Extra] INT NULL REFERENCES producto_Extra(id),
    [pedidos] INT NOT NULL REFERENCES pedidos(id),
    [cantidad] INT,
    [cantidadExtra] INT,
    [descripcion] TEXT,
    [subtotal] DECIMAL(18,2)
);

CREATE TABLE historicos(
	[id] INT PRIMARY KEY IDENTITY(1,1),
	[nombreTabla] NVARCHAR(30) NOT NULL,
	[accion] NVARCHAR(30) NOT NULL,
	[fechaCambio] SMALLDATETIME
);

CREATE TABLE usuarios(
	[id] INT PRIMARY KEY IDENTITY(1,1),
	[nombre] NVARCHAR(30) NOT NULL,
	[correo] NVARCHAR(30) NOT NULL,
	[contraseña] NVARCHAR(30) NOT NULL,
	[activo] BIT
);
GO

CREATE TABLE historial_login(
	[id] INT PRIMARY KEY IDENTITY(1,1),
	[fecha_ingreso] DATETIME NOT NULL,
	[resultado] NVARCHAR(30) NOT NULL,
	[id_usuario] INT FOREIGN KEY REFERENCES usuarios(id)
);
GO

CREATE TABLE usuario_roles(
	[id] INT PRIMARY KEY IDENTITY(1,1),
	[id_usuario] INT FOREIGN KEY REFERENCES usuarios(id),
	[id_rol] INT FOREIGN KEY REFERENCES roles(id),
	[fechaAsignacion] DATETIME NOT NULL,
	[activo] BIT,
);
GO

 CREATE TABLE sesiones(
	[id] INT PRIMARY KEY IDENTITY(1,1),
	[fecha_sesion] DATETIME NOT NULL,
	[estado] BIT,
	[id_usuario] INT FOREIGN KEY REFERENCES usuarios(id)
);
GO

INSERT INTO categorias (nombre) VALUES
('Bebidas Calientes'),
('Panaderia'),
('Reposteria'),
('Bebidas Frías'),
('Snacks');
GO

INSERT INTO sedes (nombre, direccion, fecha_fundacion, activo) VALUES
('Sede Manrique', 'Carrera 45 # 80-12', '2015-05-20', 1),
('Sede El Poblado', 'Calle 10 # 36-40', '2010-11-15', 1),
('Sede Laureles', 'Avenida Nutibara # 74-10', '2018-02-28', 1),
('Sede Belén', 'Carrera 76 # 30-22', '2021-08-10', 1),
('Sede Aranjuez', 'Calle 92 # 50-05', '2023-01-05', 0);
GO

INSERT INTO roles (nombre, descripcion, salarioBase, activo) VALUES
('Administrador', 'Responsable de la operación global y gestión de inventarios.', 2500000, 1),
('Cajero', 'Se encarga de facturar en nuestra tienda', 1450000, 1),
('Mesero', 'Atención en mesas, toma de pedidos y entrega de productos.', 1300000, 1),
('Repostero', 'Encargado de la elaboración de postres y productos de panadería.', 1600000,  1),
('Mantenimiento', 'Se encarga de cualquier daño que pueda haber en el local', 1160000, 0);
GO

INSERT INTO horarios (dia, horaEntrada, horaSalida, minutosDescanso, activo) VALUES
('Lunes a sabado', '10:00', '19:00', 60, 1),
('Lunes a sabado', '00:00', '21:00', 60, 1),
('Sábado', '02:00', '11:00', 60, 1),
('Domingo', '11:00', '08:00', 60, 1),
('Lunes', '04:00', '10:00', 0, 0);
GO

INSERT INTO estadoReserva (nombre) VALUES
('Pendiente'),
('Confirmada'),
('En Curso'),
('Finalizada'),
('Cancelada');
GO

INSERT INTO estadosPedido (nombre) VALUES
('Pendiente'),
('En Preparación'),
('Listo'),
('Entregado'),
('Cancelado');
GO

INSERT INTO metodoPago (metodo, comisionPorcentual, requiereCodigo, referenciaAprobacion,activo) VALUES
('Efectivo', 0.00, 0, 'N/A',1),
('Tarjeta de Crédito', 2.50, 1, 'V-445522',1),
('Nequi/Daviplata', 0.00, 1, 'TR-998811',1),
('Bono Regalo', 0.00, 1, 'BONO-2024',1),
('Rappi Pay', 5.00, 1, 'R-776611',0);
GO

INSERT INTO estadosMesa (nombre, descripcion, activo, PermiteAsignarPedido) VALUES
('Disponible', 'Lista para clientes.', 1, 1),
('Ocupada', 'Clientes en consumo.', 1, 1),
('Reservada', 'Apartada para evento.', 1, 0),
('En Limpieza', 'Mesa por asear.', 1, 0),
('Fuera de Servicio', 'Mesa en reparación.', 0, 0);
GO

INSERT INTO producto_Extra (nombre, cantidad, precioAdicional, activo) VALUES
('Shot Espresso Extra', 20, 2500, 1),
('Leche de almendras', 10, 3000, 1),
('Crema Batida', 10, 2000, 1),
('chips de chocolate', 0, 1000, 0),
('Queso', 5, 1200, 1);
GO

INSERT INTO proveedores (nombre, nit, direccion, telefono, activo) VALUES
('Hacienda El Cafetal', '800.123.456-1', 'Vereda La Palma, Quindío', '3104445566', 1),
('Lácteos del Campo S.A.', '900.555.222-3', 'Zona Industrial Norte, Bodega 5', '6017654321', 1),
('Dulce Detalle Distribuciones', '860.999.000-5', 'Calle 45 # 12-30', '3208889900', 1),
('EcoPack Soluciones', '901.333.444-9', 'Avenida 68 # 20-15', '6014443322', 1),
('Distribuidora El Queso Dorado', '811.000.999-2', 'Km 5 Vía San Félix, Antioquia', '3127778899', 1);
GO

INSERT INTO personas (cedula,nombre,telefono,correo,direccion,activo) values
('Juan Pérez','10203040', '3001234567', 'juan.perez@email.com', 'Calle 100 # 15-20',  1),
('Maria Garcia','52987654', '3159876543', 'maria.g@email.com', 'Carrera 7 # 12-45', 1),
('Carlos Rodriguez', '80123456', '3204567890', 'carlos.rod@email.com', 'Avenida 19 # 103-11', 0),
('Ana Martínez', '1032456789', '3112223344', 'ana.mtz@email.com', 'Calle 45 # 25-30',  1),
('Luis Felipe Gomez', '79654321', '3015556677', 'luis.gomez@gmail.com', 'Diagonal 50 # 30-15',  1),
('Valentina Herrera', '10506070', '3004445566', 'valentina.admin@hotmail.com', 'Calle 80 # 45-10', 1),
('Mateo Salazar', '10908070', '3102223344', 'mateo.coffee@yahoo.es', 'Carrera 15 # 70-20', 1),
('Diana Castro', '52444333', '3156667788', 'diana.c@gmail.com', 'Avenida Siempre Viva 123', 1),
('Roberto Gómez', '80111222', '3209990011', 'roberto.bakery@hotmail.com', 'Transversal 5 # 40-50', 1),
('Lucía Méndez', '10304050', '3118889900', 'lucia.m@gmail.com', 'Calle 10 # 2-30', 1);
GO

INSERT INTO clientes (id,fechaRegistro, sedes) VALUES
(1,GETDATE(), 1),
(2,GETDATE(), 2),
(3,GETDATE(), 3),
(4,GETDATE(), 4),
(5,GETDATE(), 5);
GO

INSERT INTO empleados (id, fechaIngreso, rol, horarios, salario) VALUES
(6,'2023-01-15', 1, 1, 2500000),
(7,'2024-02-03', 2, 2, 1450000),
(8,'2024-02-01', 3, 3, 1300000),
(9,'2023-11-10', 4, 4, 1600000),
(10,'2022-05-20', 5, 5, 1160000);
GO

INSERT INTO tareas (nombre, fechaAsignacion, observaciones, activo, empleados) VALUES
('Apertura de local', GETDATE(), 'Verificar que las máquinas de expresso calibradas.', 1, 6),
('Inventario de lácteos', '2026-03-02', 'Revisar fechas de leche de almendras', 1, 7),
('Limpieza de filtros', GETDATE(), 'Limpiar los filtros con desengrasante.', 1, 8),
('Cierre de caja parcial', GETDATE(), 'Contar efectivo y separar base para el siguiente turno.', 1, 9),
('Mantenimiento de molino', '2026-02-28', 'Tarea completada el mes pasado.', 0, 10);
GO

INSERT INTO productos (nombre, precio, descripcion, cantidad, categoria) VALUES
('Barras de cereal', 4500, 'Café negro intenso', 50, 5),
('Capuchino de Vainilla', 6800, 'Expresso con leche vaporizada y vainilla.', 30, 1),
('Croissant', 3500, 'Pan de hojaldre artesanal horneado cada mañana.', 20, 2),
('Porción Torta de Chocolate', 7500, 'Torta húmeda de chocolate amargo', 12, 3),
('Jugo de Naranja 12oz', 5000, 'Zumo de naranja recién exprimido, sin azúcar.', 15, 4);
GO

INSERT INTO mesas (nro_mesa, capacidad, activo, sedes, estadoMesa) VALUES
(101, 2, 1, 1, 1),
(102, 6, 1, 2, 2),
(103, 4, 1, 3, 3),
(201, 4, 0, 4, 4),
(1, 1, 1, 5, 5);
GO



INSERT INTO reservas (fechaHoraReserva, numeroPersonas, requerimientosEspeciales, estadoReserva, clientes) VALUES
('2026-03-14 19:30:00', 2, 'Mesa cerca de la ventana, aniversario.', 1, 1),
('2026-05-14 15:30:00', 6, 'Mesa decorada, es un cumpleaños.', 2, 2),
('2026-03-20 16:00:00', 10, 'Traerán su propio pastel. Dejar espacio para globos.', 3, 3),
('2026-12-25 05:30:00', 3, 'Sin ningun requerimiento', 4, 4),
('2026-03-05 10:30:00', 2, 'El cliente llamó para cancelar.', 5, 5);
GO

INSERT INTO pedidos (notasParaCocina, clientes, estadosPedido, total) VALUES
('El café muy caliente, por favor.', 1, 1, 7000),
('Organizar para dos personas', 2, 2, 16000),
('Sin novedad', 3, 3, 6500),
('Sin novedad', 4, 4, 22500),
('Jugo sin azucar.', 5, 5, 5000);
GO


INSERT INTO pagos (montoPagado, propina, metodoPago, pedido, devuelta) VALUES
(30000, 5000, 1, 1, 18000),
(15800, 0, 2, 2, 0),
(45000, 4500, 3, 3, 0),
(8500, 1000, 4, 4, 0),
(120000, 15000, 5, 5, 0);
GO

INSERT INTO producto_proveedor (idProducto, idProveedor, codigoProveedor, precio) VALUES
(1, 1, 'CAF-001', 45000),
(2, 2, 'LACT-G-44', 50000),
(3, 4, 'CB-V12', 1000),
(4, 3, 'L-ENT-99', 3200),
(5, 5, 'QUE-S-01', 20000);
GO

INSERT INTO detallesPedido (cantidad, descripcion, pedidos, producto, producto_Extra, cantidadExtra, subtotal) VALUES
(1, 'Barra de cereales con adicion de expreso', 1, 1, 1, 1, 7000),
(2, 'Dos capuchinos de vainilla con adicion de crema batida', 2, 2, 3, 2, 16000),
(1, 'Croissant con adicion de leche de almendras', 3, 3, 2, 1, 6500),
(3, 'tres porciones de torta de chocolate sin adicion', 4, 4, NULL, 0, 22500),
(1, 'Jugo de Naranja Natural', 5, 5, NULL, 0, 5000);
GO

INSERT INTO usuarios VALUES
('andres123','Andres45@gmsil.com','123',1),
('sara','sara@gmail.com','123',1)
GO










