using MyCat.Interfaces;
using UnityEngine;
using static MyCat.Core.Util.Enums;

namespace MyCat.Structures
{
    [System.Serializable]
    public class MoodReaction : IMoodReaction
    {
        [SerializeField, HideInInspector] private string nameElement;
        [SerializeField] private Mood mood;
        [SerializeField] private Reaction reaction;

        public string NameElement { get => nameElement; set => nameElement = value; }
        public Mood Mood { get => mood; }
        public Reaction Reaction { get => reaction; }
    }
}