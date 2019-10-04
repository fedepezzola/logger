CREATE TABLE [dbo].[logs_tipos] (
    [id]          CHAR (1)      NOT NULL,
    [descripcion] NVARCHAR (15) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[logs] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [mensaje]    TEXT     NOT NULL,
    [fecha_hora] DATETIME NOT NULL,
    [tipo]       CHAR (1) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_logs_tipos_logs] FOREIGN KEY ([tipo]) REFERENCES [dbo].[logs_tipos] ([id])
);