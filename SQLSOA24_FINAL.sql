 
CREATE TABLE Usuario (
    ID_usuario INT IDENTITY(1,1) PRIMARY KEY,
    DNIUSER INT,
    Nombre VARCHAR(255),
    Correo VARCHAR(255),
    Telefono VARCHAR(20)
);

CREATE TABLE Empresa (
    ID_empresa INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(255),
    Categoria VARCHAR(100)
);

CREATE TABLE Operadora (
    ID_operadora INT IDENTITY(1,1) PRIMARY KEY,
    ID_empresa INT,
    Nombre VARCHAR(255),
    FOREIGN KEY (ID_empresa) REFERENCES Empresa(ID_empresa)
);

 


CREATE TABLE Tarjeta (
    ID_tarjeta INT IDENTITY(1,1) PRIMARY KEY,
    NumeroDeCuenta VARCHAR(20),
    Banco VARCHAR(100),
    TipoTarjeta VARCHAR(50),
    FechaVencimiento DATE,
    Clave VARCHAR(4)
);

-- Crear tabla Cuenta modificada para soportar tanto usuarios como empresas
CREATE TABLE Cuenta (
    ID_cuenta INT IDENTITY(1,1) PRIMARY KEY,
    ID_usuario INT NULL,
    ID_empresa INT NULL,
    ID_tarjeta INT,
    Saldo DECIMAL(10, 2) DEFAULT 0,
    FOREIGN KEY (ID_usuario) REFERENCES Usuario(ID_usuario),
    FOREIGN KEY (ID_empresa) REFERENCES Empresa(ID_empresa),
    FOREIGN KEY (ID_tarjeta) REFERENCES Tarjeta(ID_tarjeta)
);

-- Modificar Contacto para agregar relación con Usuario
CREATE TABLE Contacto (
    ID_contacto INT IDENTITY(1,1) PRIMARY KEY,
    ID_operadora INT,
    ID_usuario INT, -- Nueva columna para relacionar con Usuario
    Nombre VARCHAR(255),
    Numero INT,
    Pais VARCHAR(100),
    Tipo_linea VARCHAR(10) CHECK (Tipo_linea IN ('Prepago', 'Postpago')),
    Saldo_prepago DECIMAL(10, 2) DEFAULT 0,
    FOREIGN KEY (ID_operadora) REFERENCES Operadora(ID_operadora),
    FOREIGN KEY (ID_usuario) REFERENCES Usuario(ID_usuario) -- Nueva relación
);

CREATE TABLE Yapeo (
    ID_yape INT IDENTITY(1,1) PRIMARY KEY,
    ID_usuario INT,
    ID_contacto INT,
    Monto DECIMAL(10, 2),
    Estado VARCHAR(50),
    Codigo_verificacion VARCHAR(6),
    Fecha_hora DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ID_usuario) REFERENCES Usuario(ID_usuario),
    FOREIGN KEY (ID_contacto) REFERENCES Contacto(ID_contacto)
);

CREATE TABLE Historial (
    ID_historial INT IDENTITY(1,1) PRIMARY KEY,
    ID_usuario INT,
    Calificacion BIT,
    FOREIGN KEY (ID_usuario) REFERENCES Usuario(ID_usuario)
);

CREATE TABLE Credito (
    ID_credito INT IDENTITY(1,1) PRIMARY KEY,
    ID_historial INT,
    ID_usuario INT,
    Monto DECIMAL(10, 2),
    Tasa_interes DECIMAL(5, 2),
    Plazo INT,
    Fecha_inicio DATE,
    Fecha_fin DATE,
    Estado BIT,
    FOREIGN KEY (ID_historial) REFERENCES Historial(ID_historial),
    FOREIGN KEY (ID_usuario) REFERENCES Usuario(ID_usuario)
);

