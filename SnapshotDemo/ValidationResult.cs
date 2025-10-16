namespace SnapshotDemo;

public record ValidationResult(
    Guid PersonId,
    bool IsValid,
    string Status,
    List<string> Warnings,
    ValidationMetadata Metadata
);

public record ValidationMetadata(
    Guid ValidationId,
    DateTime ValidatedAt,
    string ValidatorVersion
);
