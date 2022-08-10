IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Clientes] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(200) NOT NULL,
    [DataNascimento] datetime2 NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Vacinas] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(200) NOT NULL,
    [NumeroDoses] int NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Vacinas] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [CarteirasTrabalho] (
    [Id] int NOT NULL IDENTITY,
    [PisPasep] nvarchar(20) NOT NULL,
    [ClienteId] int NOT NULL,
    CONSTRAINT [PK_CarteirasTrabalho] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CarteirasTrabalho_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Exames] (
    [Id] int NOT NULL IDENTITY,
    [CodigoTuss] nvarchar(20) NULL,
    [DataAgendamento] datetime2 NOT NULL,
    [ClienteId] int NOT NULL,
    CONSTRAINT [PK_Exames] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Exames_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [ClientesVacinas] (
    [ClienteId] int NOT NULL,
    [VacinaId] int NOT NULL,
    [DataAplicacao] datetime2 NOT NULL,
    CONSTRAINT [PK_ClientesVacinas] PRIMARY KEY ([ClienteId], [VacinaId]),
    CONSTRAINT [FK_ClientesVacinas_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ClientesVacinas_Vacinas_VacinaId] FOREIGN KEY ([VacinaId]) REFERENCES [Vacinas] ([Id]) ON DELETE NO ACTION
);
GO

CREATE UNIQUE INDEX [IX_CarteirasTrabalho_ClienteId] ON [CarteirasTrabalho] ([ClienteId]);
GO

CREATE INDEX [IX_ClientesVacinas_VacinaId] ON [ClientesVacinas] ([VacinaId]);
GO

CREATE INDEX [IX_Exames_ClienteId] ON [Exames] ([ClienteId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220810223553_Inicial', N'6.0.8');
GO

COMMIT;
GO

