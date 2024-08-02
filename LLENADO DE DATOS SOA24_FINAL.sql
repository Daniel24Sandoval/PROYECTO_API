---INSERT USUARIOS
INSERT INTO Usuario (DNIUSER, Nombre, Correo, Telefono) VALUES
(12345678, 'Ana Pérez', 'ana.perez@example.com', '987654321'),
(23456789, 'Luis Gómez', 'luis.gomez@example.com', '987654322'),
(34567890, 'María López', 'maria.lopez@example.com', '987654323'),
(45678901, 'Carlos Martínez', 'carlos.martinez@example.com', '987654324'),
(56789012, 'Laura Fernández', 'laura.fernandez@example.com', '987654325'),
(67890123, 'Jorge Ruiz', 'jorge.ruiz@example.com', '987654326'),
(78901234, 'Paola Morales', 'paola.morales@example.com', '987654327'),
(89012345, 'Mario Díaz', 'mario.diaz@example.com', '987654328'),
(90123456, 'Carla Vargas', 'carla.vargas@example.com', '987654329'),
(12345679, 'Samuel Reyes', 'samuel.reyes@example.com', '987654330'),
(23456780, 'Vanessa Soto', 'vanessa.soto@example.com', '987654331'),
(34567891, 'Santiago Torres', 'santiago.torres@example.com', '987654332'),
(45678902, 'Isabel Ramírez', 'isabel.ramirez@example.com', '987654333'),
(56789013, 'Felipe Castro', 'felipe.castro@example.com', '987654334'),
(67890124, 'Valeria Ortega', 'valeria.ortega@example.com', '987654335'),
(78901235, 'Daniela Guerrero', 'daniela.guerrero@example.com', '987654336'),
(89012346, 'Andrés Molina', 'andres.molina@example.com', '987654337'),
(90123457, 'Sofía Gómez', 'sofia.gomez@example.com', '987654338'),
(12345680, 'Mateo Salazar', 'mateo.salazar@example.com', '987654339'),
(23456781, 'Gabriela Martínez', 'gabriela.martinez@example.com', '987654340');



----EMPRESAS:

-- Empresas de Telefonía
INSERT INTO Empresa (Nombre, Categoria) VALUES
('Movistar', 'Telefonía'),
('Claro', 'Telefonía'),
('Entel', 'Telefonía'),
('Bitel', 'Telefonía');

-- Empresas que Venden Entradas
INSERT INTO Empresa (Nombre, Categoria) VALUES
('Teleticket', 'Venta de Entradas'),
('Joinnus', 'Venta de Entradas'),
('Ticketmaster', 'Venta de Entradas');

-- Empresas que Venden Productos
INSERT INTO Empresa (Nombre, Categoria) VALUES
('TecnMart', 'Venta de Productos'),
('Saga', 'Venta de Productos'),
('Linio', 'Venta de Productos'),
('Oechsle', 'Venta de Productos');

-- Empresas que Prestan Servicios
INSERT INTO Empresa (Nombre, Categoria) VALUES
('Luz del Sur', 'Servicios Públicos'),
('Sedapal', 'Servicios Públicos'),
('Movistar TV', 'Servicios Públicos'),
('Interbank', 'Servicios Financieros'),
('BBVA', 'Servicios Financieros');


--- OPERADORS- RELACIONAR CON EMPRESA
-- Operadoras para empresas de Telefonía
INSERT INTO Operadora (ID_empresa, Nombre) VALUES
(1, 'Movistar Peru'),
(2, 'Claro Peru'),
(3, 'Entel Peru'),
(4, 'Bitel Peru');

---TARJETAS: 

-- Insertar 20 tarjetas del BCP
 -- Insertar 20 tarjetas del BCP con formato de fecha correcto - PARA USUARIOS
INSERT INTO Tarjeta (NumeroDeCuenta, Banco, TipoTarjeta, FechaVencimiento, Clave) VALUES
('1234567890123456', 'Banco de Crédito del Perú', 'Visa', '2026-12-31', '1234'),
('2345678901234567', 'Banco de Crédito del Perú', 'MasterCard', '2025-11-30', '2345'),
('3456789012345678', 'Banco de Crédito del Perú', 'Visa', '2024-10-31', '3456'),
('4567890123456789', 'Banco de Crédito del Perú', 'MasterCard', '2026-09-30', '4567'),
('5678901234567890', 'Banco de Crédito del Perú', 'Visa', '2027-08-31', '5678'),
('6789012345678901', 'Banco de Crédito del Perú', 'MasterCard', '2025-07-31', '6789'),
('7890123456789012', 'Banco de Crédito del Perú', 'Visa', '2026-06-30', '7890'),
('8901234567890123', 'Banco de Crédito del Perú', 'MasterCard', '2024-05-31', '8901'),
('9012345678901234', 'Banco de Crédito del Perú', 'Visa', '2027-04-30', '9012'),
('0123456789012345', 'Banco de Crédito del Perú', 'MasterCard', '2025-03-31', '0123'),
('1123456789012346', 'Banco de Crédito del Perú', 'Visa', '2026-02-28', '1123'),
('1223456789012347', 'Banco de Crédito del Perú', 'MasterCard', '2027-01-31', '1223'),
('1323456789012348', 'Banco de Crédito del Perú', 'Visa', '2026-12-31', '1323'),
('1423456789012349', 'Banco de Crédito del Perú', 'MasterCard', '2025-11-30', '1423'),
('1523456789012350', 'Banco de Crédito del Perú', 'Visa', '2024-10-31', '1523'),
('1623456789012351', 'Banco de Crédito del Perú', 'MasterCard', '2026-09-30', '1623'),
('1723456789012352', 'Banco de Crédito del Perú', 'Visa', '2027-08-31', '1723'),
('1823456789012353', 'Banco de Crédito del Perú', 'MasterCard', '2025-07-31', '1823'),
('1923456789012354', 'Banco de Crédito del Perú', 'Visa', '2026-06-30', '1923'),
('2023456789012355', 'Banco de Crédito del Perú', 'MasterCard', '2024-05-31', '2023');

 --- -- Insertar 20 tarjetas del BCP con formato de fecha correcto - PARA EMPRESA

 INSERT INTO Tarjeta (NumeroDeCuenta, Banco, TipoTarjeta, FechaVencimiento, Clave) VALUES 
