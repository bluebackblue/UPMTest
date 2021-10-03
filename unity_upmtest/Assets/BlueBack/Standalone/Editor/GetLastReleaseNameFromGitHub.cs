

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 最新リリース名。取得。
*/


/** BlueBack.Standalone.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.Standalone.Editor
{
	/** GetLastReleaseNameFromGitHub
	*/
	public static class GetLastReleaseNameFromGitHub
	{
		/** Connect
		*/
		public static string Connect(string a_auther,string a_reposname)
		{
			try{
				byte[] t_binary = DownloadBinary.Get("https://api.github.com/repos/" + a_auther + "/" + a_reposname + "/releases/latest");
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

