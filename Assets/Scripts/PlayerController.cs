using UnityEngine;
using System.Collections;
using Rollaball.Models;
using AssemblyCSharp;
using System;
using Pegah.SaaS.Config;
using Rollaball;

public class PlayerController : MonoBehaviour 
{	
	public float speed;
	public GUIText countText;
	public GUIText winText;
	public GUIText timerText;
	public GUIText bestText;
	private int count;
	private int numberOfGameObjects;
	private bool sentRequest = false;
	private double time = 0;

	public class RollABallDataProvider : SaaSDataProvider {
		private PlayerPrefs playerPrefs = new PlayerPrefs ();
		
		public void save(String key, String value){
			PlayerPrefs.SetString (key, value);
		}
		
		public String Load(String key){
			if (!KeyExists (key))
				return null;
			return PlayerPrefs.GetString (key);
		}
		
		public bool KeyExists(String key){
			return (PlayerPrefs.GetString (key) != null);
		}
		
		public void Remove(String key){
			PlayerPrefs.DeleteKey (key);
		}
	}
	
	void Start()
	{
		RollaballConfiguration.initialize(new RollABallDataProvider());
		numberOfGameObjects = GameObject.FindGameObjectsWithTag("PickUp").Length;
		count = 0;
		SetCountText();
		winText.text = "";
		bestText.text = "";
		BacktoryModules.getHighScore ((LeaderboardListResponse leaderboardListResponse) => {
			bestText.text = "Best: " + Math.Round(leaderboardListResponse.Data[0].Time, 1);
		}, (int resultCode) => {
			Debug.Log("failure: " + resultCode + "");
		});
	}
	
	void FixedUpdate ()
	{
		float moveHorizontal = 0f, moveVertical = 0f;
		if (Application.platform == RuntimePlatform.Android) {
			moveHorizontal = (float)Input.acceleration.x;
			moveVertical = (float)Input.acceleration.y;
		} else {
			moveHorizontal = (float)Input.GetAxis ("Horizontal");
			moveVertical = (float)Input.GetAxis ("Vertical");
		}

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		
		rigidbody.AddForce (movement * speed * Time.deltaTime);
		if (!sentRequest) {
			time += Time.deltaTime;
			timerText.text = "Time: " + Math.Round (time, 1);
		}
	}

	void OnGUI() {
		if (sentRequest) {
			if(GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2, 100, 100), "Reset")) {
				Application.LoadLevel(0);
			}
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.tag == "PickUp")
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
		}
	}
	
	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString();
		if(count >= numberOfGameObjects) {
			winText.text = "YOU WIN!";
			LeaderboardEntity leaderboardEntity = new LeaderboardEntity();
			leaderboardEntity.DeviceId = Utils.getDeviceId();
			leaderboardEntity.Time = time;
			if (!sentRequest){
				BacktoryModules.saveOrUpdate(leaderboardEntity);
				sentRequest = true;
			}
		}
	}
}
