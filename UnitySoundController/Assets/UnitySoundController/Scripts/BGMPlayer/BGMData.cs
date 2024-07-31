using UnityEngine;

namespace Service.BGM.Data
{
    [CreateAssetMenu(menuName = "Audio/BGMData")]
    public class BGMData : ScriptableObject
    {
        [field: SerializeField]
        public AudioClip AudioClip { get; private set; }

        [field: SerializeField]
        public float Volume { get; private set; }

        [field: SerializeField]
        public bool IsLoop { get; private set; }
    }
}