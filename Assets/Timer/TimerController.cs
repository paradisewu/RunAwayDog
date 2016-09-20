using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimerController : MonoBehaviour
{

    public delegate void OnCallBack(object arg);
    public delegate bool OnIsCanDo(object arg);

    public class Timer
    {
        public TimerObserverOrSubject m_Observer;
        public OnCallBack m_Callback = null;
        public object m_Arg = null;

        public TimerObserverOrSubject m_Subject;
        public OnIsCanDo m_IsCanDoFunc = null;
        public object m_ArgForIsCanDoFunc = null;

        public float m_PassTime = 0;

        public Timer(TimerObserverOrSubject observer, OnCallBack callback, object arg,
            TimerObserverOrSubject subject, OnIsCanDo isCanDoFunc, object argForIsCanDo)
        {
            m_Observer = observer;
            m_Callback = callback;
            m_Arg = arg;

            m_Subject = subject;
            m_IsCanDoFunc = isCanDoFunc;
            m_ArgForIsCanDoFunc = argForIsCanDo;

            m_PassTime = 0;
        }

        public Timer(TimerObserverOrSubject observer, OnCallBack callback, object arg, float time)
        {
            m_Observer = observer;
            m_Callback = callback;
            m_Arg = arg;

            m_Subject = null;
            m_IsCanDoFunc = null;
            m_ArgForIsCanDoFunc = null;

            m_PassTime = time;
        }
    }
    private List<Timer> m_Timers = new List<Timer>();
    private List<Timer> m_NeedRemoveTimer = new List<Timer>();
    private List<Timer> m_CurRunTimer = new List<Timer>();

    /// <summary>  
    /// Sets the timer.  
    /// </summary>  
    /// <param name='observer'>  
    /// The TimerObserverOrSubject you need to listen  
    /// </param>  
    /// <param name='callback'>  
    /// The callback when condition is true.  
    /// </param>  
    /// <param name='arg'>  
    /// Argument of the callback.  
    /// </param>  
    /// <param name='observer'>  
    /// The TimerObserverOrSubject you need to observe  
    /// </param>  
    /// <param name='isCanDoFunc'>  
    /// The condition function, must return a boolean.  
    /// </param>  
    /// <param name='argForIsCanDo'>  
    /// Argument for condition function.  
    /// </param>  
    public void SetTimer(TimerObserverOrSubject observer, OnCallBack callback, object arg,
        TimerObserverOrSubject subject, OnIsCanDo isCanDoFunc, object argForIsCanDo)
    {
        if (observer == null || subject == null || callback == null || isCanDoFunc == null) return;

        if (isCanDoFunc(argForIsCanDo))
        {
            callback(arg);
            return;
        }

        Timer timer = new Timer(observer, callback, arg, subject, isCanDoFunc, argForIsCanDo);
        m_Timers.Add(timer);
    }

    /// <summary>  
    /// Sets the timer.  
    /// </summary>  
    /// <param name='observer'>  
    /// The TimerObserverOrSubject you need to listen  
    /// </param>  
    /// <param name='callback'>  
    /// The callback when time is up.  
    /// </param>  
    /// <param name='arg'>  
    /// Argument of the callback.  
    /// </param>  
    /// <param name='timepass'>  
    /// Timepass before calling the callback.  
    /// </param>  
    public void SetTimer(TimerObserverOrSubject observer, OnCallBack callback, object arg, float timepass)
    {
        if (observer != null && callback != null)
        {
            Timer timer = new Timer(observer, callback, arg, timepass);
            m_Timers.Add(timer);
        }
    }

    /// <summary>  
    /// Clears all Timers of the observer.  
    /// </summary>  
    /// <param name='observer'>  
    /// The TimerObserverOrSubject you need to clear  
    /// </param>  
    public void ClearTimer(TimerObserverOrSubject observer)
    {
        List<Timer> needRemovedTimers = new List<Timer>();

        foreach (Timer timer in m_Timers)
        {
            if (timer.m_Observer == observer || timer.m_Subject)
            {
                needRemovedTimers.Add(timer);
            }
        }

        foreach (Timer timer in needRemovedTimers)
        {
            m_Timers.Remove(timer);
        }
    }

    // Update is called once per frame  
    void Update()
    {
        InitialCurTimerDict();
        RunTimer();
        RemoveTimer();
    }

    private void InitialCurTimerDict()
    {
        m_CurRunTimer.Clear();

        foreach (Timer timer in m_Timers)
        {
            m_CurRunTimer.Add(timer);
        }
    }

    private void RunTimer()
    {
        m_NeedRemoveTimer.Clear();

        foreach (Timer timer in m_CurRunTimer)
        {
            if (timer.m_IsCanDoFunc == null)
            {
                timer.m_PassTime = timer.m_PassTime - Time.deltaTime;
                if (timer.m_PassTime < 0)
                {
                    timer.m_Callback(timer.m_Arg);
                    m_NeedRemoveTimer.Add(timer);
                }
            }
            else
            {
                if (timer.m_IsCanDoFunc(timer.m_ArgForIsCanDoFunc))
                {
                    timer.m_Callback(timer.m_Arg);
                    m_NeedRemoveTimer.Add(timer);
                }
            }
        }
    }

    private void RemoveTimer()
    {
        foreach (Timer timer in m_NeedRemoveTimer)
        {
            if (m_Timers.Contains(timer))
            {
                m_Timers.Remove(timer);
            }
        }
    }

}