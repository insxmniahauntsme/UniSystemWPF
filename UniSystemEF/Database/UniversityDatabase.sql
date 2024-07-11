USE University
GO

CREATE SCHEMA UniversitySchema
GO

DROP TABLE UniversitySchema.Faculties;
DROP TABLE UniversitySchema.Groups;
DROP TABLE UniversitySchema.Students;

-- Створення таблиці Faculties
CREATE TABLE UniversitySchema.Faculties (
    FacultyId INT PRIMARY KEY IDENTITY(1, 1),
    FacultyName VARCHAR(100),
    Department VARCHAR(100),
    Note VARCHAR(100)
);

-- Створення таблиці Groups
CREATE TABLE UniversitySchema.Groups (
    GroupId INT PRIMARY KEY IDENTITY(1, 1),
    GroupName VARCHAR(100),
    Faculty VARCHAR(100),
    AmountOfStudents INT,
    GroupAverage FLOAT,

);

-- Створення таблиці Students
CREATE TABLE UniversitySchema.Students (
    RegistrationDate DATE PRIMARY KEY,
    Surname VARCHAR(100),
    Name VARCHAR(100),
    GroupName VARCHAR(100),
    AverageScore FLOAT,

);

-- Вставка даних в таблицю Faculties
INSERT INTO UniversitySchema.Faculties (FacultyName, Department, Note)
VALUES ('Faculty of Computer Science', 'Computer Science Department', 'Main faculty for computer-related disciplines'),
       ('Faculty of Engineering', 'Engineering Department', 'Covers various engineering disciplines'),
       ('Faculty of Arts', 'Arts Department', 'Focuses on humanities and arts');

-- Вставка даних в таблицю Groups
INSERT INTO UniversitySchema.Groups (GroupName, Faculty, AmountOfStudents, GroupAverage)
VALUES ('CS101', 'Faculty of Computer Science', 30, 85.5),
       ('ENG201', 'Faculty of Engineering', 25, 78.2),
       ('ART301', 'Faculty of Arts', 20, 87.0);

-- Вставка даних в таблицю Students
INSERT INTO UniversitySchema.Students (RegistrationDate, Surname, Name, GroupName, AverageScore)
VALUES ('2023-09-01', 'Smith', 'John', 'CS101', 88.5),
       ('2023-09-02', 'Johnson', 'Emily', 'CS101', 82.0),
       ('2023-09-03', 'Williams', 'David', 'ENG201', 76.3),
       ('2023-09-04', 'Brown', 'Emma', 'ART301', 89.2);

SELECT * FROM UniversitySchema.Faculties;
SELECT * FROM UniversitySchema.Groups;
SELECT * FROM UniversitySchema.Students;