('3333444455556661', 'Banco de Crédito del Perú', 'Visa', '2026-12-31', '5671'),
('3333444455556662', 'Banco de Crédito del Perú', 'MasterCard', '2025-11-30', '5672'),
('3333444455556663', 'Banco de Crédito del Perú', 'Visa', '2024-10-31', '5673'),
('3333444455556664', 'Banco de Crédito del Perú', 'MasterCard', '2026-09-30', '5674'),
('3333444455556665', 'Banco de Crédito del Perú', 'Visa', '2027-08-31', '5675'),
('3333444455556666', 'Banco de Crédito del Perú', 'MasterCard', '2025-07-31', '5676'),
('3333444455556667', 'Banco de Crédito del Perú', 'Visa', '2026-06-30', '5677'),
('3333444455556668', 'Banco de Crédito del Perú', 'MasterCard', '2024-05-31', '5678'),
('3333444455556669', 'Banco de Crédito del Perú', 'Visa', '2027-04-30', '5679'),
('3333444455556670', 'Banco de Crédito del Perú', 'MasterCard', '2025-03-31', '5680'),
('3333444455556671', 'Banco de Crédito del Perú', 'Visa', '2026-02-28', '5681'),
('3333444455556672', 'Banco de Crédito del Perú', 'MasterCard', '2027-01-31', '5682'),
('3333444455556673', 'Banco de Crédito del Perú', 'Visa', '2026-12-31', '5683'),
('3333444455556674', 'Banco de Crédito del Perú', 'MasterCard', '2025-11-30', '5684'),
('3333444455556675', 'Banco de Crédito del Perú', 'Visa', '2024-10-31', '5685'),
('3333444455556676', 'Banco de Crédito del Perú', 'MasterCard', '2026-09-30', '5686'),
('3333444455556677', 'Banco de Crédito del Perú', 'Visa', '2027-08-31', '5687'),
('3333444455556678', 'Banco de Crédito del Perú', 'MasterCard', '2025-07-31', '5688'),
('3333444455556679', 'Banco de Crédito del Perú', 'Visa', '2026-06-30', '5689'),
('3333444455556680', 'Banco de Crédito del Perú', 'MasterCard', '2024-05-31', '5690');

---INSERT DE CUENTAS DE USUARIO: 
--  los ID de usuario van del 1 al 20 y los ID de tarjeta del 12 al 31 para los usuarios
-- Insertar cuentas para los usuarios
INSERT INTO Cuenta (ID_usuario, ID_tarjeta, Saldo) VALUES (1, 12, 0.0);
INSERT INTO Cuenta (ID_usuario, ID_tarjeta, Saldo) VALUES (2, 13, 1200.00);
INSERT INTO Cuenta (ID_usuario, ID_tarjeta, Saldo) VALUES (3, 14, 1400.00);
INSERT INTO Cuenta (ID_usuario, ID_tarjeta, Saldo) VALUES (4, 15, 1600.00);
INSERT INTO Cuenta (ID_usuario, ID_tarjeta, Saldo) VALUES (5, 16, 1800.00);
INSERT INTO Cuenta (ID_usuario, ID_tarjeta, Saldo) VALUES (6, 17, 1800.00);
INSERT INTO Cuenta (ID_usuario, ID_tarjeta, Saldo) VALUES (7, 18, 2200.00);
INSERT INTO Cuenta (ID_usuario, ID_tarjeta, Saldo) VALUES (8, 19, 2400.00);
INSERT INTO Cuenta (ID_usuario, ID_tarjeta, Saldo) VALUES (9, 20, 2600.00);
INSERT INTO Cuenta (ID_usuario, ID_tarjeta, Saldo) VALUES (10, 21, 2800.00);
INSERT INTO Cuenta (ID_usuario, ID_tarjeta, Saldo) VALUES (11, 22, 3000.00);
INSERT INTO Cuenta (ID_usuario, ID_tarjeta, Saldo) VALUES (12, 23, 3200.00);
INSERT INTO Cuenta (ID_usuario, ID_tarjeta, Saldo) VALUES (13, 24, 3400.00);
INSERT INTO Cuenta (ID_usuario, ID_tarjeta, Saldo) VALUES (14, 25, 3600.00);
INSERT INTO Cuenta (ID_usuario, ID_tarjeta, Saldo) VALUES (15, 26, 3800.00);
INSERT INTO Cuenta (ID_usuario, ID_tarjeta, Saldo) VALUES (16, 27, 4000.00);
INSERT INTO Cuenta (ID_usuario, ID_tarjeta, Saldo) VALUES (17, 28, 4200.00);
INSERT INTO Cuenta (ID_usuario, ID_tarjeta, Saldo) VALUES (18, 29, 4400.00);
INSERT INTO Cuenta (ID_usuario, ID_tarjeta, Saldo) VALUES (19, 30, 4600.00);
INSERT INTO Cuenta (ID_usuario, ID_tarjeta, Saldo) VALUES (20, 31, 4800.00);