CREATE TABLE FacturaPago (
    ID_factura_pago INT IDENTITY(1,1) PRIMARY KEY,
    ID_empresa INT,
    ID_usuario INT,
    Codigo_cliente VARCHAR(100),
    Monto_a_pagar DECIMAL(10, 2),
    Fecha_pago DATE,
    Estado VARCHAR(20) CHECK (Estado IN ('Pagado', 'No pagado')),
    FOREIGN KEY (ID_empresa) REFERENCES Empresa(ID_empresa),
    FOREIGN KEY (ID_usuario) REFERENCES Usuario(ID_usuario)
);

CREATE TABLE PagoServicio (
    ID_pago_servicio INT IDENTITY(1,1) PRIMARY KEY,
    ID_factura_pago INT,
    ID_usuario INT,
    Monto_pagado DECIMAL(10, 2),
    Fecha_pago DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ID_factura_pago) REFERENCES FacturaPago(ID_factura_pago),
    FOREIGN KEY (ID_usuario) REFERENCES Usuario(ID_usuario)
);

CREATE TABLE Categoria_Producto (
    ID_categoria INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100)
);

CREATE TABLE Producto (
    ID_producto INT IDENTITY(1,1) PRIMARY KEY,
    ID_empresa INT,
    ID_categoria INT,
    Nombre VARCHAR(255),
    Precio DECIMAL(10, 2),
    Stock INT,
    Marca VARCHAR(100),
    Descripcion TEXT,
    FOREIGN KEY (ID_empresa) REFERENCES Empresa(ID_empresa),
    FOREIGN KEY (ID_categoria) REFERENCES Categoria_Producto(ID_categoria)
);

CREATE TABLE Direccion_Entrega (
    ID_direccion INT IDENTITY(1,1) PRIMARY KEY,
    ID_usuario INT,
    Calle VARCHAR(255),
    Numero VARCHAR(20),
    Ciudad VARCHAR(100),
    Codigo_postal VARCHAR(10),
    FOREIGN KEY (ID_usuario) REFERENCES Usuario(ID_usuario)
);

CREATE TABLE CarritoCompras (
    ID_carrito INT IDENTITY(1,1) PRIMARY KEY,
    ID_usuario INT,
    EstadoCompra VARCHAR(50),
    FOREIGN KEY (ID_usuario) REFERENCES Usuario(ID_usuario)
);

CREATE TABLE DetalleCompra (
    ID_detalle INT IDENTITY(1,1) PRIMARY KEY,
    ID_carrito INT,
    ID_producto INT,
    Cantidad INT,
    PrecioUnitario DECIMAL(10, 2),
    Total DECIMAL(10, 2),
    FOREIGN KEY (ID_carrito) REFERENCES CarritoCompras(ID_carrito),
    FOREIGN KEY (ID_producto) REFERENCES Producto(ID_producto)
);

CREATE TABLE CompraT (
    ID_compra_tienda INT IDENTITY(1,1) PRIMARY KEY,
    ID_carrito INT,
    ID_usuario INT,
    ID_direccion INT,
    TotalCompra DECIMAL(10, 2),
    Fecha DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ID_carrito) REFERENCES CarritoCompras(ID_carrito),
    FOREIGN KEY (ID_usuario) REFERENCES Usuario(ID_usuario),
    FOREIGN KEY (ID_direccion) REFERENCES Direccion_Entrega(ID_direccion)
);

CREATE TABLE CalificacionP (
    ID_calificacion INT IDENTITY(1,1) PRIMARY KEY,
    ID_detalle INT,
    Resena TEXT,
    FOREIGN KEY (ID_detalle) REFERENCES DetalleCompra(ID_detalle)
);

CREATE TABLE Recarga (
    ID_recarga INT IDENTITY(1,1) PRIMARY KEY,
    ID_contacto INT,
    ID_usuario INT,
    Numero_destino VARCHAR(20),
    Monto DECIMAL(10, 2),
    FOREIGN KEY (ID_contacto) REFERENCES Contacto(ID_contacto),
    FOREIGN KEY (ID_usuario) REFERENCES Usuario(ID_usuario)
);

CREATE TABLE Categoria_Evento (
    ID_categoria INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100)
);

