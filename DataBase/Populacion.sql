--**************************************************************************************************************************
insert  into Roles(idRol,rol) values(0,'Scanner');
insert  into Roles(idRol,rol) values(1,'Embarcador');
insert  into Roles(idRol,rol) values(2,'Administrador');
insert  into Roles(idRol,rol) values(3,'Recepcionista');
--**************************************************************************************************************************
--**************************************************************************************************************************
--Scanner(0)
select procRegistrarTrabajador('MajinLoop','207680955','Alejandro','Campos','Abarca',207680955,0);
select procRegistrarTrabajador('Nines','2B','9','S',null,999999999,0);
select procRegistrarTrabajador('4S','A2','4','S',null,444444444,0);
select procRegistrarTrabajador('JCB','31','Juan','Carlos','Bodoque',207680956,0);
select procRegistrarTrabajador('TT','Minutos','Tulio','Trivinno',null,207680957,0);
select procRegistrarTrabajador('panchito','207680955','Pancho','Rodriguez','Gonzales',207680955,0);
----------------------------------------------------------------------------------------------------------------------------
--Embarcador(1)
select procRegistrarTrabajador('RM','Cause u got that','Ricardo','Milos',null,207680958,1);
select procRegistrarTrabajador('JP','Tu profe de confianza :v','Julio','Profe',null,207680959,1);
select procRegistrarTrabajador('CARL','alaverg','Carlos','ALV',null,207680960,1);
select procRegistrarTrabajador('Simeonics','gta','Simeon',null,null,207680961,1);
select procRegistrarTrabajador('Cosmo','password','Cosmo',null,null,207680962,1);
----------------------------------------------------------------------------------------------------------------------------
--Administrador(2)
select procRegistrarTrabajador('Nombre de usuario','palabra de pasar','Yo','Soy','Administradora',207680963,2);
select procRegistrarTrabajador('White','For the glory of Mankind','La','Comandante',null,207680964,2);
select procRegistrarTrabajador('Potto','A future is not given to you.','Pod','042',null,207680965,2);
select procRegistrarTrabajador('GendoIkari','Yui','Gendo','Ikari','Rokubungi',207680966,2);
select procRegistrarTrabajador('EvilDoge','Saludos Peludos','Evil','Doge',null,207680967,2);
----------------------------------------------------------------------------------------------------------------------------
--Recepcionista(3)
select procRegistrarTrabajador('Sunshine','Weiss, u dumbass!','Kaine',null,null,207680968,3);
select procRegistrarTrabajador('Rei5','Gendo','Rei','Ayanami',null,207680969,3);
select procRegistrarTrabajador('Rata','Pika','Pikachu','Pika','Shu',207680970,3);
select procRegistrarTrabajador('MK','Subete al puto robot Shinji','Misato','Katsuragi',null,207680971,3);
select procRegistrarTrabajador('Armor','For the glory of Marley','Reiner','Brown',null,207680972,3);
--**************************************************************************************************************************

--**************************************************************************************************************************
insert into Marcas(idMarca,marca) values(0,'Forudo');
insert into Marcas(idMarca,marca) values(1,'Mazuda');
insert into Marcas(idMarca,marca) values(2,'Citoruen');
insert into Marcas(idMarca,marca) values(3,'Audista');
insert into Marcas(idMarca,marca) values(4,'Musutangu');
insert into Marcas(idMarca,marca) values(5,'Be eme doble uwu');
--**************************************************************************************************************************
--**************************************************************************************************************************
insert into BagCarts(idBagCart,marca,modelo) values(0,0,2000);
insert into BagCarts(idBagCart,marca,modelo) values(1,0,2000);
insert into BagCarts(idBagCart,marca,modelo) values(2,2,2001);
insert into BagCarts(idBagCart,marca,modelo) values(3,1,2001);
insert into BagCarts(idBagCart,marca,modelo) values(4,1,2002);

insert into BagCarts(idBagCart,marca,modelo) values(5,3,2002);
insert into BagCarts(idBagCart,marca,modelo) values(6,3,2003);
insert into BagCarts(idBagCart,marca,modelo) values(7,2,2003);
insert into BagCarts(idBagCart,marca,modelo) values(8,4,2004);
insert into BagCarts(idBagCart,marca,modelo) values(9,4,2004);

