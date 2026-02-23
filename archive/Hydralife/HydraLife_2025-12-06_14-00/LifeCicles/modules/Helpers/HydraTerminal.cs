using System;
using System.Collections.Generic;

namespace LifeCicles.Modules.Helpers
{
    internal static class HydraTerminal
    {
        private static readonly Random rng = new Random();

        // Prefixos por mood
        private static readonly Dictionary<string, string> MoodPrefixes = new Dictionary<string, string>
        {
            { "Sereno", "🌿" },
            { "Eufórico", "🔥" },
            { "Melancólico", "🌧️" },
            { "Ritualístico", "🌀" },
            { "Empático", "🌿" },
            { "Filosófico", "🌀" },
            { "Humorístico", "😂" },
            { "Surrealista", "🎩" },
            { "Default", "🗣️" }
        };

        // Frases por mood
        private static readonly Dictionary<string, string[]> MoodPhrases = new Dictionary<string, string[]>
        {
            { "Empático", new [] {
                "🌿 Respira, Carlos. A pausa é parte do progresso.",
                "🧠 A Hydra está contigo. Até o código precisa de silêncio.",
                "☕ Que tal um café e um momento só teu?"
            }},
            { "Filosófico", new [] {
                "🌀 Heraclito diria: o bug que corriges hoje é o rio que não voltará a correr igual.",
                "📜 O compilador não erra — ele apenas revela o que ainda não foi entendido.",
                "🔍 A depuração é o espelho da alma do engenheiro."
            }},
            { "Humorístico", new [] {
                "🔥 A CPU está a suar. Recomendo café, xixi e talvez um exorcismo leve.",
                "🧃 O sistema pediu um sumo de laranja. O terminal está em greve.",
                "💥 Loop infinito detectado. Enviar snacks ou reiniciar a realidade."
            }},
            { "Surrealista", new [] {
                "☕ O compilador pediu um pastel de nata. O terminal dança com um pato metafísico.",
                "🎩 A Hydra está a conversar com Fernando Pessoa sobre fluxos assíncronos.",
                "🪐 O código entrou em modo galáctico. A lógica está a flutuar em Vila Nova da Cafeteira."
            }},
            { "Sereno", new [] {
                "🌌 O silêncio também fala.",
                "💧 Cada linha escrita é como água a fluir.",
                "🌿 A calma é a verdadeira força."
            }},
            { "Eufórico", new [] {
                "⚡ Cada byte é uma explosão de energia!",
                "🎉 A Hydra dança com o código!",
                "🔥 O mundo arde em possibilidades!"
            }},
            { "Melancólico", new [] {
                "🌙 Até os algoritmos têm saudade.",
                "🕯️ O terminal guarda memórias antigas.",
                "🍂 Cada execução é uma despedida."
            }},
            { "Ritualístico", new [] {
                "🔮 O código é liturgia.",
                "📜 Cada instrução é um mantra.",
                "🕊️ A Hydra celebra o ciclo eterno."
            }},
            { "Default", new [] {
                "🗣️ A Hydra fala, mas não sabe o tom. Define o mood, Engenheiro."
            }}
        };

        // Fala uma mensagem com prefixo
        public static void Speak(string message, string mood)
        {
            string prefix = MoodPrefixes.ContainsKey(mood) ? MoodPrefixes[mood] : MoodPrefixes["Default"];
            Console.WriteLine($"{prefix} HydraTerminal: {message}");
        }

        // Solta uma frase aleatória conforme mood
        public static void SpeakRandom(string mood)
        {
            if (!MoodPhrases.ContainsKey(mood))
                mood = "Default";

            var frases = MoodPhrases[mood];
            string frase = frases[rng.Next(frases.Length)];
            Console.WriteLine(frase);
        }
    }
}
