BEGIN TRANSACTION;
CREATE TABLE [Clinicas] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Direccion] nvarchar(max) NOT NULL,
    [Telefono] nvarchar(max) NOT NULL,
    [Correo] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Clinicas] PRIMARY KEY ([Id])
);

CREATE TABLE [ClinicaMedico] (
    [ClinicasId] int NOT NULL,
    [MedicosId] int NOT NULL,
    CONSTRAINT [PK_ClinicaMedico] PRIMARY KEY ([ClinicasId], [MedicosId]),
    CONSTRAINT [FK_ClinicaMedico_Clinicas_ClinicasId] FOREIGN KEY ([ClinicasId]) REFERENCES [Clinicas] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ClinicaMedico_Medicos_MedicosId] FOREIGN KEY ([MedicosId]) REFERENCES [Medicos] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_ClinicaMedico_MedicosId] ON [ClinicaMedico] ([MedicosId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261127024401_AgregarClinicas', N'10.0.15');

COMMIT;
GO
