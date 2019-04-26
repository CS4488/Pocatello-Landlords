--Kalen Williams

DROP TABLE IF EXISTS Properties;

--mortgage value always half buy_value
CREATE TABLE Properties(
    id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
    name VARCHAR NOT NULL,
    buy_value INTEGER NOT NULL,
    house_cost INTEGER NOT NULL,
    color VARCHAR NOT NULL,
    rent_0 INTEGER NOT NULL,
    rent_1 INTEGER NOT NULL,
    rent_2 INTEGER NOT NULL,
    rent_3 INTEGER NOT NULL,
    rent_4 INTEGER NOT NULL,
    rent_5 INTEGER NOT NULL
);

/*
INSERT INTO Properties(
    name, 
    buy_value, 
    house_cost, 
    color,
    rent_0, 
    rent_1, 
    rent_2, 
    rent_3, 
    rent_4, 
    rent_5
)VALUES(

)
*/

INSERT INTO Properties(
    name, 
    buy_value, 
    house_cost, 
    color,
    rent_0, 
    rent_1, 
    rent_2, 
    rent_3, 
    rent_4, 
    rent_5
)VALUES(
    "Boardwalk",
    400,
    200,
    "Blue",
    50,
    200,
    600,
    1400,
    1700,
    2000
);

INSERT INTO Properties(
    name, 
    buy_value, 
    house_cost, 
    color,
    rent_0, 
    rent_1, 
    rent_2, 
    rent_3, 
    rent_4, 
    rent_5
)VALUES(
    "Park Place",
    350,
    200,
    "Blue",
    35,
    175,
    500,
    1100,
    1300,
    1500
);

INSERT INTO Properties(
    name, 
    buy_value, 
    house_cost, 
    color,
    rent_0, 
    rent_1, 
    rent_2, 
    rent_3, 
    rent_4, 
    rent_5
)VALUES(
    "Pennsylvania Avenue",
    320,
    200,
    "Green",
    28,
    150,
    450,
    1000,
    1200,
    1400
);

INSERT INTO Properties(
    name, 
    buy_value, 
    house_cost, 
    color,
    rent_0, 
    rent_1, 
    rent_2, 
    rent_3, 
    rent_4, 
    rent_5
)VALUES(
    "North Carolina Avenue",
    300,
    200,
    "Green",
    26,
    130,
    390,
    900,
    1100,
    1275
);

INSERT INTO Properties(
    name, 
    buy_value, 
    house_cost, 
    color,
    rent_0, 
    rent_1, 
    rent_2, 
    rent_3, 
    rent_4, 
    rent_5
)VALUES(
    "Pacific Avenue",
    300,
    200,
    "Green",
    26,
    130,
    390,
    900,
    1100,
    1275
);

INSERT INTO Properties(
    name, 
    buy_value, 
    house_cost, 
    color,
    rent_0, 
    rent_1, 
    rent_2, 
    rent_3, 
    rent_4, 
    rent_5
)VALUES(
    "Marvin Gardens",
    280,
    150,
    "Yellow",
    24,
    120,
    360,
    850,
    1025,
    1200
);

INSERT INTO Properties(
    name, 
    buy_value, 
    house_cost, 
    color,
    rent_0, 
    rent_1, 
    rent_2, 
    rent_3, 
    rent_4, 
    rent_5
)VALUES(
    "Ventnor Avenue",
    260,
    150,
    "Yellow",
    22,
    110,
    330,
    800,
    975,
    1150
);

INSERT INTO Properties(
    name, 
    buy_value, 
    house_cost, 
    color,
    rent_0, 
    rent_1, 
    rent_2, 
    rent_3, 
    rent_4, 
    rent_5
)VALUES(
    "Atlantic Avenue",
    260,
    150,
    "Yellow",
    22,
    110,
    330,
    800,
    975,
    1150
);

INSERT INTO Properties(
    name, 
    buy_value, 
    house_cost, 
    color,
    rent_0, 
    rent_1, 
    rent_2, 
    rent_3, 
    rent_4, 
    rent_5
)VALUES(
    "Illinois Avenue",
    240,
    150,
    "Red",
    20,
    100,
    300,
    750,
    925,
    1100
);

INSERT INTO Properties(
    name, 
    buy_value, 
    house_cost, 
    color,
    rent_0, 
    rent_1, 
    rent_2, 
    rent_3, 
    rent_4, 
    rent_5
)VALUES(
    "Indiana Avenue",
    220,
    150,
    "Red",
    18,
    90,
    250,
    700,
    875,
    1050
);

