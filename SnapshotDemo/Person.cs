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
