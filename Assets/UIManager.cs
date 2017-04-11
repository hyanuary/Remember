using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public Text time;
	public Text timeBig;
	public float timer = 0.0f;
	public float pTimer;
	public bool timerCheck = true;
	public bool deleteData;

	List<float> fList = new List<float> ();

	// Use this for initialization
	void Start()
	{
		if(deleteData)
		PlayerPrefs.DeleteAll ();
	}

	// Update is called once per frame
	void Update()
	{
		
		if (timerCheck != false) {
			timer += Time.deltaTime;
			pTimer += Time.deltaTime;
			time.text = "Time = " + timer.ToString ("F1");

		}
		timeBig.text = "Best Time = " + PlayerPrefs.GetFloat ("timer").ToString("F1");

	}

	void OnApplicationQuit()
	{
		timerCheck = false;
		PlayerPrefs.SetFloat ("timer", pTimer);
		PlayerPrefs.Save ();
		fList.Add (pTimer);
		List<string> sList = fList.ConvertAll<string> (x => x.ToString ());
		string myString = string.Join (",", sList.ToArray ());
		System.IO.File.WriteAllText ("TextFolder", myString);
	}
}