--  los ID de empresa van del 1 al 20 y los ID de tarjeta del 32 al 51 para las empresas
-- Insertar cuentas para las empresas
INSERT INTO Cuenta (ID_empresa, ID_tarjeta, Saldo) VALUES (1, 32, 5000.00);
INSERT INTO Cuenta (ID_empresa, ID_tarjeta, Saldo) VALUES (2, 33, 5200.00);
INSERT INTO Cuenta (ID_empresa, ID_tarjeta, Saldo) VALUES (3, 34, 5400.00);
INSERT INTO Cuenta (ID_empresa, ID_tarjeta, Saldo) VALUES (4, 35, 5600.00);
INSERT INTO Cuenta (ID_empresa, ID_tarjeta, Saldo) VALUES (5, 36, 5800.00);
INSERT INTO Cuenta (ID_empresa, ID_tarjeta, Saldo) VALUES (6, 37, 6000.00);
INSERT INTO Cuenta (ID_empresa, ID_tarjeta, Saldo) VALUES (7, 38, 6200.00);
INSERT INTO Cuenta (ID_empresa, ID_tarjeta, Saldo) VALUES (8, 39, 6400.00);
INSERT INTO Cuenta (ID_empresa, ID_tarjeta, Saldo) VALUES (9, 40, 6600.00);
INSERT INTO Cuenta (ID_empresa, ID_tarjeta, Saldo) VALUES (10, 41, 6800.00);
INSERT INTO Cuenta (ID_empresa, ID_tarjeta, Saldo) VALUES (11, 42, 7000.00);
INSERT INTO Cuenta (ID_empresa, ID_tarjeta, Saldo) VALUES (12, 43, 7200.00);
INSERT INTO Cuenta (ID_empresa, ID_tarjeta, Saldo) VALUES (13, 44, 7400.00);
INSERT INTO Cuenta (ID_empresa, ID_tarjeta, Saldo) VALUES (14, 45, 7600.00);
INSERT INTO Cuenta (ID_empresa, ID_tarjeta, Saldo) VALUES (15, 46, 7800.00);
INSERT INTO Cuenta (ID_empresa, ID_tarjeta, Saldo) VALUES (16, 47, 8000.00);
--INSERT INTO Cuenta (ID_empresa, ID_tarjeta, Saldo) VALUES (17, 48, 8200.00);
--INSERT INTO Cuenta (ID_empresa, ID_tarjeta, Saldo) VALUES (18, 49, 8400.00);
--INSERT INTO Cuenta (ID_empresa, ID_tarjeta, Saldo) VALUES (19, 50, 8600.00);
--INSERT INTO Cuenta (ID_empresa, ID_tarjeta, Saldo) VALUES (20, 51, 8800.00);


--INSERT CONTACTO

-- Asumiendo que los ID_operadora van del 1 al 4 y los ID_usuario van del 1 al 20
-- Insertar contactos
INSERT INTO Contacto (ID_operadora, ID_usuario, Nombre, Numero, Pais, Tipo_linea, Saldo_prepago) VALUES
(1, 1, 'Carlos López', 987654321, 'Perú', 'Postpago', 0.00),
(1, 2, 'Ana García', 987654322, 'Perú', 'Prepago', 50.00),
(2, 3, 'Luis Fernández', 987654323, 'Perú', 'Postpago', 0.00),
(2, 4, 'Marta Rodríguez', 987654324, 'Perú', 'Prepago', 30.00),
(3, 5, 'José Martínez', 987654325, 'Perú', 'Postpago', 0.00),
(3, 6, 'Patricia López', 987654326, 'Perú', 'Prepago', 70.00),
(4, 7, 'Ricardo Pérez', 987654327, 'Perú', 'Postpago', 0.00),
(4, 8, 'María Vargas', 987654328, 'Perú', 'Prepago', 40.00),
(1, 9, 'Juan Rodríguez', 987654329, 'Perú', 'Postpago', 0.00),
(1, 10, 'Laura Gómez', 987654330, 'Perú', 'Prepago', 60.00),
(2, 11, 'Francisco Romero', 987654331, 'Perú', 'Postpago', 0.00),
(2, 12, 'Sofía Álvarez', 987654332, 'Perú', 'Prepago', 25.00),
(3, 13, 'Diego Ortega', 987654333, 'Perú', 'Postpago', 0.00),
(3, 14, 'Isabel Castillo', 987654334, 'Perú', 'Prepago', 90.00),
(4, 15, 'Gabriel Medina', 987654335, 'Perú', 'Postpago', 0.00),
(4, 16, 'Claudia López', 987654336, 'Perú', 'Prepago', 55.00),
(1, 17, 'Héctor Morales', 987654337, 'Perú', 'Postpago', 0.00),
(1, 18, 'Verónica Torres', 987654338, 'Perú', 'Prepago', 45.00),
(2, 19, 'Ricardo Romero', 987654339, 'Perú', 'Postpago', 0.00),
(2, 20, 'Carmen Silva', 987654340, 'Perú', 'Prepago', 35.00);

