USE BDSistemaEyS;

INSERT INTO Cargo (
idCargo, nombreCargo, descripcionCargo
)
VALUES (
1, "Diseñador Web", "Diseña webs increíbles"
);

INSERT INTO Departamento (
idDepartamento, nombreDepartamento, descripcionDepartamento,
extensionDepartamento
)
VALUES (
1, "Diseño", "Departamento enfocado en el diseño.",
"336"
);

INSERT INTO Horario (
idHorario,
lunesInicio, lunesSalida,
martesInicio, martesSalida,
miercolesInicio, miercolesSalida,
juevesInicio, juevesSalida,
viernesInicio, viernesSalida,
sabadoInicio, sabadoSalida,
domingoInicio, domingoSalida
)
VALUES (
1,
"8:00", "17:00",
"8:00", "17:00",
"8:00", "17:00",
"8:00", "17:00",
"8:00", "17:00",
"8:00", "12:00",
"8:00", "12:00"
);

INSERT INTO Empleado (
idEmpleado, primerNombre, segundoNombre,
primerApellido, segundoApellido, fechaIngreso,
cedulaEmpleado, idCargo, idDepartamento, idHorario
)
VALUES (
29812, "Juan", "Ezequiel",
"Pérez", "Jiménez", "2022-04-29",
"0010405021900A", 1, 1, 1
);
INSERT INTO Asistencia (
fechaHoraEntrada, fechaHoraSalida, idEmpleado
)
VALUES (
"2022-04-30 8:10", "2022-04-30 13:45",
29812
);