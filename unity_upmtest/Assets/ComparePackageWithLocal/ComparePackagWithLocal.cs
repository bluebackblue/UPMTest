

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief パッケージとローカルを比較。
*/


/** BlueBack.Standalone.Editor
*/
#if(UNITY_EDITOR)
namespace ComparePackagWithLocal
{
	/** DeletePackageLock
	*/
	public class ComparePackagWithLocal
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

		/** CompareItem
		*/
		private class CompareItem
		{
			public string path_package;
			public string path_local;
		}

		/** MenuITem_Tool_ComparePackagWithLocal
		*/
		[UnityEditor.MenuItem("Tool/ComparePackagWithLocal")]
		private static void MenuITem_Tool_ComparePackagWithLocal()
		{
			#if(DEF_BLUEBACK_ASSETLIB)
			{
				UnityEditor.PackageManager.Requests.ListRequest t_request = UnityEditor.PackageManager.Client.List(true,true);
				while(t_request.Status == UnityEditor.PackageManager.StatusCode.InProgress){
					System.Threading.Thread.Sleep(1);
				}
				if(t_request.Status == UnityEditor.PackageManager.StatusCode.Failure){
					UnityEngine.Debug.LogError(t_request.Error.message);
					return;
				}else{
					foreach(UnityEditor.PackageManager.PackageInfo t_packageinfo in t_request.Result){
						if(System.Text.RegularExpressions.Regex.IsMatch(t_packageinfo.name,"^blueback\\.[a-zA-Z0-9_\\.]*$",System.Text.RegularExpressions.RegexOptions.Multiline) == true){
							UnityEngine.Debug.Log(t_packageinfo.name + " : " + t_packageinfo.displayName);

							string t_local_path = "..\\..\\..\\" + t_packageinfo.displayName + "\\unity_" + t_packageinfo.displayName + "\\Assets\\UPM\\";

							{
								System.Collections.Generic.List<string> t_filelist_package = BlueBack.AssetLib.Editor.FileNameList.CreateAllFileNameListFromFullPath(t_packageinfo.resolvedPath);
								System.Collections.Generic.List<string> t_filelist_local =  BlueBack.AssetLib.Editor.FileNameList.CreateAllFileNameListFromAssetsPath(t_local_path);

								System.Collections.Generic.Dictionary<string,CompareItem> t_list = new System.Collections.Generic.Dictionary<string,CompareItem>();

								foreach(string t_path in t_filelist_package){
									string t_key = System.Text.RegularExpressions.Regex.Replace(t_path,"^(?<before>.*\\\\PackageCache\\\\)([a-zA-Z_\\.]*\\@[a-zA-Z0-9]*\\\\)(?<value>.*)$",(System.Text.RegularExpressions.Match a_a_match)=>{
										return a_a_match.Groups["value"].Value;
									},System.Text.RegularExpressions.RegexOptions.Multiline);
									t_list.Add(t_key,new CompareItem(){
										path_local = null,
										path_package = t_path
									});
								}

								foreach(string t_path in t_filelist_local){
									string t_key = t_path.Replace(t_local_path,"");
									if(t_list.TryGetValue(t_key,out CompareItem t_compareitem) == true){
										t_compareitem.path_local = t_path;
									}else{
										t_list.Add(t_key,new CompareItem(){
											path_local = t_path,
											path_package = null
										});
									}
								}

								foreach(System.Collections.Generic.KeyValuePair<string,CompareItem> t_item in t_list){
									switch(t_item.Key){
									case "package-lock.json":
									case "package-lock.json.meta":
										{
										}continue;
									}

									if((t_item.Value.path_local == null)||(t_item.Value.path_package == null)){
										//ファイル構成に違い。
										UnityEngine.Debug.LogError(t_packageinfo.displayName + " : different structure : " + t_item.Key + "\n" + t_item.Value.path_local + "\n" + t_item.Value.path_package);
									}else{
										{
											switch(System.IO.Path.GetExtension(t_item.Key)){
											case ".meta":
											case ".json":
											case ".asmdef":
											case ".unity":
											case ".prefab":
											case ".mesh":
											case ".mat":
											case ".mixer":
												{
													string t_text_package = BlueBack.AssetLib.Editor.LoadText.LoadTextFromFullPath(t_item.Value.path_package,null).Replace("\r\n","\n");
													string t_text_local = BlueBack.AssetLib.Editor.LoadText.LoadTextFromAssetsPath(t_item.Value.path_local,null).Replace("\r\n","\n");
													if(t_text_package != t_text_local){
														for(int ii=0;ii<t_text_package.Length;ii++){
															if(t_text_package[ii] != t_text_local[ii]){
																UnityEngine.Debug.LogError(ii.ToString() + " : " + t_text_package.Substring(UnityEngine.Mathf.Max(0,ii-5),10));
																break;
															}
														}

														//テキストに差異。
														UnityEngine.Debug.LogError(t_packageinfo.displayName + " : different text : " + t_item.Key + "\n" + t_item.Value.path_local + "\n" + t_item.Value.path_package + "\n" + t_text_package + "\n" + t_text_local);
													}
												}break;
											default:
												{
													byte[] t_binary_package = BlueBack.AssetLib.Editor.LoadBinary.LoadBinaryFromFullPath(t_item.Value.path_package);
													byte[] t_binary_local = BlueBack.AssetLib.Editor.LoadBinary.LoadBinaryFromAssetsPath(t_item.Value.path_local);

													if((t_binary_package != null)&&(t_binary_local != null)){
														if(t_binary_package.Length == t_binary_local.Length){
															bool t_different = false;
															for(long ii=0;ii<t_binary_package.Length;ii++){
																if(t_binary_package[ii] != t_binary_local[ii]){
																	t_different = true;
																}
															}
															if(t_different == true){
																//バイナリに差異。
																UnityEngine.Debug.LogError(t_packageinfo.displayName + " : different : " + t_item.Key + "\n" + t_item.Value.path_local + "\n" + t_item.Value.path_package);
															}
														}else{
															//サイズに差異。
															UnityEngine.Debug.LogError(t_packageinfo.displayName + " : different size : " + t_item.Key + "\n" + t_item.Value.path_local + "\n" + t_item.Value.path_package);
														}
													}else{
														//読み込みエラー。
														UnityEngine.Debug.LogError(t_packageinfo.displayName + " : read error : " + t_item.Key + "\n" + t_item.Value.path_local + "\n" + t_item.Value.path_package);
													}
												}break;
											}
										}
									}
								}
							}
						}
					}	
				}
			}
			#endif
		}
	}
}
#endif

