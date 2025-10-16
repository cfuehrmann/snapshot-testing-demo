namespace SnapshotDemo;

public class PersonProcessor
{
    public ValidationResult ValidatePerson(Person inputPerson)
    {
        var warnings = new List<string>();
        
        if (inputPerson.FirstName != inputPerson.FirstName.Trim())
            warnings.Add("FirstName contains leading or trailing whitespace");
            
        if (inputPerson.LastName != inputPerson.LastName.Trim())
            warnings.Add("LastName contains leading or trailing whitespace");
            
        if (inputPerson.Address.City != inputPerson.Address.City.Trim())
            warnings.Add("City contains leading or trailing whitespace");
            
        if (char.IsLower(inputPerson.FirstName[0]))
            warnings.Add("FirstName should start with uppercase letter");
            
        if (char.IsLower(inputPerson.LastName[0]))
            warnings.Add("LastName should start with uppercase letter");
        
        var isValid = warnings.Count == 0;
        var status = isValid ? "Valid" : "Has Warnings";
        
        return new ValidationResult(
            PersonId: inputPerson.PersonId,
            IsValid: isValid,
            Status: status,
            Warnings: warnings,
            ValidatedAt: DateTime.UtcNow,
            ValidationId: Guid.NewGuid()
        );
    }
}

public static class StringExtensions
{
    public static string ToTitleCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;
            
        return char.ToUpper(input[0]) + input[1..].ToLower();
    }
}
