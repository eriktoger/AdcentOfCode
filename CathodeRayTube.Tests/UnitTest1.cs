namespace CathodeRayTube.Tests;
using Xunit;
using CathodeRayTube;
public class UnitTest1
{
    [Fact]
    public void Example()
    {
        string fullPath = Path.GetFullPath("example.txt");
        var answer = Solution.PartOne(fullPath);
        Assert.Equal(13140, answer);
    }

    [Fact]
    public void PartOne()
    {
        string fullPath = Path.GetFullPath("part1.txt");
        var answer = Solution.PartOne(fullPath);
        Assert.Equal(17020, answer);
    }
}