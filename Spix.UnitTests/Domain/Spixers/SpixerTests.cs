using FluentAssertions;
using Spix.Domain.Core.SeedOfWork;
using Spix.Domain.Entities;

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
        var spixer = new Spixer(content, userId);

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
        var spixer = new Spixer(content, userId);

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
        var spixer = new Spixer(content, userId);

        // Assert
        spixer.SpixerLikes.Should().BeEmpty();  
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
        var spixer = new Spixer(content, userId);
        var likerId = Guid.NewGuid();
        
        var like = new SpixerLike(likerId, spixer.Id); 
        // Act
        spixer.Like(like);

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
        var spixer = new Spixer(content, userId);
        var likerId = Guid.NewGuid();
        var like = new SpixerLike(likerId, spixer.Id);

        spixer.Like(like);

        // Act
        spixer.Unlike(like);

        // Assert
        spixer.LikesCount.Should().Be(0);
    }

    [Fact]
    [Trait("Type", TestsTypesTraits.Unit)]
    [Trait("Category", TestsCategorys.Validation)]
    [Trait("Group", TestGroups.Domain)]
    [Trait("Entity", TestEntities.Spixer)]
    public void Spixer_WhenCreatedWithInvalidContent_ShouldFailure()
    {
        // Arrange
        string invalidContent = "";  
        var userId = Guid.NewGuid();

        // Act & Assert
        var result = Spixer.Create(invalidContent, userId);
        result.IsFailure.Should().BeTrue();
    }


    [Fact]
    [Trait("Type", TestsTypesTraits.Unit)]
    [Trait("Category", TestsCategorys.Validation)]
    [Trait("Group", TestGroups.Domain)]
    [Trait("Entity", TestEntities.Spixer)]
    public void ShouldFailure()
    {
        // Arrange
        string invalidContent = "";  
        var userId = Guid.NewGuid();

        // Act & Assert
        var result =  Spixer.Create(invalidContent, userId);
        
        result.IsFailure.Should().BeTrue();

    }
}
