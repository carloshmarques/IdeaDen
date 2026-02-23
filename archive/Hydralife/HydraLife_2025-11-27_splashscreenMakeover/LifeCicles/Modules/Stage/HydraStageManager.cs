using LifeCicles.Boot_System;
using LifeCicles.Modules.Voice;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using HydraLife;
namespace LifeCicles.Modules.Stage
{
    public static class HydraStageManager
    {
        // 🎬 Sequência inicial do ritual
        public static async Task StartCeremonialSequence(SplashScreen splash)
        {
            splash.TriggerBackgroundFade(Color.LightBlue);
            splash.CreateTerminalPanel();
            splash.CreateCeremonialLabels();
            splash.CreateProgressBar();
            splash.PositionCeremonialLayout();

            await splash.StartLogoSlideWithPause();
            splash.AppendCeremonialMessage("[RITUAL] Terminal cerimonial iniciado.");
            splash.PlayCeremonialMusic(splash.MusicPath);
            splash.StartProgressTimer();
        }

        // 🎬 Entrada do logótipo com pausa
        public static async Task StartLogoSlideWithPause(this SplashScreen splash)
        {
            var logo = splash.PicLogo;
            if (logo == null) return;

            logo.Visible = true;
            int targetX = (splash.ClientSize.Width - logo.Width) / 2;
            logo.Location = new Point(-logo.Width, splash.terminalPanel.Top - 80);

            splash.logoSlide = new Timer { Interval = 15 };
            splash.logoSlide.Tick += async (s, e) =>
            {
                logo.Left += 12;
                if (logo.Left >= targetX)
                {
                    logo.Left = targetX;
                    splash.logoSlide.Stop();
                    splash.logoSlide.Dispose();

                    await Task.Delay(300); // pausa cerimonial
                    splash.PositionCeremonialLayout();
                    await Task.Delay(200);
                    splash.PicLogo.Top = splash.terminalPanel.Top - 80;
                }
            };
            splash.logoSlide.Start();
        }

        // 🎬 Progressão com pausas e comando final
        public static async Task HandleProgressMilestones(this SplashScreen splash, int percent, string frame)
        {
            if (percent == 30)
            {
                await Task.Delay(200);
                splash.AppendCeremonialMessage("[ PAUSA ] A Hydra contempla o meio do ritual...");
            }

            if (percent == 60)
            {
                await Task.Delay(300);
                splash.AppendCeremonialMessage("[ PAUSA ] Respiração profunda antes do final...");
            }

            if (percent == 90)
            {
                await Task.Delay(400);
                splash.RevealCeremonialButtons(); // se tiveres este método
                splash.AppendCeremonialMessage("[ FINALIZAÇÃO ] Preparando entrada dos botões...");
            }

            if (percent >= 100)
            {
                splash.timer1?.Stop();
                splash.spinnerTimer?.Stop();

                // Mensagem final cerimonial dentro do terminal
                splash.AppendCeremonialMessage($"[ OK ] Carregamento concluído. Ritual finalizado. {frame}");

                // Cursor continua vivo, piscando abaixo da última linha
                splash.lblCursor.BackColor = splash.terminalPanel.BackColor;
                splash.lblCursor.ForeColor = Color.LimeGreen;
                splash.lblCursor.Visible = true;

                HydraVoice.Volume = 50;
                splash.SpeakIfOpen("Carregamento concluído. Ritual finalizado.");

                await splash.TransitionToLogin();
            }


        }

        // 🎬 Transição final para login com fade
        public static async Task TransitionToLogin(this SplashScreen splash)
        {
            splash.splashClosed = true;
            splash.ritualTimer?.Stop();
            splash.spinnerTimer?.Stop();
            splash.cursorBlinkTimer?.Stop();

            try { HydraVoice.Stop(); } catch { /* silêncio cerimonial */ }

            for (double opacity = 1.0; opacity >= 0; opacity -= 0.05)
            {
                splash.Opacity = opacity;
                await Task.Delay(40);
            }

            splash.Hide();
            var loginForm = new LoginForm { Opacity = 0 };
            loginForm.Show();

            for (double opacity = 0; opacity <= 1.0; opacity += 0.05)
            {
                loginForm.Opacity = opacity;
                await Task.Delay(40);
            }
        }
    }
}
