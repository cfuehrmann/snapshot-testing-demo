namespace SnapshotDemo;

public record Address(
    string City,
    Guid AddressId,
    DateTime CreatedAt
);

public record Person(
    string FirstName,
    string LastName,
    Address Address,
    Guid PersonId,
    DateTime LastUpdated
);

public record ValidationMetadata(
    Guid ValidationId,
    DateTime ValidatedAt,
    string ValidatorVersion
);

public record ValidationResult(
    Guid PersonId,
    bool IsValid,
    string Status,
    List<string> Warnings,
    ValidationMetadata Metadata
);