INSERT INTO Properties(
    name, 
    buy_value, 
    house_cost, 
    color,
    rent_0, 
    rent_1, 
    rent_2, 
    rent_3, 
    rent_4, 
    rent_5
)VALUES(
    "Kentucky Avenue",
    220,
    150,
    "Red",
    18,
    90,
    250,
    700,
    875,
    1050
);

INSERT INTO Properties(
    name, 
    buy_value, 
    house_cost, 
    color,
    rent_0, 
    rent_1, 
    rent_2, 
    rent_3, 
    rent_4, 
    rent_5
)VALUES(
    "New York Avenue",
    200,
    100,
    "Orange",
    16,
    80,
    220,
    600,
    800,
    1000
);

INSERT INTO Properties(
    name, 
    buy_value, 
    house_cost, 
    color,
    rent_0, 
    rent_1, 
    rent_2, 
    rent_3, 
    rent_4, 
    rent_5
)VALUES(
    "Tennessee Avenue",
    180,
    100,
    "Orange",
    14,
    70,
    200,
    550,
    750,
    950
);

INSERT INTO Properties(
    name, 
    buy_value, 
    house_cost, 
    color,
    rent_0, 
    rent_1, 
    rent_2, 
    rent_3, 
    rent_4, 
    rent_5
)VALUES(
    "St. James Place",
    180,
    100,
    "Orange",
    14,
    70,
    200,
    550,
    750,
    950
);

INSERT INTO Properties(
    name, 
    buy_value, 
    house_cost, 
    color,
    rent_0, 
    rent_1, 
    rent_2, 
    rent_3, 
    rent_4, 
    rent_5
)VALUES(
    "Virginia Avenue",
    160,
    100,
    "Pink",
    12,
    60,
    180,
    500,
    700,
    900
);

INSERT INTO Properties(
    name, 
    buy_value, 
    house_cost, 
    color,
    rent_0, 
    rent_1, 
    rent_2, 
    rent_3, 
    rent_4, 
    rent_5
)VALUES(
    "States Avenue",
    140,
    100,
    "Pink",
    10,
    50,
    150,
    450,
    625,
    750
);

INSERT INTO Properties(
    name, 
    buy_value, 
    house_cost, 
    color,
    rent_0, 
    rent_1, 
    rent_2, 
    rent_3, 
    rent_4, 
    rent_5
)VALUES(
    "St. Charles Place",
    140,
    100,
    "Pink",
    10,
    50,
    150,
    450,
    625,
    750
);

INSERT INTO Properties(
    name, 
    buy_value, 
    house_cost, 
    color,
    rent_0, 
    rent_1, 
    rent_2, 
    rent_3, 
    rent_4, 
    rent_5
)VALUES(
    "Connecticut Avenue",
    120,
    50,
    "Light blue",
    8,
    40,
    100,
    300,
    450,
    600
);

INSERT INTO Properties(
    name, 
    buy_value, 
    house_cost, 
    color,
    rent_0, 
    rent_1, 
    rent_2, 
    rent_3, 
    rent_4, 
    rent_5
)VALUES(
    "Vermont Avenue",
    100,
    50,
    "Light blue",
    6,
    30,
    90,
    270,
    400,
    550
);

INSERT INTO Properties(
    name, 
    buy_value, 
    house_cost, 
    color,
    rent_0, 
    rent_1, 
    rent_2, 
    rent_3, 
    rent_4, 
    rent_5
)VALUES(
    "Oriental Avenue",
    100,
    50,
    "Light blue",
    6,
    30,
    90,
    270,
    400,
    550
);

INSERT INTO Properties(
    name, 
    buy_value, 
    house_cost, 
    color,
    rent_0, 
    rent_1, 
    rent_2, 
    rent_3, 
    rent_4, 
    rent_5
)VALUES(
    "Baltic Avenue",
    60,
    50,
    "Brown",
    4,
    20,
    60,
    180,
    320,
    450
);

INSERT INTO Properties(
    name, 
    buy_value, 
    house_cost, 
    color,
    rent_0, 
    rent_1, 
    rent_2, 
    rent_3, 
    rent_4, 
    rent_5
)VALUES(
    "Mediterranean Avenue",
    60,
    50,
    "Brown",
    2,
    10,
    30,
    90,
    160,
    250
);

