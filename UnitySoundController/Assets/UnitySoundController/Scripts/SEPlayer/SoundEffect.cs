using System;
using UnityEngine;

namespace Service.SE.Data
{
    [CreateAssetMenu(fileName = "SE", menuName = "Audio/SoundEffect")]
    public class SoundEffect : ScriptableObject, IDisposable
    {
        [SerializeField, Tooltip("音声データ")]
        private AudioClip clip;
        public AudioClip Clip => clip;

        [field: SerializeField, Range(0f, 1f), Header("音量")]
        public float Volume { get; private set; } = 1;

        [field: SerializeField, Header("ピッチを乱数化")]
        public bool RandomPitch { get; private set; } = false;

        [field: SerializeField, Range(-3f, 3f), Header("最低ピッチ")]
        public float MinPitch { get; private set; } = -3f;

        [field: SerializeField, Range(-3f, 3f), Header("最高ピッチ")]
        public float MaxPitch { get; private set; } = 3f;

        [field: SerializeField, Header("立体音響")]
        public bool Audio3D { get; private set; } = true;

        [field: SerializeField, Header("同時再生数")]
        public int MaxMultiPlayCount { get; private set; } = 3;

        /// <summary>
        /// 各SEの現在の再生数
        /// </summary>
        [field: NonSerialized]
        public int CurrentPlayCount { get; private set; }

        public static SoundEffect Create(AudioClip clip)
        {
            SoundEffect instance = CreateInstance<SoundEffect>();
            instance.clip = clip;
            return instance;
        }
        public void SetUp()
        {
            CurrentPlayCount++;
        }

        public void Dispose()
        {
            CurrentPlayCount--;
        }
    }

    public class Disposable : IDisposable
    {
        private readonly Action onDispose;

        public Disposable(Action onDispose)
        {
            this.onDispose = onDispose;
        }

        public void Dispose()
        {
            onDispose?.Invoke();
        }
    }
}