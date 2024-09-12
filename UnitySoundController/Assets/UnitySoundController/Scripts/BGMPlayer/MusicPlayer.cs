using UnityEngine;
using Cysharp.Threading.Tasks;
using UnitySoundController.BGM.Data;

namespace UnitySoundController.BGM
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private BGMData bgmData;

        private void Awake()
        {
            audioSource.clip = bgmData.AudioClip;

            SetVolume(bgmData.Volume);
        }

        public void Play()
        {
            audioSource.Play();
            audioSource.loop = bgmData.IsLoop;
        }

        public void Stop()
        {
            audioSource.Stop();
        }

        public void Pause()
        {
            audioSource.Pause();
        }

        public void Unpause()
        {
            audioSource.UnPause();
        }

        public void ChangeVolume(float volume)
        {
            SetVolume(volume);
        }

        public async UniTask FadeIn(float duration)
        {
            float startVolume = 0;
            float endVolume = 1;

            float delataTime = 0f;
            while (delataTime < duration)
            {
                delataTime += Time.deltaTime;
                float normalizedTime = delataTime / duration;
                audioSource.volume = Mathf.Lerp(startVolume, endVolume, normalizedTime);
                await UniTask.Yield();
            }
        }

        public async UniTask FadeOut(float duration)
        {
            float startVolume = 1;
            float endVolume = 0;

            float delataTime = 0f;
            while (delataTime < duration)
            {
                delataTime += Time.deltaTime;
                float normalizedTime = delataTime / duration;
                audioSource.volume = Mathf.Lerp(startVolume, endVolume, normalizedTime);
                await UniTask.Yield();
            }
        }

        private void SetVolume(float volume)
        {
            audioSource.volume = volume;
        }
    }
}