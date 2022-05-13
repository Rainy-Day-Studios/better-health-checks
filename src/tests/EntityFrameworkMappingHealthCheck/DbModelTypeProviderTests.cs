using lib.EntityFrameworkMappingHealthCheck;
using Microsoft.EntityFrameworkCore;

namespace tests.EntityFrameworkMappingHealthCheck;

public class DbModelTypeProviderTests
{
  [Fact]
  public void GetDbModelTypes_PassedContextIsNull_ThrowsArgumentNullException()
  {
    // Arrange
    var typeProvider = new DbModelTypeProvider();

    // Act
    Assert.Throws<ArgumentNullException>(() => typeProvider.GetDbModelTypes(null));
  }

  [Fact]
  public void GetDbModelTypes_PassedContextHasProperties_ReturnsDbSetProperties()
  {
    // Arrange
    var typeProvider = new DbModelTypeProvider();

    var expectedTypes = new List<Type> { typeof(Student), typeof(Teacher) };

    // Act
    var foundTypes = typeProvider.GetDbModelTypes(new TestDbContext());

    // Assert
    foundTypes.Should().BeEquivalentTo(expectedTypes);
  }

  private class TestDbContext
  {
    public int NotADbModel { get; set; }
    public string AlsoNotADbModel { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public dynamic StillNotADbModel { get; set; }
    public DbSetNot NotADbSet { get; set; }
    public DbSet<Student> Students { get; set; }
  }

  private class DbSetNot { }

  private class Student
  {
    public int Id { get; set; }
  }

  private class Teacher
  {
    public int Id { get; set; }
  }
}