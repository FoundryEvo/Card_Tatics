using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioMgr : Singleton<AudioMgr>
{
    //唯一的背景音乐组件
    private AudioSource bgMusic = null;
    //音乐大小，初始为最大值
    private float bgVolume = 1;
    //音效依附对象,一开始为空
    private GameObject soundObj = null;
    //音效列表
    private List<AudioSource> soundList = new List<AudioSource>();
    //音效大小,一开始设置为最大值
    private float soundVolume = 1;


    //构造函数
    public AudioMgr()
    {
        MonoMgr.Instance().AddUpdateListener(Update);
    }

    //播放背景音乐
    public void PlayBGMusic(string name)
    {
        //先给背景音乐赋值
        if (bgMusic == null)
        {
            GameObject obj = new GameObject();
            obj.name = "bgMusic";
            bgMusic = obj.AddComponent<AudioSource>();
        }
        //异步加载背景音乐 加载完成后 播放
        ResMgr.Instance().LoadAsync<AudioClip>("Audio/BG/" + name, (clip) =>
        {
            bgMusic.clip = clip;
            bgMusic.loop = true;
            bgMusic.volume = bgVolume;
            bgMusic.Play();
        });


    }

    //暂停背景音乐
    public void PauseBGMusic()
    {
        if (bgMusic == null)
            return;
        bgMusic.Pause();
    }

    //停止背景音乐
    public void StopBGMusic()
    {
        if (bgMusic == null)
            return;
        bgMusic.Stop();
    }

    //改变背景音乐大小
    public void ChangeBGVolume(float v)
    {
        bgVolume = v;
        if (bgMusic == null)
            return;
        bgMusic.volume = bgVolume;
    }
    //播放音效
    public void PlaySound(string name, bool isLoop, UnityAction<AudioSource> callBack = null)
    {
        if (soundObj == null)
        {
            soundObj = new GameObject();
            soundObj.name = "Sound";
        }
        //当音效资源异步加载结束后 再添加一个音效
        ResMgr.Instance().LoadAsync<AudioClip>("Audio/Sound/" + name, (clip) =>
        {
            AudioSource source = soundObj.AddComponent<AudioSource>();
            source.clip = clip;
            source.loop = isLoop;
            source.volume = soundVolume;
            source.Play();
            soundList.Add(source);
            if (callBack != null)
                callBack(source);
        });
    }

    //停止音效
    public void StopSound(AudioSource source)
    {
        if (soundList.Contains(source))
        {
            soundList.Remove(source);
            source.Stop();
            GameObject.Destroy(source);
        }
    }

    //改变音效声音大小
    public void ChangeSoundVolume(float value)
    {
        soundVolume = value;
        for (int i = 0; i < soundList.Count; ++i)
            soundList[i].volume = value;
    }
    private void Update()
    {
        for (int i = soundList.Count - 1; i >= 0; --i)
        {
            if (!soundList[i].isPlaying)
            {
                GameObject.Destroy(soundList[i]);
                soundList.RemoveAt(i);
            }
        }

    }
}
