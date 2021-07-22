-- CREATE TABLE IF NOT EXISTS accounts(
--   id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
--   createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
--   updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
--   name varchar(255) COMMENT 'User Name',
--   email varchar(255) COMMENT 'User Email',
--   picture varchar(255) COMMENT 'User Picture'
-- ) default charset utf8 COMMENT '';


-- CREATE TABLE Merchants(
--   id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
--   name VARCHAR(255) NOT NULL,
--   category VARCHAR(255) NOT NULL,
--   creatorId VARCHAR(255) NOT NULL,
--    FOREIGN KEY (creatorId)
--    REFERENCES accounts(id)
-- )


-- CREATE TABLE Products(
--   id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
--   merchantId int NOT NULL,
--   creatorId VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   price double NOT NULL DEFAULT 1.00,
--   imgUrl VARCHAR(255),
--   qty int,

--   FOREIGN KEY (merchantId)
--   REFERENCES merchants(id),

--   FOREIGN KEY (creatorId)
--   REFERENCES accounts(Id)

-- )
