namespace CXD.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.zzd_Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        AccountName = c.String(maxLength: 50, storeType: "nvarchar"),
                        UserName = c.String(maxLength: 50, storeType: "nvarchar"),
                        Password = c.String(maxLength: 50, storeType: "nvarchar"),
                        IMEICode = c.String(unicode: false),
                        IsActivated = c.String(unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CAccount_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.AbpAuditLogs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(),
                        ServiceName = c.String(maxLength: 256, storeType: "nvarchar"),
                        MethodName = c.String(maxLength: 256, storeType: "nvarchar"),
                        Parameters = c.String(maxLength: 1024, storeType: "nvarchar"),
                        ReturnValue = c.String(unicode: false),
                        ExecutionTime = c.DateTime(nullable: false, precision: 0),
                        ExecutionDuration = c.Int(nullable: false),
                        ClientIpAddress = c.String(maxLength: 64, storeType: "nvarchar"),
                        ClientName = c.String(maxLength: 128, storeType: "nvarchar"),
                        BrowserInfo = c.String(maxLength: 512, storeType: "nvarchar"),
                        Exception = c.String(maxLength: 2000, storeType: "nvarchar"),
                        ImpersonatorUserId = c.Long(),
                        ImpersonatorTenantId = c.Int(),
                        CustomData = c.String(maxLength: 2000, storeType: "nvarchar"),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AuditLog_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.AbpBackgroundJobs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        JobType = c.String(nullable: false, maxLength: 512, storeType: "nvarchar"),
                        JobArgs = c.String(nullable: false, unicode: false),
                        TryCount = c.Short(nullable: false),
                        NextTryTime = c.DateTime(nullable: false, precision: 0),
                        LastTryTime = c.DateTime(precision: 0),
                        IsAbandoned = c.Boolean(nullable: false),
                        Priority = c.Byte(nullable: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.IsAbandoned, t.NextTryTime });
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(unicode: false),
                        CompanyAddress = c.String(unicode: false),
                        Contactor = c.String(unicode: false),
                        Mobile = c.String(unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CCompany_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.zzd_Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        Title = c.String(unicode: false),
                        ImgUrl = c.String(unicode: false),
                        IsActivated = c.String(unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CPicture_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.CTides",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        PublicDate = c.DateTime(nullable: false, precision: 0),
                        MoonDate = c.String(unicode: false),
                        Flood1 = c.DateTime(nullable: false, precision: 0),
                        Ebb1 = c.DateTime(nullable: false, precision: 0),
                        Flood2 = c.DateTime(nullable: false, precision: 0),
                        Ebb2 = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.zzd_user",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        UserType = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CWeathers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        Title = c.String(unicode: false),
                        Type = c.Int(nullable: false),
                        Content = c.String(unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CWeather_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.AbpFeatures",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Value = c.String(nullable: false, maxLength: 2000, storeType: "nvarchar"),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                        EditionId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EditionFeatureSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_FeatureSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_TenantFeatureSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.EditionId);
            
            CreateTable(
                "dbo.AbpEditions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 32, storeType: "nvarchar"),
                        DisplayName = c.String(nullable: false, maxLength: 64, storeType: "nvarchar"),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Edition_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.AbpEntityChanges",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ChangeTime = c.DateTime(nullable: false, precision: 0),
                        ChangeType = c.Byte(nullable: false),
                        EntityChangeSetId = c.Long(nullable: false),
                        EntityId = c.String(maxLength: 48, storeType: "nvarchar"),
                        EntityTypeFullName = c.String(maxLength: 192, storeType: "nvarchar"),
                        TenantId = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityChange_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.AbpEntityPropertyChanges",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EntityChangeId = c.Long(nullable: false),
                        NewValue = c.String(maxLength: 512, storeType: "nvarchar"),
                        OriginalValue = c.String(maxLength: 512, storeType: "nvarchar"),
                        PropertyName = c.String(maxLength: 96, storeType: "nvarchar"),
                        PropertyTypeFullName = c.String(maxLength: 192, storeType: "nvarchar"),
                        TenantId = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityPropertyChange_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantId);

            CreateTable(
                "dbo.AbpEntityChangeSets",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    BrowserInfo = c.String(maxLength: 512, storeType: "nvarchar"),
                    ClientIpAddress = c.String(maxLength: 64, storeType: "nvarchar"),
                    ClientName = c.String(maxLength: 128, storeType: "nvarchar"),
                    CreationTime = c.DateTime(nullable: false, precision: 0),
                    ExtensionData = c.String(unicode: false),
                    ImpersonatorTenantId = c.Int(),
                    ImpersonatorUserId = c.Long(),
                    Reason = c.String(maxLength: 256, storeType: "nvarchar"),
                    TenantId = c.Int(),
                    UserId = c.Long(),
                },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityChangeSet_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantId);
               
            
            CreateTable(
                "dbo.AbpLanguages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenantId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        DisplayName = c.String(nullable: false, maxLength: 64, storeType: "nvarchar"),
                        Icon = c.String(maxLength: 128, storeType: "nvarchar"),
                        IsDisabled = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ApplicationLanguage_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ApplicationLanguage_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.AbpLanguageTexts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        LanguageName = c.String(nullable: false, maxLength: 10, storeType: "nvarchar"),
                        Source = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Key = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        Value = c.String(nullable: false, unicode: false),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ApplicationLanguageText_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.zzd_Notices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        Title = c.String(unicode: false),
                        NewsAuthor = c.String(unicode: false),
                        DisplayIndex = c.Int(),
                        NewsContent = c.String(unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CNotice_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.AbpNotifications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NotificationName = c.String(nullable: false, maxLength: 96, storeType: "nvarchar"),
                        Data = c.String(unicode: false),
                        DataTypeName = c.String(maxLength: 512, storeType: "nvarchar"),
                        EntityTypeName = c.String(maxLength: 250, storeType: "nvarchar"),
                        EntityTypeAssemblyQualifiedName = c.String(maxLength: 512, storeType: "nvarchar"),
                        EntityId = c.String(maxLength: 96, storeType: "nvarchar"),
                        Severity = c.Byte(nullable: false),
                        UserIds = c.String(unicode: false),
                        ExcludedUserIds = c.String(unicode: false),
                        TenantIds = c.String(unicode: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.AbpNotificationSubscriptions",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    TenantId = c.Int(),
                    UserId = c.Long(nullable: false),
                    NotificationName = c.String(maxLength: 96, storeType: "nvarchar"),
                    EntityTypeName = c.String(maxLength: 250, storeType: "nvarchar"),
                    EntityTypeAssemblyQualifiedName = c.String(maxLength: 512, storeType: "nvarchar"),
                    EntityId = c.String(maxLength: 96, storeType: "nvarchar"),
                    CreationTime = c.DateTime(nullable: false, precision: 0),
                    CreatorUserId = c.Long(),
                },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_NotificationSubscriptionInfo_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantId);
         
            
            CreateTable(
                "dbo.AbpOrganizationUnitRoles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        RoleId = c.Int(nullable: false),
                        OrganizationUnitId = c.Long(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_OrganizationUnitRole_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantId);

            CreateTable(
                "dbo.AbpOrganizationUnits",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    TenantId = c.Int(),
                    ParentId = c.Long(),
                    Code = c.String(nullable: false, maxLength: 95, storeType: "nvarchar"),
                    DisplayName = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    IsDeleted = c.Boolean(nullable: false),
                    DeleterUserId = c.Long(),
                    DeletionTime = c.DateTime(precision: 0),
                    LastModificationTime = c.DateTime(precision: 0),
                    LastModifierUserId = c.Long(),
                    CreationTime = c.DateTime(nullable: false, precision: 0),
                    CreatorUserId = c.Long(),
                },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_OrganizationUnit_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_OrganizationUnit_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
               .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.AbpPermissions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        IsGranted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                        RoleId = c.Int(),
                        UserId = c.Long(),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PermissionSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_RolePermissionSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_UserPermissionSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AbpRoles",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Description = c.String(maxLength: 5000, storeType: "nvarchar"),
                    NormalizedName = c.String(nullable: false, maxLength: 32, storeType: "nvarchar"),
                    TenantId = c.Int(),
                    Name = c.String(nullable: false, maxLength: 32, storeType: "nvarchar"),
                    DisplayName = c.String(nullable: false, maxLength: 64, storeType: "nvarchar"),
                    IsStatic = c.Boolean(nullable: false),
                    IsDefault = c.Boolean(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                    DeleterUserId = c.Long(),
                    DeletionTime = c.DateTime(precision: 0),
                    LastModificationTime = c.DateTime(precision: 0),
                    LastModifierUserId = c.Long(),
                    CreationTime = c.DateTime(nullable: false, precision: 0),
                    CreatorUserId = c.Long(),
                },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Role_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Role_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
               .Index(t => t.TenantId);
               
            
            CreateTable(
                "dbo.AbpUsers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NormalizedUserName = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        NormalizedEmailAddress = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        AuthenticationSource = c.String(maxLength: 64, storeType: "nvarchar"),
                        UserName = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        TenantId = c.Int(),
                        EmailAddress = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 64, storeType: "nvarchar"),
                        Surname = c.String(nullable: false, maxLength: 64, storeType: "nvarchar"),
                        Password = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        EmailConfirmationCode = c.String(maxLength: 328, storeType: "nvarchar"),
                        PasswordResetCode = c.String(maxLength: 328, storeType: "nvarchar"),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        AccessFailedCount = c.Int(nullable: false),
                        IsLockoutEnabled = c.Boolean(nullable: false),
                        PhoneNumber = c.String(maxLength: 32, storeType: "nvarchar"),
                        IsPhoneNumberConfirmed = c.Boolean(nullable: false),
                        SecurityStamp = c.String(maxLength: 128, storeType: "nvarchar"),
                        IsTwoFactorEnabled = c.Boolean(nullable: false),
                        IsEmailConfirmed = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_User_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_User_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)             
                .Index(t => t.TenantId) ;
            
            CreateTable(
                "dbo.AbpUserClaims",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        ClaimType = c.String(maxLength: 256, storeType: "nvarchar"),
                        ClaimValue = c.String(unicode: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserClaim_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)               
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AbpUserLogins",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserLogin_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AbpUserRoles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        RoleId = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserRole_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)                 
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AbpSettings",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    TenantId = c.Int(),
                    UserId = c.Long(),
                    Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                    Value = c.String(maxLength: 2000, storeType: "nvarchar"),
                    LastModificationTime = c.DateTime(precision: 0),
                    LastModifierUserId = c.Long(),
                    CreationTime = c.DateTime(nullable: false, precision: 0),
                    CreatorUserId = c.Long(),
                },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Setting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AbpTenantNotifications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(),
                        NotificationName = c.String(nullable: false, maxLength: 96, storeType: "nvarchar"),
                        Data = c.String(unicode: false),
                        DataTypeName = c.String(maxLength: 512, storeType: "nvarchar"),
                        EntityTypeName = c.String(maxLength: 250, storeType: "nvarchar"),
                        EntityTypeAssemblyQualifiedName = c.String(maxLength: 512, storeType: "nvarchar"),
                        EntityId = c.String(maxLength: 96, storeType: "nvarchar"),
                        Severity = c.Byte(nullable: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_TenantNotificationInfo_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.AbpTenants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EditionId = c.Int(),
                        TenancyName = c.String(nullable: false, maxLength: 64, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ConnectionString = c.String(maxLength: 1024, storeType: "nvarchar"),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Tenant_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.EditionId);
            
            CreateTable(
                "dbo.AbpUserAccounts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        UserLinkId = c.Long(),
                        UserName = c.String(maxLength: 256, storeType: "nvarchar"),
                        EmailAddress = c.String(maxLength: 256, storeType: "nvarchar"),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserAccount_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);

            CreateTable(
                "dbo.AbpUserLoginAttempts",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    TenantId = c.Int(),
                    TenancyName = c.String(maxLength: 64, storeType: "nvarchar"),
                    UserId = c.Long(),
                    UserNameOrEmailAddress = c.String(maxLength: 255, storeType: "nvarchar"),
                    ClientIpAddress = c.String(maxLength: 64, storeType: "nvarchar"),
                    ClientName = c.String(maxLength: 128, storeType: "nvarchar"),
                    BrowserInfo = c.String(maxLength: 512, storeType: "nvarchar"),
                    Result = c.Byte(nullable: false),
                    CreationTime = c.DateTime(nullable: false, precision: 0),
                },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserLoginAttempt_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantId);
             
            CreateTable(
                "dbo.AbpUserNotifications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        TenantNotificationId = c.Guid(nullable: false),
                        State = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserNotificationInfo_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.AbpUserOrganizationUnits",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        OrganizationUnitId = c.Long(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserOrganizationUnit_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_UserOrganizationUnit_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.vaisala_wxt536_view",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        equipment_no = c.String(unicode: false),
                        tp = c.String(unicode: false),
                        sm = c.String(unicode: false),
                        dm = c.String(unicode: false),
                        pa = c.String(unicode: false),
                        rd = c.String(unicode: false),
                        rc = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.xylem_5400_view",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        equipment_no = c.String(unicode: false),
                        cell_index = c.String(unicode: false),
                        depth = c.String(unicode: false),
                        horizontal_speed = c.String(unicode: false),
                        direction = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AbpTenants", "LastModifierUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpTenants", "EditionId", "dbo.AbpEditions");
            DropForeignKey("dbo.AbpTenants", "DeleterUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpTenants", "CreatorUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpPermissions", "RoleId", "dbo.AbpRoles");
            DropForeignKey("dbo.AbpRoles", "LastModifierUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpRoles", "DeleterUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpRoles", "CreatorUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpSettings", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUserRoles", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpPermissions", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUserLogins", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUsers", "LastModifierUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUsers", "DeleterUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUsers", "CreatorUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUserClaims", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpOrganizationUnits", "ParentId", "dbo.AbpOrganizationUnits");
            DropForeignKey("dbo.AbpEntityChanges", "EntityChangeSetId", "dbo.AbpEntityChangeSets");
            DropForeignKey("dbo.AbpEntityPropertyChanges", "EntityChangeId", "dbo.AbpEntityChanges");
            DropForeignKey("dbo.AbpFeatures", "EditionId", "dbo.AbpEditions");
            DropIndex("dbo.AbpUserOrganizationUnits", new[] { "IsDeleted" });
            DropIndex("dbo.AbpUserOrganizationUnits", new[] { "TenantId" });
            DropIndex("dbo.AbpUserNotifications", new[] { "UserId", "State", "CreationTime" });
            DropIndex("dbo.AbpUserNotifications", new[] { "TenantId" });
            DropIndex("dbo.AbpUserLoginAttempts", new[] { "TenancyName", "UserNameOrEmailAddress", "Result" });
            DropIndex("dbo.AbpUserLoginAttempts", new[] { "UserId", "TenantId" });
            DropIndex("dbo.AbpUserLoginAttempts", new[] { "TenantId" });
            DropIndex("dbo.AbpUserAccounts", new[] { "IsDeleted" });
            DropIndex("dbo.AbpTenants", new[] { "CreatorUserId" });
            DropIndex("dbo.AbpTenants", new[] { "LastModifierUserId" });
            DropIndex("dbo.AbpTenants", new[] { "DeleterUserId" });
            DropIndex("dbo.AbpTenants", new[] { "IsDeleted" });
            DropIndex("dbo.AbpTenants", new[] { "EditionId" });
            DropIndex("dbo.AbpTenantNotifications", new[] { "TenantId" });
            DropIndex("dbo.AbpSettings", new[] { "TenantId", "Name", "UserId" });
            DropIndex("dbo.AbpUserRoles", new[] { "UserId" });
            DropIndex("dbo.AbpUserRoles", new[] { "TenantId" });
            DropIndex("dbo.AbpUserLogins", new[] { "UserId" });
            DropIndex("dbo.AbpUserLogins", new[] { "TenantId" });
            DropIndex("dbo.AbpUserClaims", new[] { "UserId" });
            DropIndex("dbo.AbpUserClaims", new[] { "TenantId" });
            DropIndex("dbo.AbpUsers", new[] { "CreatorUserId" });
            DropIndex("dbo.AbpUsers", new[] { "LastModifierUserId" });
            DropIndex("dbo.AbpUsers", new[] { "DeleterUserId" });
            DropIndex("dbo.AbpUsers", new[] { "IsDeleted" });
            DropIndex("dbo.AbpUsers", new[] { "TenantId" });
            DropIndex("dbo.AbpRoles", new[] { "CreatorUserId" });
            DropIndex("dbo.AbpRoles", new[] { "LastModifierUserId" });
            DropIndex("dbo.AbpRoles", new[] { "DeleterUserId" });
            DropIndex("dbo.AbpRoles", new[] { "IsDeleted" });
            DropIndex("dbo.AbpRoles", new[] { "TenantId" });
            DropIndex("dbo.AbpPermissions", new[] { "UserId" });
            DropIndex("dbo.AbpPermissions", new[] { "RoleId" });
            DropIndex("dbo.AbpPermissions", new[] { "TenantId" });
            DropIndex("dbo.AbpOrganizationUnits", new[] { "IsDeleted" });
            DropIndex("dbo.AbpOrganizationUnits", new[] { "ParentId" });
            DropIndex("dbo.AbpOrganizationUnits", new[] { "TenantId" });
            DropIndex("dbo.AbpOrganizationUnitRoles", new[] { "TenantId" });
            DropIndex("dbo.AbpNotificationSubscriptions", new[] { "NotificationName", "EntityTypeName", "EntityId", "UserId" });
            DropIndex("dbo.AbpNotificationSubscriptions", new[] { "TenantId" });
            DropIndex("dbo.zzd_Notices", new[] { "IsDeleted" });
            DropIndex("dbo.AbpLanguageTexts", new[] { "TenantId" });
            DropIndex("dbo.AbpLanguages", new[] { "IsDeleted" });
            DropIndex("dbo.AbpLanguages", new[] { "TenantId" });
            DropIndex("dbo.AbpEntityChangeSets", "IX_TenantId_UserId");
            DropIndex("dbo.AbpEntityChangeSets", new[] { "TenantId" });
            DropIndex("dbo.AbpEntityChangeSets", new[] { "TenantId", "Reason" });
            DropIndex("dbo.AbpEntityChangeSets", "IX_TenantId_CreationTime");
            DropIndex("dbo.AbpEntityPropertyChanges", new[] { "TenantId" });
            DropIndex("dbo.AbpEntityPropertyChanges", new[] { "EntityChangeId" });
            DropIndex("dbo.AbpEntityChanges", new[] { "TenantId" });
            DropIndex("dbo.AbpEntityChanges", new[] { "EntityTypeFullName", "EntityId" });
            DropIndex("dbo.AbpEntityChanges", new[] { "EntityChangeSetId" });
            DropIndex("dbo.AbpEditions", new[] { "IsDeleted" });
            DropIndex("dbo.AbpFeatures", new[] { "EditionId" });
            DropIndex("dbo.AbpFeatures", new[] { "TenantId" });
            DropIndex("dbo.CWeathers", new[] { "IsDeleted" });
            DropIndex("dbo.zzd_Pictures", new[] { "IsDeleted" });
            DropIndex("dbo.Company", new[] { "IsDeleted" });
            DropIndex("dbo.AbpBackgroundJobs", new[] { "IsAbandoned", "NextTryTime" });
            DropIndex("dbo.AbpAuditLogs", new[] { "TenantId" });
            DropIndex("dbo.zzd_Accounts", new[] { "IsDeleted" });
            DropTable("dbo.xylem_5400_view");
            DropTable("dbo.vaisala_wxt536_view");
            DropTable("dbo.AbpUserOrganizationUnits",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserOrganizationUnit_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_UserOrganizationUnit_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpUserNotifications",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserNotificationInfo_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpUserLoginAttempts",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserLoginAttempt_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpUserAccounts",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserAccount_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpTenants",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Tenant_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpTenantNotifications",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_TenantNotificationInfo_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpSettings",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Setting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpUserRoles",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserRole_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpUserLogins",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserLogin_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpUserClaims",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserClaim_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpUsers",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_User_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_User_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpRoles",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Role_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Role_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpPermissions",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PermissionSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_RolePermissionSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_UserPermissionSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpOrganizationUnits",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_OrganizationUnit_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_OrganizationUnit_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpOrganizationUnitRoles",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_OrganizationUnitRole_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpNotificationSubscriptions",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_NotificationSubscriptionInfo_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpNotifications");
            DropTable("dbo.zzd_Notices",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CNotice_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpLanguageTexts",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ApplicationLanguageText_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpLanguages",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ApplicationLanguage_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ApplicationLanguage_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpEntityChangeSets",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityChangeSet_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpEntityPropertyChanges",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityPropertyChange_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpEntityChanges",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityChange_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpEditions",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Edition_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpFeatures",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EditionFeatureSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_FeatureSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_TenantFeatureSetting_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.CWeathers",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CWeather_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.zzd_user");
            DropTable("dbo.CTides");
            DropTable("dbo.zzd_Pictures",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CPicture_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Company",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CCompany_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpBackgroundJobs");
            DropTable("dbo.AbpAuditLogs",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AuditLog_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.zzd_Accounts",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CAccount_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
