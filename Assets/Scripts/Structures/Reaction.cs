using MyCat.Interfaces;
using UnityEngine;
using static MyCat.Core.Util.Enums;

namespace MyCat.Structures
{
    [System.Serializable]
    public struct Reaction : IReaction
    {
        [SerializeField] private string animatorBoolVariable;
        [SerializeField] private Mood newMood;
        [SerializeField, TextArea(3, 10)] private string description;

        public string AnimatorBoolVariable { get => animatorBoolVariable; }
        public Mood NewMood { get => newMood; }
        public string Description { get => description; }
    }
}