insert into BagCarts(idBagCart,marca,modelo) values(10,5,2018);
insert into BagCarts(idBagCart,marca,modelo) values(11,5,2018);
insert into BagCarts(idBagCart,marca,modelo) values(12,5,2018);
insert into BagCarts(idBagCart,marca,modelo) values(13,5,2018);
insert into BagCarts(idBagCart,marca,modelo) values(14,5,1600);
--**************************************************************************************************************************
--**************************************************************************************************************************
insert into Estados(idEstado,estado) values(0,'Sin Revisar');
insert into Estados(idEstado,estado) values(1,'Aprovada');
insert into Estados(idEstado,estado) values(2,'Rechazada');
--**************************************************************************************************************************
--**************************************************************************************************************************
insert into Maletas(idMaleta,username,color,peso,costo) values(0,'Koppa','000111222',5,2500);
--**************************************************************************************************************************

--**************************************************************************************************************************
select proc_asignarMaletaBagCart(0,'Koppa','MajinLoop',1,null,0);
--**************************************************************************************************************************
--**************************************************************************************************************************
/*
proc_asignarMaletaAvion
(
   param_idMaleta int
  ,param_username varchar(60)
  ,param_avion int
  ,param_bodega int
  ,param_trabajadorSc varchar(60)
)
*/
select proc_asignarMaletaAvion(0,'Koppa',0,0,'Nines');
--**************************************************************************************************************************

--**************************************************************************************************************************
insert into Modelos(idModelo,modelo,cantidadBodegas) values(0,'Boing 747',4);
insert into Modelos(idModelo,modelo,cantidadBodegas) values(1,'Northrop Grumman B-2 Spirit',1);
insert into Modelos(idModelo,modelo,cantidadBodegas) values(2,'F-35',2);
--**************************************************************************************************************************
--**************************************************************************************************************************
insert into Aviones(idAvion,modelo) values(0,0);
insert into Aviones(idAvion,modelo) values(1,0);
insert into Aviones(idAvion,modelo) values(2,0);
insert into Aviones(idAvion,modelo) values(3,0);
insert into Aviones(idAvion,modelo) values(4,0);

insert into Aviones(idAvion,modelo) values(5,1);
insert into Aviones(idAvion,modelo) values(6,1);
insert into Aviones(idAvion,modelo) values(7,1);
insert into Aviones(idAvion,modelo) values(8,1);
insert into Aviones(idAvion,modelo) values(9,1);

insert into Aviones(idAvion,modelo) values(10,2);
insert into Aviones(idAvion,modelo) values(11,2);
insert into Aviones(idAvion,modelo) values(12,2);
insert into Aviones(idAvion,modelo) values(13,2);
insert into Aviones(idAvion,modelo) values(14,2);
--**************************************************************************************************************************
--**************************************************************************************************************************
select proc_insertBodega(0,0,80000);
select proc_insertBodega(0,1,80000);
select proc_insertBodega(0,2,80000);
select proc_insertBodega(0,3,80000);
select proc_insertBodega(0,4,80000);

select proc_insertBodega(1,0,5000);

select proc_insertBodega(2,0,2500);
--**************************************************************************************************************************
--**************************************************************************************************************************
insert into Vuelos(id,avion,fecha) values(0,0,'2019-11-15 13:00:00');
insert into Vuelos(id,avion,fecha) values(1,1,'2019-11-15 14:00:00');
insert into Vuelos(id,avion,fecha) values(2,2,'2019-11-15 15:00:00');
insert into Vuelos(id,avion,fecha) values(3,3,'2019-11-15 16:00:00');
insert into Vuelos(id,avion,fecha) values(4,4,'2019-11-15 17:00:00');
insert into Vuelos(id,avion,fecha) values(5,5,'2019-11-15 18:00:00');
insert into Vuelos(id,avion,fecha) values(6,6,'2019-11-15 19:00:00');
insert into Vuelos(id,avion,fecha) values(7,7,'2019-11-15 20:00:00');
insert into Vuelos(id,avion,fecha) values(8,8,'2019-11-15 21:00:00');
insert into Vuelos(id,avion,fecha) values(9,9,'2019-11-15 22:00:00');

