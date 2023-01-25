--------------------------------------------------------
-- Archivo creado  - martes-enero-24-2023   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Sequence SECUENCIA_LIBRO
--------------------------------------------------------

   CREATE SEQUENCE  "IVAN"."SECUENCIA_LIBRO"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 21 CACHE 20 NOORDER  NOCYCLE  NOKEEP  NOSCALE  GLOBAL ;
--------------------------------------------------------
--  DDL for Sequence SECUENCIA_PRESTAMO
--------------------------------------------------------

   CREATE SEQUENCE  "IVAN"."SECUENCIA_PRESTAMO"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 41 CACHE 20 NOORDER  NOCYCLE  NOKEEP  NOSCALE  GLOBAL ;

--------------------------------------------------------
--  DDL for Table LIBRO
--------------------------------------------------------

  CREATE TABLE "IVAN"."LIBRO" 
   (	"ID" NUMBER, 
	"NOMBRE" VARCHAR2(100 BYTE), 
	"CATEGORIA" VARCHAR2(100 BYTE), 
	"AUTOR" VARCHAR2(100 BYTE), 
	"PAIS" VARCHAR2(100 BYTE), 
	"FECHA_PUBLICACION" VARCHAR2(10 BYTE), 
	"EDITORIAL" VARCHAR2(100 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table PRESTAMO
--------------------------------------------------------

  CREATE TABLE "IVAN"."PRESTAMO" 
   (	"ID" NUMBER, 
	"ID_LIBRO" NUMBER, 
	"FECHA_PRESTAMO" DATE, 
	"DNI_USUARIO" VARCHAR2(8 BYTE), 
	"TIPO_LECTURA" NUMBER, 
	"FECHA_DEVOLUCION" DATE
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table USUARIO
--------------------------------------------------------

  CREATE TABLE "IVAN"."USUARIO" 
   (	"DNI" VARCHAR2(8 BYTE), 
	"NOMBRES" VARCHAR2(50 BYTE), 
	"APELLIDOS" VARCHAR2(100 BYTE), 
	"EMAIL" VARCHAR2(100 BYTE), 
	"TELEFONO" VARCHAR2(15 BYTE), 
	"ESTADO" NUMBER(1,0), 
	"TIPO" NUMBER(1,0)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
REM INSERTING into IVAN.LIBRO
SET DEFINE OFF;
Insert into IVAN.LIBRO (ID,NOMBRE,CATEGORIA,AUTOR,PAIS,FECHA_PUBLICACION,EDITORIAL) values ('1','Poemas Humanos IV','Poesia','Cesar Vallejo','Per�','01/18/2023','Navarrete');
Insert into IVAN.LIBRO (ID,NOMBRE,CATEGORIA,AUTOR,PAIS,FECHA_PUBLICACION,EDITORIAL) values ('2','La ciudad y los perros','Poesia','Mario Vargas Llosa','Per�','01/10/2023','Navarrete');
Insert into IVAN.LIBRO (ID,NOMBRE,CATEGORIA,AUTOR,PAIS,FECHA_PUBLICACION,EDITORIAL) values ('3','El exito es una decisi�n','Liderazgo','David Fitchman','Per�','01/13/2023','El Comercio');
Insert into IVAN.LIBRO (ID,NOMBRE,CATEGORIA,AUTOR,PAIS,FECHA_PUBLICACION,EDITORIAL) values ('4','Mi fiesta es m�a','Liderazgo','Wendy','Per�','01/19/2023','Comercio');
Insert into IVAN.LIBRO (ID,NOMBRE,CATEGORIA,AUTOR,PAIS,FECHA_PUBLICACION,EDITORIAL) values ('6','Cecretos de Luz','Liderazgo','Rosa Mar�a Cifuentes','Per�','06/18/2020','Comercio');

REM INSERTING into IVAN.PRESTAMO
SET DEFINE OFF;
Insert into IVAN.PRESTAMO (ID,ID_LIBRO,FECHA_PRESTAMO,DNI_USUARIO,TIPO_LECTURA,FECHA_DEVOLUCION) values ('31','4',to_date('24/01/23','DD/MM/RR'),'14714714','2',to_date('24/01/23','DD/MM/RR'));
Insert into IVAN.PRESTAMO (ID,ID_LIBRO,FECHA_PRESTAMO,DNI_USUARIO,TIPO_LECTURA,FECHA_DEVOLUCION) values ('29','1',to_date('24/01/23','DD/MM/RR'),'47425815','1',to_date('24/01/23','DD/MM/RR'));
Insert into IVAN.PRESTAMO (ID,ID_LIBRO,FECHA_PRESTAMO,DNI_USUARIO,TIPO_LECTURA,FECHA_DEVOLUCION) values ('30','2',to_date('24/01/23','DD/MM/RR'),'12121212','2',to_date('24/01/23','DD/MM/RR'));
REM INSERTING into IVAN.USUARIO
SET DEFINE OFF;
Insert into IVAN.USUARIO (DNI,NOMBRES,APELLIDOS,EMAIL,TELEFONO,ESTADO,TIPO) values ('47425815','Ivan','Morales Manayalle','ivan16sc@gmail.com','945472496','1','1');
Insert into IVAN.USUARIO (DNI,NOMBRES,APELLIDOS,EMAIL,TELEFONO,ESTADO,TIPO) values ('12121212','Juan','Perez','jperez@gmail.com','1245124545','1','2');
Insert into IVAN.USUARIO (DNI,NOMBRES,APELLIDOS,EMAIL,TELEFONO,ESTADO,TIPO) values ('14714714','Pedro','Fernandez','ejemplo@ejemplo.com','159159159','1','1');
Insert into IVAN.USUARIO (DNI,NOMBRES,APELLIDOS,EMAIL,TELEFONO,ESTADO,TIPO) values ('12345612','Jose Paolo','Guerrero','paolo.23@guerrero.com','12312321','1','2');

--------------------------------------------------------
--  Constraints for Table PRESTAMO
--------------------------------------------------------

  ALTER TABLE "IVAN"."PRESTAMO" ADD PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Constraints for Table USUARIO
--------------------------------------------------------

  ALTER TABLE "IVAN"."USUARIO" ADD PRIMARY KEY ("DNI")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;

--------------------------------------------------------
--  Constraints for Table LIBRO
--------------------------------------------------------

  ALTER TABLE "IVAN"."LIBRO" ADD PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;

--------------------------------------------------------
--  DDL for Trigger GATILLADOR_LIBRO
--------------------------------------------------------

  CREATE OR REPLACE NONEDITIONABLE TRIGGER "IVAN"."GATILLADOR_LIBRO" 
BEFORE INSERT ON Libro
FOR EACH ROW
BEGIN
  SELECT secuencia_libro.nextval INTO :new.ID FROM dual;
END;
/
ALTER TRIGGER "IVAN"."GATILLADOR_LIBRO" ENABLE;
--------------------------------------------------------
--  DDL for Trigger GATILLADOR_PRESTAMO
--------------------------------------------------------

  CREATE OR REPLACE NONEDITIONABLE TRIGGER "IVAN"."GATILLADOR_PRESTAMO" 
BEFORE INSERT ON Prestamo
FOR EACH ROW
BEGIN
  SELECT secuencia_prestamo.nextval INTO :new.ID FROM dual;
END;
/
ALTER TRIGGER "IVAN"."GATILLADOR_PRESTAMO" ENABLE;
