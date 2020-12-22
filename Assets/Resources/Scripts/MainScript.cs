using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public enum actions
{
    hello,no , hi ,ohk,bye
}
public class MainScript : MonoBehaviour
{
    public actions a;
    

   
   // string s = "BOo";
    // Start is called before the first frame update
    void Start()
    {
        //TimeManager.Instance.Initialize();
        //TimeManager.Instance.AddDelegate(MyString,5.5f);
        string g = "Hellloooooo";
        TimeManager.Instance.Initialize();   
        TimeManager.MyDelegate d = () => { OutputString(g); };
        TimeManager.Instance.AddDelegate(d, 4.5f,3);
        g = "No Way";
        TimeManager.MyDelegate m = () => { OutputString(g); };
        TimeManager.Instance.AddDelegate(m, 9f,3);

        //TimeManager.Instance.AddArgumentDeleGate(MyStr, 5.5f);
        // TimeManager.Instance.AddArgumentDeleGate(


      


        int[] arr = new int[] { 1, 2, 3, 4, 5 };
        IEnumerable<string> lol = arr.Select(x => x.ToString());
        for (int i = 0; i < lol.Count(); i++)
        {
            Debug.Log("Element at : " + arr.ElementAt(i));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeManager.Instance.Refresh();
    }
    public void MyString()
    {
        Debug.Log("Hello");
    }

    public string MyStr(string b)
    {
        return b;
    }

    public void MyString(string s,int a ,float j)
    {
        Debug.Log("Its String: " + s + " Its Int: " + a + " float j: " + j);
    }

    public void OutputString(string s)
    {
        Debug.Log("String is: " + s);
    }
}
