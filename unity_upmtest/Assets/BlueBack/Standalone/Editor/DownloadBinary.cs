

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief ダウンロードバイナリー。
*/


/** BlueBack.Standalone.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.Standalone.Editor
{
	/** DownloadBinary
	*/
	public static class DownloadBinary
	{
		/** Get
		*/
		public static byte[] Get(string a_url)
		{
			try{
				using(UnityEngine.Networking.UnityWebRequest t_webrequest = ((System.Func<UnityEngine.Networking.UnityWebRequest>)(()=>{
					return UnityEngine.Networking.UnityWebRequest.Get(a_url);
				}))()){
					UnityEngine.Networking.UnityWebRequestAsyncOperation t_async = t_webrequest.SendWebRequest();
					while(true){
						System.Threading.Thread.Sleep(1);
						if(t_async.isDone == true){
							if(t_webrequest.error != null){
								string t_text = "";
								if(t_webrequest.downloadHandler.text != null){
									t_text = t_webrequest.downloadHandler.text;
								}
								UnityEngine.Debug.LogError(a_url + " : " + t_webrequest.error + " : " + t_text);
								return null;
							}else{
								return t_webrequest.downloadHandler.data;
							}
						}
					}
				}
			}catch(System.Exception t_exception){
				UnityEngine.Debug.LogError(a_url + " : " + t_exception.Message + "\n" + t_exception.StackTrace);
				return null;
			}
		}
	}
}
#endif

