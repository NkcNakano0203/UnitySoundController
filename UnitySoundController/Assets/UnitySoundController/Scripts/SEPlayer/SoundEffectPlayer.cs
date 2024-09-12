using Cysharp.Threading.Tasks;
using UnitySoundController.SE.Data;
using UnitySoundController.SE.Element;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Pool;

namespace UnitySoundController.SE
{
    public class SoundEffectPlayer : MonoBehaviour, ISoundEffectPlayer, ISoundEffectController
    {
        [SerializeField]
        int defaultCapacity = 10;

        private ObjectPool<SEPlayerElement> soundEffectPlayerPool;
        private readonly List<SEPlayerElement> activeSEList = new();

        // デバッグ表示用
        [SerializeField]
        private bool displayPlayingCount = false;
        private readonly Dictionary<SoundEffect, int> playingCount = new();

        private void Awake()
        {
            soundEffectPlayerPool = new ObjectPool<SEPlayerElement>(
                 createFunc: CreateChild,
                 actionOnGet: target => target.gameObject.SetActive(true),
                 actionOnRelease: target => target.gameObject.SetActive(false),
                 actionOnDestroy: Destroy,
                 collectionCheck: true,
                 defaultCapacity: defaultCapacity,
                 maxSize: 100);
        }

        public async UniTask PlayAsync(SoundEffect soundEffect, Vector3 playPos, CancellationToken ctc)
        {
            // 同時再生数を絞る
            if (soundEffect.CurrentPlayCount >= soundEffect.MaxMultiPlayCount) return;

            SEPlayerElement sePlayerChild = soundEffectPlayerPool.Get();
            activeSEList.Add(sePlayerChild);

            // Disposeを使って現在の同時再生数を増減させる
            using (soundEffect)
            {
                soundEffect.SetUp();

                playingCount.TryAdd(soundEffect, 0);

                playingCount[soundEffect]++;
                await sePlayerChild.PlayAsync(soundEffect, playPos, ctc);
                playingCount[soundEffect]--;
            }
            activeSEList.Remove(sePlayerChild);
            soundEffectPlayerPool.Release(sePlayerChild);
        }

        public async UniTask PlayAsync(SoundEffect soundEffect, Transform parent, CancellationToken ctc)
        {
            // 各SE同時再生数を絞る
            if (soundEffect.CurrentPlayCount >= soundEffect.MaxMultiPlayCount) return;

            SEPlayerElement sePlayerChild = soundEffectPlayerPool.Get();
            activeSEList.Add(sePlayerChild);

            // Disposeを使って現在の同時再生数を増減させる
            using (soundEffect)
            {
                soundEffect.SetUp();

                playingCount.TryAdd(soundEffect, 0);

                playingCount[soundEffect]++;
                await sePlayerChild.Play(soundEffect, parent, ctc);
                playingCount[soundEffect]--;
            }

            activeSEList.Remove(sePlayerChild);
            soundEffectPlayerPool.Release(sePlayerChild);
        }

        /// <summary>
        /// プールが足りない時の追加メソッド
        /// </summary>
        private SEPlayerElement CreateChild()
        {
            SEPlayerElement instance = new GameObject().AddComponent<SEPlayerElement>();
            instance.transform.SetParent(transform);
            return instance;
        }

        public void Pause()
        {
            foreach (SEPlayerElement item in activeSEList)
            {
                item.Pause();
            }
        }

        public void UnPause()
        {
            foreach (SEPlayerElement item in activeSEList)
            {
                item.UnPause();
            }
        }

#if DEBUG
        private void OnGUI()
        {
            if (!displayPlayingCount) return;

            // 各SEの同時再生数をゲームビュー左上に表示
            foreach (var sounds in playingCount)
            {
                GUI.skin.box.fontSize = 50;
                GUILayout.Box(
                    sounds.Key.name + " : " + sounds.Value.ToString(),
                    GUILayout.Width(500),
                    GUILayout.Height(70));
            }
        }
#endif
    }
}