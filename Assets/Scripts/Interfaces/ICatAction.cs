using MyCat.Structures;
using System.Collections.Generic;
using UnityEngine;

namespace MyCat.Interfaces
{
    public interface ICatAction
    {
        public string Name { get; }
        public Sprite Icon { get; }
        public List<MoodReaction> Reactions { get; }
    }
}