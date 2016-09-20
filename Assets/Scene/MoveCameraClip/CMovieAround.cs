using UnityEngine;
using System.Collections;

public class CMovieAround : MonoBehaviour 
{
	public Transform AroundRoot;
	public Transform CameraPoint;
    public Transform StartPoint;
    public Transform EndPoint;
	//public Vector3 StartAngle;
	//public Vector3 EndAngle;
	//public Vector3 StartPoint.localPosition;
	//public Vector3 EndPoint.localPosition;
	public float StartPush;
	public float EndPush;
	public float TimeLength;
	public float Delay;
	public bool IsLerp;
	//public bool Finish;

	float StartTime,Frame,FinishRedayTime;
	CMovieCtrl CMovieCtrl;
    bool IsBegin = false,IsPlayOnce=false, IsFinishReday;
    AudioSource TheAudio;
	// Use this for initialization
	void OnEnable () 
	{
        
		CMovieCtrl=GetComponent<CMovieCtrl>();

		StartTime = Time.time;
		Frame = TimeLength / 0.02f;//FixedUpdate每帧固定时间为0.02秒

        AroundRoot.position = StartPoint.position;
        AroundRoot.localEulerAngles = StartPoint.localEulerAngles;
		CameraPoint.localPosition = new Vector3 (0, 0, StartPush);
        TheAudio=GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
        if (CMovieCtrl.Finish=true)
        {
            CMovieCtrl.Finish = false;
			//CMovieCtrl.Begin = false;
        }
            
        //
		if(CMovieCtrl.Begin)
		{
			if(!IsBegin)
			{
				StartTime = Time.time;

                AroundRoot.position = StartPoint.position;
                AroundRoot.localEulerAngles = StartPoint.localEulerAngles;
                CameraPoint.localPosition = new Vector3(0, 0, StartPush);
				IsBegin=true;
                IsFinishReday = false;
			}
			else if(!IsLerp && !CMovieCtrl.Finish)
			{
				//旋转
                AroundRoot.localEulerAngles = new Vector3((EndPoint.localEulerAngles.x - StartPoint.localEulerAngles.x) / Frame + AroundRoot.localEulerAngles.x,
                                                        (EndPoint.localEulerAngles.y - StartPoint.localEulerAngles.y) / Frame + AroundRoot.localEulerAngles.y, 0);
														//(EndPoint.localEulerAngles.z-StartPoint.localEulerAngles.z)/Frame+AroundRoot.localEulerAngles.z);
				//移动
                AroundRoot.Translate((EndPoint.position - StartPoint.position) / Frame,Space.World);
				//推拉
				CameraPoint.Translate(0,0,(EndPush-StartPush)/Frame);

				if(Time.time-StartTime>TimeLength+Delay)
				{
                    //print(Time.time - StartTime);
					CMovieCtrl.Finish=true;
					CMovieCtrl.Begin=false;
					IsBegin=false;
				}
			}
            else if (IsLerp && !CMovieCtrl.Finish)
            {
                //旋转
                AroundRoot.localEulerAngles = Vector3.Lerp(AroundRoot.localEulerAngles, EndPoint.localEulerAngles, 10 / Frame);
                //移动
                AroundRoot.position = Vector3.Lerp(AroundRoot.position, EndPoint.localPosition, 10 / Frame);
                //推拉
                CameraPoint.localPosition = new Vector3(0, 0, Mathf.Lerp(CameraPoint.localPosition.z, EndPush, 10 / Frame));

                if (Vector3.Distance(AroundRoot.localEulerAngles, EndPoint.localEulerAngles) < 0.05f
                    && Vector3.Distance(AroundRoot.position, EndPoint.localPosition) < 0.05f
                    && Vector3.Distance(CameraPoint.localPosition, new Vector3 (0,0,EndPush)) < 0.05f)
                {
                    if(!IsFinishReday)
                    {
                        IsFinishReday = true;
                    }
                }
                else
                {
                    FinishRedayTime = Time.time;
                }

                if(IsFinishReday && Time.time - FinishRedayTime>Delay)
                {
                    CMovieCtrl.Finish = true;
                    CMovieCtrl.Begin = false;
                    IsFinishReday = false;
                    IsBegin = false;
                    /*
                    AroundRoot.position = StartPoint.localPosition;
                    AroundRoot.localEulerAngles = StartPoint.localEulerAngles;
                    CameraPoint.localPosition = new Vector3(0, 0, StartPush);*/
                }
            }
		}

        if (TheAudio != null)
        {
            if (CMovieCtrl.Begin && !CMovieCtrl.Finish)
            {
                //播放声音
                if (!TheAudio.isPlaying && !IsPlayOnce)
                {
                    TheAudio.Play();
                    IsPlayOnce = true;
                }
            }
            if (CMovieCtrl.Finish)
            {
                IsPlayOnce = false;
                //停止声音
                if (TheAudio.isPlaying)
                {
                    TheAudio.Stop();
                }
            }
        }
	}
		
}
