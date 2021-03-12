create database bdClinOdonto;
Use bdClinOdonto;

create table tblogin(
usuario varchar(50) primary key,
senha varchar(10),
tipo int
);

create table tbPaciente(
codPac int primary key,
nomePac varchar(50),
telPac varchar(13)
);

create table tbDentista(
codDentista int primary key,
NomeDentista varchar(50),
TelDentista  varchar(20),
EmailDentista varchar(50)
);

create table tbAtendimento(
codAtendimento int primary key,
dataAtend varchar(8),
horaAtend varchar(8),
codDentista int references tbDentista(codDentista),
codPac int references tbPaciente(codPac)
);
-- delete from table tbatendimento where codPac = null;

insert into tblogin (usuario, senha, tipo) values ('edigar','edigar',1);
insert into tblogin (usuario, senha, tipo) values ('edigarmaia','12345',2);

insert into tbPaciente (codPac, nomePac, telPac) values (1,'Ana Maria','97979-5656');
insert into tbPaciente (codPac, nomePac, telPac) values (2,'João','97979-3637');
insert into tbPaciente (codPac, nomePac, telPac) values (3,'Anastácio','96464-5456');

insert into tbDentista (codDentista, NomeDentista, TelDentista, EmailDentista) values (1,'Arthur','96464-5456', 'arthur@gmail.com');
insert into tbDentista (codDentista, NomeDentista, TelDentista, EmailDentista) values (2,'Maria','9667-5226', 'maria@gmail.com');
insert into tbDentista (codDentista, NomeDentista, TelDentista, EmailDentista) values (3,'Theófilo','97839-4586', 'theofilo@gmail.com');


select * from tblogin;
select * from tbPaciente;
select * from tbdentista;


