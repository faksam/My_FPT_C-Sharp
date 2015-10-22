USE master
GO
if exists (select * from sysdatabases where name='StudentDB')
		drop database StudentDB
go
create database StudentDB
go
use StudentDB
go
create table Semester
(
Id int identity(1,1) primary key,
Name nvarchar(30) not null,
StartDate smalldatetime not null,
EndDate smalldatetime not null
)
go 
create table Class
(
ClassCode nvarchar(8) primary key,
Batch int not null,
Major nvarchar(50) not null
)
go
create table Student
(
RollNo nvarchar(8) primary key,
ClassCode nvarchar(8) references Class(ClassCode),
FullName nvarchar(50) not null,
Nationality nvarchar(30) not null
)
go
create table StudentStatus
(
RollNo nvarchar(8) references Student(RollNo),
SemesterId int references Semester(id),
SemesterNo int not null,
Status nvarchar(30) not null,
primary key(RollNo,SemesterId)
)
go
--for class table
insert into Class values('ISE0801',8,'ISE')
insert into Class values('IBA0801',8,'IBA')
insert into Class values('ISE0901',9,'ISE')
insert into Class values('IBA0901',9,'IBA')
go
--for semester table
insert into Semester values('Fall2013','9/9/2013','12/23/2013')
insert into Semester values('Spring2014','1/6/2014','04/26/2014')
insert into Semester values('Summer2014','5/12/2014','08/25/2014')
insert into Semester values('Fall2014','9/9/2014','12/23/2014')
go
--for student tables
insert into Student values('SE03442','ISE0801','Chinedu Agwu','Nigeria')
insert into Student values('SE03443','ISE0801','Samuel Oluwaseun Ogunmokunwa','Nigeria')
insert into Student values('SE03444','ISE0801','Kanda Joshua David','Nigeria')
insert into Student values('SE03446','ISE0801','Samuel Onyedikachi Columbus','Nigeria')
insert into Student values('SE03499','ISE0801','Sadiq Abubakar Usman','Nigeria')
insert into Student values('SE03500','ISE0801','Funmi Tejumola Bolarin','Nigeria')
insert into Student values('SE03501','ISE0801','Folorunsho Mathew Faniyi','Nigeria')
insert into Student values('SE03502','ISE0801','Kashim Idris','Nigeria')
insert into Student values('SE03503','ISE0801','Muhammad Awwal Hussein','Nigeria')
insert into Student values('SE03504','ISE0801','Ibrahim Ajanah','Nigeria')
insert into Student values('SE03505','ISE0801','Lukman Abubakar Tijjatli','Nigeria')
insert into Student values('SE03506','ISE0801','Monday Abubakar Abdullawal','Nigeria')
insert into Student values('SE03507','ISE0801','Justin Sunday Adejoh','Nigeria')
insert into Student values('SB01592','IBA0901','Rita Blessing Amesomiade Osirama','Nigeria')
insert into Student values('SB01445','IBA0801','Ugo Emeka Promise','Nigeria')
insert into Student values('SB01448','IBA0801','Chanvongnaraz Pany','Lao PDR')
insert into Student values('SB01460','IBA0801','Sodiq Abayomi Ojulari','Nigeria')
insert into Student values('SB01461','IBA0801','Sunday Paul Boyie','Nigeria')
insert into Student values('SB01506','IBA0801','Ndegnong Sessingoung Boris','Cameron')
insert into Student values('SB01507','IBA0801','Bell Steve Yacinthe','Cameron')
insert into Student values('SB01517','IBA0801','Ogunobo Richard Ikhena','Nigeria')
insert into Student values('SB01559','IBA0801','Marius Baria Gheadji','Cameron')
insert into Student values('SB01560 ','IBA0901','Khamphouvong Vongsack','Lao PDR')
insert into Student values('SE03451','ISE0901','Phimmathong Soulivong','Lao PDR')
insert into Student values('SB01598','IBA0901','Umezinawa Kenneth Osita','Nigeria')
insert into Student values('SB01578','IBA0901','Jinadu Oluwakemi Odunayo','Nigeria')
insert into Student values('SB01579','IBA0901','Faniyi Mutiat Omowunmi','Nigeria')
insert into Student values('SB01580','IBA0901','Ezeoayiwara Edmund Emeka','Nigeria')
insert into Student values('SE03923','ISE0901','Chilika Obinna Hippolytus','Nigeria')
insert into Student values('SE03917','ISE0901','Fakunle Mavowa Samuel','Nigeria')
insert into Student values('SE03963','ISE0901','Okwe Victor','Nigeria')
insert into Student values('SE03964','ISE0901','Okwe Elvis  Onyema','Nigeria')
insert into Student values('SE03966','ISE0901','Ogboma Ifeanvichukwu  Victor','Nigeria')
insert into Student values('SB01600','IBA0901','Valentine Obumneke Oforha','Nigeria')
insert into Student values('SB01599','IBA0901','Emmanuel Onyedikachukwu Otiji','Nigeria')
insert into Student values('SE03918','ISE0901','Ogon David  Paddy','Nigeria')
go
--for StudentStatus
insert into StudentStatus values('SE03442',1,4,'Studying')
insert into StudentStatus values('SE03443',1,4,'Studying')
insert into StudentStatus values('SE03444',1,4,'Studying')
insert into StudentStatus values('SE03446',1,4,'Studying')
insert into StudentStatus values('SE03499',1,4,'Studying')
insert into StudentStatus values('SE03500',1,4,'Studying')
insert into StudentStatus values('SE03501',1,4,'Studying')
insert into StudentStatus values('SE03502',1,4,'Studying')
insert into StudentStatus values('SE03503',1,4,'Studying')
insert into StudentStatus values('SE03504',1,4,'Studying')
insert into StudentStatus values('SE03505',1,4,'Studying')
insert into StudentStatus values('SE03506',1,4,'Studying')
insert into StudentStatus values('SE03507',1,4,'Studying')
insert into StudentStatus values('SB01592',2,3,'Studying')
insert into StudentStatus values('SB01445',1,4,'Studying')
insert into StudentStatus values('SB01448',1,4,'Studying')
insert into StudentStatus values('SB01460',1,4,'Suspended')
insert into StudentStatus values('SB01461',1,4,'Suspended')
insert into StudentStatus values('SB01506',1,4,'Studying')
insert into StudentStatus values('SB01507',1,4,'Studying')
insert into StudentStatus values('SB01517',1,4,'Studying')
insert into StudentStatus values('SB01559',1,4,'Studying')
insert into StudentStatus values('SB01560 ',2,3,'Studying')
insert into StudentStatus values('SE03451',2,3,'Studying')
insert into StudentStatus values('SB01598',2,3,'Studying')
insert into StudentStatus values('SB01578',2,3,'Studying')
insert into StudentStatus values('SB01579',2,3,'Studying')
insert into StudentStatus values('SB01580',2,3,'Studying')
insert into StudentStatus values('SE03923',2,3,'Studying')
insert into StudentStatus values('SE03917',2,3,'Studying')
insert into StudentStatus values('SE03963',2,3,'Studying')
insert into StudentStatus values('SE03964',2,3,'Studying')
insert into StudentStatus values('SE03966',2,3,'Studying')
insert into StudentStatus values('SB01600',2,3,'Studying')
insert into StudentStatus values('SB01599',2,3,'Studying')
insert into StudentStatus values('SE03918',4,1,'Suspended')