insert into Vuelos(id,avion,fecha) values(10,10,'2019-11-20 13:00:00');
insert into Vuelos(id,avion,fecha) values(11,11,'2019-11-20 14:00:00');
insert into Vuelos(id,avion,fecha) values(12,12,'2019-11-20 15:00:00');
insert into Vuelos(id,avion,fecha) values(13,13,'2019-11-20 16:00:00');
insert into Vuelos(id,avion,fecha) values(14,14,'2019-11-20 17:00:00');
insert into Vuelos(id,avion,fecha) values(15,0,'2019-11-20 18:00:00');
insert into Vuelos(id,avion,fecha) values(16,1,'2019-11-20 19:00:00');
insert into Vuelos(id,avion,fecha) values(17,2,'2019-11-20 20:00:00');
insert into Vuelos(id,avion,fecha) values(18,3,'2019-11-20 21:00:00');
insert into Vuelos(id,avion,fecha) values(19,4,'2019-11-20 22:00:00');

insert into Vuelos(id,avion,fecha) values(20,5,'2019-11-21 13:00:00');
insert into Vuelos(id,avion,fecha) values(21,6,'2019-11-21 14:00:00');
insert into Vuelos(id,avion,fecha) values(22,7,'2019-11-21 15:00:00');
insert into Vuelos(id,avion,fecha) values(23,8,'2019-11-21 16:00:00');
insert into Vuelos(id,avion,fecha) values(24,9,'2019-11-21 17:00:00');
insert into Vuelos(id,avion,fecha) values(25,10,'2019-11-21 18:00:00');
insert into Vuelos(id,avion,fecha) values(26,11,'2019-11-21 19:00:00');
insert into Vuelos(id,avion,fecha) values(27,12,'2019-11-21 20:00:00');
insert into Vuelos(id,avion,fecha) values(28,13,'2019-11-21 21:00:00');
insert into Vuelos(id,avion,fecha) values(29,14,'2019-11-21 22:00:00');

insert into Vuelos(id,avion,fecha) values(30,0,'2019-11-22 13:00:00');
insert into Vuelos(id,avion,fecha) values(31,1,'2019-11-22 14:00:00');
insert into Vuelos(id,avion,fecha) values(32,2,'2019-11-22 15:00:00');
insert into Vuelos(id,avion,fecha) values(33,3,'2019-11-22 16:00:00');
insert into Vuelos(id,avion,fecha) values(34,4,'2019-11-22 17:00:00');
insert into Vuelos(id,avion,fecha) values(35,5,'2019-11-22 18:00:00');
insert into Vuelos(id,avion,fecha) values(36,6,'2019-11-22 19:00:00');
insert into Vuelos(id,avion,fecha) values(37,7,'2019-11-22 20:00:00');
insert into Vuelos(id,avion,fecha) values(38,8,'2019-11-22 21:00:00');
insert into Vuelos(id,avion,fecha) values(39,9,'2019-11-22 22:00:00');

insert into Vuelos(id,avion,fecha) values(40,10,'2019-11-23 13:00:00');
insert into Vuelos(id,avion,fecha) values(41,11,'2019-11-23 14:00:00');
insert into Vuelos(id,avion,fecha) values(42,12,'2019-11-23 15:00:00');
insert into Vuelos(id,avion,fecha) values(43,13,'2019-11-23 16:00:00');
insert into Vuelos(id,avion,fecha) values(44,14,'2019-11-23 17:00:00');
insert into Vuelos(id,avion,fecha) values(45,0,'2019-11-23 18:00:00');
insert into Vuelos(id,avion,fecha) values(46,1,'2019-11-23 19:00:00');
insert into Vuelos(id,avion,fecha) values(47,2,'2019-11-23 20:00:00');
insert into Vuelos(id,avion,fecha) values(48,3,'2019-11-23 21:00:00');
insert into Vuelos(id,avion,fecha) values(49,4,'2019-11-23 22:00:00');

/*
select * from Vuelos where id = 0;
select * from Vuelos where id = 1;

--update Vuelos set bagCart = null where id = 0;
--update Vuelos set bagCart = null where id = 1;

select proc_asignarBagCartVuelo(0,0);
select proc_asignarBagCartVuelo(1,0);

select proc_asignarBagCartVuelo(3,0);

select * from BagCarts where idBagCart = 0;
select * from BagCarts where idBagCart = 1;
--update BagCarts set sello = null where idBagCart = 0;
--update BagCarts set sello = null where idBagCart = 1;

select proc_cerrarVuelo(1);
*/
--**************************************************************************************************************************