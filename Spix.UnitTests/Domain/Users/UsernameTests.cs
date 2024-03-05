using FluentAssertions;
using Spix.Domain.SeedOfWork;
using Spix.Domain.ValueObjects;

namespace Spix.UnitTests.Domain.Users;

public class UsernameTests
{
    [Fact]
    [Trait("Type", TestsTypesTraits.Unit)]
    [Trait("Category", TestsCategorys.Validation)]
    [Trait("Group", TestGroups.Domain)]
    [Trait("Entity", TestEntities.UserSpix)]
    public void Username_WhenCreatedWithValidParameters_ShouldNotBeNull()
    {
        // Arrange
        var value = "validUsername";

        // Act
        var userName = new Username(value);

        // Assert
        userName.Should().NotBeNull();
    }

    [Fact]
    [Trait("Type", TestsTypesTraits.Unit)]
    [Trait("Category", TestsCategorys.Validation)]
    [Trait("Group", TestGroups.Domain)]
    [Trait("Entity", TestEntities.UserSpix)]
    public void Username_WhenCreatedWithValidParameters_ShouldHaveCorrectValue()
    {
        // Arrange
        var value = "validUsername";

        // Act
        var userName = new Username(value);

        // Assert
        userName.Value.Should().Be(value);
    }

    [Fact]
    [Trait("Type", TestsTypesTraits.Unit)]
    [Trait("Category", TestsCategorys.Validation)]
    [Trait("Group", TestGroups.Domain)]
    [Trait("Entity", TestEntities.UserSpix)]
    public void Username_WhenCreatedWithEmptyValue_ShouldThrowException()
    {
        // Arrange
        var value = "";

        // Act & Assert
        Action act = () => new Username(value);
        act.Should().Throw<BusinessRuleValidationException>()
           .WithMessage("Username cannot be empty");
    }

    [Fact]
    [Trait("Type", TestsTypesTraits.Unit)]
    [Trait("Category", TestsCategorys.Validation)]
    [Trait("Group", TestGroups.Domain)]
    [Trait("Entity", TestEntities.UserSpix)]
    public void Username_WhenLengthIsLessThanMinLength_ShouldThrowException()
    {
        // Arrange
        var value = "ab";  

        // Act & Assert
        Action act = () => new Username(value);
        act.Should().Throw<BusinessRuleValidationException>()
           .WithMessage("Username must be at least 3 characters long");
    }

    [Fact]
    [Trait("Type", TestsTypesTraits.Unit)]
    [Trait("Category", TestsCategorys.Validation)]
    [Trait("Group", TestGroups.Domain)]
    [Trait("Entity", TestEntities.UserSpix)]
    public void Username_WhenLengthExceedsMaxLength_ShouldThrowException()
    {
        // Arrange
        var value = new string('a', Username.MaxLength + 1 );  

        // Act & Assert
        Action act = () => new Username(value);
        act.Should().Throw<BusinessRuleValidationException>()
           .WithMessage($"Username must be at most {Username.MaxLength} characters long");
    }
}
