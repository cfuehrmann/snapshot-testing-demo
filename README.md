# Snapshot Testing Demo with Verify and NUnit

A minimal .NET 9 project demonstrating snapshot testing using [Verify](https://github.com/VerifyTests/Verify) and NUnit.

## What is Snapshot Testing?

Snapshot testing captures the output of your code and saves it as a verified snapshot file. Future test runs compare new output against these snapshots, making it easy to detect unexpected changes. It's particularly useful for testing complex object graphs where writing manual assertions would be tedious and error-prone.

## Project Structure

```
snapshot-testing/
├── SnapshotDemo/                 # Production code
│   ├── Person.cs                 # Person and Address records
│   ├── ValidationResult.cs       # ValidationResult and ValidationMetadata records
│   └── PersonProcessor.cs        # System under test
└── SnapshotDemo.Tests/
    └── PersonProcessor/
        └── ValidatePersonTests/
            ├── Tests.cs          # Test cases
            ├── Tests.Basic.verified.txt
            ├── Tests.ExplicitScrubbing.verified.txt
            └── Tests.TestThatIncludesInput.verified.txt
```

## Key Concepts Demonstrated

### 1. Basic Snapshot Testing
The `Basic` test shows the simplest use case - verify the entire output structure with minimal configuration.

### 2. Implicit Scrubbing
Verify automatically scrubs (replaces with placeholders) certain types like `Guid` and `DateTime` to make tests deterministic. These appear as `Guid_1`, `DateTime_1`, etc. in snapshots.

### 3. Explicit Scrubbing
The `ExplicitScrubbing` test demonstrates how to scrub specific properties (like `Status`) that aren't automatically scrubbed.

### 4. Input/Output Verification
The `TestThatIncludesInput` test shows a powerful pattern: by including both input and output in the snapshot with `Verify(new { input, output })`, you can:
- Make snapshots more readable by showing the transformation
- Implicitly assert that certain values (like `PersonId`) are preserved from input to output

When the same `Guid` appears in both input and output, Verify assigns it the same placeholder (e.g., `Guid_2`), effectively asserting equality without explicit code.

### 5. Nested Objects
Both input (`Person` with nested `Address`) and output (`ValidationResult` with nested `ValidationMetadata`) demonstrate that snapshot testing handles complex object graphs effortlessly.

## Running the Tests

```bash
dotnet test
```

The first time you run a new test, Verify creates `.received.txt` files. Review these, and if correct, copy them to `.verified.txt` to approve the snapshot.

## File Organization

- `.verified.txt` files are committed to Git and represent the approved baseline
- `.received.txt` files are generated during test runs and ignored by Git (via `.gitignore`)
- Snapshots are co-located with test files for easy discovery

## Technologies

- .NET 9
- NUnit 4.4
- Verify.NUnit 31.0

## Learning Resources

- [Verify Documentation](https://github.com/VerifyTests/Verify)
- [Snapshot Testing Guide](https://github.com/VerifyTests/Verify/blob/main/docs/snapshot-testing.md)
