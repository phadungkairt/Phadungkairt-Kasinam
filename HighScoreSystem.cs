using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreSystem : MonoBehaviour
{
	public Text hightxt;
	void Start()
	{
		hightxt.text = "High Score : " + PlayerPrefs.GetInt("HighScore", 0);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
