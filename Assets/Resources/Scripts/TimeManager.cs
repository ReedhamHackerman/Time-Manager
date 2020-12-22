using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager
{
    public delegate void MyDelegate();
    MyDelegate myDelegate;
    private static TimeManager instance;
    public static TimeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new TimeManager();
            }
            return instance;
        }
    }
    public delegate string MyArgumentDelegate(string S);

   


    List<DelegateTimer> delegateTimerList;
    public void Initialize()
    {
        delegateTimerList = new List<DelegateTimer>();
    }
    public void Refresh()
    {
        for (int i = delegateTimerList.Count-1; i >= 0; i--)
        {
            if (delegateTimerList[i].timeToInvoke<=Time.time)
            {
                for (int j = 0; j < delegateTimerList[i].repeat; j++)
                {
                    try
                    {
                        delegateTimerList[i].delegateToInvoke();
                    }
                    catch (System.Exception)
                    {

                        Debug.LogError("Exception Thrown");
                    }
                   
                }
                
                delegateTimerList.RemoveAt(i);
            }
        }
    }
    public void EndGame()
    {
        delegateTimerList.Clear();
    }


    public void AddDelegate(MyDelegate del,float time,int repeat)
    {
        DelegateTimer toADD = new DelegateTimer(Time.time + time, del,repeat);
        delegateTimerList.Add(toADD);
       
    }

    public void AddArgumentDeleGate(MyArgumentDelegate arg,float time)
    {
        DelegateTimer toadd = new DelegateTimer(time + Time.time, arg);
        delegateTimerList.Add(toadd);
    }



    private class DelegateTimer
    {
       public float timeToInvoke;
       public   MyDelegate delegateToInvoke;
       public MyArgumentDelegate MyArgumentDelegate;
       public int repeat;
        public DelegateTimer(float timeOfInvo,MyDelegate del)
        {
            this.timeToInvoke = timeOfInvo;
            this.delegateToInvoke = del;

        }
        public DelegateTimer(float timeOfInvo, MyArgumentDelegate myArgumentDelegate)
        {
            this.timeToInvoke = timeOfInvo;
            this.MyArgumentDelegate = myArgumentDelegate;
        }
        public DelegateTimer(float timeOfInvo,MyDelegate del,int repeat)
        {
            this.timeToInvoke = timeOfInvo;
            this.delegateToInvoke = del;
            this.repeat = repeat;
        }

    }
}