--INSERT HISTORIAL CREDITICIO
-- Insertar datos en Historial
INSERT INTO Historial (ID_usuario, Calificacion) VALUES
(1, 1),  -- Usuario 1, calificación positiva
(2, 0),  -- Usuario 2, calificación negativa
(3, 1),  -- Usuario 3, calificación positiva
(4, 1),  -- Usuario 4, calificación positiva
(5, 0),  -- Usuario 5, calificación negativa
(6, 1),  -- Usuario 6, calificación positiva
(7, 0),  -- Usuario 7, calificación negativa
(8, 1),  -- Usuario 8, calificación positiva
(9, 1),  -- Usuario 9, calificación positiva
(10, 0), -- Usuario 10, calificación negativa
(11, 1), -- Usuario 11, calificación positiva
(12, 0), -- Usuario 12, calificación negativa
(13, 1), -- Usuario 13, calificación positiva
(14, 1), -- Usuario 14, calificación positiva
(15, 0), -- Usuario 15, calificación negativa
(16, 1), -- Usuario 16, calificación positiva
(17, 0), -- Usuario 17, calificación negativa
(18, 1), -- Usuario 18, calificación positiva
(19, 1), -- Usuario 19, calificación positiva
(20, 0); -- Usuario 20, calificación negativa


------ Insertar datos en FacturaPago para usuarios postpago
INSERT INTO FacturaPago (ID_empresa, ID_usuario, Codigo_cliente, Monto_a_pagar, Fecha_pago, Estado) VALUES
(1, 1, 'CL001', 120.00, '2024-07-01', 'No pagado'),  -- Movistar
(2, 3, 'CL002', 150.00, '2024-07-02', 'No pagado'), -- Claro
(3, 5, 'CL003', 130.00, '2024-07-03', 'No pagado'),  -- Entel
(4, 7, 'CL004', 140.00, '2024-07-04', 'No pagado'),  -- Bitel
(12, 9, 'CL005', 160.00, '2024-07-05', 'No pagado'), -- Luz del Sur
(13, 11, 'CL006', 170.00, '2024-07-06', 'No pagado'),  -- Sedapal
(14, 13, 'CL007', 180.00, '2024-07-07', 'No pagado'),  -- Movistar TV
(15, 15, 'CL008', 200.00, '2024-07-08', 'No pagado'), -- Interbank
(16, 17, 'CL009', 190.00, '2024-07-09', 'No pagado'),  -- BBVA
(1, 19, 'CL010', 210.00, '2024-07-10', 'No pagado');  -- Movistar
-- Insertar datos en FacturaPago para usuarios prepago
INSERT INTO FacturaPago (ID_empresa, ID_usuario, Codigo_cliente, Monto_a_pagar, Fecha_pago, Estado) VALUES
(12, 2, 'CL011', 110.00, '2024-07-01', 'No pagado'),  -- Luz del Sur
(13, 4, 'CL012', 140.00, '2024-07-02', 'No pagado'), -- Sedapal
(14, 6, 'CL013', 120.00, '2024-07-03', 'No pagado'),  -- Movistar TV
(15, 8, 'CL014', 200.00, '2024-07-04', 'No pagado'), -- Interbank
(16, 10, 'CL015', 150.00, '2024-07-05', 'No pagado'),  -- BBVA
(12, 12, 'CL016', 130.00, '2024-07-06', 'No pagado'), -- Luz del Sur
(13, 14, 'CL017', 160.00, '2024-07-07', 'No pagado'),  -- Sedapal
(14, 16, 'CL018', 170.00, '2024-07-08', 'No pagado'), -- Movistar TV
(15, 18, 'CL019', 180.00, '2024-07-09', 'No pagado'),  -- Interbank
(16, 20, 'CL020', 190.00, '2024-07-10', 'No pagado');  -- BBVA


---SELECT *FROM Empresa where Categoria='Servicios Públicos' OR Categoria='Servicios Financieros' OR Categoria='Telefonía' ;

---INSERT CATEGORIAS PRODUCTOS: 
INSERT INTO Categoria_Producto (Nombre) VALUES
('Electrónica'),
('Hogar'),
('Ropa y Accesorios'),
('Deportes'),
('Juguetes');



----PRODUCTOS:
--DELETE FROM Producto
-- Productos para TecMart (Venta de Productos)
INSERT INTO Producto (ID_empresa, ID_categoria, Nombre, Precio, Stock, Marca, Descripcion) VALUES
(8, 1, 'Smartphone', 299.99, 50, 'Samsung', 'Smartphone de última generación con 128GB de almacenamiento.'),
(8, 1, 'Laptop', 799.99, 30, 'HP', 'Laptop potente con 16GB de RAM y 512GB de SSD.'),
(8, 2, 'Aspiradora', 149.99, 20, 'Dyson', 'Aspiradora sin bolsa con tecnología ciclónica.'),
(8, 3, 'Chaqueta', 79.99, 40, 'North Face', 'Chaqueta impermeable para exteriores.');

