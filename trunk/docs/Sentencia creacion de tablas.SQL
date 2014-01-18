CREATE TABLE Bingo ( 
Id long ,
CantidadBolillas int ,
CantidadSorteos int ,
idEstadoBingo int ,
Fecha Datetime,
Nombre text(255),
Observaciones text(255),
Precio double ,
idTipoBingo int,constraint pk primary key (id) 
) 

;
CREATE TABLE Carton ( 
	Id long ,
	Numeros text(255),
	constraint pk primary key (id)
) 
;
CREATE TABLE CartonBingo ( 
	idEstado int,
	Id long ,
	NroCarton long,
	idBingo long,
	idvendedor long, 
	idComprador long,
	idCarton long,
	constraint pk primary key (id)
) 
;CREATE TABLE Comprador ( 
	id long,
	constraint pk primary key (id)	
) 
;

CREATE TABLE Persona ( 
	Id long,
	Apellido text(255),
	Direccion text(255),
	DNI text(255),
	Mail text(255),
	Nombre text(255),
	Observaciones text(255),
	Telefono text(255),
	constraint pk primary key (id)
) 
;
CREATE TABLE Sorteo ( 
	idEstadoSorteo int,
	Id long ,
	Numeros text(255),
	Observaciones MEMO,
	idBingo long,
	constraint pk primary key (id)
) 
;CREATE TABLE Vendedor ( 
	id long,constraint pk primary key (id)
) 
;
