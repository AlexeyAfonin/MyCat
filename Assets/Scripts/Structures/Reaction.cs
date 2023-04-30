using MyCat.Interfaces;
using UnityEditor.Animations;
using UnityEngine;
using static MyCat.Core.Util.Enums;

namespace MyCat.Structures
{
    [System.Serializable]
    public struct Reaction : IReaction
    {
        [SerializeField] private AnimatorController animatorController;
        [SerializeField] private Mood newMood;
        [SerializeField, TextArea(3, 10)] private string description;

        public AnimatorController AnimatorController { get => animatorController; }
        public Mood NewMood { get => newMood; }
        public string Description { get => description; }
    }
}