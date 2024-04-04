DROP TABLE IF EXISTS student;

CREATE TABLE student (
 id SERIAL NOT NULL PRIMARY KEY,
 lastname  VARCHAR(15), 
 firstname VARCHAR(15),
 age INTEGER
);

INSERT INTO student (lastname, firstname, age) VALUES ('Vila','Rosa',24);
INSERT INTO student (lastname, firstname, age) VALUES ('Peris','Josep',27);
INSERT INTO student (lastname, firstname, age) VALUES ('Rull','Silvia',32);
INSERT INTO student (lastname, firstname, age) VALUES ('Cases','Roc',22);
INSERT INTO student (lastname, firstname, age) VALUES ('Avila','Ramon',26);
INSERT INTO student (lastname, firstname, age) VALUES ('Sobirats','Enric',26);

COMMIT;


