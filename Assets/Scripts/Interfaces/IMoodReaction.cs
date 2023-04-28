using MyCat.Structures;
using static MyCat.Core.Util.Enums;

namespace MyCat.Interfaces
{
    public interface IMoodReaction
    {
        public string NameElement { get; set; }
        public Mood Mood { get; }
        public Reaction Reaction { get; }
    }
}