using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.IO;

namespace LifeCicles.Modules.Voice
{
    public static class HydraVoice
    {
        private static readonly SpeechSynthesizer synth;

        // Tornar público para controle externo, se precisares ajustar em runtime
        public static int Volume
        {
            get => synth?.Volume ?? 0;
            set
            {
                if (synth != null)
                {
                    var v = Math.Max(0, Math.Min(100, value));
                    synth.Volume = v;
                }
            }
        }

        static HydraVoice()
        {
            synth = new SpeechSynthesizer
            {
                Volume = 50,  // volume médio
                Rate = -4     // mais lento, estilo ritual
            };

            var preferredVoice = "Microsoft Zira Desktop";
            var installed = synth.GetInstalledVoices().Select(v => v.VoiceInfo.Name).ToList();

            if (installed.Contains(preferredVoice))
            {
                synth.SelectVoice(preferredVoice);
            }
            else if (installed.Count > 0)
            {
                synth.SelectVoice(installed.First());
                synth.SpeakAsync("A voz Zira não está disponível. A Hydra usará uma voz alternativa.");
            }
        }

        // Stop: para todas as locuções assíncronas
        public static void Stop()
        {
            try
            {
                synth?.SpeakAsyncCancelAll();
            }
            catch
            {
                // silêncio cerimonial
            }
        }

        public static string GetCurrentVoice()
        {
            return synth?.Voice?.Name ?? "Voz não definida";
        }

        public static List<string> GetInstalledVoiceNames()
        {
            return synth.GetInstalledVoices().Select(v => v.VoiceInfo.Name).ToList();
        }

        public static void Speak(string text)
        {
            if (!string.IsNullOrWhiteSpace(text) && synth != null)
            {
                synth.SpeakAsync(text);
            }
        }

        public static void WelcomeUser(string username)
        {
            Speak($"Bem-vindo, {username}. A Hydra está consciente.");
        }

        public static void AnnounceDirectoryCreation(string path)
        {
            Speak($"Diretório criado com sucesso: {Path.GetFileName(path)}.");
        }

        public static void RitualClosing()
        {
            Speak("Encerramento cerimonial em progresso. Até breve.");
        }

        // NarrateMood: existe e fala estado emocional
        public static void NarrateMood(string mood)
        {
            Speak($"Estado emocional atual: {mood}. Ajustando atmosfera.");
        }

        public static void ReadText(string content)
        {
            Speak(content);
        }
    }
}
