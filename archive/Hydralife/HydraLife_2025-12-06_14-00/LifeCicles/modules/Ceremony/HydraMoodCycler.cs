using System;
using System.Drawing;
using System.Windows.Forms;

namespace HydraLife.Modules.Ceremony
{
    public static class HydraMoodCycler
    {
        private static string[] moods = { "Sereno", "Eufórico", "Melancólico", "Ritualístico" };
        private static int moodIndex = 0;
        private static Timer moodTimer;

        // Inicia o ciclo automático de moods
        public static void Start(Form targetForm)
        {
            moodTimer = new Timer();
            moodTimer.Interval = 10000; // muda a cada 10 segundos
            moodTimer.Tick += (sender, args) =>
            {
                string currentMood = moods[moodIndex];
                ApplyMood(targetForm, currentMood);
                Console.WriteLine($"🌀 Mood atual: {currentMood}");
                moodIndex = (moodIndex + 1) % moods.Length;
            };
            moodTimer.Start();
        }

        // Aplica cor e música conforme mood
        public static void ApplyMood(Form splash, string mood)
        {
            switch (mood)
            {
                case "Sereno":
                    splash.BackColor = Color.LightSkyBlue;
                    Console.WriteLine("🎵 Música ambiente calma iniciada.");
                    break;

                case "Eufórico":
                    splash.BackColor = Color.OrangeRed;
                    Console.WriteLine("🎵 Música energética iniciada.");
                    break;

                case "Melancólico":
                    splash.BackColor = Color.DarkBlue;
                    Console.WriteLine("🎵 Piano suave iniciado.");
                    break;

                case "Ritualístico":
                    splash.BackColor = Color.Purple;
                    Console.WriteLine("🎵 Música litúrgica iniciada.");
                    break;

                default:
                    splash.BackColor = Color.Black;
                    Console.WriteLine("🎵 Música padrão iniciada.");
                    break;
            }
        }
    }
}
