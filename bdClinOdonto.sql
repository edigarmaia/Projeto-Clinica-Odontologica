create database bdClinOdonto;
Use bdClinOdonto;

create table tblogin(
usuario varchar(50) primary key,
senha varchar(10),
tipo int
);

insert into tblogin (usuario, senha, tipo) values ('edigar','edigar',1);
insert into tblogin (usuario, senha, tipo) values ('edigarmaia','12345',2);

select * from tblogin;
