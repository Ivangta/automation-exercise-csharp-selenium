using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationExercise.Tests.Helpers
{
    public static class RandomDataGenerator
    {
        public static string GenerateRandomString(int length = 10)
        {
            const string chars =
                "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            Random random = new Random();

            return new string(
                Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());
        }
    }
}
