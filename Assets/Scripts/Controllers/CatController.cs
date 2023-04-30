using MyCat.Core.Util;
using MyCat.Structures;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;
using UnityEngine;
using static MyCat.Core.Util.Enums;

namespace MyCat.Controllers
{
    [RequireComponent(typeof(Animator))]
    public sealed class CatController : MonobehSingleton<CatController>
    {
        [SerializeField] private AnimatorController defaultAnimatorController;

        private AnimatorController _reactionAnimatorController;

        private Animator _animator;

        private Mood _mood = Mood.None;
        private Mood _newMood = Mood.None;

        public Mood ActiveMood
        {
            get => _mood;
            set
            {
                _mood = value;

                if (_animator is not null && _mood is not Mood.None)
                {
                    foreach (Mood enumElement in GetEnumValues<Mood>())
                    {
                        _animator.SetBool($"IsMood{enumElement}", false);
                    }

                    _animator.SetBool($"IsMood{_mood}", true);
                }

                if (UIController.HasReference)
                {
                    UIController.Instance.UpdateInfoPanel(_mood.ToString(), null);
                }
            }
        }

        protected override void Awake()
        {
            base.Awake();

            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            ActiveMood = Mood.Good;
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        public void SetReaction(CatAction action)
        {
            var reaction = action.Reactions
                .FirstOrDefault(r => r.Mood == ActiveMood)
                .Reaction;

            if (reaction.AnimatorController is not null)
            {
                _reactionAnimatorController = reaction.AnimatorController;
                _animator.runtimeAnimatorController = _reactionAnimatorController;
            }

            _newMood = reaction.NewMood is not Mood.None
                    ? reaction.NewMood
                    : ActiveMood;

            if (UIController.HasReference)
            {
                UIController.Instance.UpdateInfoPanel(_newMood.ToString(), reaction.Description);
            }
        }

        public void StartReactionCoroutine()
        {
            if (UIController.HasReference)
            {
                UIController.Instance.LockUI(true);
            }
            ActiveMood = _mood;
            StartCoroutine(ReactionAnimationCoroutine());
        }

        public void StopReactionCoroutine()
        {
            if (UIController.HasReference)
            {
                UIController.Instance.LockUI(false);
            }
            StopCoroutine(ReactionAnimationCoroutine());

            _animator.runtimeAnimatorController = defaultAnimatorController;

            if (_newMood is not Mood.None)
            {
                ActiveMood = _newMood;
                _newMood = Mood.None;
            }
        }

        private IEnumerator ReactionAnimationCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}