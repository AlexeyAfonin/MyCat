using MyCat.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using static MyCat.Core.Util.Enums;

namespace MyCat.Animation
{
    public class ReactionAnimationController : StateMachineBehaviour
    {
        [SerializeField] private ReactionAnimationState state;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (state is ReactionAnimationState.Start)
            {
                ReactionStart(animator);
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (state is ReactionAnimationState.Complete &&
                stateInfo.normalizedTime >= 1.0f)
            {
                ReactionCompete(animator);
            }
        }

        private void ReactionStart(Animator animator)
        {
            var cat = animator.GetComponent<CatController>();
            cat.StartReactionCoroutine();
        }

        private void ReactionCompete(Animator animator)
        {
            var cat = animator.GetComponent<CatController>();
            cat.StopReactionCoroutine();
        }
    }
}
