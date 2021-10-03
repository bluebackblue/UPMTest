

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 全パッケージインストール。
*/


/** BlueBack.Standalone.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.Standalone.Editor
{
	/** InstallAllPackage
	*/
	public class InstallAllPackage
	{
		/** LIST
		*/
		private readonly static string[] LIST = new string[]{
			"blueback.assetlib",			"AssetLib",
			"blueback.code",				"Code",
			"blueback.excel",				"Excel",
			"blueback.jsonitem",			"JsonItem",
			"blueback.mouse",				"Mouse",
			"blueback.pad",					"Pad",
			"blueback.scene",				"Scene",
			"blueback.slackwebapi",			"SlackWebApi",
			"blueback.testlib",				"TestLib",
			"blueback.timescale",			"TimeScale",
			"blueback.unityplayerloop",		"UnityPlayerLoop",
			"blueback.upmversionmanager",	"UpmVersionManager",
		};

		/** AUTHER
		*/
		private const string AUTHER = "bluebackblue";

		/** URL
		*/
		private const string URL = "https://github.com/<<Auther>>/<<Name>>.git?path=unity_<<Name>>/Assets/UPM<<Version>>";

		/** MenuITem_BlueBackl_InstallAllPackage

			「manifest.json」に追加すると追加したパッケージがインストールされる。

		*/
		[UnityEditor.MenuItem("BlueBack/InstallAllPackage")]
		public static void MenuITem_BlueBackl_InstallAllPackage()
		{
			//読み込み。
			string t_text;
			using(System.IO.StreamReader t_reader = new System.IO.StreamReader(UnityEngine.Application.dataPath + "/../Packages/manifest.json")){
				t_text = t_reader.ReadToEnd();
				t_reader.Close();
			}

			//一旦削除。
			for(int ii=0;ii<(LIST.Length / 2);ii++){
				t_text = RemovePackage(t_text,LIST[ii*2]);
			}

			for(int ii=0;ii<(LIST.Length / 2);ii++){
				string t_url = URL.Replace("<<Auther>>",AUTHER).Replace("<<Name>>",LIST[ii*2+1]);

				{
					string t_version = GetLastVersion(AUTHER,LIST[ii*2+1]);
					if(t_version == null){
						t_url = t_url.Replace("<<Version>>","");
					}else if(t_version.Length <= 0){
						t_url = t_url.Replace("<<Version>>","");
					}else{
						t_url = t_url.Replace("<<Version>>","#" + t_version);
					}
				}

				AddPackage(t_text,LIST[0],t_url);
			}

			//書き込み。
			using(System.IO.StreamWriter t_writer = new System.IO.StreamWriter(UnityEngine.Application.dataPath + "/../Packages/manifest.json")){
				t_writer.Write(t_text);
				t_writer.Flush();
				t_writer.Close();
			}
		}

		/** AddPackage
		*/
		private static string AddPackage(string a_text,string a_packagename,string a_url)
		{
			return  System.Text.RegularExpressions.Regex.Replace(a_text,"^(?<before>[\\d\\D\\n]*\\\"dependencies\\\"\\s*\\:\\s*\\{\\s*\\n)(?<after>[\\d\\D\\n]*)$",(System.Text.RegularExpressions.Match a_a_match)=>{
				UnityEngine.Debug.Log("AddPackage : " + a_packagename + " : " + a_url);
				return a_a_match.Groups["before"].Value + "    \"" +  a_packagename + "\": \"" + a_url + "\",\n" + a_a_match.Groups["after"].Value;
			},System.Text.RegularExpressions.RegexOptions.Multiline);
		}

		/** RemovePackage
		*/
		private static string RemovePackage(string a_text,string a_packagename)
		{
			return System.Text.RegularExpressions.Regex.Replace(a_text,"^(?<before>[\\d\\D\\n]*)(?<package>\\n\\s*\\\"" + a_packagename + "\\\"\\s*\\:\\s*\\\"[a-zA-Z0-9_\\.\\/\\?\\=\\:\\#]*\\\"\\s*\\,\\s*\\n)(?<after>[\\d\\D\\n]*)$",(System.Text.RegularExpressions.Match a_a_match)=>{
				UnityEngine.Debug.Log("RemovePackage : " + a_packagename);
				return a_a_match.Groups["before"].Value + "\n" +  a_a_match.Groups["after"].Value;
			},System.Text.RegularExpressions.RegexOptions.Multiline);
		}

		/** ダウンロード。
		*/
		private static byte[] DownLoad(string a_url)
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
								UnityEngine.Debug.LogError(a_url + " : " + t_webrequest.error);
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

		/** GetLastVersion
		*/
		private static string GetLastVersion(string a_auther,string a_reposname)
		{
			try{
				byte[] t_binary = DownLoad("https://api.github.com/repos/" + a_auther + "/" + a_reposname + "/releases/latest");
				if(t_binary != null){
					string t_text = System.Text.Encoding.UTF8.GetString(t_binary,0,t_binary.Length);
					System.Text.RegularExpressions.Match t_match = System.Text.RegularExpressions.Regex.Match(t_text,".*(?<name>\\\"name\\\")\\s*\\:\\s*\\\"(?<value>[a-zA-Z0-9_\\.]*)\\\".*");
					t_text = t_match.Groups["value"].Value;
					if(t_text != null){
						return t_text;
					}else{
						UnityEngine.Debug.LogError(a_auther + " : " + a_reposname + " : text == null");
						return null;
					}
				}else{
					UnityEngine.Debug.LogError(a_auther + " : " + a_reposname + " : binary == null");
					return null;
				}
			}catch(System.Exception t_exception){
				UnityEngine.Debug.LogError(a_auther + " : " + a_reposname + " : " + t_exception.Message + "\n" + t_exception.StackTrace);
				return null;
			}
		}
	}
}
#endif

