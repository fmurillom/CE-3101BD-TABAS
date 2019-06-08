----------------------------------------------------------------------------------------------------------------------------
--Script database tabas
----------------------------------------------------------------------------------------------------------------------------
--create database tabas;
--drop database tabas;
--connect tabas;
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------


----------------------------------------------------------------------------------------------------------------------------
--Relations
----------------------------------------------------------------------------------------------------------------------------
create table Roles
( 
   idRol int primary key
  ,rol varchar(13) unique not null
);
--drop table Roles
--select * from Roles

----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------


create Table Trabajadores
(
   username varchar(60) primary key
  ,pw bytea not null
  ,nombre varchar(60)  not null
  ,apellido1 varchar(60)
  ,apellido2 varchar(60)
  ,cedula int not null
  ,rol int not null
  
  ,foreign key(rol) references Roles(idRol)
);
/*
drop table Trabajadores
delete from Trabajadores;
select * from Trabajadores;

Ale :D, [04.06.19 21:05]
select * from procGetTrabajador('JP');
delete from Trabajadores where username = 'RM';
select * from Trabajadores where rol = 2
select * from procGetPasswordTrabajador('RM');
*/
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------


create Table Marcas
(
   idMarca int not null primary key
  ,marca varchar(40) not null
);
/*
drop table Marcas;
delete from Marcas;
select * from Marcas;
*/
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------

create Table BagCarts
(
   idBagCart int not null primary key
  ,marca int not null
  ,modelo int not null --(anno)
  ,sello varchar(10) default null
  
  ,foreign key(marca) references Marcas(idMarca)
);
/*
drop table BagCarts;
delete from BagCarts;
select * from BagCarts;
select idBagCart,M.marca,sello from BagCarts as B join Marcas as M on B.marca = M.idMarca;
select count(idBagCart) from BagCarts;
*/
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------
create Table Estados
(
   idEstado int primary key
  ,estado varchar(60) not null
);
/*
drop table Estados;
delete from Estados;
select * from Estados;
*/
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------


create Table Maletas
(
   idMaleta int not null
  ,username varchar(60) not null
  ,color varchar(15) not null--RGB
  ,peso int not null--kg
  ,costo int not null--G
  
  ,primary key(idMaleta, username)

--,foreign key(username) references Usuarios(userName)
  --Debe hacerse la restriccion de llave foranea manualmente!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
);
/*
drop table Maletas;
delete from Maletas;
select * from Maletas;
*/
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------

create Table MaletasBagCarts
(
   idMaleta int not null
  ,username varchar(60) not null
  ,trabajadorRX varchar(60) default null
  ,bagCart int default null
  ,estado int default 0 not null
  ,comentario text default null
  
  ,primary key(idMaleta, username)
  ,foreign key(idMaleta,username) references Maletas(idMaleta,username)
  ,foreign key(bagCart) references BagCarts(idBagCart)
  ,foreign key(trabajadorRX) references Trabajadores(username)
  ,foreign key(estado) references Estados(idEstado)  
);
/*
drop table MaletasBagCarts;
delete from MaletasBagCarts;
select * from MaletasBagCarts;
*/
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------




create table Modelos
(  
   idmodelo int primary key
  ,modelo varchar(60)    
  ,cantidadBodegas int not null
);
/*
drop table Modelos cascade;
delete from Modelos;
select * from Modelos;
*/
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------


create table Aviones
(  
   idAvion int primary key
  ,modelo int not null
  
  ,foreign key(modelo) references Modelos(idModelo)
);
/*
drop table Aviones;
delete from Aviones;
select * from Aviones;

select count(*) from Aviones;
*/
--varios bagCar por Vuelo!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
--cada vez que se llena el bagCar, se pone un sello alfanumerico de varchar(10)
--REPORTE: maletas por cliente
--REPORTE: Conciliacion de Maletas
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------




create table Bodegas
(  
   avion int
  ,idBodega int
  ,capacidad int not null
  
  ,primary key(avion,idBodega)
  ,foreign key(avion) references Aviones(idAvion)
);
/*
drop table Bodegas;
delete from Bodegas;
select * from Bodegas;

select 
  sum(capacidad)
from Bodegas as B join Modelos as M on B.modelo = M.idModelo
where M.modelo = 'Northrop Grumman B-2 Spirit';

select 
  count(idBodega)
from Bodegas as B join Aviones as A on B.avion = A.idAvion
where avion = 0
*/
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------

create Table MaletasAviones
(
   idMaleta int not null
  ,username varchar(60) not null
  
  ,avion int default null
  ,bodega int default null
  ,trabajadorSc varchar(60) default null
  
  ,primary key(idMaleta, username)
  ,foreign key(idMaleta,username) references Maletas(idMaleta,username)
  
  ,foreign key(avion) references Aviones(idAvion)
  ,foreign key(bodega,avion) references Bodegas(idBodega,avion)
  ,foreign key(trabajadorSc) references Trabajadores(username)
);
/*
drop table MaletasAviones;
delete from MaletasAviones;
select * from MaletasAviones;
*/
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------


