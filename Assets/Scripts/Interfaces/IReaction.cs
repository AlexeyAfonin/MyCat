using UnityEditor.Animations;
using static MyCat.Core.Util.Enums;

namespace MyCat.Interfaces
{
    public interface IReaction
    {
        public AnimatorController AnimatorController { get; }
        public Mood NewMood { get; }
        public string Description { get; }
    }
}