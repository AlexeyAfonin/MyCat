using System;

namespace MyCat.Core.Util
{
    public static class Enums
    {
        public static Array GetEnumValues<T>() =>
            Enum.GetValues(typeof(T));

        public enum Mood
        {
            None = 0,
            Bad = 1,
            Good = 2,
            Great = 3,
        }

        public enum LockState
        {
            Lock = 0,
            Unlock = 1,
        }

        public enum ReactionAnimationState
        {
            Start = 0,
            Complete = 1,
        }
    }
}