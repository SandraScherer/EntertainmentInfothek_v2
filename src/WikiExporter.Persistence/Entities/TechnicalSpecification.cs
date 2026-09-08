using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>TechnicalSpecification</c>. The entity is persistence-only.</summary>
public sealed class TechnicalSpecification
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
    public BusinessModel? BusinessModel { get; set; }

    /// <summary>Navigation for FK <c>MinimumCDRomDriveSpeedID</c> to <c>CDROMDriveSpeed</c>.</summary>
    public CDROMDriveSpeed? MinimumCDRomDriveSpeed { get; set; }

    /// <summary>Navigation for FK <c>MinimumCPUClassID</c> to <c>CPU</c>.</summary>
    public CPU? MinimumCPUClass { get; set; }

    /// <summary>Navigation for FK <c>MinimumDirectXID</c> to <c>DirectX</c>.</summary>
    public DirectX? MinimumDirectX { get; set; }

    /// <summary>Navigation for FK <c>MinimumOSClassID</c> to <c>OperatingSystem</c>.</summary>
    public OperatingSystem? MinimumOSClass { get; set; }

    /// <summary>Navigation for FK <c>MinimumRAMID</c> to <c>RAM</c>.</summary>
    public RAM? MinimumRAM { get; set; }

    /// <summary>Navigation for FK <c>MinimumVideoRAMID</c> to <c>RAM</c>.</summary>
    public RAM? MinimumVideoRAM { get; set; }

    /// <summary>Navigation for FK <c>PlatformID</c> to <c>Platform</c>.</summary>
    public Platform? Platform { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }

    /// <summary>Navigation for FK <c>VideoGameID</c> to <c>VideoGame</c>.</summary>
    public VideoGame? VideoGame { get; set; }

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationCopyProtection> TechnicalSpecificationCopyProtections { get; set; } = new List<TechnicalSpecificationCopyProtection>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationMacOSSprocket> TechnicalSpecificationMacOSSprockets { get; set; } = new List<TechnicalSpecificationMacOSSprocket>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationMediaType> TechnicalSpecificationMediaTypes { get; set; } = new List<TechnicalSpecificationMediaType>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationMultiplayerGameMode> TechnicalSpecificationMultiplayerGameModes { get; set; } = new List<TechnicalSpecificationMultiplayerGameMode>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationMultiplayerOption> TechnicalSpecificationMultiplayerOptions { get; set; } = new List<TechnicalSpecificationMultiplayerOption>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationRequiredAdditionalHardware> TechnicalSpecificationRequiredAdditionalHardwares { get; set; } = new List<TechnicalSpecificationRequiredAdditionalHardware>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationRequiredInputDevice> TechnicalSpecificationRequiredInputDevices { get; set; } = new List<TechnicalSpecificationRequiredInputDevice>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationSaveGameMethod> TechnicalSpecificationSaveGameMethods { get; set; } = new List<TechnicalSpecificationSaveGameMethod>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationSupportedAdditionalHardware> TechnicalSpecificationSupportedAdditionalHardwares { get; set; } = new List<TechnicalSpecificationSupportedAdditionalHardware>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationSupportedDriver> TechnicalSpecificationSupportedDrivers { get; set; } = new List<TechnicalSpecificationSupportedDriver>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationSupportedInputDevice> TechnicalSpecificationSupportedInputDevices { get; set; } = new List<TechnicalSpecificationSupportedInputDevice>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationSupportedInputDeviceFeature> TechnicalSpecificationSupportedInputDeviceFeatures { get; set; } = new List<TechnicalSpecificationSupportedInputDeviceFeature>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationSupportedSoundDevice> TechnicalSpecificationSupportedSoundDevices { get; set; } = new List<TechnicalSpecificationSupportedSoundDevice>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationSupportedSoundMode> TechnicalSpecificationSupportedSoundModes { get; set; } = new List<TechnicalSpecificationSupportedSoundMode>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationSupportedVideoMode> TechnicalSpecificationSupportedVideoModes { get; set; } = new List<TechnicalSpecificationSupportedVideoMode>();

    /// <summary>Dependent rows referencing this TechnicalSpecification.</summary>
    public ICollection<TechnicalSpecificationSupportedVideoResolution> TechnicalSpecificationSupportedVideoResolutions { get; set; } = new List<TechnicalSpecificationSupportedVideoResolution>();
}