CREATE TABLE Evento (
    ID_evento INT IDENTITY(1,1) PRIMARY KEY,
    ID_empresa INT,
    ID_categoria INT,
    Nombre VARCHAR(255),
    Fecha DATE,
    Hora TIME,
    Ubicacion VARCHAR(255),
    Descripcion TEXT,
    Artistas TEXT,
    FOREIGN KEY (ID_empresa) REFERENCES Empresa(ID_empresa),
    FOREIGN KEY (ID_categoria) REFERENCES Categoria_Evento(ID_categoria)
);

-- Modificada: Tipo_Entrada ahora tiene relación con Evento
CREATE TABLE Tipo_Entrada (
    ID_tipo_entrada INT IDENTITY(1,1) PRIMARY KEY,
    ID_evento INT,
    Nombre VARCHAR(100),
    Precio DECIMAL(10, 2),
    Capacidad INT,
    FOREIGN KEY (ID_evento) REFERENCES Evento(ID_evento)
);

-- Modificada: UbicacionEvento ahora tiene relación con Tipo_Entrada en lugar de Evento
CREATE TABLE UbicacionEvento (
    ID_ubicacion_evento INT IDENTITY(1,1) PRIMARY KEY,
    ID_tipo_entrada INT,
    N_asiento VARCHAR(50),
    FOREIGN KEY (ID_tipo_entrada) REFERENCES Tipo_Entrada(ID_tipo_entrada)
);

-- Nueva tabla: CarritoEntrada
CREATE TABLE CarritoEntrada (
    ID_carrito_entrada INT IDENTITY(1,1) PRIMARY KEY,
    ID_usuario INT,
    Total DECIMAL(10, 2),
    Estado VARCHAR(50),
    FOREIGN KEY (ID_usuario) REFERENCES Usuario(ID_usuario)
);

-- Nueva tabla: DetalleEntrada
CREATE TABLE DetalleEntrada (
    ID_detalle_entrada INT IDENTITY(1,1) PRIMARY KEY,
    ID_carrito_entrada INT,
    ID_ubicacion_evento INT,
    Precio DECIMAL(10, 2),
    FOREIGN KEY (ID_carrito_entrada) REFERENCES CarritoEntrada(ID_carrito_entrada),
    FOREIGN KEY (ID_ubicacion_evento) REFERENCES UbicacionEvento(ID_ubicacion_evento)
);

-- Modificada: CompraE ahora tiene relación con CarritoEntrada en lugar de Evento
CREATE TABLE CompraE (
    ID_compra_entrada INT IDENTITY(1,1) PRIMARY KEY,
    ID_carrito_entrada INT,
    ID_usuario INT,
    Monto DECIMAL(10, 2),
    Fecha DATE,
    FOREIGN KEY (ID_carrito_entrada) REFERENCES CarritoEntrada(ID_carrito_entrada),
    FOREIGN KEY (ID_usuario) REFERENCES Usuario(ID_usuario)
);

CREATE TABLE Notificacion (
    ID_notificacion INT IDENTITY(1,1) PRIMARY KEY,
    ID_usuario INT,
    Nombre_servicio VARCHAR(255),
    Nombre_accion VARCHAR(255),
    Monto DECIMAL(10, 2),
    FOREIGN KEY (ID_usuario) REFERENCES Usuario(ID_usuario)
);

 -- Modificar tabla Movimiento para incluir ID_cuenta para origen y destino
