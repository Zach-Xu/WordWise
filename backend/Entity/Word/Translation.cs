using System.ComponentModel;

namespace backend.Entity.Word
{
    public record Translation
    {
        public Language Language { get; set; }
        public string Definition { get; set; }

        public Translation(Language language, string definition)
        {
            Language = language;
            Definition = definition;
        }

    }
    public enum Language
    {
        Bulgarian,
        Czech,
        Danish,
        German,
        Greek,
        English,
        Spanish,
        Estonian,
        Finnish,
        French,
        Hungarian,
        Indonesian,
        Italian,
        Japanese,
        Korean,
        Lithuanian,
        Latvian,
        [Description("Norwegian (Bokmål)")]
        NorwegianBokmal,
        Dutch,
        Polish,
        [Description("Portuguese (all Portuguese varieties mixed)")]
        Portuguese,
        Romanian,
        Russian,
        Slovak,
        Slovenian,
        Swedish,
        Turkish,
        Ukrainian,
        Chinese
    }
}
