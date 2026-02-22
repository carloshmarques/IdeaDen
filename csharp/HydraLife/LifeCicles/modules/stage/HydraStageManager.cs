// Usings necessários
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using LifeCicles.Boot_System;

// Referências internas do projeto
using HydraLife;                          // SplashScreen, LoginForm
using LifeCicles.Modules.Themes;          // ThemeManifest
using LifeCicles.Modules.Voice;           // HydraVoice (se usado)
using HydraLife.LifeCicles.Modules.UI;    // SmoothRichTextBox
using LifeCicles.Properties;              // Resources
using HydraLife.Modules.UI;               // SmoothTransitions

namespace HydraLife.Modules.Ceremony
{
    public static class HydraStageManager
    {
        // Sequência principal do ritual
        public static async Task StartCeremonialSequence(SplashScreen splash)
        {
            // 1. Coluna: logo + terminal
            await PositionLogoAndTerminal(splash);

            // 2. Tema
            if (splash.Theme != null)
                ApplyTheme(splash, splash.Theme);

            // 3. Música
            if (!string.IsNullOrEmpty(splash.MusicPath))
                PlayBackgroundMusic(splash.MusicPath);

            // 4. Mood cycle (ativar quando existir)
            // HydraMoodCycler.Start(splash);

            // 5. Progress bar lógica interna
            splash.HydraProgressBar.Minimum = 0;
            splash.HydraProgressBar.Maximum = 100;
            splash.HydraProgressBar.Value = 0;
            splash.HydraProgressBar.Visible = true;
        }

        // Posiciona logo, progress bar e terminal
        private static async Task PositionLogoAndTerminal(SplashScreen splash)
        {
            // Logo cerimonial
            splash.HydraLogo = new PictureBox
            {
                Size = new Size(150, 150),
                Location = new Point(
                    (splash.ClientSize.Width - 200) / 2,
                    (splash.ClientSize.Height - 200) / 4
                ),
                Image = Resources.hydra1,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent
            };
            splash.Controls.Add(splash.HydraLogo);
            splash.HydraLogo.BringToFront();

            // Progress bar invisível
            splash.HydraProgressBar.Minimum = 0;
            splash.HydraProgressBar.Maximum = 100;
            splash.HydraProgressBar.Value = 0;
            splash.HydraProgressBar.Visible = true;

            await Task.Delay(1500);

            // Terminal panel proporcional
            int terminalTop = splash.HydraLogo.Bottom + 20;
            int terminalHeight = (int)(splash.ClientSize.Height * 0.37);

            Panel terminalPanel = new Panel
            {
                Width = (int)(splash.ClientSize.Width * 0.88),
                Height = terminalHeight,
                Location = new Point(
                    (splash.ClientSize.Width - (int)(splash.ClientSize.Width * 0.88)) / 2,
                    terminalTop
                ),
                BackColor = splash.BackColor,
                BorderStyle = BorderStyle.None
            };
            splash.Controls.Add(terminalPanel);
            terminalPanel.BringToFront();

            splash.bootMessagesRtb = new SmoothRichTextBox
            {
                Dock = DockStyle.Fill,
                BackColor = splash.BackColor,
                ForeColor = Color.LimeGreen,
                Font = new Font("Consolas", 10, FontStyle.Bold),
                ReadOnly = true,
                ScrollBars = RichTextBoxScrollBars.None
            };

            terminalPanel.Controls.Add(splash.bootMessagesRtb);

            // Fade inicial cerimonial (agora via SmoothTransitions)
            await SmoothTransitions.TriggerBackgroundFade(splash, Color.LightBlue);
        }

        // Aplica tema plasma
        private static void ApplyTheme(SplashScreen splash, ThemeManifest theme)
        {
            splash.BackColor = ColorTranslator.FromHtml(theme.PrimaryColor ?? "#000000");
            splash.Font = new Font(theme.FontFamily ?? "Segoe UI", 10);
        }

        // Música cerimonial
        private static void PlayBackgroundMusic(string path)
        {
            string ext = Path.GetExtension(path).ToLowerInvariant();
            if (ext == ".wav")
                new System.Media.SoundPlayer(path).Play();

            // MP3 só se tiveres referência ao WMPLib
            // else if (ext == ".mp3")
            // {
            //     var wmp = new WMPLib.WindowsMediaPlayer();
            //     wmp.URL = path;
            //     wmp.controls.play();
            // }
        }

        // Transição final para login
        public static void TransitionToLogin(SplashScreen splash)
        {
            LoginForm login = new LoginForm();
            login.Show();
            splash.Hide();
        }
    }
}
