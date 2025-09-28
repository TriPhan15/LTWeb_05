create database QL_NhanSu
use QL_NhanSu
create  table department(
	deptid int not null primary key,
	name nvarchar (30)
)
create table employee(
	id int not null primary key,
	name nvarchar(50),
	gender nvarchar(10),
	city nvarchar(50),
	deptid int,
	constraint fk_employee_department foreign key(deptid) references department(deptid)
)
drop table department;
drop table employee;
insert into department values
(1, N'Khoa CNTT'),
(2, N'Khoa Ngoại Ngữ'),
(3, N'Khoa Tài Chính'),
(4, N'Khoa Thực Phẩm'),
(5, N'Phòng Đào Tạo')
insert into employee values(1,N'Nguyễn hải Yến',N'Nữ',N'Đà Lạt',1),
(2,N'Trương Mạnh Hùng',N'Nam',N'TP,HCM',1),
(3,N'Đinh Duy Minh',N'Nam',N'Thái Bình',1),
(4,N'Ngô Thị Nguyệt',N'Nữ',N'Long An',1)
select * from department