create table Vuelos
(
   id int primary key
  ,avion int not null
  ,fecha timestamp not null
  ,abierto boolean default true
  ,bagCart int default null

  ,foreign key(avion) references Aviones(idAvion)
  ,foreign key(bagCart) references BagCarts(idBagCart)
);
/*
drop table Vuelos;
delete from Vuelos;
select * from Vuelos;

select count(*) from Vuelos;
*/
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------



----------------------------------------------------------------------------------------------------------------------------
--Procedures
----------------------------------------------------------------------------------------------------------------------------

CREATE EXTENSION pgcrypto;


create or replace function procRegistrarTrabajador
(
   param_username varchar(60)
  ,param_pw varchar(60)
  ,param_nombre varchar(40)
  ,param_apellido1 varchar(40)
  ,param_apellido2 varchar(40)  
  ,param_cedula int
  ,param_rol int
)
returns text
AS
$$
begin  
  insert into Trabajadores(username,pw,nombre,apellido1,apellido2,cedula,rol)
    values
    (
       param_username
      ,encrypt(cast(param_pw as bytea) ,'smas' ,'aes')
      ,param_nombre,param_apellido1,param_apellido2,param_cedula,param_rol
    );
  return 'Success';
end;
$$
LANGUAGE plpgsql;
--drop function procRegistrarTrabajador;
--DROP FUNCTION procregistrartrabajador(character varying,character varying,character varying,character varying,character varying,integer,integer)
--select procRegistrarTrabajador('MajinLoop','207680955','Alejandro','Campos','Abarca',207680955,0);
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------


create or replace function procGetPasswordTrabajador
(
    param_username varchar(60)
  ,OUT password varchar(60)
)
AS
$$
begin
  password = (SELECT convert_from(decrypt((SELECT pw FROM Trabajadores WHERE username = param_username),'smas','aes'), 'SQL_ASCII')FROM Trabajadores WHERE username = param_username);
end;
$$
LANGUAGE plpgsql;
--drop function procGetPasswordTrabajador
--select * from procGetPasswordTrabajador('Nines')
/*
select convert_from(decrypt('\x34591627f9c8eae417fc7cbbf458592c','1234','aes'),'SQL_ASCII');
  convert_from
*/  
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------

create or replace function procGetTrabajador
(
   param_username varchar(60)  
)
returns
table
(   username varchar(60)
  ,pw varchar(60)
  ,nombre varchar(60)
  ,apellido1 varchar(60)
  ,apellido2 varchar(60)
  ,cedula int
   ,rol int
)
AS
'
begin
return query
(
  select
     Trabajadores.username
    ,(select procGetPasswordTrabajador(param_username))
    ,Trabajadores.nombre
    ,Trabajadores.apellido1
    ,Trabajadores.apellido2
    ,Trabajadores.cedula
    ,Trabajadores.rol
  from Trabajadores where Trabajadores.username = param_username
);
end;
'
LANGUAGE plpgsql;
--drop function procGetTrabajador
--select * from procGetTrabajador('MajinLoop')
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------
  

create or replace function proc_getCantidadMaximaDeBodegasPorAvion
(
   param_idAvion int
)
returns int
AS
'
begin
return
(
  select
    M.cantidadBodegas
  from Modelos as M join Aviones as A on M.idModelo = A.modelo  
  where A.idAvion = param_idAvion
);
end;
'
LANGUAGE plpgsql;
--drop function proc_getCantidadMaximaDeBodegasPorAvion;
--select * from proc_getCantidadMaximaDeBodegasPorAvion(0);
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------

CREATE FUNCTION func_x()
RETURNS TRIGGER
AS
$trgg_setSello$
  BEGIN  
    IF(TG_OP = 'UPDATE')
    THEN
      if((select sello from BagCarts where idBagCart = NEW.bagCart) is null and (select abierto from Vuelos where id = NEW.id) = true)
      then            
        update BagCarts set
          sello = (select random_string(10))
        where idBagCart = NEW.bagCart
        ;
      end if;
      return NULL;
    END IF;
    RETURN NULL;  
  --return NEW;
  END;
$trgg_setSello$
LANGUAGE plpgsql;
--drop function func_x cascade;
--select * from func_cCB(0);

CREATE TRIGGER trgg_setSello
after
update
ON Vuelos
FOR EACH ROW
EXECUTE PROCEDURE func_x();
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------


CREATE FUNCTION proc_insertBodega
(
   param_avion int
  ,param_idBodega int
  ,param_capacidad int
)
RETURNS text
as
$$
BEGIN
  IF((select count(idBodega) from Bodegas where avion = param_avion) <= (proc_getCantidadMaximaDeBodegasPorAvion(param_avion)))
  THEN
    insert into Bodegas(avion,idBodega,capacidad) values(param_avion,param_idBodega,param_capacidad);
    return 'Success';
  else
    return 'No se pueden asignar mas bodegas a ese avion.';
  END IF;  
