-- Active: 1666715478973@@SG-mirror-push-8951-6845-mysql-master.servers.mongodirector.com@3306@garbageCollector
CREATE TABLE IF NOT EXISTS recipes(
  id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  title VARCHAR(255) NOT NULL,
  instructions VARCHAR(255) NOT NULL,
  img VARCHAR(255) NOT NULL DEFAULT "https://images.unsplash.com/photo-1547516508-4c1f9c7c4ec3?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=880&q=80",
  category VARCHAR(255) NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';