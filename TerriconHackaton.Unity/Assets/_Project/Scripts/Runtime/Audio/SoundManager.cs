using UnityEngine;
using System;

namespace Assets.Scripts.Audio
{
    public enum SoundType
    {
        FOOTSTEPS,
        TRAPS,
        ONENEMYSEE
    }

    [RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;
        [SerializeField, Range(0, 1)] private float _musicVolume;
        [SerializeField] private SoundList[] _soundList;
        [SerializeField] private AudioSource _musicSource;

        public int PrefSoundVolumeKey;

        private AudioSource _audioSource;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(Instance);
            }
            
            Instance = this;
        }

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();

            _musicSource.volume = _musicVolume;
            _musicSource.loop = true;
            _musicSource.Play();
        }

        public void PlaySound(SoundType sound, float volume = 1)
        {
            AudioClip[] clips = Instance._soundList[(int)sound].Sounds;
            AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)]; 
            _audioSource.PlayOneShot(randomClip, volume);
        }

        public void PlaySound(SoundType sound, AudioSource source, float volume = 1)
        {
            AudioClip[] clips = Instance._soundList[(int)sound].Sounds;
            AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)]; 
            source.PlayOneShot(randomClip, volume);
        }

#if UNITY_EDITOR
        private void OnEnable()
        {
            string[] names = Enum.GetNames(typeof(SoundType));
            Array.Resize(ref _soundList, names.Length);
            for (int i = 0; i < _soundList.Length; i++)
                _soundList[i].name = names[i];
        }
#endif
    }

    [Serializable]
    public struct SoundList
    {
        public AudioClip[] Sounds { get => sounds; }
        [HideInInspector] public string name;
        [SerializeField] private AudioClip[] sounds;
    }
}