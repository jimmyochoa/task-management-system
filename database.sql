--create database query
CREATE DATABASE task_system

--use of the current table
USE task_system;

--users table--
CREATE TABLE users (
    user_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL,
    profile_photo_loc VARCHAR(100) NOT NULL,
	is_active BIT NOT NULL DEFAULT 1,
	created_at DATETIME NOT NULL DEFAULT GETDATE(),
	modified_at DATETIME NOT NULL
);

--status table--
CREATE TABLE status (
	status_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(150) NOT NULL,
	description VARCHAR(150) NOT NULL,
	is_active BIT NOT NULL DEFAULT 1,
	created_at DATETIME NOT NULL DEFAULT GETDATE(),
	modified_at DATETIME NOT NULL
);

--tasks table--
CREATE TABLE tasks (
	task_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	title VARCHAR(255) NOT NULL,
	description VARCHAR(255) NOT NULL,
	is_active BIT NOT NULL DEFAULT 1,
	created_at DATETIME NOT NULL DEFAULT GETDATE(),
	modified_at DATETIME NOT NULL
);

--groups table--
CREATE TABLE groups (
	group_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(255) NOT NULL,
	description VARCHAR(255),
	is_active BIT NOT NULL DEFAULT 1,
	created_at DATETIME NOT NULL DEFAULT GETDATE(),
	modified_at DATETIME NOT NULL
);

--user_task table--
CREATE TABLE user_task (
	user_task_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	user_id INT NOT NULL,
	task_id INT NOT NULL,
	status_id INT NOT NULL,
	description VARCHAR(255),
	expiration_date DATETIME NOT NULL,
	is_active BIT NOT NULL DEFAULT 1,
	created_at DATETIME NOT NULL DEFAULT GETDATE(),
	modified_at DATETIME NOT NULL,
	FOREIGN KEY (user_id) REFERENCES users(user_id),
	FOREIGN KEY (task_id) REFERENCES tasks(task_id),
	FOREIGN KEY (status_id) REFERENCES status(status_id)
);


--user_group table--
CREATE TABLE user_group (
	user_group_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	user_id INT NOT NULL,
	group_id INT NOT NULL,
	description VARCHAR(255) NOT NULL,
	is_active BIT NOT NULL DEFAULT 1,
	created_at DATETIME NOT NULL DEFAULT GETDATE(),
	modified_at DATETIME NOT NULL,
	FOREIGN KEY (user_id) REFERENCES users(user_id),
	FOREIGN KEY (group_id) REFERENCES groups(group_id)
);

--task_group table--
CREATE TABLE task_group (
	task_group_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	group_id INT NOT NULL,
	task_id INT NOT NULL,
	description VARCHAR(255) NOT NULL,
	is_active BIT NOT NULL DEFAULT 1,
	created_at DATETIME NOT NULL DEFAULT GETDATE(),
	modified_at DATETIME NOT NULL,
	FOREIGN KEY (group_id) REFERENCES groups(group_id),
	FOREIGN KEY (task_id) REFERENCES tasks(task_id)
);