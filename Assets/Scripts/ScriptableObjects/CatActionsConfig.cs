using MyCat.Interfaces;
using MyCat.Structures;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static MyCat.Core.Util.Enums;

namespace MyCat.Configs
{
    [CreateAssetMenu(fileName = "CatActionsConfig", menuName = "MyCat/Configs/CatActions", order = 0)]
    public class CatActionsConfig : ScriptableObject
    {
        [SerializeField] private List<CatAction> actions;

        public List<CatAction> Actions { get => actions; }

#if UNITY_EDITOR
        private void OnValidate()
        {
            foreach (var action in actions)
            {
                var duplicates = action.Reactions.Where(r => r.Mood is not Mood.None).GroupBy(r => r.Mood);

                if (duplicates.Any(g => g.Count() > 1))
                {
                    EditorUtility.DisplayDialog("Error", $"There can only be one reaction for one mood!", "OK");
                }

                action.Reactions.ForEach(r => r.NameElement = r.Mood.ToString());
            }
        }
#endif
    }
}