using FluentAssertions;
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
}