-- Productos para Saga (Venta de Productos)
INSERT INTO Producto (ID_empresa, ID_categoria, Nombre, Precio, Stock, Marca, Descripcion) VALUES
(9, 1, 'Tablet', 199.99, 60, 'Apple', 'Tablet con pantalla Retina de 10.2 pulgadas.'),
(9, 2, 'Silla de Oficina', 129.99, 25, 'IKEA', 'Silla ergonómica para oficina con ajuste de altura.'),
(9, 4, 'Balón de Fútbol', 29.99, 100, 'Nike', 'Balón de fútbol con diseño profesional.'),
(9, 5, 'Juego de Construcción', 49.99, 70, 'LEGO', 'Juego de construcción con 500 piezas.');

-- Productos para Linio (Venta de Productos)
INSERT INTO Producto (ID_empresa, ID_categoria, Nombre, Precio, Stock, Marca, Descripcion) VALUES
(10, 1, 'Auriculares Bluetooth', 89.99, 80, 'Sony', 'Auriculares inalámbricos con cancelación de ruido.'),
(10, 2, 'Lámpara LED', 39.99, 45, 'Philips', 'Lámpara LED con ajuste de brillo y temperatura de color.'),
(10, 3, 'Camisa', 49.99, 60, 'Levi', 'Camisa de algodón con diseño clásico.'),
(10, 4, 'Raqueta de Tenis', 119.99, 15, 'Wilson', 'Raqueta de tenis para jugadores profesionales.');

-- Productos para Oechsle (Venta de Productos)
INSERT INTO Producto (ID_empresa, ID_categoria, Nombre, Precio, Stock, Marca, Descripcion) VALUES
(11, 1, 'Smartwatch', 199.99, 25, 'Garmin', 'Reloj inteligente con monitoreo de salud y GPS.'),
(11, 2, 'Sofá', 499.99, 10, 'Ashley', 'Sofá de tres plazas con tapizado en tela resistente.'),
(11, 3, 'Zapatos Deportivos', 89.99, 50, 'Adidas', 'Zapatos deportivos con tecnología de amortiguación.'),
(11, 4, 'Bicicleta', 299.99, 20, 'Trek', 'Bicicleta de montaña con marco de aluminio.');

 
 ---INSERT DIRECCION USUARIO:
 -- Insertar direcciones para los usuarios
INSERT INTO Direccion_Entrega (ID_usuario, Calle, Numero, Ciudad, Codigo_postal) VALUES
(1, 'Av. Javier Prado Este', '1234', 'Lima', 'LIMA01'),
(2, 'Calle Bolognesi', '567', 'Miraflores', 'LIMA02'),
(3, 'Av. Arequipa', '890', 'San Isidro', 'LIMA03'),
(4, 'Calle Larco', '456', 'Surco', 'LIMA04'),
(5, 'Av. Pardo', '789', 'San Borja', 'LIMA05'),
(6, 'Calle de la Paz', '1011', 'La Molina', 'LIMA06'),
(7, 'Av. La Mar', '1213', 'San Miguel', 'LIMA07'),
(8, 'Calle San Martín', '1415', 'San Juan de Miraflores', 'LIMA08'),
(9, 'Av. El Sol', '1617', 'San Luis', 'LIMA09'),
(10, 'Calle Brasil', '1819', 'Villa María del Triunfo', 'LIMA10'),
(11, 'Av. San Borja Sur', '2021', 'San Borja', 'LIMA11'),
(12, 'Calle Centenario', '2223', 'Miraflores', 'LIMA12'),
(13, 'Av. Bolivar', '2425', 'San Isidro', 'LIMA13'),
(14, 'Calle Ramón Castilla', '2627', 'Surco', 'LIMA14'),
(15, 'Av. Primavera', '2829', 'La Molina', 'LIMA15'),
(16, 'Calle Ayacucho', '3031', 'San Miguel', 'LIMA16'),
(17, 'Av. Universitaria', '3233', 'San Juan de Miraflores', 'LIMA17'),
(18, 'Calle Salaverry', '3435', 'San Luis', 'LIMA18'),
(19, 'Av. Grau', '3637', 'Villa María del Triunfo', 'LIMA19'),
(20, 'Calle República', '3839', 'La Molina', 'LIMA20');



---CATEGORIA EVENTOs:
-- Insertar categorías de eventos
INSERT INTO Categoria_Evento (Nombre) VALUES
('Conciertos'),
('Teatro'),
('Deportes'),
('Cine'),
('Exposiciones');

