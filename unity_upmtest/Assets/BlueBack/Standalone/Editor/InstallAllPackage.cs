

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

			//追加。
			for(int ii=0;ii<(LIST.Length / 2);ii++){
				string t_url = URL.Replace("<<Auther>>",AUTHER).Replace("<<Name>>",LIST[ii*2+1]);

				//リリース名がバージョン。
				{
					string t_version = GetLastReleaseNameFromGitHub.Connect(AUTHER,LIST[ii*2+1]);
					if(t_version == null){
						//アクセス制限にかかった。
						t_url = t_url.Replace("<<Version>>","");
					}else if(t_version.Length <= 0){
						t_url = t_url.Replace("<<Version>>","");
					}else{
						t_url = t_url.Replace("<<Version>>","#" + t_version);
					}
				}

				t_text = AddPackage(t_text,LIST[ii*2],t_url);
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
	}
}
#endif

