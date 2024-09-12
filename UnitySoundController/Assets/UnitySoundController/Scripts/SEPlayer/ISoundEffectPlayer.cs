using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using UnitySoundController.SE.Data;

namespace UnitySoundController.SE
{
    public interface ISoundEffectPlayer
    {
        /// <summary>
        /// その場で鳴らす用
        /// </summary>
        /// <param name="soundEffect">SEデータ</param>
        /// <param name="playPos">再生したい場所</param>
        /// <returns></returns>
        public UniTask PlayAsync(SoundEffect soundEffect, Vector3 playPos, CancellationToken ctc) { return default; }

        /// <summary>
        /// 追従させたい時用
        /// </summary>
        /// <param name="soundEffect">SEデータ</param>
        /// <param name="parent">親オブジェクト</param>
        /// <returns></returns>
        public UniTask PlayAsync(SoundEffect soundEffect, Transform parent, CancellationToken ctc) { return default; }
    }
}