using System;
using System.Windows.Forms;
using System.Drawing;   // 👈 necessário para usar Color
using LifeCicles.Modules.Media;
using LifeCicles.Modules;
using LifeCicles.Modules.UI;


namespace LifeCicles.Modules.UI
{
    internal class SplashScreenManager
    {
        public static void TriggerBackgroundFade(Form targetForm, Color targetColor)
        {
            Color startColor = targetForm.BackColor;
            int steps = 20, step = 0;

            Timer fadeTimer = new Timer { Interval = 50 };
            fadeTimer.Tick += (s, e) =>
            {
                int r = startColor.R + (targetColor.R - startColor.R) * step / steps;
                int g = startColor.G + (targetColor.G - startColor.G) * step / steps;
                int b = startColor.B + (targetColor.B - startColor.B) * step / steps;

                targetForm.BackColor = Color.FromArgb(r, g, b);
                step++;
                if (step > steps)
                {
                    fadeTimer.Stop();
                    fadeTimer.Dispose();
                }
            };
            fadeTimer.Start();
        }

        public static SplashVisual AdaptVisual(string mood)
        {

            SplashVisual style;

            switch (mood)
            {
                case "Sereno":
                    style = SplashVisual.DarkAscend;
                    break;
                case "Eufórico":
                    style = SplashVisual.SurrealPulse;
                    break;
                case "Melancólico":
                    style = SplashVisual.MinimalFade;
                    break;
                case "Ritualístico":
                    style = SplashVisual.LightDescend;
                    break;
                default:
                    style = SplashVisual.MinimalFade;
                    break;
            }

            return style;

        }

        public static void ShowEntrySplash()
        {
            // Primeiro, obtém o estado emocional
            string mood = HydraMediaLexicon.GetCurrentMood();

            // Depois, invoca os elementos cerimoniais
            string message = HydraMediaLexicon.GetSplashMessage(mood);
            string music = HydraMediaLexicon.GetSuggestedTrack(mood);
            SplashVisual style = SplashScreenManager.AdaptVisual(mood);

            // Finalmente, constrói e mostra o splash
            var splash = new SplashForm
            {
                Message = message,
                MusicPath = music,
                VisualStyle = style
            };

            splash.Show();
        }


        // 👉 Também static void
        public static void ShowExitSplash()
        {
            var splash = new SplashForm
            {
                Message = "🌌 Encerramento cerimonial\nA Hydra repousa, mas a memória permanece.",
                MusicPath = "Assets/Sounds/wagner_outro.mp3",
                VisualStyle = SplashVisual.LightDescend
            };
            splash.Show();
        }
    }

    internal enum SplashVisual
    {
        DarkAscend,
        LightDescend,
        SurrealPulse,
        MinimalFade
    }

    internal class SplashForm : Form
    {
        public string Message { get; set; }
        public string MusicPath { get; set; }
        public SplashVisual VisualStyle { get; set; }

    }
}