CREATE TABLE Movimiento (
    ID_movimiento INT IDENTITY(1,1) PRIMARY KEY,
    ID_yape INT NULL,
    ID_credito INT NULL,
    ID_pago_servicio INT NULL,
    ID_compra_tienda INT NULL,
    ID_recarga INT NULL,
    ID_compra_entrada INT NULL,
    ID_cuenta_origen INT NULL, -- Nueva columna para cuenta de origen
    ID_cuenta_destino INT NULL, -- Nueva columna para cuenta de destino
    Nombre_servicio VARCHAR(255),
    Entidad_origen VARCHAR(255),
    Entidad_destino VARCHAR(255),
    Monto DECIMAL(10, 2),
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (ID_yape) REFERENCES Yapeo(ID_yape),
    FOREIGN KEY (ID_credito) REFERENCES Credito(ID_credito),
    FOREIGN KEY (ID_pago_servicio) REFERENCES PagoServicio(ID_pago_servicio),
    FOREIGN KEY (ID_compra_tienda) REFERENCES CompraT(ID_compra_tienda),
    FOREIGN KEY (ID_recarga) REFERENCES Recarga(ID_recarga),
    FOREIGN KEY (ID_compra_entrada) REFERENCES CompraE(ID_compra_entrada),
    FOREIGN KEY (ID_cuenta_origen) REFERENCES Cuenta(ID_cuenta), -- Relación con Cuenta
    FOREIGN KEY (ID_cuenta_destino) REFERENCES Cuenta(ID_cuenta) -- Relación con Cuenta
);



--------------------------------------------------------------TIGGRES



---YAPE
 
CREATE TRIGGER trg_ActualizarSaldoYapeo
ON Yapeo
AFTER INSERT
AS
BEGIN
    -- Declarar variables para almacenar IDs y monto
    DECLARE @ID_usuario INT;
    DECLARE @ID_contacto INT;
    DECLARE @Monto DECIMAL(10, 2);
    DECLARE @ID_cuenta_origen INT;
    DECLARE @ID_cuenta_destino INT;
    DECLARE @ID_usuario_destino INT;
    
    -- Obtener los valores de la inserción
    SELECT 
        @ID_usuario = inserted.ID_usuario,
        @ID_contacto = inserted.ID_contacto,
        @Monto = inserted.Monto
    FROM inserted;
    
    -- Obtener cuenta de origen
    SELECT @ID_cuenta_origen = ID_cuenta
    FROM Cuenta
    WHERE ID_usuario = @ID_usuario;
    
    -- Obtener cuenta de destino
    SELECT @ID_usuario_destino = ID_usuario
    FROM Contacto
    WHERE ID_contacto = @ID_contacto;
    
    SELECT @ID_cuenta_destino = ID_cuenta
    FROM Cuenta
    WHERE ID_usuario = @ID_usuario_destino;
    
    -- Actualizar saldo de la cuenta de origen
    UPDATE Cuenta
    SET Saldo = Saldo - @Monto
    WHERE ID_cuenta = @ID_cuenta_origen;
    
    -- Actualizar saldo de la cuenta de destino
    UPDATE Cuenta
    SET Saldo = Saldo + @Monto
    WHERE ID_cuenta = @ID_cuenta_destino;
    -- Insertar en la tabla Movimiento
    INSERT INTO Movimiento (ID_yape, ID_cuenta_origen, ID_cuenta_destino, Nombre_servicio, Entidad_origen, Entidad_destino,Monto, Fecha)
    SELECT
        inserted.ID_yape,
        @ID_cuenta_origen,
        @ID_cuenta_destino,
		'YAPE',
		'BCP',
		'BCP',
        @Monto,
        GETDATE()
    FROM inserted;
END;




---CREDITO:
CREATE TRIGGER trg_AfterCredito
ON Credito
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Actualizar saldo del usuario cuando se aprueba un crédito
    UPDATE Cuenta
    SET Saldo = Saldo + i.Monto
    FROM Cuenta c
    INNER JOIN inserted i ON c.ID_usuario = i.ID_usuario
    WHERE c.ID_cuenta = i.ID_usuario
      AND i.Estado = 1; -- Considera '1' como aprobado. Cambia según el estado definido para créditos aprobados.

    -- Insertar movimiento en la tabla Movimiento
    INSERT INTO Movimiento (ID_credito, ID_cuenta_origen, Nombre_servicio, Monto, Fecha)
    SELECT i.ID_credito, 
           (SELECT ID_cuenta FROM Cuenta WHERE ID_usuario = i.ID_usuario),
           'Credito', 
           i.Monto, 
           GETDATE()
    FROM inserted i
    WHERE i.Estado = 1;
