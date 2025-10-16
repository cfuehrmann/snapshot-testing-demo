namespace SnapshotDemo;

public record Address(
    string Street,
    string City,
    string PostalCode,
    Guid AddressId,
    DateTime CreatedAt
);

public record Person(
    string FirstName,
    string LastName,
    Address Address,
    Guid PersonId,
    DateTime DateOfBirth,
    DateTime LastUpdated
);

public record ValidationResult(
    Guid PersonId,
    bool IsValid,
    string Status,
    List<string> Warnings,
    DateTime ValidatedAt,
    Guid ValidationId
);