---EVENTOS: 
-- Insertar eventos para la categoría 'Conciertos' con empresas de venta de entradas
INSERT INTO Evento (ID_empresa, ID_categoria, Nombre, Fecha, Hora, Ubicacion, Descripcion, Artistas) VALUES
(5, 1, 'Concierto de Rock', '2024-08-15', '20:00:00', 'Estadio Nacional', 'Un gran concierto de rock con bandas locales e internacionales.', 'Banda X, Banda Y'),
(6, 1, 'Festival de Jazz', '2024-09-10', '18:00:00', 'Centro de Convenciones', 'Festival de jazz con artistas internacionales.', 'Artista A, Artista B'),
(7, 1, 'Concierto de Música Clásica', '2024-10-05', '19:00:00', 'Teatro Municipal', 'Concierto de música clásica con la Orquesta Filarmónica.', 'Orquesta Filarmónica'),
(5, 1, 'Show de Música Electrónica', '2024-11-20', '22:00:00', 'Club de Música', 'Evento de música electrónica con DJs de renombre.', 'DJ 1, DJ 2');

-- Insertar eventos para la categoría 'Teatro' con empresas de venta de entradas
INSERT INTO Evento (ID_empresa, ID_categoria, Nombre, Fecha, Hora, Ubicacion, Descripcion, Artistas) VALUES
(6, 2, 'Obra de Teatro Clásica', '2024-08-20', '21:00:00', 'Teatro Principal', 'Representación de una obra teatral clásica.', 'Actriz A, Actor B'),
(7, 2, 'Comedia en Vivo', '2024-09-15', '19:30:00', 'Teatro Nacional', 'Noche de comedia en vivo con humoristas locales.', 'Humorista X, Humorista Y'),
(5, 2, 'Teatro Experimental', '2024-10-10', '20:00:00', 'Espacio Cultural', 'Teatro experimental con una propuesta innovadora.', 'Grupo Experimental A'),
(6, 2, 'Danza Teatral', '2024-11-25', '18:00:00', 'Centro de Arte', 'Espectáculo de danza con elementos teatrales.', 'Compañía de Danza B');

-- Insertar eventos para la categoría 'Deportes' con empresas de venta de entradas
INSERT INTO Evento (ID_empresa, ID_categoria, Nombre, Fecha, Hora, Ubicacion, Descripcion, Artistas) VALUES
(7, 3, 'Partido de Fútbol', '2024-08-25', '16:00:00', 'Estadio Universitario', 'Partido de fútbol entre dos equipos locales.', 'Equipo A vs. Equipo B'),
(5, 3, 'Maratón Ciudad de Lima', '2024-09-30', '07:00:00', 'Parque Central', 'Maratón anual con participantes de todo el país.', 'Corredores locales e internacionales'),
(6, 3, 'Competencia de Natación', '2024-10-15', '14:00:00', 'Piscina Olímpica', 'Competencia de natación con nadadores de élite.', 'Nadador X, Nadador Y'),
(7, 3, 'Torneo de Vóley', '2024-11-05', '09:00:00', 'Complejo Deportivo', 'Torneo de vóley con equipos de diferentes categorías.', 'Equipo 1 vs. Equipo 2');

-- Insertar eventos para la categoría 'Cine' con empresas de venta de entradas
INSERT INTO Evento (ID_empresa, ID_categoria, Nombre, Fecha, Hora, Ubicacion, Descripcion, Artistas) VALUES
(5, 4, 'Estreno de Película A', '2024-08-30', '19:00:00', 'Cine Multicines', 'Estreno de la nueva película de acción.', 'Director A, Actor A'),
(6, 4, 'Festival de Cine Independiente', '2024-09-20', '18:30:00', 'Centro de Cine', 'Festival que presenta películas independientes.', 'Directores y productores independientes'),
(7, 4, 'Maratón de Películas de Terror', '2024-10-31', '22:00:00', 'Cine Horror', 'Maratón de películas de terror para celebrar Halloween.', 'Películas de terror clásicas y modernas'),
(5, 4, 'Cine de Animación Infantil', '2024-11-15', '16:00:00', 'Cine Infantil', 'Proyección de películas de animación para niños.', 'Películas animadas para toda la familia');

-- Insertar eventos para la categoría 'Exposiciones' con empresas de venta de entradas
INSERT INTO Evento (ID_empresa, ID_categoria, Nombre, Fecha, Hora, Ubicacion, Descripcion, Artistas) VALUES
(6, 5, 'Exposición de Arte Moderno', '2024-08-05', '10:00:00', 'Museo de Arte', 'Exposición de arte moderno con artistas contemporáneos.', 'Artista A, Artista B'),
(7, 5, 'Feria de Fotografía', '2024-09-10', '11:00:00', 'Galería de Arte', 'Feria con exhibiciones de fotografía profesional.', 'Fotógrafo X, Fotógrafo Y'),
(5, 5, 'Muestra de Arte Textil', '2024-10-20', '12:00:00', 'Centro Cultural', 'Exposición de arte textil con obras innovadoras.', 'Artista Textil A'),
(6, 5, 'Salón del Diseño', '2024-11-05', '09:00:00', 'Espacio de Diseño', 'Evento de diseño con presentaciones y talleres.', 'Diseñador A, Diseñador B');


----TIPO DE ENTRADAS EVENTOS: 



