using System;
using UnityEngine;

namespace UnitySoundController.SE.Data
{
    [CreateAssetMenu(fileName = "SE", menuName = "Audio/SoundEffect")]
    public class SoundEffect : ScriptableObject, IDisposable
    {
        public AudioClip Clip;

        public float Volume = 1;

        public bool RandomPitch = false;

        public float MinPitch = -3f;

        public float MaxPitch = 3f;

        public bool Audio3D = false;

        public int MaxMultiPlayCount = 3;

        /// <summary>
        /// 各SEの現在の再生数
        /// </summary>
        [field: NonSerialized]
        public int CurrentPlayCount { get; private set; }

        public static SoundEffect Create(AudioClip clip)
        {
            SoundEffect instance = CreateInstance<SoundEffect>();
            instance.Clip = clip;
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
}