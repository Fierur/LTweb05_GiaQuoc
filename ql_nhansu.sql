create database ql_nhansu
go
use ql_nhansu
go
create table department(
deptid int,
dname nvarchar(50),
primary key(deptid)
)

create table employee(
id int,
fname nvarchar(50),
gender nvarchar(3),
city nvarchar(30),
deptid int,
primary key(id),
foreign key(deptid) references department(deptid)
)

INSERT INTO DEPARTMENT (DEPTID, DNAME) VALUES
('1', N'Khoa CNTT'),
('2', N'Khoa ngoại ngữ'),
('3', N'Khoa tài chính'),
('4', N'Khoa thực phẩm'),
('5', N'Phòng đào tạo');

INSERT INTO EMPLOYEE (id, fname, gender, city, deptid) VALUES
(1, N'Nguyễn Văn An', N'Nam', N'Hà Nội', '1'),
(2, N'Trần Thị Bình', N'Nữ', N'Đà Nẵng', '2'),
(3, N'Lê Văn Cường', N'Nam', N'Hồ Chí Minh', '3'),
(4, N'Phạm Thị Dung', N'Nữ', N'Hải Phòng', '4'),
(5, N'Hoàng Văn Hưng', N'Nam', N'Cần Thơ', '5'),
(6, N'Vũ Thị Hoa', N'Nữ', N'Hà Nội', '1'),
(7, N'Đặng Văn Khoa', N'Nam', N'Đà Nẵng', '2'),
(8, N'Bùi Thị Lan', N'Nữ', N'Hồ Chí Minh', '3'),
(9, N'Ngô Văn Minh', N'Nam', N'Hải Phòng', '4'),
(10, N'Phan Thị Nga', N'Nữ', N'Cần Thơ', '5'),
(11, N'Đỗ Văn Quang', N'Nam', N'Hà Nội', '1'),
(12, N'Văn Thị Thu', N'Nữ', N'Đà Nẵng', '2'),
(13, N'Trịnh Văn Sơn', N'Nam', N'Hồ Chí Minh', '3'),
(14, N'Lý Thị Trang', N'Nữ', N'Hải Phòng', '4'),
(15, N'Nguyễn Văn Tuấn', N'Nam', N'Cần Thơ', '5'),
(16, N'Phạm Thị Uyên', N'Nữ', N'Hà Nội', '1'),
(17, N'Trần Văn Vinh', N'Nam', N'Đà Nẵng', '2');
select * from employee
select * from department

SELECT d.deptid, d.dname, COUNT(e.id) AS SoNhanVien
FROM department d
LEFT JOIN employee e ON d.deptid = e.deptid
GROUP BY d.deptid, d.dname
