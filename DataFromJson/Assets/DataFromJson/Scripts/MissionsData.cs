using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Pathfinding.Serialization.JsonFx;

public class MissionsData : MonoBehaviour {
	public List<MissionInformationDataConfig> allMissionDataConfig = new List<MissionInformationDataConfig>();



	private void Start (){
		allMissionDataConfig = getmissionObjectDatafromJSON ();
		//		Debug.Log ("Getting DAta");
	}


	public void ReadJsonFile (){
		TextAsset textFile = Resources.Load ("MissionInfo", typeof(TextAsset)) as TextAsset;
		Debug.Log (textFile.ToString());
		deserialiseMissionsDataFormString (textFile.ToString());
		//		Debug.Log (RootMissionInformationData.json_data.Count);
	}

	public static List<MissionInformationDataConfig> getmissionObjectDatafromJSON(){

		TextAsset textFile = Resources.Load ("MissionInfo", typeof(TextAsset)) as TextAsset;
		//		Debug.Log (textFile.ToString());
		deserialiseMissionsDataFormString (textFile.ToString());

		Debug.Log (RootMissionInformationData.json_data.Count);
		List<MissionInformationDataConfig> config = new List<MissionInformationDataConfig>();
		for (int i = 0; i < RootMissionInformationData.json_data.Count; i++) {
			MissionInformationData tData = RootMissionInformationData.json_data[i];
			config.Add (new MissionInformationDataConfig (tData.missionName, tData.subHeading, tData.missionID, tData.description, tData.timer, tData.missionType, tData.XP, tData.Gold));
		}
		return config;
	}



	public  class RootMissionInformationData
	{
		public static List<MissionInformationData> json_data { get; set; }
	}

	public static RootMissionInformationData obj_MissionData = new RootMissionInformationData();

	public static void deserialiseMissionsDataFormString(string dataString)
	{
		//		obj_MissionData = JsonUtility.FromJson<RootMissionInformationData> (dataString);
		obj_MissionData = JsonReader.Deserialize<RootMissionInformationData>(dataString);
		Debug.Log(obj_MissionData.ToString());
	}

}


[System.Serializable]
public class SaveMissionData
{
	public List<MissionInformationDataConfig> mission_data = new List<MissionInformationDataConfig>();
}


[System.Serializable]
public class MissionInformationData
{
	public string missionName { get; set; }
	public string subHeading { get; set; }
	public string missionID { get; set; }
	public string description { get; set; }
	public int timer { get; set; }
	public string missionType { get; set; }
	public int XP { get; set; }
	public int Gold { get; set; }
}

[System.Serializable]
public class MissionInformationDataConfig
{
	public string missionName ;
	public string subHeading ;
	public string missionID ;
	public string description ;
	public int timer ;
	public string missionType ;
	public int XP;
	public int Gold;

	public MissionInformationDataConfig (string missionName, string subHeading, string missionID, string description, int timer, string missionType, int XP, int Gold){
		this.missionName = missionName;
		this.subHeading = subHeading;
		this.missionID = missionID;
		this.description = description;
		this.timer = timer;
		this.missionType = missionType;
		this.XP = XP;
		this.Gold = Gold;

	}

}
