CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS recipes(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'recipe id',
  creatorId varchar(255) NOT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  title TEXT NOT NULL,
  subtitle TEXT NOT NULL,
  catigory TEXT NOT NULL,
  picture TEXT NOT NULL COMMENT 'Recipe Picture',
  FOREIGN KEY (creatorId) REFERENCES accounts(id)
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS ingredients(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'ingredient id',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  recipeId INT Not NULL,
  name varchar(255),
  quantity TEXT NOT Null,
  FOREIGN KEY(recipeId) REFERENCES recipes(id)
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS steps(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'step id',
  position INT,
  body TEXT,
  recipeId INT NOT NULL,
  FOREIGN KEY(recipeId) REFERENCES recepes(id),
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS favorites(
  id INT AUTO_INCREMENT NOT NULL primary key COMMENT 'favorites id',
  accountId VARCHAR(255) NOT NULL,
  recipeId INT NOT NULL,
  FOREIGN KEY (accountID) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (recipeID) REFERENCES recipes(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
SELECT
  *
FROM
  recipes;