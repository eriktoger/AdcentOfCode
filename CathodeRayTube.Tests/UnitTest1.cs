namespace CathodeRayTube.Tests;
using Xunit;
using CathodeRayTube;
public class UnitTest1
{
    [Fact]
    public void Example()
    {
        string fullPath = Path.GetFullPath("example.txt");
        var answer = Solution.Solve(fullPath);
        Assert.Equal(13140, answer);
    }

    [Fact]
    public void PartOne()
    {
        string fullPath = Path.GetFullPath("part1.txt");
        var answer = Solution.Solve(fullPath);
        Assert.Equal(17020, answer);
    }


    private static void CompareFiles(string inputFile, string outputFile, string solutionFile)
    {

        File.WriteAllText(outputFile, string.Empty);
        Solution.Solve(inputFile, outputFile);

        var actualLines = File.ReadAllLines(outputFile);
        var expectedLines = File.ReadAllLines(solutionFile);


        Assert.Equal(expectedLines.Length, actualLines.Length);

        for (int i = 0; i < expectedLines.Length; i++)
        {
            Assert.Equal(expectedLines[i], actualLines[i]);
        }
    }


    [Fact]
    public void PartTwoExample()
    {
        string inputPath = Path.GetFullPath("example.txt");
        string outputPath = Path.GetFullPath("outputExample.txt");
        string solutionPath = Path.GetFullPath("outputExampleSolution.txt");
        CompareFiles(inputPath, outputPath, solutionPath);

    }

    [Fact]
    public void PartTwo()
    {
        string inputPath = Path.GetFullPath("part1.txt");
        string outputPath = Path.GetFullPath("output.txt");
        string solutionPath = Path.GetFullPath("outputSolution.txt");
        CompareFiles(inputPath, outputPath, solutionPath);
    }
}