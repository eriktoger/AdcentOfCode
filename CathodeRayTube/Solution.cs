
namespace CathodeRayTube;
public class Solution(string inputFilePath, string? outputFilePath = null)
{
    private readonly int width = 40;
    private readonly int spriteRange = 2;
    private readonly string _inputFilePath = inputFilePath;
    private readonly string? _outputFilePath = outputFilePath;
    private readonly string addOperation = "addx";
    private readonly char litPixel = '#';
    private readonly char darkPixel = '.';

    private void Draw(int xRegister, int cycleCounter)
    {
        if (_outputFilePath == null)
        {
            return;
        }

        using StreamWriter writer = new(_outputFilePath, append: true);
        var xPosition = cycleCounter % width;

        var addNewLine = xPosition == 0 && cycleCounter != 0;
        if (addNewLine)
        {
            writer.WriteLine();
        }

        var isInsideSpriteRange = xPosition > xRegister - spriteRange &&
                                  xPosition < xRegister + spriteRange;
        if (isInsideSpriteRange)
        {
            writer.Write(litPixel);
        }
        else
        {
            writer.Write(darkPixel);
        }
    }

    private void UpdateSum(ref int sum, int xRegister, int cycleCounter)
    {
        var middleOfScreen = cycleCounter % width == width / 2;
        if (middleOfScreen)
        {
            sum += xRegister * cycleCounter;
        }
    }

    private void HandleCycle(ref int sum, int xRegister, ref int cycleCounter)
    {
        Draw(xRegister, cycleCounter);

        cycleCounter++;

        UpdateSum(ref sum, xRegister, cycleCounter);
    }

    private static void UpdateXRegister(string line, ref int xRegister)
    {
        string[] parts = line.Split(' ');
        xRegister += int.Parse(parts[1]);
    }

    public int Solve()
    {
        int sum = 0;
        int xRegister = 1;
        int cycleCounter = 0;

        using (StreamReader reader = new(_inputFilePath))
        {
            string line;
            while ((line = reader.ReadLine()!) != null)
            {
                HandleCycle(ref sum, xRegister, ref cycleCounter);

                if (line.StartsWith(addOperation))
                {
                    HandleCycle(ref sum, xRegister, ref cycleCounter);
                    UpdateXRegister(line, ref xRegister);
                }
            }
        }

        return sum;
    }
}