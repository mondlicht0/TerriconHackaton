using UnityEngine;

namespace Assets.Scripts.Audio
{
    public class PlaySoundEnter : StateMachineBehaviour
    {
        [SerializeField] private SoundType _sound;
        [SerializeField, Range(0, 1)] private float _volume = 1;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            SoundManager.Instance.PlaySound(_sound, _volume);
        }
    }
}