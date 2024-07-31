using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using Service.SE.Data;

namespace Service.SE.Element
{
    [RequireComponent(typeof(AudioSource))]
    public class SEPlayerElement : MonoBehaviour
    {
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public async UniTask PlayAsync(SoundEffect soundEffect, Vector3 playPos, CancellationToken cancellationToken)
        {
            gameObject.transform.position = playPos;

            audioSource.clip = soundEffect.Clip;
            audioSource.volume = soundEffect.Volume;
            audioSource.spatialBlend = soundEffect.Audio3D ? 1 : 0;

            if (soundEffect.RandomPitch)
            {
                audioSource.pitch = Random.Range(soundEffect.MinPitch, soundEffect.MaxPitch);
            }

            audioSource.Play();

            await UniTask.WaitWhile(() => IsPlayed(audioSource),
            cancellationToken: cancellationToken);
        }

        public async UniTask Play(SoundEffect soundEffect, Transform parent, CancellationToken cancellationToken)
        {
            gameObject.transform.SetParent(parent);

            audioSource.clip = soundEffect.Clip;
            audioSource.volume = soundEffect.Volume;
            audioSource.spatialBlend = soundEffect.Audio3D ? 1 : 0;

            if (soundEffect.RandomPitch)
            {
                audioSource.pitch = Random.Range(soundEffect.MinPitch, soundEffect.MaxPitch);
            }

            audioSource.Play();

            await UniTask.WaitWhile(() => IsPlayed(audioSource),
            cancellationToken: cancellationToken);
            transform.SetParent(null);
        }

        public void Pause()
        {
            audioSource.Pause();
        }

        public void UnPause()
        {
            audioSource.UnPause();
        }

        /// <summary>
        /// 再生終了判定
        /// </summary>
        /// <returns>終了したらTrue</returns>
        private bool IsPlayed(AudioSource audioSource)
        {
            // ピッチの値によって再生終了判定を切り替える
            // ピッチがマイナス値になると逆再生になるので
            if (audioSource.pitch >= 0)
            {
                return audioSource.time < audioSource.clip.length;
            }
            else
            {
                return audioSource.time > 0;
            }
        }
    }
}