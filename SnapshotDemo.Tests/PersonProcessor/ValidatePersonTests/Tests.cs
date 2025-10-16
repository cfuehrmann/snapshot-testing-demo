using NUnit.Framework;
using SnapshotDemo;

namespace SnapshotDemo.Tests.PersonProcessor.ValidatePersonTests;

[TestFixture]
public class Tests
{
    private SnapshotDemo.PersonProcessor _processor = null!;

    [SetUp]
    public void Setup()
    {
        _processor = new SnapshotDemo.PersonProcessor();
    }

    [Test]
    public Task Basic()
    {
        var address = new Address(
            Street: "123 main st",
            City: "new york",
            PostalCode: "10001",
            AddressId: Guid.Parse("11111111-1111-1111-1111-111111111111"),
            CreatedAt: new DateTime(2023, 1, 15, 10, 30, 0, DateTimeKind.Utc)
        );

        var person = new Person(
            FirstName: "john",
            LastName: "DOE",
            Address: address,
            PersonId: Guid.Parse("22222222-2222-2222-2222-222222222222"),
            DateOfBirth: new DateTime(1990, 5, 15),
            LastUpdated: new DateTime(2023, 1, 1, 9, 0, 0, DateTimeKind.Utc)
        );

        var output = _processor.ValidatePerson(person);

        return Verify(output);
    }

    [Test]
    public Task ExplicitScrubbing()
    {
        var address = new Address(
            Street: "456 elm street",
            City: "los angeles",
            PostalCode: "90210",
            AddressId: Guid.Parse("33333333-3333-3333-3333-333333333333"),
            CreatedAt: new DateTime(2023, 2, 20, 14, 45, 0, DateTimeKind.Utc)
        );

        var person = new Person(
            FirstName: "jane",
            LastName: "smith",
            Address: address,
            PersonId: Guid.Parse("44444444-4444-4444-4444-444444444444"),
            DateOfBirth: new DateTime(1985, 8, 22),
            LastUpdated: new DateTime(2023, 2, 1, 11, 30, 0, DateTimeKind.Utc)
        );

        var output = _processor.ValidatePerson(person);

        return Verify(output)
            .ScrubMember<ValidationResult>(x => x.Status);
    }

    // By including input in the verification, we can
    // 1. Make the snapshot more readable
    // 2. Assert equalities between input and output properties. (Here `PersonId`)
    [Test]
    public Task TestThatIncludesInput()
    {
        var inputPersonId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
        var inputAddressId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
        
        var address = new Address(
            Street: "789 Oak Avenue",
            City: "chicago",
            PostalCode: "60601",
            AddressId: inputAddressId,
            CreatedAt: new DateTime(2023, 3, 10, 16, 20, 0, DateTimeKind.Utc)
        );

        var input = new Person(
            FirstName: "alice",
            LastName: "JOHNSON",
            Address: address,
            PersonId: inputPersonId,
            DateOfBirth: new DateTime(1992, 11, 3),
            LastUpdated: new DateTime(2023, 3, 1, 8, 15, 0, DateTimeKind.Utc)
        );

        var output = _processor.ValidatePerson(input);

        Assert.That(output.PersonId, Is.EqualTo(inputPersonId), 
            "Person ID should be preserved from input to output");

        return Verify(new { input, output });
    }
}
