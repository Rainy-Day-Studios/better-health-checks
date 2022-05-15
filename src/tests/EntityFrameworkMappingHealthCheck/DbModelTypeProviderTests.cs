using BetterHealthChecks;
using BetterHealthChecks.EntityFrameworkMappingHealthCheck;
using Microsoft.EntityFrameworkCore;

namespace tests.EntityFrameworkMappingHealthCheck;

public class DbModelTypeProviderTests
{
    [Fact]
    public void GetDbModelTypes_PassedContextHasProperties_ReturnsDbSetProperties()
    {
        // Arrange
        var typeProvider = new DbModelTypeProvider();

        var expectedTypes = new List<Type> { typeof(Student), typeof(Teacher) };

        // Act
        var foundTypes = typeProvider.GetDbModelTypes<TestDbContext1>();

        // Assert
        foundTypes.Should().BeEquivalentTo(expectedTypes);
    }

    [Fact]
    public void GetDbModelTypes_DbContextHasHealthCheckIgnore_ReturnsDbSetWithoutIgnore()
    {
        // Arrange
        var typeProvider = new DbModelTypeProvider();

        var expectedTypes = new List<Type> { typeof(Student) };

        // Act
        var foundTypes = typeProvider.GetDbModelTypes<TestDbContext2>();

        // Assert
        foundTypes.Should().BeEquivalentTo(expectedTypes);
    }

    private class TestDbContext1 : DbContext
    {
        public int NotADbModel { get; set; }
        public string AlsoNotADbModel { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public dynamic StillNotADbModel { get; set; }
        public DbSetNot NotADbSet { get; set; }
        public DbSet<Student> Students { get; set; }
    }

    private class TestDbContext2 : DbContext
    {
        public DbSet<Student> Students { get; set; }

        [HealthCheckIgnore]
        public DbSet<Teacher> IgnoredTeachers { get; set; }
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