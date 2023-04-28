using MyCat.Structures;
using static MyCat.Core.Util.Enums;

namespace MyCat.Interfaces
{
    public interface IReaction
    {
        public string AnimatorBoolVariable { get; }
        public Mood NewMood { get; }
        public string Description { get; }
    }
}