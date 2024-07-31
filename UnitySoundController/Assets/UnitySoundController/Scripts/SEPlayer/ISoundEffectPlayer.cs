using Cysharp.Threading.Tasks;
using Service.SE.Data;
using System.Threading;
using UnityEngine;

namespace Service.SE
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