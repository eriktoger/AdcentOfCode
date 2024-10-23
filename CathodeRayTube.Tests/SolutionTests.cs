namespace CathodeRayTube.Tests;
using Xunit;
using CathodeRayTube;
public class UnitTest1
{
    [Fact]
    public void Example()
    {
        string filePath = "example.txt";
        var solution = new Solution(filePath);
        var answer = solution.Solve();
        Assert.Equal(13140, answer);
    }

    [Fact]
    public void PartOne()
    {
        string filePath = "part1.txt";
        var solution = new Solution(filePath);
        var answer = solution.Solve();
        Assert.Equal(17020, answer);
    }

    private static void CompareFiles(string inputFile, string outputFile, string solutionFile)
    {

        File.WriteAllText(outputFile, string.Empty);
        var solution = new Solution(inputFile, outputFile);
        solution.Solve();

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
        string inputPath = "example.txt";
        string outputPath = "outputExample.txt";
        string solutionPath = "outputExampleSolution.txt";
        CompareFiles(inputPath, outputPath, solutionPath);

    }

    [Fact]
    public void PartTwo()
    {
        string inputPath = "part1.txt";
        string outputPath = "output.txt";
        string solutionPath = "outputSolution.txt";
        CompareFiles(inputPath, outputPath, solutionPath);
    }
}