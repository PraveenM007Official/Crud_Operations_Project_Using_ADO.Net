create database Crud
use Crud
create table vehicle(vehicle_id int not null unique,vehicle_name varchar(20),
             vehicle_Model_Year int,vehicle_Facil varchar(7) null,
             vehicle_type varchar(15) not null,EV_ char(3) not null,Vehicle_space varchar(10)null,vehicle_price_per_Hr money not null)

insert into vehicle values(1,'Toyota_supra',2015,'ac','Car','No','2-seater',55),
                          (2,'Renault duster',2014,'ac','Car','No','4-seater',58),
                          (3,'Maruthi shift',2017,'non-ac','Car','No','4-seater',45),
                          (4,'Land_rover',2022,'ac','Car','No','6-seater',70)

create table Employee(Emp_id int primary key,Emp_name varchar(15),Emp_gender varchar(12),Emp_rating float,Emp_contact bigint not null)
insert into Employee values(100,'Ram','Male',2.5,9912345679),
                           (101,'Sundhari','Trans',3.5,7612345678),
                           (102,'Vignesh','Male',3.7,6612345671),
                           (103,'Mary','Female',3.0,7912345676)


truncate table vehicle
drop  table vehicle
drop  table Employee
select*from vehicle
select*from Employee

select employee.Emp_name,employee.Emp_gender,employee.Emp_rating,employee.Emp_contact,vehicle.* from Employee left join vehicle on vehicle.Emp_id=Employee.Emp_id 
