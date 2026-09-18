using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>TechnicalSpecification</c>. The entity is persistence-only.</summary>
public sealed class TechnicalSpecificationEntity
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>VideoGameID</c>.</summary>
    public string? VideoGameId { get; set; }
    /// <summary>Maps to <c>PlatformID</c>.</summary>
    public string? PlatformId { get; set; }
    /// <summary>Maps to <c>BusinessModelID</c>.</summary>
    public string? BusinessModelId { get; set; }
    /// <summary>Maps to <c>MinimumCPUClassID</c>.</summary>
    public string? MinimumCPUClassId { get; set; }
    /// <summary>Maps to <c>MinimumOSClassID</c>.</summary>
    public string? MinimumOSClassId { get; set; }
    /// <summary>Maps to <c>MinimumRAMID</c>.</summary>
    public string? MinimumRAMId { get; set; }
    /// <summary>Maps to <c>MinimumDirectXID</c>.</summary>
    public string? MinimumDirectXId { get; set; }
    /// <summary>Maps to <c>MinimumCDRomDriveSpeedID</c>.</summary>
    public string? MinimumCDRomDriveSpeedId { get; set; }
    /// <summary>Maps to <c>MinimumVideoRAMID</c>.</summary>
    public string? MinimumVideoRAMId { get; set; }
    /// <summary>Maps to <c>NoOfPlayersOffline</c>.</summary>
    public string? NoOfPlayersOffline { get; set; }
    /// <summary>Maps to <c>NoOfPlayersOfflineMultitap</c>.</summary>
    public string? NoOfPlayersOfflineMultitap { get; set; }
    /// <summary>Maps to <c>NoOfPlayersOnline</c>.</summary>
    public string? NoOfPlayersOnline { get; set; }
    /// <summary>Maps to <c>EnglishAnnotation</c>.</summary>
    public string? EnglishAnnotation { get; set; }
    /// <summary>Maps to <c>GermanAnnotation</c>.</summary>
    public string? GermanAnnotation { get; set; }
    /// <summary>Maps to <c>MiscAttributes</c>.</summary>
    public string? MiscAttributes { get; set; }
    /// <summary>Maps to <c>Details</c>.</summary>
    public string? Details { get; set; }
    /// <summary>Maps to <c>Notes</c>.</summary>
    public string? Notes { get; set; }
    /// <summary>Maps to <c>StatusID</c>.</summary>
    public string? StatusId { get; set; }
    /// <summary>Maps to <c>LastUpdated</c>.</summary>
    public string? LastUpdated { get; set; }

    /// <summary>Navigation for FK <c>BusinessModelID</c> to <c>BusinessModel</c>.</summary>
    public BusinessModelEntity? BusinessModelEntity { get; set; }

    /// <summary>Navigation for FK <c>MinimumCDRomDriveSpeedID</c> to <c>CDROMDriveSpeed</c>.</summary>
    public CDROMDriveSpeedEntity? MinimumCDRomDriveSpeed { get; set; }

    /// <summary>Navigation for FK <c>MinimumCPUClassID</c> to <c>CPU</c>.</summary>
    public CPUEntity? MinimumCPUClass { get; set; }

    /// <summary>Navigation for FK <c>MinimumDirectXID</c> to <c>DirectX</c>.</summary>
    public DirectXEntity? MinimumDirectX { get; set; }

    /// <summary>Navigation for FK <c>MinimumOSClassID</c> to <c>OperatingSystem</c>.</summary>
    public OperatingSystemEntity? MinimumOSClass { get; set; }

    /// <summary>Navigation for FK <c>MinimumRAMID</c> to <c>RAM</c>.</summary>
    public RAMEntity? MinimumRAM { get; set; }

    /// <summary>Navigation for FK <c>MinimumVideoRAMID</c> to <c>RAM</c>.</summary>
    public RAMEntity? MinimumVideoRAM { get; set; }

    /// <summary>Navigation for FK <c>PlatformID</c> to <c>Platform</c>.</summary>
    public PlatformEntity? PlatformEntity { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public StatusEntity? StatusEntity { get; set; }

    /// <summary>Navigation for FK <c>VideoGameID</c> to <c>VideoGame</c>.</summary>
    public VideoGameEntity? VideoGameEntity { get; set; }

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationCopyProtectionEntity> TechnicalSpecificationCopyProtections { get; set; } = new List<TechnicalSpecificationCopyProtectionEntity>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationMacOSSprocketEntity> TechnicalSpecificationMacOSSprockets { get; set; } = new List<TechnicalSpecificationMacOSSprocketEntity>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationMediaTypeEntity> TechnicalSpecificationMediaTypes { get; set; } = new List<TechnicalSpecificationMediaTypeEntity>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationMultiplayerGameModeEntity> TechnicalSpecificationMultiplayerGameModes { get; set; } = new List<TechnicalSpecificationMultiplayerGameModeEntity>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationMultiplayerOptionEntity> TechnicalSpecificationMultiplayerOptions { get; set; } = new List<TechnicalSpecificationMultiplayerOptionEntity>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationRequiredAdditionalHardwareEntity> TechnicalSpecificationRequiredAdditionalHardwares { get; set; } = new List<TechnicalSpecificationRequiredAdditionalHardwareEntity>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationRequiredInputDeviceEntity> TechnicalSpecificationRequiredInputDevices { get; set; } = new List<TechnicalSpecificationRequiredInputDeviceEntity>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationSaveGameMethodEntity> TechnicalSpecificationSaveGameMethods { get; set; } = new List<TechnicalSpecificationSaveGameMethodEntity>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationSupportedAdditionalHardwareEntity> TechnicalSpecificationSupportedAdditionalHardwares { get; set; } = new List<TechnicalSpecificationSupportedAdditionalHardwareEntity>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationSupportedDriverEntity> TechnicalSpecificationSupportedDrivers { get; set; } = new List<TechnicalSpecificationSupportedDriverEntity>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationSupportedInputDeviceEntity> TechnicalSpecificationSupportedInputDevices { get; set; } = new List<TechnicalSpecificationSupportedInputDeviceEntity>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationSupportedInputDeviceFeatureEntity> TechnicalSpecificationSupportedInputDeviceFeatures { get; set; } = new List<TechnicalSpecificationSupportedInputDeviceFeatureEntity>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationSupportedSoundDeviceEntity> TechnicalSpecificationSupportedSoundDevices { get; set; } = new List<TechnicalSpecificationSupportedSoundDeviceEntity>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationSupportedSoundModeEntity> TechnicalSpecificationSupportedSoundModes { get; set; } = new List<TechnicalSpecificationSupportedSoundModeEntity>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationSupportedVideoModeEntity> TechnicalSpecificationSupportedVideoModes { get; set; } = new List<TechnicalSpecificationSupportedVideoModeEntity>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationSupportedVideoResolutionEntity> TechnicalSpecificationSupportedVideoResolutions { get; set; } = new List<TechnicalSpecificationSupportedVideoResolutionEntity>();
}
