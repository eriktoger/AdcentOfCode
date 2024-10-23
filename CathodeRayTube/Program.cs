
namespace CathodeRayTube;
public static class Solution
{
    public static int PartOne(string filePath)
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
                cycleCounter++;
                if (cycleCheckPoints.Contains(cycleCounter))
                {
                    sum += xRegister * cycleCounter;
                }

                if (line.StartsWith("addx "))
                {
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