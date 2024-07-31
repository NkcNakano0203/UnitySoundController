using Service.SE;
using Service.SE.Data;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using Service.BGM;

public class Test : MonoBehaviour
{
    [SerializeField]
    private MusicPlayer musicPlayer;

    [SerializeField]
    private SoundEffect soundEffect;

    [SerializeField]
    private SoundEffectPlayer soundEffectPlayer;

    [SerializeField]
    private int playCount = 1000;

    private CancellationTokenSource cts = new();


    void Start()
    {
        musicPlayer.Play();

        for (int i = 0; i < playCount; i++)
        {
            soundEffectPlayer.PlayAsync(soundEffect, Vector3.zero, cts.Token).Forget();

        }
    }
}