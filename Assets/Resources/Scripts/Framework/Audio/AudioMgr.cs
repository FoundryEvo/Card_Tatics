using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioMgr : Singleton<AudioMgr>
{
    //Ψһ�ı����������
    private AudioSource bgMusic = null;
    //���ִ�С����ʼΪ���ֵ
    private float bgVolume = 1;
    //��Ч��������,һ��ʼΪ��
    private GameObject soundObj = null;
    //��Ч�б�
    private List<AudioSource> soundList = new List<AudioSource>();
    //��Ч��С,һ��ʼ����Ϊ���ֵ
    private float soundVolume = 1;


    //���캯��
    public AudioMgr()
    {
        MonoMgr.Instance().AddUpdateListener(Update);
    }

    //���ű�������
    public void PlayBGMusic(string name)
    {
        //�ȸ��������ָ�ֵ
        if (bgMusic == null)
        {
            GameObject obj = new GameObject();
            obj.name = "bgMusic";
            bgMusic = obj.AddComponent<AudioSource>();
        }
        //�첽���ر������� ������ɺ� ����
        ResMgr.Instance().LoadAsync<AudioClip>("Audio/BG/" + name, (clip) =>
        {
            bgMusic.clip = clip;
            bgMusic.loop = true;
            bgMusic.volume = bgVolume;
            bgMusic.Play();
        });


    }

    //��ͣ��������
    public void PauseBGMusic()
    {
        if (bgMusic == null)
            return;
        bgMusic.Pause();
    }

    //ֹͣ��������
    public void StopBGMusic()
    {
        if (bgMusic == null)
            return;
        bgMusic.Stop();
    }

    //�ı䱳�����ִ�С
    public void ChangeBGVolume(float v)
    {
        bgVolume = v;
        if (bgMusic == null)
            return;
        bgMusic.volume = bgVolume;
    }
    //������Ч
    public void PlaySound(string name, bool isLoop, UnityAction<AudioSource> callBack = null)
    {
        if (soundObj == null)
        {
            soundObj = new GameObject();
            soundObj.name = "Sound";
        }
        //����Ч��Դ�첽���ؽ����� �����һ����Ч
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

    //ֹͣ��Ч
    public void StopSound(AudioSource source)
    {
        if (soundList.Contains(source))
        {
            soundList.Remove(source);
            source.Stop();
            GameObject.Destroy(source);
        }
    }

    //�ı���Ч������С
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
