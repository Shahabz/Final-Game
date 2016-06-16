using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

	public static GameControl control;

	public float numOfBlocks;
	public int[] starsArray;

	void Awake() 
	{
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
			starsArray[0] = 0;
			for(int i = 1; i < 20; i++) {
				starsArray[i] = -1;
			}
			numOfBlocks = 20;
		} else if (control != this) {
			Destroy (gameObject);
		}
	}

	// game will automatically save each game after every update and 
	// load the game automatically upon opening the game after closing it
	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData ();
		data.numOfBlocks = numOfBlocks;	
		data.starsArray = starsArray;

		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load() 
	{
		if(File.Exists(Application.persistentDataPath + "/playerInfo.dat")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();

			numOfBlocks = data.numOfBlocks;
			starsArray = data.starsArray;
		}
	}

	// for debugging purposes only - show info on page...)
//	void OnGUI() 
//	{
//		GUI.Label (new Rect (100, 10, 100, 300), "Num of Blocks: " + numOfBlocks);
//		GUI.Label (new Rect (100, 40, 150, 300), "Stars level 1: " + starsArray[0]);
//		GUI.Label (new Rect (100, 80, 200, 300), "Stars level 2: " + starsArray [1]);
//	}
}

[Serializable]
class PlayerData {
	public float numOfBlocks;
	public int[] starsArray;
}

