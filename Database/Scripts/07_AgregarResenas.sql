BEGIN TRANSACTION;
CREATE TABLE [Resenas] (
    [Id] int NOT NULL IDENTITY,
    [Calificacion] int NOT NULL,
    [Comentario] nvarchar(max) NOT NULL,
    [Fecha] datetime2 NOT NULL,
    [MedicoId] int NOT NULL,
    [PacienteId] int NOT NULL,
    CONSTRAINT [PK_Resenas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Resenas_Medicos_MedicoId] FOREIGN KEY ([MedicoId]) REFERENCES [Medicos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Resenas_Pacientes_PacienteId] FOREIGN KEY ([PacienteId]) REFERENCES [Pacientes] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Resenas_MedicoId] ON [Resenas] ([MedicoId]);

CREATE INDEX [IX_Resenas_PacienteId] ON [Resenas] ([PacienteId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261127191749_AgregarResenas', N'10.0.15');

COMMIT;
GO

