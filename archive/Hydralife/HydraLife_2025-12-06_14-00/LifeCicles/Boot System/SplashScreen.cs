using HydraLife.Modules.Ceremony;
using LifeCicles.Modules.Themes;
using System;
using System.Drawing;
using System.Windows.Forms;
using HydraLife.Modules.UI; // SmoothTransitions

namespace HydraLife
{
    public partial class SplashScreen : Form
    {
        // Controles principais expostos para o StageManager
        public PictureBox HydraLogo { get; set; }
        public RichTextBox bootMessagesRtb { get; set; }

        // Wrapper property; no name collision with designer field
        public ProgressBar SplashProgressBar => this.progressBar1;

        public ThemeManifest Theme { get; set; }
        public string MusicPath { get; set; }
        public string Message { get; set; }

        public SplashScreen()
        {
            InitializeComponent();
            this.Load += SplashScreen_Load;
        }

        // Wrapper público para a progress bar do designer
        public ProgressBar HydraProgressBar
        {
            get => progressBar2;
            private set => progressBar2 = value;
        }


        private async void SplashScreen_Load(object sender, EventArgs e)
        {
            // Mensagem inicial mínima
            if (bootMessagesRtb != null)
                bootMessagesRtb.AppendText("[SYSTEM] Ritual iniciado...\r\n");

            // Entregar ao maestro (HydraStageManager cuida do fade e da sequência)
            await HydraStageManager.StartCeremonialSequence(this);
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEndSession_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
