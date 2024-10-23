
namespace CathodeRayTube;
public static class Solution
{

    private static void Draw(int xRegister, int cycleCounter, string outputFilePath)
    {
        using StreamWriter writer = new(outputFilePath, append: true);
        var xPosition = cycleCounter % 40;

        if (xPosition == 0 && cycleCounter != 0)
        {
            writer.WriteLine("");
        }

        var hitsThreeSprites = xPosition == xRegister - 1 || xPosition == xRegister || xPosition == xRegister + 1;
        if (hitsThreeSprites)
        {
            writer.Write("#");
        }
        else
        {
            writer.Write(".");
        }

    }
    public static int Solve(string filePath, string outputFilePath = "")
    {
        int sum = 0;
        int xRegister = 1;
        int[] cycleCheckPoints = [20, 60, 100, 140, 180, 220];
        int cycleCounter = 0;


        using (StreamReader reader = new(filePath))
        {
            string line;
            while ((line = reader.ReadLine()!) != null)
            {

                if (outputFilePath != "")
                {
                    Draw(xRegister, cycleCounter, outputFilePath);
                }
                cycleCounter++;
                if (cycleCheckPoints.Contains(cycleCounter))
                {
                    sum += xRegister * cycleCounter;
                }

                if (line.StartsWith("addx "))
                {

                    if (outputFilePath != "")
                    {
                        Draw(xRegister, cycleCounter, outputFilePath);
                    }
                    cycleCounter++;

                    if (cycleCheckPoints.Contains(cycleCounter))
                    {
                        sum += xRegister * cycleCounter;
                    }

                    string[] parts = line.Split(' ');
                    int number = int.Parse(parts[1]);

                    xRegister += number;
                }
            }
        }
        return sum;
    }
}