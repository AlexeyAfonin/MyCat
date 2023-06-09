using MyCat.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace MyCat.Structures
{
    [System.Serializable]
    public struct CatAction : ICatAction
    {
        [SerializeField] private string name;
        [SerializeField] private Sprite icon;
        [SerializeField] private List<MoodReaction> reactions;

        public string Name { get => name; }
        public Sprite Icon { get => icon; }
        public List<MoodReaction> Reactions { get => reactions; }
    }
}