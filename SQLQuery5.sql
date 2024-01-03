create database DBgestion_election
use DBgestion_election

-------------------------------------------Création des tables------------------------------------------------------------------------
Create table Compte(NomC varchar(30) not null,MotPassC varchar(30) not null,CONSTRAINT PK_Compte primary key(NomC,MotPassC))

Create table Utilisateur(Nom varchar(30) not null,MotPass varchar(30) not null,CONSTRAINT PK_Utilisateur primary key(Nom,MotPass))

Create table DBelection(NUM int identity,Num_Electeur int not null, CIN varchar(40) not null, Adresse nvarchar(120), 
						date_Naissance date, Nom nvarchar(50),
						Prenom nvarchar(50), Sexe varchar(10),
						Cercle_Election int, Commune nvarchar(100),
						Nom_Bureau_Election nvarchar(60),Adresse_bureau nvarchar(100),
						Lieux_Bureau nvarchar(100),Province nvarchar(120),
						CONSTRAINT PK_DBelecteur primary key(NUM,CIN,Num_Electeur))
-------------------------------------------Affichage des tables----------------------------------------------------------------------
select * from Compte

select * from Utilisateur

select * from DBelection 
--------------------------------------------------------------------------------------------------------------------------------------
insert into Compte values('Admin','Admin')
insert into Utilisateur values('123','123')
--------------------------------------------------------------------------------------------------------------------------------------
delete DBelection
DROP TABLE DBelection
DROP TABLE Compte
--------------------------------------------------------------------------------------------------------------------------------------
--create procedure Compte(
--@NomC varchar(30),
--@MotPassC varchar(30))
--as insert into Compte (NomC,@MotPassC)values(@NomC,@MotPassC)
--go