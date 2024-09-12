using Cysharp.Threading.Tasks;
using UnityEngine;
using UnitySoundController.SE.Data;

namespace UnitySoundController.SE.Player
{
    // インスペクタから楽にSEを再生するためのクラス
    // Created by Nkn on 2024/09/12
    public sealed class SoundAssistant : MonoBehaviour
    {
        [SerializeField]
        private SoundEffectPlayer _soundEffectPlayer;

        public void Play(Object seAsset)
        {
            if (seAsset is SoundEffect soundEffect)
            {
                _soundEffectPlayer.PlayAsync(soundEffect, transform, this.GetCancellationTokenOnDestroy()).Forget();
            }
        }
    }
}