using UnityEngine;
using System.Collections;

public class SpeechToText : MonoBehaviour{
	
	public KeyCode CommandKey = KeyCode.RightCommand;
	private int Commanding = 0;
	private bool SecondKeyOn = false;
	public string textInput = "";
	
	void Update(){
		CheckCommandFirst();
	}
	
	void CheckCommandFirst(){
		// check if 'command' is clicked
		if(Input.GetKeyDown(CommandKey) && Commanding == 0 && SecondKeyOn == false){
			Debug.LogWarning("First Command");
			Commanding = 1;
			textInput = textInput.Insert(textInput.Length, Input.inputString);
		}else if(Input.GetKeyUp(CommandKey) && (Commanding == 1 || Commanding == 2) && SecondKeyOn == false){
			Debug.LogWarning("First Button's off");
			Commanding = 2;
			SecondKeyOn = true;
			textInput = textInput.Insert(textInput.Length, Input.inputString);
			CheckCommandSecond();
		}else if(Commanding == 1 || Commanding == 2){
			Debug.LogWarning("Checking First Command: "+Commanding+", "+SecondKeyOn);
			textInput = textInput.Insert(textInput.Length, Input.inputString);
			CheckCommandSecond();
		}
	}

	void CheckCommandSecond(){
		// check if 'command' is clicked again
		if(Input.GetKeyDown(CommandKey) && Commanding == 2 && SecondKeyOn == true){
			textInput = textInput.Insert(textInput.Length, Input.inputString);
			Debug.LogWarning("Second Command");
			Commanding = 3;
			Debug.LogWarning(textInput);
			Commanding = 0;
			SecondKeyOn = false;
			textInput = "";
		}else{
			Debug.LogWarning("Checking Second Command: "+Commanding+", "+SecondKeyOn);
			textInput = textInput.Insert(textInput.Length, Input.inputString);
		}
	}
}




//
//using UnityEngine;
//using System;
//using System.Collections;
//
//public class SpeechToText : MonoBehaviour {
//
//	public string textInput;
//
//	void OnGUI(){
//		if (textInput.Length < 7) {
//			textInput += Input.GetKey;	
//		} else {
//			Debug.Log (textInput);
//			textInput = "";
//		}
//	}
//
//	public void FuncForTimer()
//	{
//		System.Timers.Timer aTimer = new System.Timers.Timer();
//		aTimer.Elapsed+=new ElapsedEventHandler(OnTimedEvent);
//		aTimer.Interval=5000;
//		aTimer.Enabled=true;
//		
//		Console.WriteLine("Press \'q\' to quit the sample.");
//		while(Console.Read()!='q');
//	}
//	
//	// Specify what you want to happen when the Elapsed event is raised.
//	private static void OnTimedEvent(object source, ElapsedEventArgs e)
//	{
//		Console.WriteLine("Hello World!");
//	
//	 Use this for initialization
//	void Start () {
//		Console.WriteLine("Started");
//		while (true) {
//			if(Console.Read() ==null){
//				;
//			}else{
//				Console.WriteLine(Console.ReadLine());
//			}
//		}
//	}
//	
//	// Update is called once per frame
//	void Update () {
//
//	}
//}