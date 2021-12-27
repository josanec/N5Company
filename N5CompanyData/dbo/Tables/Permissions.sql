CREATE TABLE [dbo].[Permissions] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [EmployeeForename] NVARCHAR (50) NOT NULL,
    [EmployeeSurname]  NVARCHAR (50) NOT NULL,
    [PermissionType]   INT           NOT NULL,
    [PermissionDate]   DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Permissions_PermissionTypes] FOREIGN KEY ([PermissionType]) REFERENCES [dbo].[PermissionTypes] ([Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Unique ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Permissions', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Employee Forename', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Permissions', @level2type = N'COLUMN', @level2name = N'EmployeeForename';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Employee Surname', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Permissions', @level2type = N'COLUMN', @level2name = N'EmployeeSurname';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Permission Type', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Permissions', @level2type = N'COLUMN', @level2name = N'PermissionType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Permission granted on Date', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Permissions', @level2type = N'COLUMN', @level2name = N'PermissionDate';

