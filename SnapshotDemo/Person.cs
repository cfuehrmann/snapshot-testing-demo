namespace SnapshotDemo;

public record Person(
    string FirstName,
    string LastName,
    Address Address,
    Guid PersonId,
    DateTime LastUpdated
);

public record Address(
    string City,
    Guid AddressId,
    DateTime CreatedAt
);
