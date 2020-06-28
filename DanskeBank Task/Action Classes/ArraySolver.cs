using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingTask
{
    public static class ArraySolver
    {
        public static bool Solve(int[] numbers, out List<int> path)
        {
            List<int> maxIndexPath = new List<int> { 0 };
            List<List<int>> numbersPaths = new List<List<int>>();
            path = new List<int>();

            foreach (var number in numbers)
            {
                numbersPaths.Add(new List<int>());
            }

            bool result;
            if (numbers.Length == 0)
            {
                result = false;
            }
            else
            {
                path.Add(0);
                result = IsWinnable(numbers, maxIndexPath, numbersPaths, path);
            }

            FilterCorrectPath(path);

            return result;
        }

        private static bool IsWinnable(int[] numbers, List<int> maxIndexPath, List<List<int>> numbersPaths, List<int> path, int currentIndex = 0)
        {
            int currentNumber = numbers[currentIndex];

            // If number is positive
            if (currentNumber > 0)
            {
                for (int i = currentNumber; i >= 1; i--)
                {
                    int next = currentIndex + i;

                    NextStep(next, currentIndex, numbers, numbersPaths, maxIndexPath, path);

                    if (maxIndexPath[maxIndexPath.Count - 1] == numbers.Length - 1) return true;
                }
            }
            // If number is negative
            else
            {
                for (int i = currentNumber; i < 0; i++)
                {
                    int next = currentIndex + i;

                    NextStep(next, currentIndex, numbers, numbersPaths, maxIndexPath, path);

                    if (maxIndexPath[maxIndexPath.Count - 1] == numbers.Length - 1) return true;
                }
            }

            return false;
        }

        private static void NextStep(int next, int currentIndex, int[] numbers, List<List<int>> numbersPaths, List<int> maxIndexPath, List<int> path)
        {
            if (next <= numbers.Length - 1 &&
                next >= 0 &&
                !numbersPaths[currentIndex].Contains(next) &&
                (numbers[next] != 0 || next == numbers.Length - 1))
            {
                if (next > maxIndexPath[maxIndexPath.Count - 1]) maxIndexPath.Add(next);
                path.Add(next);

                if (!numbersPaths[currentIndex].Contains(next)) numbersPaths[currentIndex].Add(next);

                IsWinnable(numbers, maxIndexPath, numbersPaths, path, next);
            }
        }
        private static void FilterCorrectPath(List<int> path)
        {
            for (int i = 1; i < path.Count; i++)
            {
                if (path[i - 1] >= path[i])
                {
                    path.RemoveAt(i - 1);
                    i--;
                }
            }

            path = path.Distinct().ToList();
        }

    }
}