-- Insertar tipos de entrada para los eventos de Conciertos
INSERT INTO Tipo_Entrada (ID_evento, Nombre, Precio, Capacidad) VALUES
(1, 'General', 50.00, 1000),   -- Concierto de Rock
(1, 'VIP ROCK', 100.00, 200),       -- Concierto de Rock
(2, 'General', 40.00, 800),    -- Festival de Jazz
(2, 'VIP', 90.00, 150),        -- Festival de Jazz
(3, 'General', 60.00, 500),    -- Concierto de Música Clásica
(3, 'VIP', 120.00, 100),       -- Concierto de Música Clásica
(4, 'General', 70.00, 1200),   -- Show de Música Electrónica
(4, 'VIP', 150.00, 250);       -- Show de Música Electrónica

-- Insertar tipos de entrada para los eventos de Teatro
INSERT INTO Tipo_Entrada (ID_evento, Nombre, Precio, Capacidad) VALUES
(5, 'General', 30.00, 600),    -- Obra de Teatro Clásica
(5, 'VIP', 70.00, 100),        -- Obra de Teatro Clásica
(6, 'General', 35.00, 500),    -- Comedia en Vivo
(6, 'VIP', 80.00, 80),         -- Comedia en Vivo
(7, 'General', 40.00, 450),    -- Teatro Experimental
(7, 'VIP', 90.00, 60),         -- Teatro Experimental
(8, 'General', 25.00, 550);    -- Danza Teatral

-- Insertar tipos de entrada para los eventos de Deportes
INSERT INTO Tipo_Entrada (ID_evento, Nombre, Precio, Capacidad) VALUES
(9, 'Norte', 20.00, 2000),   -- Partido de Fútbol
(9, 'Sur', 50.00, 500),        -- Partido de Fútbol
(9, 'Occidente', 50.00, 500),        -- Partido de Fútbol
(10, 'General', 25.00, 1500),  -- Maratón Ciudad de Lima
(10, 'Norte y Sur', 60.00, 300),       -- Maratón Ciudad de Lima
(11, 'General', 30.00, 800),   -- Competencia de Natación
(11, 'Occidente', 70.00, 150),       -- Competencia de Natación
(12, 'General', 20.00, 1000);  -- Torneo de Vóley

-- Insertar tipos de entrada para los eventos de Cine
INSERT INTO Tipo_Entrada (ID_evento, Nombre, Precio, Capacidad) VALUES
(13, 'General', 15.00, 700),   -- Estreno de Película A
(13, 'VIP', 35.00, 150),       -- Estreno de Película A
(14, 'General', 20.00, 600),   -- Festival de Cine Independiente
(14, 'VIP', 45.00, 120),       -- Festival de Cine Independiente
(15, 'General', 12.00, 800),   -- Maratón de Películas de Terror
(15, 'VIP', 30.00, 200),       -- Maratón de Películas de Terror
(16, 'General', 18.00, 500);   -- Cine de Animación Infantil

-- Insertar tipos de entrada para los eventos de Exposiciones
INSERT INTO Tipo_Entrada (ID_evento, Nombre, Precio, Capacidad) VALUES
(17, 'General', 25.00, 400),   -- Exposición de Arte Moderno
(17, 'VIP', 60.00, 80),        -- Exposición de Arte Moderno
(18, 'General', 30.00, 350),   -- Feria de Fotografía
(18, 'VIP', 70.00, 70),        -- Feria de Fotografía
(19, 'General', 20.00, 300),   -- Muestra de Arte Textil
(19, 'VIP', 50.00, 50),        -- Muestra de Arte Textil
(20, 'General', 15.00, 400);   -- Salón del Diseño

---- SELECT *FROM Empresa where Categoria='Venta de Entradas'  


--UBICACION ASIENTO DE EVENTOS Y ENTRADAS: 
-- Insertar ubicaciones para tipos de entrada del Concierto de Rock
INSERT INTO UbicacionEvento (ID_tipo_entrada, N_asiento) VALUES
(1, 'A1'), (1, 'A2'), (1, 'A3'), (1, 'A4'),
(2, 'B1'), (2, 'B2'), (2, 'B3'), (2, 'B4');

-- Insertar ubicaciones para tipos de entrada del Festival de Jazz
INSERT INTO UbicacionEvento (ID_tipo_entrada, N_asiento) VALUES
(3, 'C1'), (3, 'C2'), (3, 'C3'), (3, 'C4'),
(4, 'D1'), (4, 'D2'), (4, 'D3'), (4, 'D4');

-- Insertar ubicaciones para tipos de entrada del Concierto de Música Clásica
INSERT INTO UbicacionEvento (ID_tipo_entrada, N_asiento) VALUES
(5, 'E1'), (5, 'E2'), (5, 'E3'), (5, 'E4'),
(6, 'F1'), (6, 'F2'), (6, 'F3'), (6, 'F4');

-- Insertar ubicaciones para tipos de entrada del Show de Música Electrónica
INSERT INTO UbicacionEvento (ID_tipo_entrada, N_asiento) VALUES
(7, 'G1'), (7, 'G2'), (7, 'G3'), (7, 'G4'),
(8, 'H1'), (8, 'H2'), (8, 'H3'), (8, 'H4');

-- Insertar ubicaciones para tipos de entrada del Obra de Teatro Clásica
INSERT INTO UbicacionEvento (ID_tipo_entrada, N_asiento) VALUES
(9, 'I1'), (9, 'I2'), (9, 'I3'), (9, 'I4'),
(10, 'J1'), (10, 'J2'), (10, 'J3'), (10, 'J4');