END;
--- RECARGA:
CREATE TRIGGER trg_AfterRecarga
ON Recarga
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ID_usuario INT;
    DECLARE @ID_contacto INT;
    DECLARE @ID_operadora INT;
    DECLARE @ID_empresa INT;
    DECLARE @Monto DECIMAL(10, 2);
    DECLARE @ID_cuenta_usuario INT;
    DECLARE @ID_cuenta_empresa INT;
    DECLARE @Tipo_Linea VARCHAR(50);
    
    -- Obtener los valores de la inserción
    SELECT 
        @ID_usuario = inserted.ID_usuario,
        @ID_contacto = inserted.ID_contacto,
        @Monto = inserted.Monto
    FROM inserted;

    -- Obtener el ID_operadora y Tipo_Linea del contacto
    SELECT @ID_operadora = ID_operadora, @Tipo_Linea = Tipo_Linea
    FROM Contacto
    WHERE ID_contacto = @ID_contacto;

    -- Verificar que el Tipo_Linea sea Prepago antes de proceder
    IF @Tipo_Linea = 'Prepago'
    BEGIN
        -- Obtener el ID_empresa de la operadora
        SELECT @ID_empresa = ID_empresa
        FROM Operadora
        WHERE ID_operadora = @ID_operadora;

        -- Obtener cuenta del usuario que realiza la recarga
        SELECT @ID_cuenta_usuario = ID_cuenta
        FROM Cuenta
        WHERE ID_usuario = @ID_usuario;

        -- Obtener cuenta de la empresa (operadora) que recibe la recarga
        SELECT @ID_cuenta_empresa = ID_cuenta
        FROM Cuenta
        WHERE ID_empresa = @ID_empresa;

        -- Actualizar saldo de la cuenta del usuario que realiza la recarga
        UPDATE Cuenta
        SET Saldo = Saldo - @Monto
        WHERE ID_cuenta = @ID_cuenta_usuario;

        -- Actualizar saldo de la cuenta de la empresa que recibe la recarga
        UPDATE Cuenta
        SET Saldo = Saldo + @Monto
        WHERE ID_cuenta = @ID_cuenta_empresa;

        -- Actualizar el saldo prepago del contacto
        UPDATE Contacto
        SET Saldo_prepago = Saldo_prepago + @Monto
        WHERE ID_contacto = @ID_contacto;

        -- Insertar en la tabla Movimiento
        INSERT INTO Movimiento (ID_recarga, ID_cuenta_origen, ID_cuenta_destino, Nombre_servicio, Entidad_origen, Entidad_destino, Monto, Fecha)
        VALUES (
            (SELECT ID_recarga FROM inserted),
            @ID_cuenta_usuario,
            @ID_cuenta_empresa,
            'Recarga',
            (SELECT Nombre FROM Empresa WHERE ID_empresa = @ID_empresa),
            (SELECT Nombre FROM Empresa WHERE ID_empresa = @ID_empresa),
            @Monto,
            GETDATE()
        );
    END;
END;





---CompraE
 
 CREATE TRIGGER trg_AfterCompraE
ON CompraE
AFTER INSERT
AS
BEGIN
    -- Descontar el monto de la cuenta del usuario
    UPDATE c
    SET c.Saldo = c.Saldo - i.Monto
    FROM Cuenta c
    INNER JOIN inserted i ON c.ID_usuario = i.ID_usuario
    WHERE c.ID_usuario = i.ID_usuario;

    -- Obtener el ID_empresa a partir del evento asociado a la entrada
    DECLARE @ID_empresa INT;
    
    SELECT @ID_empresa = e.ID_empresa
    FROM CarritoEntrada ce
    INNER JOIN inserted i ON ce.ID_carrito_entrada = i.ID_carrito_entrada
    INNER JOIN Evento e ON e.ID_evento = (SELECT e.ID_evento 
                                          FROM DetalleEntrada de
                                          INNER JOIN UbicacionEvento ue ON de.ID_ubicacion_evento = ue.ID_ubicacion_evento
                                          WHERE de.ID_carrito_entrada = ce.ID_carrito_entrada)
    WHERE e.ID_empresa IS NOT NULL;

    -- Aumentar el monto a la cuenta de la empresa
    UPDATE c
    SET c.Saldo = c.Saldo + i.Monto
    FROM Cuenta c
    INNER JOIN inserted i ON c.ID_empresa = @ID_empresa
    WHERE c.ID_empresa = @ID_empresa;
