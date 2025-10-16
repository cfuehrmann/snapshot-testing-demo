namespace SnapshotDemo;

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
