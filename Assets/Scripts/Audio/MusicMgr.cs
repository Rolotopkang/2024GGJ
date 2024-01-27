using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MusicMgr : Singleton<MusicMgr>
{
    //背景音乐组件
    private AudioSource bkMusic ;

    //音效依附对象
    private AudioSource soundObj ;
    

    //音效路径
    private string path;

    public void Init()
    {
        path = "/Clip/";
        bkMusic=GameObject.Find("Main Camera").GetComponent<AudioSource>();
        soundObj = GameObject.Find("EffectAudioSources").GetComponent<AudioSource>();
    }


    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="name"></param>
    public void PlayBkMusic(string dictionary,string clip,float value=0.5f,bool ismute=false)
    {
        if (bkMusic == null)
            return;
        bkMusic.clip = Resources.Load<AudioClip>(path + dictionary + "/" + clip);
        bkMusic.volume = value;
        bkMusic.mute = ismute;
        bkMusic.Play();

    }

    /// <summary>
    /// 暂停背景音乐
    /// </summary>
    public void PauseBKMusic()
    {
        if (bkMusic == null)
            return;
        bkMusic.Pause();
    }

    /// <summary>
    /// 停止背景音乐
    /// </summary>
    public void StopBKMusic()
    {
        if (bkMusic == null)
            return;
        bkMusic.Stop();
    }

    /// <summary>
    /// 改变背景音乐
    /// </summary>
    /// <param name="v"></param>
    public void ChangeBKClip(string dictionary, string clip)
    {
        if(bkMusic == null)
            return;
        bkMusic.clip = Resources.Load<AudioClip>(path + dictionary + "/" + clip);
        bkMusic.Play();
    }
    /// <summary>
    /// 改变背景音乐大小
    /// </summary>
    public void ChangeBKValue(float v)
    {
        if (bkMusic == null)
            return;
        bkMusic.volume = v;
    }

    /// <summary>
    /// 播放音效
    /// </summary>
    public void PlayEffectMusic(string dictionary, string clip, float value = 0.5f, bool ismute = false)
    {
        if (soundObj == null)
            return;
        soundObj.volume = value;
        soundObj.mute = ismute;
        soundObj.PlayOneShot(Resources.Load<AudioClip>(path + dictionary + "/" + clip));
    }

    /// <summary>
    /// 改变音效声音大小
    /// </summary>
    /// <param name="value"></param>
    public void ChangeSoundValue( float v)
    {
        if (soundObj == null)
            return;
        soundObj.volume= v;
    }
}