END;


--PagoServicio
 
CREATE TRIGGER trg_AfterPagoServicio
ON PagoServicio
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Actualizar el saldo del usuario
    UPDATE Cuenta
    SET Saldo = Saldo - i.Monto_pagado
    FROM Cuenta c
    INNER JOIN inserted i ON c.ID_usuario = i.ID_usuario
    WHERE c.ID_usuario IS NOT NULL;

    -- Actualizar el saldo de la empresa
    UPDATE Cuenta
    SET Saldo = Saldo + i.Monto_pagado
    FROM Cuenta c
    INNER JOIN Empresa e ON c.ID_empresa = e.ID_empresa
    INNER JOIN inserted i ON c.ID_empresa = (
        SELECT f.ID_empresa
        FROM FacturaPago f
        INNER JOIN inserted i ON f.ID_factura_pago = i.ID_factura_pago
    );

    -- Registrar la transacción en la tabla Movimiento
    INSERT INTO Movimiento (
        ID_pago_servicio,
        ID_cuenta_origen,
        ID_cuenta_destino,
        Nombre_servicio,
        Entidad_origen,
        Entidad_destino,
        Monto,
        Fecha
    )
    SELECT 
        i.ID_pago_servicio,
        (SELECT c.ID_cuenta
         FROM Cuenta c
         WHERE c.ID_usuario = i.ID_usuario) AS ID_cuenta_origen,
        (SELECT c.ID_cuenta
         FROM Cuenta c
         WHERE c.ID_empresa = (
             SELECT f.ID_empresa
             FROM FacturaPago f
             INNER JOIN inserted i ON f.ID_factura_pago = i.ID_factura_pago
         )) AS ID_cuenta_destino,
        'Pago Servicio' AS Nombre_servicio,
        'Usuario' AS Entidad_origen,
        'Empresa' AS Entidad_destino,
        i.Monto_pagado AS Monto,
        GETDATE() AS Fecha
    FROM inserted i;

    -- Actualizar el estado de la factura de pago a 'Pagado'
    UPDATE FacturaPago
    SET Estado = 'Pagado'
    FROM FacturaPago f
    INNER JOIN inserted i ON f.ID_factura_pago = i.ID_factura_pago;
END;





-----COMPRAT
CREATE TRIGGER trg_AfterCompraT
ON CompraT
AFTER INSERT
AS
BEGIN
    -- Descontar el monto de la cuenta del usuario
    UPDATE c
    SET c.Saldo = c.Saldo - i.TotalCompra
    FROM Cuenta c
    INNER JOIN inserted i ON c.ID_usuario = i.ID_usuario
    WHERE c.ID_usuario = i.ID_usuario;

    -- Obtener el ID_empresa a partir del carrito
    DECLARE @ID_empresa INT;

    SELECT @ID_empresa = p.ID_empresa
    FROM DetalleCompra dc
    INNER JOIN Producto p ON dc.ID_producto = p.ID_producto
    INNER JOIN CarritoCompras cc ON dc.ID_carrito = cc.ID_carrito
    INNER JOIN inserted i ON i.ID_carrito = cc.ID_carrito
    WHERE p.ID_empresa IS NOT NULL;

    -- Aumentar el monto a la cuenta de la empresa
    UPDATE c
    SET c.Saldo = c.Saldo + i.TotalCompra
    FROM Cuenta c
    INNER JOIN inserted i ON c.ID_empresa = @ID_empresa
    WHERE c.ID_empresa = @ID_empresa;
END;
