using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("結束音效")]
    public AudioClip soundEnd;

    private AudioSource aud;
    private Runner runner;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
        runner = FindObjectOfType<Runner>();

        runner.onEnd += EndSound;                   // 訂閱事件
    }

    /// <summary>
    /// 結束音效
    /// </summary>
    private void EndSound()
    {
        aud.PlayOneShot(soundEnd);
    }
}
