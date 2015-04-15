using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour 
{
    protected UnityCallAndroid pMyAndroid ;
    void Awake()
    {

    }
	// Use this for initialization
	void Start () 
    {
        // tips: this.transform = "Main Camera"
        pMyAndroid = this.transform.GetComponent<UnityCallAndroid>();
	}	
	// Update is called once per frame
	void Update () 
    {
	
	}
    //
    protected string szSubject = "WORD-O-MAZE";
    protected string szBody = "PLAY THIS AWESOME. GET IT ON THE PLAYSTORE";
    protected string sTemp = "..";
    void OnGUI()
    {
        int iUnitY = Screen.height / (9+5) ;
        int iSizeY = (iUnitY > 30) ? iUnitY : 30;
        int iSizeX = Screen.width / 2;
        int iSeparator = (iSizeY > 20) ? (iSizeY + 20) : (iSizeY + 10);
		int iY = 10 ;
        if (GUI.Button(new Rect(10, iY, iSizeX, iSizeY), "Unity Call Android Show AlertDialog"))
        {
            pMyAndroid.UnityCallAndroidAlert("Complete!", "Retry?", "OK", "CANCEL");
        }
        iY += iSeparator;
        if (GUI.Button(new Rect(10, iY, iSizeX, iSizeY), "Unity Call Android Show Toast"))
        {
            pMyAndroid.UnityCallAndroidToast("You are not prepared!");
        }
        iY += iSeparator;
        if (GUI.Button(new Rect(10, iY, iSizeX, iSizeY), "Unity Call Android Show PopupWindow"))
        {
            int iPopX = (int)(Screen.width * 0.8);
            int iPopY = (int)(Screen.height * 0.3);
            pMyAndroid.UnityCallAndroidPopupWindow(iPopX, iPopY, "Drink Health Pot", "Drink mana pot", "Quit");
        }
        iY += iSeparator;
        if (GUI.Button(new Rect(10, iY, iSizeX, iSizeY), "Unity Call Android Share Text"))
        {
            pMyAndroid.UnityCallAndroidShareText(szSubject, szBody);
        }
        iY += iSeparator;
        if (GUI.Button(new Rect(10, iY, iSizeX, iSizeY), "Unity Call Android SDK VersionName")) 
		{
            pMyAndroid.UnityCallAndroidGetVersionNameAndVersionCode();
			sTemp = pMyAndroid.GetVersioName() ;
		}
        iY += iSeparator;
        if (GUI.Button(new Rect(10, iY, iSizeX, iSizeY), "Unity Call Android SDK VersionCode"))
		{
            pMyAndroid.UnityCallAndroidGetVersionNameAndVersionCode();
            sTemp = pMyAndroid.GetVersioCode();
		}
        iY += iSeparator;
        if (GUI.Button(new Rect(10, iY, iSizeX, iSizeY), sTemp))
		{

		}
        iY += iSeparator;
        if (GUI.Button(new Rect(10, iY, iSizeX, iSizeY), "Reset"))
        {
            pMyAndroid.reset();
        }
        iY += iSeparator;
        if (GUI.Button(new Rect(10, iY, iSizeX, iSizeY), "Quit"))
        {
            pMyAndroid.UnityFinish();
        }
        iY += iSeparator;
        GUI.Label(new Rect(10, iY, iSizeX, iSizeY), sTemp);
    }
}