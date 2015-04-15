using UnityEngine;
using System.Collections;

public class UnityCallAndroid : MonoBehaviour 
{
	protected bool bOneTimeSetAlert = false ;
	protected bool bOneTimeSetToast = false ;
    protected bool bOneTimeSetPopup = false ;
    protected bool bOneTimeSetShare = false ;
    protected bool bOneTimeSetVersion = false;
	void Awake()
	{
	}
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		//點擊手機返回鍵關閉應用程序
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Home) )
		{
			Application.Quit();
		}
	}        
    /// <summary>
    /// unity call android toast()
    /// </summary>
    /// <param name="sToastString">訊息內容</param>    
	public void UnityCallAndroidToast(string sToastString)
	{
		if (bOneTimeSetToast == true) return ;
		bOneTimeSetToast = true ;
		//
		AndroidJavaClass ajc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject ajo = ajc.GetStatic<AndroidJavaObject>("currentActivity");			
		//functionName , ToastMessage
        ajo.Call("androidShowToast", sToastString);
	}
    /// <summary>
    /// unity call android AlertDialog()
    /// </summary>
    /// <param name="sInformation">內容</param>
    /// <param name="sTitle">標題</param>
    /// <param name="sLeftButton">左鍵</param>
    /// <param name="sRightButton">右鍵</param>
	public void UnityCallAndroidAlert(string sInformation,string sTitle,string sLeftButton,string sRightButton)
	{
		if (bOneTimeSetAlert == true) return ;
		bOneTimeSetAlert = true ;
		//
		AndroidJavaClass ajc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject ajo = ajc.GetStatic<AndroidJavaObject>("currentActivity");
		//functionName , DialogTitle , DialogMessage , PositiveButton Name , NegativeButton Name
        ajo.Call("androidShowAlertDialog", sInformation, sTitle, sLeftButton, sRightButton);	
	}
    /// <summary>
    /// unity call android finish()
    /// </summary>
	public void UnityCallAndroidFinish()
	{
		AndroidJavaClass ajc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject ajo = ajc.GetStatic<AndroidJavaObject>("currentActivity");
		ajo.Call("exit");
	}
    /// <summary>
    /// Test 2nd Jar file
    /// unity call android toast()
    /// </summary>
    /// <param name="sToastString"></param>
	public void UnityCallAndroidToast2(string sToastString)
	{
		if (bOneTimeSetToast == true) return ;
/*		bOneTimeSetToast = true ;
		//
		AndroidJavaClass ajc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject ajo = ajc.GetStatic<AndroidJavaObject>("currentActivity");			
		//functionName , ToastMessage
		ajo.Call("showToast2" , sToastString);
*/	}
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
	public int UnityCallAndroidSDKVersion()
	{
/*		AndroidJavaClass ajc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject ajo = ajc.GetStatic<AndroidJavaObject>("currentActivity");
		int iHash = ajo.Call<int>("getAndroidSDKVersion");
		return iHash ;
*/	
        return 16 ;
	}
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
	public string UnityCallAndroidVersionName()
	{
/*		AndroidJavaClass ajc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject ajo = ajc.GetStatic<AndroidJavaObject>("currentActivity");
		return (ajo.Call<string>("getAndroidVersionName"));
*/		return "2nd Jar File need 2nd AndroidManifest file! and it will return 4.1.1 ! by each android phone. " ;
	}
    /// <summary>
    //  unity call android ' Intent.putExtra(android.content.Intent.EXTRA_SUBJECT, subject);
    //  unity call android ' Intent.putExtra(android.content.Intent.EXTRA_TEXT, body);
    /// </summary>
    /// <param name="szSubject"></param>
    /// <param name="szBody"></param>
    public void UnityCallAndroidShareText(string szSubject , string szBody)
    {
        if (bOneTimeSetShare == true) return;
        bOneTimeSetShare = true;
        //
        AndroidJavaClass ajc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject ajo = ajc.GetStatic<AndroidJavaObject>("currentActivity");
        ajo.Call("androidShareText", szSubject, szBody);
    }
    /// <summary>
    /// Unity call Android method Show PopupWindow     
    /// </summary>
    /// <param name="iWidth">彈出式視窗的寬</param>
    /// <param name="iHeight">彈出式視窗的高</param>
    /// <param name="sTopButton">上鍵</param>
    /// <param name="sMiddleButton">中鍵</param>
    /// <param name="sBottomButton">下鍵</param>
    public void UnityCallAndroidPopupWindow(int iWidth , int iHeight , string sTopButton, string sMiddleButton, string sBottomButton)
    {
        if (bOneTimeSetPopup == true) return;
        bOneTimeSetPopup = true;
        //
        AndroidJavaClass ajc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject ajo = ajc.GetStatic<AndroidJavaObject>("currentActivity");
        //functionName , DialogTitle , DialogMessage , PositiveButton Name , NegativeButton Name
        ajo.Call("androidShowPopupWindow", iWidth, iHeight , sTopButton, sMiddleButton, sBottomButton);
    }
    /// <summary>
    /// Unity call android method to get version name and version code
    /// </summary>
    public void UnityCallAndroidGetVersionNameAndVersionCode()
    {
        if (bOneTimeSetVersion == true) return;
        bOneTimeSetVersion = true;
        //
        AndroidJavaClass ajc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject ajo = ajc.GetStatic<AndroidJavaObject>("currentActivity");
        ajo.Call("androidSDKVersion");
    }
    /// <summary>
    /// android call unity quit()
    /// </summary>
	public void UnityFinish()
	{
		Application.Quit() ;
	}
    /// <summary>
    /// Android Callback unity Function, after AlertDialog click button
    /// </summary>
    /// <param name="sClickButton">彈出式對話盒按了哪個鍵</param>
	public void UnityAlertDialogOnClick(string sClickButton)
	{
		//Android AlertDialog "OK" pressed.(PositiveButtonName)
		if (string.Compare(sClickButton , "POSITIVE") == 0)
		{
		  //Application.LoadLevel(Application.loadedLevel);
			reset() ;
		}
		//Android AlertDialog "CANCEL" pressed.(NegativeButtonName)
		if (string.Compare(sClickButton , "NEGATIVE") == 0)
		{
			Application.Quit() ;
		}
		//Android AlertDialog "Middle Button" pressed.(NeutralButtonName)
		if (string.Compare(sClickButton , "NEUTRAL") == 0)
		{
			Application.Quit() ;
		}
	}
    /// <summary>
    /// Android Callback unity Function, after Menu(PopupWindow) Clicked.
    /// </summary>
    /// <param name="sKeyword">彈出式視窗按了哪個鍵</param>
    public void UnityPopupWindowOnClick(string sKeyword)
	{
		if (string.Compare(sKeyword , "TOP") == 0)
		{
            reset();
		}
        else if (string.Compare(sKeyword, "MIDDLE") == 0)
		{
            Application.Quit();
		}
        else if (string.Compare(sKeyword, "BOTTOM") == 0)
        {
            Application.Quit();
        }
		else
			return ;//no thing happen..hmm?
	}
    protected string sVersionName = "";
    protected string sVersionCode = "";
    /// <summary>
    /// Android callback unity function , after android get VersionName or VedrsioCode
    /// </summary>
    /// <param name="sValue">取得VersioName,Ex:1.2.12.435</param>
    public void UnityGetAndroidSDKVersionName(string sValue) { sVersionName = string.Copy(sValue); }
    /// <summary>
    /// Android callback unity function , after android get VersionName or VedrsioCode
    /// </summary>
    /// <param name="sValue">取得VersioCode,Ex:10</param>
    public void UnityGetAndroidSDKVersionCode(string sValue) { sVersionCode = string.Copy(sValue); }
    public string GetVersioName() { return sVersionName ; }
    public string GetVersioCode() { return sVersionCode ; }
	//
	public void reset()
	{
		bOneTimeSetAlert = false ;
		bOneTimeSetToast = false ;
        bOneTimeSetPopup = false ;
        bOneTimeSetShare = false ;
        bOneTimeSetVersion = false;
	}
}
