using MyCat.Structures;
using System.Collections.Generic;

namespace MyCat.Interfaces
{
    public interface ICatAction
    {
        public string Name { get; }
        public List<MoodReaction> Reactions { get; }
    }
}