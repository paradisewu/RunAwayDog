using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UGUIMovie : MonoBehaviour
{
    //电影纹理

    public MovieTexture movTexture;
    public AudioClip myclip;

    void Start()
    {

        //GetComponent<RawImage>().material.mainTexture = movTexture;
        //movTexture.Play();
        string path1 = "file://" + Application.dataPath + "/LoadMovie/CricothyroidPuncture.mov";
        string path = "file://C:/Users/Administrator/Desktop/1.ogg";
        StartCoroutine(LoadMovie(path));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            movTexture.Play();
        }
    }

    IEnumerator LoadMovie(string path)
    {

        WWW www = new WWW(path);
        Debug.Log(path);
        yield return www;


        movTexture = www.movie;
        GetComponent<RawImage>().texture = movTexture;


        myclip = movTexture.audioClip;  // 加载视频音频
        GetComponent<AudioSource>().clip = myclip;
        movTexture.loop = true;
        movTexture.Play();
        GetComponent<AudioSource>().Play();
    }
}
