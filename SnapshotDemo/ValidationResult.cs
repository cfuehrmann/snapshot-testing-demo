namespace SnapshotDemo;

public record ValidationResult(
    Guid PersonId,
    bool IsValid,
    string Status,
    List<string> Warnings,
    ValidationMetadata Metadata // nested data, relevant for snapshot demo!
);

public record ValidationMetadata(
    Guid ValidationId,
    DateTime ValidatedAt,
    string ValidatorVersion
);
