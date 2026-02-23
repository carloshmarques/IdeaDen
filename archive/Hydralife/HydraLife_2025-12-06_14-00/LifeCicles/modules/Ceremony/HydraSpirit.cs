using System;

namespace HydraLife.Modules.Ceremony
{
    public static class HydraSpirit
    {
        private static readonly string[] moods = {
            "Sereno",
            "Eufórico",
            "Melancólico",
            "Ritualístico",
            "Empático",
            "Filosófico",
            "Humorístico",
            "Surrealista"
        };

        private static readonly Random rng = new Random();

        // Escolhe mood aleatório
        public static string GetCurrentMood()
        {
            return moods[rng.Next(moods.Length)];
        }
    }
}
