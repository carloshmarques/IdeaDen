using HydraLife.Modules;
using LifeCicles.Boot_System;
using LifeCicles.Modules;
using LifeCicles.Modules.Ceremony;
using LifeCicles.Modules.Helpers;
using LifeCicles.Modules.Lexicon;
using LifeCicles.Modules.Stage; 
using LifeCicles.Modules.Themes;
using LifeCicles.Modules.UI;
using LifeCicles.Modules.Voice;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HydraLife
{
    public partial class SplashScreen : Form
    {
        public class SmoothRichTextBox : RichTextBox
        {
            public SmoothRichTextBox()
            {
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                this.SetStyle(ControlStyles.ResizeRedraw, true);
                this.SetStyle(ControlStyles.UserPaint, false);
                this.UpdateStyles();
            }
        }

        // Timers usados externamente
        public System.Windows.Forms.Timer timer1;
        public Timer logoSlide;
        public Timer ritualTimer;
        public Timer spinnerTimer;
        public Timer cursorBlinkTimer;

        // Controles visuais acessíveis externamente
        public PictureBox PictureBox2;
        public Panel terminalPanel;
        public RichTextBox bootMessagesRtb;
        public Label lblCursor, lblMessage, lblSpinner, label3, label2;

        // Propriedades já públicas
        public ThemeManifest Theme { get; set; }
        public string MusicPath { get; set; }

        // Campos internos (mantidos privados)
        private string startTimeFormatted;
        private HydraTerminalConfig _terminal;
        private bool themeMessageShown = false;
        public bool splashClosed = false; // ← usado externamente, agora público
        private bool terminalRitualSpoken = false;
        private bool temaAnunciado = false;
        private bool moodNarrado = false;
        private bool diretóriosCriados = false;
        private bool ritualFinalizado = false;


        // Construtor
        public SplashScreen()
        {
            InitializeComponent();
            this.Load += SplashScreen_Load;
        }
        public void CreateProgressBar()
        {
            if (progressBar1 != null) return;

            progressBar1 = new ProgressBar
            {
                Name = "progressBar1",
                Minimum = 0,
                Maximum = 100,
                Value = 0,
                Height = 18,
                Visible = true,
                Style = ProgressBarStyle.Continuous
            };

            this.Controls.Add(progressBar1);
            progressBar1.BringToFront();
        }

       public void PositionProgressBarRightOfLabel()
        {
            if (progressBar1 == null || lblMessage == null) return;

            int spacing = 12;
            int safeRight = this.ClientSize.Width - 20;
            int buttonsLeftBoundary = safeRight;

            if (btnCloseApp != null)
                buttonsLeftBoundary = Math.Min(buttonsLeftBoundary, btnCloseApp.Left);

            // A barra deve parar 100px antes dos botões
            int maxRightForBar = buttonsLeftBoundary - 100;

            int left = lblMessage.Right + spacing;
            int desiredWidth = Math.Max(120, maxRightForBar - left); // grande, mas com respiro
            int maxWidthByTerminal = terminalPanel != null ? Math.Max(120, terminalPanel.Width) : desiredWidth;

            progressBar1.Width = Math.Min(desiredWidth, maxWidthByTerminal);
            progressBar1.Left = left;

            // Colocar mais acima, próximo do terminal
            int top = terminalPanel != null ? terminalPanel.Bottom + 8 : Math.Max(0, lblMessage.Top - 4);
            progressBar1.Top = top;

            progressBar1.Visible = true;
            progressBar1.BringToFront();
        }


       public void PositionCeremonialLayout()
        {
            if (terminalPanel != null && PicLogo != null)
            {
                terminalPanel.Left = 70; // 👈 ajuste cerimonial para a direita
                terminalPanel.Top = PicLogo.Bottom + 20;
            }

            PositionCeremonialLabels();
            PositionProgressBarRightOfLabel();
        }

        public void EnsureProgressBarVisibleBounds()
        {
            if (progressBar1 == null) return;

            // largura mínima para não desaparecer
            progressBar1.Width = Math.Max(80, progressBar1.Width);

            // manter dentro dos limites horizontais da janela
            if (progressBar1.Left < 0)
                progressBar1.Left = 0;
            if (progressBar1.Right > this.ClientSize.Width)
                progressBar1.Left = this.ClientSize.Width - progressBar1.Width - 4;

            // manter dentro dos limites verticais da janela
            if (progressBar1.Top < 0)
                progressBar1.Top = 0;
            if (progressBar1.Bottom > this.ClientSize.Height)
                progressBar1.Top = this.ClientSize.Height - progressBar1.Height - 4;

            // garantir visibilidade e ordem cerimonial
            progressBar1.Visible = true;
            progressBar1.BringToFront();
        }

        public void SplashScreen_Resize(object sender, EventArgs e)
        {
            PositionCeremonialLayout();        // centraliza terminal, labels e progress bar
            EnsureProgressBarVisibleBounds();  // garante que a barra não sai da tela
            UpdateTerminalLayout();            // atualiza cursor e scroll
        }


        public async Task TransitionToLogin(int pauseMs = 3500)
        {
            splashClosed = true;

            // parar voz imediatamente
            HydraVoice.Stop();

            // parar timers
            ritualTimer?.Stop();
            spinnerTimer?.Stop();
            cursorBlinkTimer?.Stop();
            timer1?.Stop();

            ritualTimer = null;
            spinnerTimer = null;
            cursorBlinkTimer = null;
            timer1 = null;

            // pausa cerimonial antes de esconder
            await Task.Delay(pauseMs);

            this.Hide();
            var loginForm = new LoginForm();
            loginForm.Show();
        }



        // Método de entrada
        private async void SplashScreen_Load(object sender, EventArgs e)
        {
            // Ajustes gráficos básicos
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.BackColor = Color.Black;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            // Hora cerimonial
            startTimeFormatted = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // 👉 Chama o maestro que orquestra todo o ritual
            await HydraStageManager.StartCeremonialSequence(this);

            // Evento de resize
            this.Resize += SplashScreen_Resize;

            // Tema
            string manifestPath = Path.Combine(HydraDataPath, "App", "Settings", "Theme", "ThemeManifest.json");
            if (!File.Exists(manifestPath)) CopyThemeManifest();

            ThemeManifest theme = HydraThemeManager.LoadThemeManifest(manifestPath);
            ApplyTheme(theme);
        }





        // Diretórios essenciais
        private readonly string[] appDirectories = {
            "App", "App\\Data", "App\\Settings", "App\\Shared", "App\\Users",
            "App\\Settings\\Theme", "App\\Shared\\Documents", "App\\Shared\\Music"
        };

        // Caminho base
        public static string HydraDataPath =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HydraLife");

        #region VisualCeremony

        private const int TerminalTop = 600;

        // Painel cerimonial do terminal
        public void CreateTerminalPanel()
        {
            if (terminalPanel != null) return;

            int terminalWidth = (int)(this.ClientSize.Width * 0.72);
            int top = PicLogo != null ? PicLogo.Bottom + 20 : 120;

            terminalPanel = new Panel
            {
                Size = new Size(terminalWidth, 240),
                Location = new Point((this.ClientSize.Width - terminalWidth) / 2 - 40, top),
                BackColor = this.BackColor,
                BorderStyle = BorderStyle.FixedSingle,
                AutoScroll = false
            };

            bootMessagesRtb = new SmoothRichTextBox
            {
                Dock = DockStyle.Fill,
                BackColor = this.BackColor,
                ForeColor = Color.LimeGreen,
                Font = new Font("Consolas", 10),
                ScrollBars = RichTextBoxScrollBars.None,
                ReadOnly = false
            };

            terminalPanel.Controls.Add(bootMessagesRtb);
            this.Controls.Add(terminalPanel);
            terminalPanel.BringToFront();

            _terminal = new HydraTerminalConfig(bootMessagesRtb);
        }






        // Labels cerimoniais
        public void CreateCeremonialLabels()
        {
            label3 = new Label
            {
                AutoSize = true,
                Font = new Font("Consolas", 10, FontStyle.Bold),
                ForeColor = Color.LimeGreen,
                BackColor = Color.Transparent,
                Text = "[ OK ]"
            };

            lblSpinner = new Label
            {
                AutoSize = true,
                Font = new Font("Consolas", 10),
                ForeColor = Color.LimeGreen,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft
            };

            lblMessage = new Label
            {
                AutoSize = true,
                Font = new Font("Consolas", 11, FontStyle.Bold),
                ForeColor = Color.LimeGreen,
                BackColor = Color.Transparent,
                Text = "🔄 Carregando componentes cerimoniais..."
            };

            label2 = new Label
            {
                AutoSize = true,
                Font = new Font("Consolas", 9),
                ForeColor = Color.LimeGreen,
                BackColor = Color.Transparent,
                Text = $"Application started at: {startTimeFormatted}"
            };

            // Cursor discreto
            if (lblCursor == null)
            {
                lblCursor = new Label
                {
                    AutoSize = false,
                    Size = new Size(8, 18),
                    Font = new Font("Consolas", 10, FontStyle.Regular),
                    ForeColor = Color.LimeGreen,
                    BackColor = bootMessagesRtb.BackColor,
                    Text = "_",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Visible = true
                }; ;
            }

            this.Controls.Add(label3);
            this.Controls.Add(lblSpinner);
            this.Controls.Add(lblMessage);
            this.Controls.Add(label2);
            this.Controls.Add(lblCursor);

            // Timer de piscar do cursor
            cursorBlinkTimer = new Timer { Interval = 500 };
            cursorBlinkTimer.Tick += (s, e) =>
            {
                if (lblCursor != null && !splashClosed)
                    lblCursor.Visible = !lblCursor.Visible;
            };
            cursorBlinkTimer.Start();
        }

        // Posiciona os labels abaixo do terminal e ajusta o cursor
        private void PositionCeremonialLabels()
        {
            if (terminalPanel != null && lblMessage != null)
            {
                int labelOffsetLeft = terminalPanel.Left + 20; // 👈 alinhado com o terminal
                lblMessage.Left = labelOffsetLeft;
                lblMessage.Top = terminalPanel.Bottom + 8;
            }

            int baseY = terminalPanel.Bottom + 10;

            label3.Location = new Point(terminalPanel.Left + 10, baseY);
            lblSpinner.Location = new Point(label3.Left, label3.Bottom + 5);
            lblMessage.Location = new Point(lblSpinner.Left, lblSpinner.Bottom + 5);
            label2.Location = new Point(label3.Right + 10, label3.Top);

            // Cursor deve piscar na linha abaixo das mensagens
            int lineHeight = TextRenderer.MeasureText("A", bootMessagesRtb.Font).Height;
            int cursorX = terminalPanel.Left + 10;
            int cursorY = terminalPanel.Top + (lineHeight * (bootMessagesRtb.Lines.Length + 1)) + 8;
            lblCursor.Location = new Point(cursorX, cursorY);

            label3.BringToFront();
            lblSpinner.BringToFront();
            lblMessage.BringToFront();
            label2.BringToFront();
            lblCursor.BringToFront();
        }

        // Atualiza layout do terminal e reposiciona cursor
        private void UpdateTerminalLayout()
        {
            if (terminalPanel == null || bootMessagesRtb == null) return;

            bootMessagesRtb.Dock = DockStyle.Fill;
            bootMessagesRtb.SelectionStart = bootMessagesRtb.TextLength;
            bootMessagesRtb.ScrollToCaret();

            // Cursor vivo → uma linha abaixo do último texto
            int lineHeight = TextRenderer.MeasureText("A", bootMessagesRtb.Font).Height;
            int cursorX = terminalPanel.Left + 10;
            int cursorY = terminalPanel.Top + (lineHeight * (bootMessagesRtb.Lines.Length + 1)) + 8;

            if (lblCursor != null)
            {
                lblCursor.Location = new Point(cursorX, cursorY);
                lblCursor.BringToFront();
            }
        }

        // Transição suave de cor de fundo
        public void TriggerBackgroundFade(Color targetColor)
        {
            Color startColor = this.BackColor;
            int steps = 20, step = 0;

            Timer fadeTimer = new Timer { Interval = 50 };
            fadeTimer.Tick += (s, e) =>
            {
                int r = startColor.R + (targetColor.R - startColor.R) * step / steps;
                int g = startColor.G + (targetColor.G - startColor.G) * step / steps;
                int b = startColor.B + (targetColor.B - startColor.B) * step / steps;

                this.BackColor = Color.FromArgb(r, g, b);
                step++;
                if (step > steps)
                {
                    fadeTimer.Stop();
                    fadeTimer.Dispose();
                }
            };
            fadeTimer.Start();
        }


        #endregion

        // Cria todos os componentes visuais cerimoniais
        public void EnsureCeremonialControls()
        {
            if (PictureBox2 == null)
            {
                PictureBox2 = new PictureBox
                {
                    Size = new Size(300, 120),
                    Location = new Point(-300, 100),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.Transparent,
                    Visible = true
                };
                this.Controls.Add(PictureBox2);
            }

            int terminalWidth = (int)(this.ClientSize.Width * 0.75);
            int top = PictureBox2.Bottom + 20;

            terminalPanel = new Panel
            {
                Size = new Size(terminalWidth, 240),
                Location = new Point((this.ClientSize.Width - terminalWidth) / 2, top),
                BackColor = Color.Transparent,
                BorderStyle = BorderStyle.FixedSingle
            };

            bootMessagesRtb = new SmoothRichTextBox
            {
                Dock = DockStyle.Fill,
                BackColor = this.BackColor,

                ForeColor = Color.LimeGreen,
                Font = new Font("Consolas", 10),
                ScrollBars = RichTextBoxScrollBars.None
            };

            terminalPanel.Controls.Add(bootMessagesRtb);
            this.Controls.Add(terminalPanel);
        }




        #region MessageCeremony

        // Adiciona uma nova linha cerimonial ao terminal
        public void AppendCeremonialMessage(string message, Color? color = null)
        {
            if (bootMessagesRtb == null || bootMessagesRtb.IsDisposed) return;

            bootMessagesRtb.SelectionStart = bootMessagesRtb.TextLength;
            bootMessagesRtb.SelectionColor = color ?? Color.LimeGreen;
            bootMessagesRtb.AppendText(message + Environment.NewLine);
            bootMessagesRtb.SelectionColor = bootMessagesRtb.ForeColor;

            const int MaxLines = 20;
            if (bootMessagesRtb.Lines.Length > MaxLines)
            {
                var lines = bootMessagesRtb.Lines.Skip(bootMessagesRtb.Lines.Length - MaxLines).ToArray();
                bootMessagesRtb.Lines = lines;
            }

            bootMessagesRtb.SelectionStart = bootMessagesRtb.TextLength;
            bootMessagesRtb.ScrollToCaret();

            // 👉 Cursor sempre abaixo da última linha
            int lineHeight = TextRenderer.MeasureText("A", bootMessagesRtb.Font).Height;
            int cursorX = terminalPanel.Left + 10;
            int cursorY = terminalPanel.Top + (lineHeight * (bootMessagesRtb.Lines.Length + 1)) + 8;
            if (lblCursor != null)
            {
                lblCursor.Location = new Point(cursorX, cursorY);
                lblCursor.BringToFront();
            }
        }


        // Atualiza a última linha cerimonial (ex.: spinner ou estado vivo)
        public void UpdateLastCeremonialLine(string message, Color? color = null)
        {
            if (bootMessagesRtb == null || bootMessagesRtb.IsDisposed) return;

            var lines = bootMessagesRtb.Lines;
            if (lines.Length == 0)
            {
                AppendCeremonialMessage(message, color);
                return;
            }

            lines[lines.Length - 1] = message;
            bootMessagesRtb.Lines = lines;

            bootMessagesRtb.SelectionStart = bootMessagesRtb.TextLength;
            bootMessagesRtb.SelectionColor = color ?? Color.LimeGreen;
            bootMessagesRtb.ScrollToCaret();

            // 👉 Cursor sempre abaixo da última linha
            int lineHeight = TextRenderer.MeasureText("A", bootMessagesRtb.Font).Height;
            int cursorX = terminalPanel.Left + 10;
            int cursorY = terminalPanel.Top + (lineHeight * (bootMessagesRtb.Lines.Length + 1)) + 8;
            if (lblCursor != null)
            {
                lblCursor.Location = new Point(cursorX, cursorY);
                lblCursor.BringToFront();
            }
        }


         public void UpdateProgressMessage()
        {
            if (lblMessage == null || progressBar1 == null) return;

            progressBar1.Value = Math.Min(progressBar1.Value + 10, progressBar1.Maximum);
            lblMessage.Text = $"🔄 Progresso: {progressBar1.Value}%";

            if (progressBar1.Value == 10 && !themeMessageShown)
            {
                TriggerBackgroundFade(Color.DarkBlue);
                AppendCeremonialMessage("[RITUAL] Terminal cerimonial iniciado.");
                AppendCeremonialMessage($"[ OK ] 🎯 Tema atual: {Theme?.Name ?? "Desconhecido"}");
                SpeakIfOpen("Terminal cerimonial iniciado.");
                themeMessageShown = true;
            }
        }

        #endregion

        #region DirectoriesAndTheme
        private bool directoriesCreated = false;

        public void InjectSystemDirectories()
        {
            if (directoriesCreated) return;

            foreach (string dir in appDirectories)
            {
                string fullPath = Path.Combine(HydraDataPath, dir);
                Directory.CreateDirectory(fullPath);
                AppendCeremonialMessage($"[ OK ] Created: {fullPath}");
            }

            directoriesCreated = true;
        }



        public void CopyThemeManifest()
        {
            string sourcePath = Path.Combine(
                Application.StartupPath,
                @"..\..\..\LifeCicles\Assets\Themes\Colorful-Plasma-Themes\ThemeManifest.json"
            );

            string targetPath = Path.Combine(HydraDataPath, "App", "Settings", "Theme", "ThemeManifest.json");

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(targetPath));
                File.Copy(sourcePath, targetPath, true);
                AppendCeremonialMessage("[ OK ] Tema cerimonial copiado para diretório App/Settings/Theme.");
            }
            catch (Exception ex)
            {
                AppendCeremonialMessage($"[ ERRO ] Falha ao copiar tema: {ex.Message}");
            }
        }

        public void CopyThemeToBase()
        {
            string sourcePath = Path.Combine(
                Application.StartupPath,
                @"..\..\..\LifeCicles\Assets\Themes\Colorful-Plasma-Themes\ThemeManifest.json"
            );

            string targetPath = Path.Combine(HydraDataPath, "ThemeManifest.json");

            try
            {
                Directory.CreateDirectory(HydraDataPath);
                File.Copy(sourcePath, targetPath, true);
                AppendCeremonialMessage("[ OK ] Tema copiado para diretório base.");
            }
            catch (Exception ex)
            {
                AppendCeremonialMessage($"[ ERRO ] Falha ao copiar tema base: {ex.Message}");
            }
        }

       public void ApplyTheme(ThemeManifest theme)
        {
            if (theme == null)
            {
                AppendCeremonialMessage("[ERRO] Tema não encontrado.");
                return;
            }

            this.Theme = theme;
            HydraThemeManager.Apply(theme);

            AppendCeremonialMessage($"[ OK ] 🎯 Tema atual: {Theme?.Name ?? "null"}");

            this.BackColor = ColorTranslator.FromHtml(Theme.PrimaryColor ?? "#000000");
            this.Font = new Font(Theme.FontFamily ?? "Segoe UI", 10);
        }

        #endregion

        #region VoiceAndMusic

       public void PlayCeremonialMusic(string path)
        {
            if (string.IsNullOrEmpty(path)) return;

            string ext = Path.GetExtension(path).ToLowerInvariant();

            try
            {
                if (ext == ".wav")
                {
                    var player = new System.Media.SoundPlayer(path);
                    player.Play();
                }
                else if (ext == ".mp3")
                {
                    var wmp = new WMPLib.WindowsMediaPlayer();
                    wmp.URL = path;
                    wmp.controls.play();
                }
                else
                {
                    SpeakIfOpen("Formato de música não suportado.");
                }
            }
            catch
            {
                SpeakIfOpen($"Falha ao tocar música {ext.ToUpperInvariant()}.");
            }
        }

        private void RitualTimer_Tick(object sender, EventArgs e)
        {
            ritualTimer.Stop();

            if (Theme != null)
            {
                if (!splashClosed)
                {
                    SpeakIfOpen($"Bem-vindo ao ritual Hydra. Tema atual: {Theme.Name}.");
                    HydraVoice.NarrateMood(Theme.Mood);
                }
            }
            else
            {
                if (!splashClosed)
                    SpeakIfOpen("Bem-vindo ao ritual Hydra. Tema não definido.");
            }
        }

        #endregion

        #region AnimationAndBreath

      
        public void StartLogoSlide(PictureBox logo)
        {
            if (logo == null) return;

            logo.Visible = true;
            int targetX = (this.ClientSize.Width - logo.Width) / 2;
            int targetY = logo.Location.Y;
            logo.Location = new Point(-logo.Width, targetY);

            logoSlide = new Timer { Interval = 15 };
            logoSlide.Tick += async (s, e) =>
            {
                logo.Left += 12;
                if (logo.Left >= targetX)
                {
                    logo.Left = targetX;
                    logoSlide.Stop();
                    logoSlide.Dispose();

                    await Task.Delay(300);

                    CreateTerminalPanel();
                    
                    AppendCeremonialMessage("[RITUAL] Terminal cerimonial iniciado.");

                    if (!splashClosed && !terminalRitualSpoken)
                    {
                        SpeakIfOpen("Terminal cerimonial iniciado.");
                        terminalRitualSpoken = true;
                    }

                    CreateCeremonialLabels();
                    PositionCeremonialLabels();

                    PlayCeremonialMusic(MusicPath);
                    await Task.Delay(300);
                    TriggerBackgroundFade(Color.LightBlue);

                    spinnerTimer = new Timer { Interval = 500 };
                    spinnerTimer.Tick += SpinnerTimer_Tick;
                    spinnerTimer.Start();
                    CreateProgressBar(); // 👈 garante que está visível e posicionada
                    StartProgressTimer();

                }
            };

            logoSlide.Start();
        }



        
        public void SpeakIfOpen(string text)
        {
            if (!splashClosed) HydraVoice.Speak(text);
        }






        // Estado do spinner
        private bool respirationAnnounced = false;
        private int spinnerCycles = 0;
        private int maxSpinnerCycles = 10;
        private int spinnerIndex = 0;
        private readonly string[] spinnerFrames = { "|", "/", "-", ".", "..", "...", "\\" };

        // Spinner de respiração
        private async void SpinnerTimer_Tick(object sender, EventArgs e)
        {
            if (bootMessagesRtb == null || bootMessagesRtb.IsDisposed || lblSpinner == null) return;

            string frame = spinnerFrames[spinnerIndex];
            spinnerIndex = (spinnerIndex + 1) % spinnerFrames.Length;

            if (spinnerCycles == 0)
            {
                AppendCeremonialMessage("[Loading] Hydra deu a 1ª golfada de ar!");
                SpeakIfOpen("Hydra deu a primeira golfada de ar.");
            }
            else if (spinnerCycles < maxSpinnerCycles)
            {
                UpdateLastCeremonialLine($"[Loading] Hydra está a respirar {frame}");
            }
            else
            {
                string finalLine = $"[ OK ] Respiração estabilizada {frame}";
                UpdateLastCeremonialLine(finalLine);
                lblSpinner.Text = finalLine;

                await Task.Delay(1000);

                finalLine = $"[ OK ] Respiração estabilizada. Sistema pronto, lançando HydraLife {frame}";
                UpdateLastCeremonialLine(finalLine);
                lblSpinner.Text = finalLine;

                SpeakIfOpen("Respiração estabilizada. Sistema pronto, lançando HydraLife!");

                spinnerTimer?.Stop();
                spinnerTimer?.Dispose();
                spinnerTimer = null;
            }

            spinnerCycles++;
        }




        #endregion

        #region ProgressCeremony

        public void StartProgressTimer()
        {
            if (timer1 == null)
            {
                timer1 = new System.Windows.Forms.Timer { Interval = 200 };
                timer1.Tick += Timer1_Tick;
            }
            timer1.Start();
        }

        public async void Timer1_Tick(object sender, EventArgs e)
        {
            await RunProgressTick();
        }

        public async Task RunProgressTick()
        {
            if (progressBar1 == null) return;

            progressBar1.Value = Math.Min(progressBar1.Value + 1, progressBar1.Maximum);
            int percent = (int)(progressBar1.Value * 100.0 / Math.Max(1, progressBar1.Maximum));

            if (lblSpinner != null)
                lblSpinner.Text = $"🧠 Progresso: {percent}% ({progressBar1.Value}/{progressBar1.Maximum})";

            // 1% → despertar e tema
            if (percent == 1 && !temaAnunciado)
            {
                AppendCeremonialMessage("[ Despertar… preparando consciência para o ritual ]");
                AppendCeremonialMessage("[ Verificando integridade do sistema... ]");
                AppendCeremonialMessage("[ OK ] Procedendo...");
                TriggerBackgroundFade(Color.LightBlue);

                AppendCeremonialMessage("[RITUAL] Terminal cerimonial iniciado.");

                if (!splashClosed && !terminalRitualSpoken)
                {
                    SpeakIfOpen("Terminal cerimonial iniciado.");
                    terminalRitualSpoken = true;
                }

                AppendCeremonialMessage($"[ OK ] 🎯 Tema atual: {Theme?.Name ?? "Desconhecido"}");
                SpeakIfOpen($"Tema atual: {Theme?.Name ?? "Desconhecido"}");

                temaAnunciado = true;
            }

            // 10% → mood e integridade
            if (percent == 10 && !moodNarrado)
            {
                TriggerBackgroundFade(Color.DarkBlue);

                if (Theme != null)
                {
                    HydraVoice.NarrateMood(Theme.Mood);
                    AppendCeremonialMessage($"[ MOOD ] Estado cerimonial: {Theme.Mood}");
                }
                else
                {
                    AppendCeremonialMessage("[ ERRO ] Tema não definido.");
                }

                SpeakIfOpen("Integridade verificada.");
                moodNarrado = true;
            }

            // 11% → diretórios
            if (percent == 11 && !diretóriosCriados)
            {
                AppendCeremonialMessage("[ Inicializando diretórios do sistema... ]");
                InjectSystemDirectories();
                SpeakIfOpen("Diretórios essenciais estão a ser preparados.");
                diretóriosCriados = true;
            }

            // 20% → perfis
            if (percent == 20)
            {
                AppendCeremonialMessage("[ Carregando perfis de configuração… ]");
                AppendCeremonialMessage("[ OK ] Perfis de utilizador preparados.");
            }

            // 25% → assets
            if (percent == 25)
            {
                AppendCeremonialMessage("[ Preparando recursos e bibliotecas partilhadas… ]");
                AppendCeremonialMessage("[ OK ] Recursos cerimoniais mapeados.");
            }

            // 30% → serviços
            if (percent == 30)
            {
                AppendCeremonialMessage("[ Lançando serviços principais... ]");
                AppendCeremonialMessage("[ OK ] Procedendo...");
                TriggerBackgroundFade(Color.DarkGreen);
                SpeakIfOpen("Serviços principais lançados.");
            }

            // 40% → hidratação
            if (percent == 40)
            {
                AppendCeremonialMessage("[ Preparando cache de hidratação… ]");
                AppendCeremonialMessage("[ OK ] Rituais de hidratação indexados.");
            }

            // 50% → verificação UI
            if (percent == 50)
            {
                AppendCeremonialMessage("[ Verificando saúde dos componentes visuais… ]");
                AppendCeremonialMessage("[ OK ] Cursor, spinner e labels alinhados.");
            }

            // 60% → checkpoint
            if (percent == 60)
            {
                AppendCeremonialMessage("[ Ponto de verificação intermédio alcançado... ]");
                TriggerBackgroundFade(Color.MediumPurple);
                SpeakIfOpen("Estamos a meio do ritual.");
            }

            // 70% → permissões
            if (percent == 70)
            {
                AppendCeremonialMessage("[ Validando permissões e pontes de registo… ]");
                AppendCeremonialMessage("[ OK ] Permissões verificadas.");
            }

            // 75% → voz
            if (percent == 75)
            {
                AppendCeremonialMessage("[ Calibrando voz cerimonial e música… ]");
                AppendCeremonialMessage("[ OK ] Voz da Hydra ajustada.");
            }

            // 80% → tema finalizado
            if (percent == 80)
            {
                AppendCeremonialMessage("[ Finalizando aplicação do tema… ]");
                AppendCeremonialMessage("[ OK ] Paleta e tipografia definidas.");
            }

            // 85% → login
            if (percent == 85)
            {
                AppendCeremonialMessage("[ Preparando entrega da sessão ao Login… ]");
                AppendCeremonialMessage("[ OK ] Portal de credenciais aquecido.");
            }

            // 90% → sequência final
            if (percent == 90)
            {
                AppendCeremonialMessage("[ Finalizando sequência de carregamento... ]");
                AppendCeremonialMessage("[ OK ] Procedendo...");
                TriggerBackgroundFade(Color.DarkSlateGray);
                SpeakIfOpen("Sequência de arranque finalizada.");
                RevealCeremonialButtons();
            }

            // 95% → prompt final
            if (percent == 95)
            {
                AppendCeremonialMessage("[ Preparando prompt final de comando… ]");
                UpdateTerminalLayout();
            }

            // 100% → encerramento
            if (percent >= 100 && !ritualFinalizado)
            {
                ritualFinalizado = true;

                timer1.Stop();
                timer1.Tick -= Timer1_Tick;

                AppendCeremonialMessage("[ OK ] Carregamento concluído. Ritual finalizado.");
                HydraVoice.Volume = 50;
                SpeakIfOpen("Carregamento concluído. Ritual finalizado.");

                PlayCeremonialMusic(Path.Combine(HydraDataPath, "App", "Shared", "Music", "RideOfTheValkyries.mp3"));

                lblCursor.BackColor = terminalPanel.BackColor;
                lblCursor.ForeColor = Color.LimeGreen;
                lblCursor.Text = "[ OK ] Carregamento concluído. Ritual finalizado. ◐";

                RevealCeremonialButtons();
                await TransitionToLogin();
            }

            await Task.Delay(200);
        }





        private void btnCloseApp_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        public void RevealCeremonialButtons()
        {
            btnCloseApp.Visible = true;
            btnEndSession.Visible = true;
            btnrestart.Visible = true;

            btnCloseApp.BringToFront();
            btnEndSession.BringToFront();
            btnrestart.BringToFront();
        }


        #endregion

        #region EntryAndExitCeremony

        public void PrepareForRestart()
        {
            lblMessage.Text = "🔄 Reiniciando sistema...";
            TriggerBackgroundFade(Color.DarkOrange);
            AppendCeremonialMessage("[INFO] Sistema em reinício cerimonial...");
            if (!splashClosed) SpeakIfOpen("Reiniciando sistema com dignidade.");
        }

        public void PrepareForShutdown()
        {
            lblMessage.Text = "🔻 Encerrando sistema com dignidade...";
            TriggerBackgroundFade(Color.DarkRed);
            AppendCeremonialMessage("[INFO] Sistema em encerramento cerimonial...");
            if (!splashClosed) SpeakIfOpen("Encerrando sistema com dignidade.");
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
