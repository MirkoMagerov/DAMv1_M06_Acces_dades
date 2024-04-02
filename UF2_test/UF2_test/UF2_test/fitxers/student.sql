CREATE TABLE student (
 id SERIAL NOT NULL PRIMARY KEY,
 lastname  VARCHAR(15), 
 firstname VARCHAR(15)
);

INSERT INTO student (lastname, firstname) VALUES ('Vila','Rosa');
INSERT INTO student (lastname, firstname) VALUES ('Peris','Josep');
INSERT INTO student (lastname, firstname) VALUES ('Rull','Silvia');
INSERT INTO student (lastname, firstname) VALUES ('Cases','Roc');

COMMIT;


