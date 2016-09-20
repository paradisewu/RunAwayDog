using UnityEngine;
using System.Collections;

public class TimerSample : TimerObserverOrSubject
{

    private TimerController m_TimerCtr = null;

    private bool m_IsCanDisplay = false;

    private string m_DisplayContent = "Hello, candycat!";

    // Use this for initialization  
    void Start()
    {
        m_TimerCtr = Singleton.getInstance("TimerController") as TimerController;

        //m_TimerCtr.SetTimer(this, Display, m_DisplayContent, 5);  

        m_TimerCtr.SetTimer(this, Display, null, this, IsCanDisplay, null);

        StartCoroutine(DelayDisplay());
    }

    void Display(object arg)
    {
        if (arg == null)
        {
            Debug.Log(m_DisplayContent);
        }
        else
        {
            string content = arg as string;

            Debug.Log(content);
        }
    }

    bool IsCanDisplay(object arg)
    {
        return m_IsCanDisplay;
    }

    IEnumerator DelayDisplay()
    {
        yield return new WaitForSeconds(5.0f);

        m_IsCanDisplay = true;
    }

    // Update is called once per frame  
    void Update()
    {

    }
}