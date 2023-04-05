CREATE TABLE "public"."rjo_project" ( 
  "id" SERIAL,
  "project_name" VARCHAR(50) NOT NULL,
  CONSTRAINT "rjo_project_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."rjo_project_person" ( 
  "id" SERIAL,
  "project_id" INTEGER NOT NULL,
  "person_id" INTEGER NOT NULL,
  "hours" INTEGER NOT NULL,
  CONSTRAINT "rjo_project_person_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."rjo_person" ( 
  "id" SERIAL,
  "person_name" VARCHAR(25) NOT NULL,
  CONSTRAINT "rjo_person_pkey" PRIMARY KEY ("id")
);
ALTER TABLE "public"."rjo_project" DISABLE TRIGGER ALL;
ALTER TABLE "public"."rjo_project_person" DISABLE TRIGGER ALL;
ALTER TABLE "public"."rjo_person" DISABLE TRIGGER ALL;
INSERT INTO "public"."rjo_project" ("id", "project_name") VALUES (1, 'Weapons');
INSERT INTO "public"."rjo_project" ("id", "project_name") VALUES (2, 'Armour');
INSERT INTO "public"."rjo_project" ("id", "project_name") VALUES (3, 'Spells');
INSERT INTO "public"."rjo_project" ("id", "project_name") VALUES (4, 'Food');
INSERT INTO "public"."rjo_project" ("id", "project_name") VALUES (5, 'Monsters');
INSERT INTO "public"."rjo_project" ("id", "project_name") VALUES (6, 'meow');
INSERT INTO "public"."rjo_project_person" ("id", "project_id", "person_id", "hours") VALUES (1, 1, 1, 5);
INSERT INTO "public"."rjo_project_person" ("id", "project_id", "person_id", "hours") VALUES (2, 4, 3, 8);
INSERT INTO "public"."rjo_project_person" ("id", "project_id", "person_id", "hours") VALUES (3, 4, 3, 5);
INSERT INTO "public"."rjo_project_person" ("id", "project_id", "person_id", "hours") VALUES (4, 1, 1, 8);
INSERT INTO "public"."rjo_project_person" ("id", "project_id", "person_id", "hours") VALUES (5, 2, 3, 4);
INSERT INTO "public"."rjo_project_person" ("id", "project_id", "person_id", "hours") VALUES (6, 1, 1, 8);
INSERT INTO "public"."rjo_project_person" ("id", "project_id", "person_id", "hours") VALUES (7, 2, 3, 1);
INSERT INTO "public"."rjo_project_person" ("id", "project_id", "person_id", "hours") VALUES (8, 1, 1, 5);
INSERT INTO "public"."rjo_project_person" ("id", "project_id", "person_id", "hours") VALUES (10, 1, 1, 8);
INSERT INTO "public"."rjo_project_person" ("id", "project_id", "person_id", "hours") VALUES (11, 4, 5, 5);
INSERT INTO "public"."rjo_project_person" ("id", "project_id", "person_id", "hours") VALUES (12, 5, 1, 3);
INSERT INTO "public"."rjo_project_person" ("id", "project_id", "person_id", "hours") VALUES (9, 2, 1, 5);
INSERT INTO "public"."rjo_project_person" ("id", "project_id", "person_id", "hours") VALUES (13, 1, 1, 20);
INSERT INTO "public"."rjo_person" ("id", "person_name") VALUES (2, 'Happy');
INSERT INTO "public"."rjo_person" ("id", "person_name") VALUES (3, 'Rodrick');
INSERT INTO "public"."rjo_person" ("id", "person_name") VALUES (4, 'Piglet');
INSERT INTO "public"."rjo_person" ("id", "person_name") VALUES (5, 'Ocs');
INSERT INTO "public"."rjo_person" ("id", "person_name") VALUES (1, 'Zak');
ALTER TABLE "public"."rjo_project" ENABLE TRIGGER ALL;
ALTER TABLE "public"."rjo_project_person" ENABLE TRIGGER ALL;
ALTER TABLE "public"."rjo_person" ENABLE TRIGGER ALL;
ALTER TABLE "public"."rjo_project_person" ADD CONSTRAINT "FK_rjo_person_project_person_id" FOREIGN KEY ("person_id") REFERENCES "public"."rjo_person" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."rjo_project_person" ADD CONSTRAINT "FK_rjo_project_person_project_id" FOREIGN KEY ("project_id") REFERENCES "public"."rjo_project" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;
