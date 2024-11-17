CREATE DATABASE fruit

create table users
(
users_id int identity(1,1) primary key,
users_password nvarchar(50),
users_name nvarchar(60),
types_user nvarchar(50)
)
insert into users
values
('manosh17','menna','supplier'),
('mody','mohmed','user'),
('samasemo','sama','user')
SELECT *FROM users

create table fruits
(
fruit_id int identity(1,1) primary key,
fruit_name nvarchar(50),
fruit_quantity int,
fruit_price decimal(10,2),
)
insert into fruits
values
('banana',5,250),
('apple',50,600),
('mango',70,900)
select *from fruits

create table orders
(
order_id int identity(1,1) primary key,
users_id int,
order_date datetime default Getdate(),
price decimal(10,2),
order_quantity int,
fruit_id int,
Total_Price AS (order_quantity * price) PERSISTED,
foreign key (users_id) references users (users_id),
foreign key (fruit_id) references fruits (fruit_id),
)
select * from orders
insert into orders (users_id,price,order_quantity,fruit_id)
values
(1,50.25,10,1),
(2,101.2,5,2),
(3,70.50,21,3)
select *from orders