END;
$$
LANGUAGE plpgsql;
--drop function proc_insertBodega;
--select * from proc_insertBodega(0);
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------

  
CREATE FUNCTION proc_cerrarVuelo(param_vuelo int)
RETURNS text
as
$$
BEGIN
  --if((select bagCart from Vuelos where id = param_vuelo) is not null)
  --then
    update Vuelos set abierto = false where id = param_vuelo;
    return CONCAT('Vuelo: ',param_vuelo,' cerrado.');  
  --else
    --return CONCAT('El vuelo: ',param_vuelo,' no tenia un BagCart asignado');
  --end if;
END;
$$
LANGUAGE plpgsql;
--drop function proc_cerrarVuelo;
--select * from proc_cerrarVuelo(0);
--update Vuelos set abierto = true where id = 0;
--select * from Vuelos;
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------

CREATE FUNCTION func_y()
RETURNS TRIGGER
AS
$trgg_quitarSello$
  BEGIN  
    IF(TG_OP = 'UPDATE')
    THEN
      if((select abierto from Vuelos where id = NEW.id) = false)
      then            
        update BagCarts set
          sello = null
        where idBagCart = NEW.bagCart
        ;
      end if;
      return NULL;
    END IF;
    RETURN NULL;  
  --return NEW;
  END;
$trgg_quitarSello$
LANGUAGE plpgsql;
--drop function func_y cascade;

CREATE TRIGGER trgg_quitarSello
after
update
ON Vuelos
FOR EACH ROW
EXECUTE PROCEDURE func_y();
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------

CREATE FUNCTION proc_asignarBagCartVuelo
(       
   param_bagCart int
  ,param_vuelo int
)
RETURNS text
as
$$
BEGIN
  if(exists (select id from Vuelos where id = param_vuelo))--Si existe el vuelo
  then
    if((select abierto from Vuelos where id = param_vuelo) = true)--Si el vuelo esta abierto
    then
      if((select bagCart from Vuelos where id = param_vuelo) is null)--Si el vuelo aun no tiene bagCart asignado
      then
        if((select sello from BagCarts where idBagCart = param_bagCart) is null)--Si el bagCart no tiene sello aun
        then
          update Vuelos set bagCart = param_bagCart where id = param_vuelo;
          --update BagCarts set sello = (select random_string(10));
          return 'Success';
        else
          return 'El bagCart ya tiene sello';
        end if;
      else
        return 'El Vuelo ya tiene BagCart asignado';
      end if;
    else
      return 'El vuelo esta cerrado';
    end if;  
  else
    return 'No existe el vuelo';
  end if;
END;
$$
LANGUAGE plpgsql;
--drop function proc_asignarBagCartVuelo;
--select * from proc_asignarBagCartVuelo(0,0);
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------

  
CREATE FUNCTION proc_asignarMaletaBagCart
(
   param_idMaleta int
  ,param_username varchar(60)
  ,param_trabajadorRX varchar(60)
  ,param_estado int
  ,param_comentario text
  ,param_bagCart int  
)
RETURNS text
as
$$
BEGIN
  insert into MaletasBagCarts(idMaleta,username,trabajadorRX,estado,comentario,bagCart) values(param_idMaleta,param_username,param_trabajadorRX,param_estado,param_comentario,param_bagCart);
  return 'Success';
END;
$$
LANGUAGE plpgsql;
--drop function proc_asignarMaletaBagCart;
--select * from proc_asignarMaletaBagCart;
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------

CREATE FUNCTION proc_asignarMaletaAvion
(
   param_idMaleta int
  ,param_username varchar(60)
  ,param_avion int
  ,param_bodega int
  ,param_trabajadorSc varchar(60)
)
RETURNS text
as
$$
BEGIN
  if((select estado from MaletasBagCarts where idMaleta = param_idMaleta and username = param_username) = 1)--Si es aceptada
  then
    if((select rol from Trabajadores where username = param_trabajadorSc) = 0)--Si el trabajador efectivamente es de tipo Scanner
    then
      if(exists (select M.bagCart from MaletasBagCarts as M join Vuelos as V on M.bagCart = V.bagCart where idMaleta = 0 and username = 'Koppa'))--Si el BagCart esta asignado a un vuelo
      THEN
        insert into MaletasAviones(idMaleta,username,avion,bodega,trabajadorSc) values(param_idMaleta,param_username,param_avion,param_bodega,param_trabajadorSc);
        return 'Success';
      else
        return 'El bagCart no esta asigando a un Vuelo';
      END IF;
    else
      return 'El trabajador no es Scanner.';
    end if;
  else
    return 'No es una maleta aceptada';
  end if;
END;
$$
LANGUAGE plpgsql;
--drop function proc_asignarMaletaAvion;
--select * from proc_asignarMaletaAvion;
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------

Create or replace function random_string(length integer) returns text as
$$
declare
  chars text[] := '{0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z}';
  result text := '';
  i integer := 0;
begin
  if length < 0 then
    raise exception 'Given length cannot be less than 0';
  end if;
  for i in 1..length loop
    result := result || chars[1+random()*(array_length(chars, 1)-1)];
  end loop;
  return result;
end;
$$ language plpgsql;
/*
drop table aux1;
delete from aux1;
select * from aux1;
*/
----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------