-- Insertar ubicaciones para tipos de entrada del Comedia en Vivo
INSERT INTO UbicacionEvento (ID_tipo_entrada, N_asiento) VALUES
(11, 'K1'), (11, 'K2'), (11, 'K3'), (11, 'K4'),
(12, 'L1'), (12, 'L2'), (12, 'L3'), (12, 'L4');

-- Insertar ubicaciones para tipos de entrada del Teatro Experimental
INSERT INTO UbicacionEvento (ID_tipo_entrada, N_asiento) VALUES
(13, 'M1'), (13, 'M2'), (13, 'M3'), (13, 'M4'),
(14, 'N1'), (14, 'N2'), (14, 'N3'), (14, 'N4');

-- Insertar ubicaciones para tipos de entrada del Danza Teatral
INSERT INTO UbicacionEvento (ID_tipo_entrada, N_asiento) VALUES
(15, 'O1'), (15, 'O2'), (15, 'O3'), (15, 'O4');

-- Insertar ubicaciones para tipos de entrada del Partido de Fútbol
INSERT INTO UbicacionEvento (ID_tipo_entrada, N_asiento) VALUES
(16, 'P1'), (16, 'P2'), (16, 'P3'), (16, 'P4'),
(17, 'Q1'), (17, 'Q2'), (17, 'Q3'), (17, 'Q4'),
(18, 'R1'), (18, 'R2'), (18, 'R3'), (18, 'R4');

-- Insertar ubicaciones para tipos de entrada del Maratón Ciudad de Lima
INSERT INTO UbicacionEvento (ID_tipo_entrada, N_asiento) VALUES
(19, 'S1'), (19, 'S2'), (19, 'S3'), (19, 'S4'),
(20, 'T1'), (20, 'T2'), (20, 'T3'), (20, 'T4');

-- Insertar ubicaciones para tipos de entrada del Competencia de Natación
INSERT INTO UbicacionEvento (ID_tipo_entrada, N_asiento) VALUES
(21, 'U1'), (21, 'U2'), (21, 'U3'), (21, 'U4'),
(22, 'V1'), (22, 'V2'), (22, 'V3'), (22, 'V4');

-- Insertar ubicaciones para tipos de entrada del Torneo de Vóley
INSERT INTO UbicacionEvento (ID_tipo_entrada, N_asiento) VALUES
(23, 'W1'), (23, 'W2'), (23, 'W3'), (23, 'W4');

-- Insertar ubicaciones para tipos de entrada del Estreno de Película A
INSERT INTO UbicacionEvento (ID_tipo_entrada, N_asiento) VALUES
(24, 'X1'), (24, 'X2'), (24, 'X3'), (24, 'X4'),
(25, 'Y1'), (25, 'Y2'), (25, 'Y3'), (25, 'Y4');

-- Insertar ubicaciones para tipos de entrada del Festival de Cine Independiente
INSERT INTO UbicacionEvento (ID_tipo_entrada, N_asiento) VALUES
(26, 'Z1'), (26, 'Z2'), (26, 'Z3'), (26, 'Z4'),
(27, 'AA1'), (27, 'AA2'), (27, 'AA3'), (27, 'AA4');

-- Insertar ubicaciones para tipos de entrada del Maratón de Películas de Terror
INSERT INTO UbicacionEvento (ID_tipo_entrada, N_asiento) VALUES
(28, 'BB1'), (28, 'BB2'), (28, 'BB3'), (28, 'BB4'),
(29, 'CC1'), (29, 'CC2'), (29, 'CC3'), (29, 'CC4');

-- Insertar ubicaciones para tipos de entrada del Cine de Animación Infantil
INSERT INTO UbicacionEvento (ID_tipo_entrada, N_asiento) VALUES
(30, 'DD1'), (30, 'DD2'), (30, 'DD3'), (30, 'DD4');

-- Insertar ubicaciones para tipos de entrada del Exposición de Arte Moderno
INSERT INTO UbicacionEvento (ID_tipo_entrada, N_asiento) VALUES
(31, 'EE1'), (31, 'EE2'), (31, 'EE3'), (31, 'EE4'),
(32, 'FF1'), (32, 'FF2'), (32, 'FF3'), (32, 'FF4');

-- Insertar ubicaciones para tipos de entrada del Feria de Fotografía
INSERT INTO UbicacionEvento (ID_tipo_entrada, N_asiento) VALUES
(33, 'GG1'), (33, 'GG2'), (33, 'GG3'), (33, 'GG4'),
(34, 'HH1'), (34, 'HH2'), (34, 'HH3'), (34, 'HH4');

-- Insertar ubicaciones para tipos de entrada del Muestra de Arte Textil
INSERT INTO UbicacionEvento (ID_tipo_entrada, N_asiento) VALUES
(35, 'II1'), (35, 'II2'), (35, 'II3'), (35, 'II4'),
(36, 'JJ1'), (36, 'JJ2'), (36, 'JJ3'), (36, 'JJ4');

-- Insertar ubicaciones para tipos de entrada del Salón del Diseño
INSERT INTO UbicacionEvento (ID_tipo_entrada, N_asiento) VALUES
(37, 'KK1'), (37, 'KK2'), (37, 'KK3'), (37, 'KK4');


----

--select*from UbicacionEvento