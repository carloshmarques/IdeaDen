using System;
using System.Globalization;
using System.Drawing;
using System.Windows.Forms;
using LifeCicles.Modules.Voice;       // HydraVoice
using HydraLife.Modules.Ceremony;     // HydraSpirit
using LifeCicles.Modules.Helpers;     // HydraTerminal

namespace HydraLife.Modules
{
    public class HydraTerminalConfig
    {
        private readonly RichTextBox _console;
        private const int MaxLines = 18;

        public HydraTerminalConfig(RichTextBox console)
        {
            _console = console ?? throw new ArgumentNullException(nameof(console));
            ConfigureConsole();
        }

        private void ConfigureConsole()
        {
            _console.ReadOnly = true;
            _console.Multiline = true;
            _console.WordWrap = false;
            _console.ScrollBars = RichTextBoxScrollBars.None;
            _console.Font = new Font("Consolas", 10, FontStyle.Bold);
            _console.ForeColor = Color.LimeGreen;
            _console.BackColor = Color.FromArgb(0, 0, 64);
            _console.HideSelection = true;
        }

        // Escrita genérica com truncamento e gatilhos
        public void Write(string message, params object[] args)
        {
            if (_console.Lines.Length >= MaxLines)
            {
                _console.Clear();
                _console.AppendText("[CTRL+L] Terminal limpo para novo bloco...\n");
            }

            string formatted = string.Format(CultureInfo.CurrentCulture, message, args);
            _console.AppendText(formatted + Environment.NewLine);
            _console.SelectionStart = _console.Text.Length;
            _console.ScrollToCaret();

            // Mood aleatório
            string mood = HydraSpirit.GetCurrentMood();

            // Voz
            HydraVoice.Speak(formatted);
            HydraVoice.NarrateMood(mood);

            // Terminal falante
            HydraTerminal.Speak(formatted, mood);
            HydraTerminal.SpeakRandom(mood);
        }

        // Mensagem ritual
        public void Ritual(string message)
        {
            Write("[RITUAL] " + message);
        }

        // Mensagem de erro
        public void Error(string message)
        {
            Write("[ERROR] " + message);
            HydraVoice.Speak("Erro detectado: " + message);
        }

        // Mensagem financeira
        public void Finance(string message, decimal valor)
        {
            string formatted = string.Format(CultureInfo.CurrentCulture, "{0} {1:C}", message, valor);
            Write("[FINANCE] " + formatted);
            HydraVoice.Speak("Aviso financeiro: " + formatted);
        }

        // Limpeza manual
        public void Clear()
        {
            _console.Clear();
        }
    }
}
