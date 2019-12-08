--JUAN DANIEL TORRES MORENO
--Tecnologico Nacional de México en Roque

--MYSQL

create database prueba;
use prueba;
Create table productos(
id_producto int,
nombre VARCHAR(130),
precio VARCHAR(6),
CONSTRAINT PRIMARY KEY (id_producto)
);