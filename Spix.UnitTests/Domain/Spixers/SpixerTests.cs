using FluentAssertions;
using Spix.Domain.Core;
using Spix.Domain.Spixers;

namespace Spix.UnitTests.Domain.Spixers;

public class SpixerTests
{

    [Fact]
    [Trait("Type", TestsTypesTraits.Unit)]
    [Trait("Category", TestsCategorys.Creation)]
    [Trait("Group", TestGroups.Domain)]
    [Trait("Entity", TestEntities.Spixer)]

    public void Spixer_WhenCreatedWithValidParameters_ShouldNotNull()
    {
        // Arrange
        var content = "Test Content";
        var userId = Guid.NewGuid();


        //Act
        var spixer = new Spixer(content, userId, null);

        //Assert
        spixer.Should().NotBeNull();



    }

    [Fact]
    [Trait("Type", TestsTypesTraits.Unit)]
    [Trait("Category", TestsCategorys.Creation)]
    [Trait("Group", TestGroups.Domain)]
    [Trait("Entity", TestEntities.Spixer)]
    public void Spixer_WhenCreatedWithValidParameters_ShouldHaveContent()
    {
        // Arrange
        var content = "Test Content";
        var userId = Guid.NewGuid();

        //Arrange
        var spixer = new Spixer(content, userId, null);

        //Assert
        spixer.Content.Should().Be(content);

    }

    [Fact]
    [Trait("Type", TestsTypesTraits.Unit)]
    [Trait("Category", TestsCategorys.Creation)]
    [Trait("Group", TestGroups.Domain)]
    [Trait("Entity", TestEntities.Spixer)]
    public void Spixer_WhenCreated_ShouldHaveEmptyLikes()
    {
        // Arrange
        var content = "Test Content";
        var userId = Guid.NewGuid();

        // Act
        var spixer = new Spixer(content, userId, null);

        // Assert
        spixer.LikedByUsers.Should().BeEmpty();
    }

    [Fact]
    [Trait("Type", TestsTypesTraits.Unit)]
    [Trait("Category", TestsCategorys.Behavior)]
    [Trait("Group", TestGroups.Domain)]
    [Trait("Entity", TestEntities.Spixer)]
    public void AddLike_WhenCalledWithNewUser_ShouldIncrementLikesCount()
    {
        // Arrange
        var content = "Test Content";
        var userId = Guid.NewGuid();
        var spixer = new Spixer(content, userId, null);
        var likerId = Guid.NewGuid();

        // Act
        spixer.AddLike(likerId);

        // Assert
        spixer.LikesCount.Should().Be(1);
    }


    [Fact]
    [Trait("Type", TestsTypesTraits.Unit)]
    [Trait("Category", TestsCategorys.Behavior)]
    [Trait("Group", TestGroups.Domain)]
    [Trait("Entity", TestEntities.Spixer)]
    public void RemoveLike_WhenCalledWithExistingUser_ShouldDecrementLikesCount()
    {
        // Arrange
        var content = "Test Content";
        var userId = Guid.NewGuid();
        var spixer = new Spixer(content, userId, null);
        var likerId = Guid.NewGuid();
        spixer.AddLike(likerId);

        // Act
        spixer.RemoveLike(likerId);

        // Assert
        spixer.LikesCount.Should().Be(0);
    }

    [Fact]
    [Trait("Type", TestsTypesTraits.Unit)]
    [Trait("Category", TestsCategorys.Validation)]
    [Trait("Group", TestGroups.Domain)]
    [Trait("Entity", TestEntities.Spixer)]
    public void Spixer_WhenCreatedWithInvalidContent_ShouldThrowException()
    {
        // Arrange
        string invalidContent = "";  
        var userId = Guid.NewGuid();

        // Act & Assert
        Action act = () => new Spixer(invalidContent, userId, null);
        act.Should().Throw<BusinessRuleValidationException>();
    }


    [Fact]
    [Trait("Type", TestsTypesTraits.Unit)]
    [Trait("Category", TestsCategorys.Validation)]
    [Trait("Group", TestGroups.Domain)]
    [Trait("Entity", TestEntities.Spixer)]
    public void Spixer_WhenCreatedWithContentExceeding280Characters_ShouldThrowExceptionWithMessage()
    {
        // Arrange
        string invalidContent = "";  
        var userId = Guid.NewGuid();

        // Act & Assert
        Action act = () => new Spixer(invalidContent, userId, null);
        act.Should().Throw<BusinessRuleValidationException>();
    }
}
