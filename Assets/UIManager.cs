using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
public class UIManager : MonoBehaviour {

	public Text time;
	public Text timeBig;
	public float timer = 0.0f;
	public float pTimer;
    public float cTimer;
    public float minute;
    public float pMinute;
    public float pickCheck;
    public bool pickOn = false;
	public bool timerCheck = true;
	public bool deleteData;

	List<float> fList = new List<float> ();
    List<float> pList = new List<float>();

    

    // Use this for initialization
    void Start()
	{
		if(deleteData)
		PlayerPrefs.DeleteAll ();

        Cursor.visible = false;
	}

	// Update is called once per frame
	void Update()
	{
        timeCheck();
    }

    void timeCheck()
    {
        if (timerCheck != false)
        {
            timer += Time.deltaTime;
            pTimer += Time.deltaTime;
            cTimer += Time.deltaTime;
            time.text = "Time = " + minute.ToString() + "m " + timer.ToString("F1") + "s";

        }
        if (timer > 60)
        {
            timer = 0;
            minute += 1;
        }
        if (cTimer > 60)
        {
            cTimer = 0;
            pMinute += 1;
        }
        timeBig.text = "Best Time = " + PlayerPrefs.GetFloat("minute").ToString("F0") + "m " + PlayerPrefs.GetFloat("cTimer").ToString("F1") + "s";
    }

    public void temper()
    {
        pickCheck += 1;
    }


	void OnApplicationQuit()
	{
		timerCheck = false;
        PlayerPrefs.SetFloat("pickUpCheck", pickCheck);
		PlayerPrefs.SetFloat ("timer", pTimer);
        PlayerPrefs.SetFloat("cTimer", cTimer);
        PlayerPrefs.SetFloat("minute", pMinute);
		PlayerPrefs.Save ();
        //saving the time to the list
		fList.Add (cTimer);
        pList.Add (pickCheck);
        //converting from float list to string list
		List<string> sList = fList.ConvertAll<string> (x => x.ToString ());
        List<string> sPList = pList.ConvertAll<string>(x => x.ToString());
        //converting from string list to string
        string myString = string.Join (",", sList.ToArray ());
        string myPString = string.Join(",", sPList.ToArray());
        //writing the timer to a folder
        StreamWriter sw = File.AppendText("TextFolder");
        StreamWriter swP = File.AppendText("TextPFolder");
        sw.WriteLine(myString);
        swP.WriteLine(myPString);
        sw.Close();
        swP.Close();
	}
}
