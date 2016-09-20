using UnityEngine;
using System.Collections;

public class MovieSetByClip : MonoBehaviour 
{
	public CMovieCtrl[] CameraClips;
    public GameObject[] UIClips;

	int IndexOfClip=0;
	bool IsPass=false;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		PlayMove ();
	}

	void PlayMove()
	{
		if(!IsPass)
		{
            if (UIClips.Length <= 0)
            {
                return;
            }

			CameraClips[IndexOfClip].Begin=true;
			CameraClips[IndexOfClip].Finish=false;
			transform.parent=CameraClips[IndexOfClip].transform;
			transform.localPosition=Vector3.zero;
			transform.localEulerAngles=Vector3.zero;
			IsPass=true;

            //

            for (int i = 0; i < UIClips.Length; i++)
            {
                if(i==IndexOfClip)
                {
                    UIClips[i].SetActive(true);
                }
                else
                {
                    UIClips[i].SetActive(false);
                }
            }
		}
		
		if(CameraClips[IndexOfClip].Finish)
		{
			if(IsPass)
			{
				IsPass=false;
				if(IndexOfClip<CameraClips.Length-1)
				{
					IndexOfClip++;
				}
				else
				{
					IndexOfClip=0;
				}
			}
		}
	}
}
