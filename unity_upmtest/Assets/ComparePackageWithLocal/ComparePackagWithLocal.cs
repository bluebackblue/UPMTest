

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief パッケージとローカルを比較。
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
						string t_local_path = null;
						{
							switch(t_packageinfo.name){
							case "blueback.assetlib":			t_local_path += "..\\..\\..\\"	+	"UpmAssetLib"			+	"\\"	+"BlueBackAssetLib"				+ "\\Assets\\UPM";break;
							case "blueback.audio":				t_local_path += "..\\..\\..\\"	+	"UpmAudio"				+	"\\"	+"BlueBackAudio"				+ "\\Assets\\UPM";break;
							case "blueback.code":				t_local_path += "..\\..\\..\\"	+	"UpmCode"				+	"\\"	+"BlueBackCode"					+ "\\Assets\\UPM";break;
							case "blueback.excel":				t_local_path += "..\\..\\..\\"	+	"UpmExcel"				+	"\\"	+"BlueBackExcel"				+ "\\Assets\\UPM";break;
							case "blueback.jsonitem":			t_local_path += "..\\..\\..\\"	+	"UpmJsonItem"			+	"\\"	+"BlueBackJsonItem"				+ "\\Assets\\UPM";break;
							case "blueback.mouse":				t_local_path += "..\\..\\..\\"	+	"UpmMouse"				+	"\\"	+"BlueBackMouse"				+ "\\Assets\\UPM";break;
							case "blueback.pad":				t_local_path += "..\\..\\..\\"	+	"UpmPad"				+	"\\"	+"BlueBackPad"					+ "\\Assets\\UPM";break;
							case "blueback.scene":				t_local_path += "..\\..\\..\\"	+	"UpmScene"				+	"\\"	+"BlueBackScene"				+ "\\Assets\\UPM";break;
							case "blueback.slackwebapi":		t_local_path += "..\\..\\..\\"	+	"UpmSlackWebApi"		+	"\\"	+"BlueBackSlackWebApi"			+ "\\Assets\\UPM";break;
							case "blueback.testlib":			t_local_path += "..\\..\\..\\"	+	"UpmTestLib"			+	"\\"	+"BlueBackTestLib"				+ "\\Assets\\UPM";break;
							case "blueback.timescale":			t_local_path += "..\\..\\..\\"	+	"UpmTimeScale"			+	"\\"	+"BlueBackTimeScale"			+ "\\Assets\\UPM";break;
							case "blueback.unityplayerloop":	t_local_path += "..\\..\\..\\"	+	"UpmUnityPlayerLoop"	+	"\\"	+"BlueBackUnityPlayerLoop"		+ "\\Assets\\UPM";break;
							case "blueback.versionmanager":		t_local_path += "..\\..\\..\\"	+	"UpmVersionManager"		+	"\\"	+"BlueBackVersionManager"		+ "\\Assets\\UPM";break;
							}
						}

						if(t_local_path != null){
							UnityEngine.Debug.Log(t_packageinfo.name + " : " + t_packageinfo.displayName);

							System.Collections.Generic.Dictionary<string,CompareItem> t_structure_list = new System.Collections.Generic.Dictionary<string,CompareItem>();

							{
								System.Collections.Generic.List<string> t_filelist_package = BlueBack.AssetLib.Editor.CreateFileNameListWithFullPath.CreateAll(t_packageinfo.resolvedPath);
								foreach(string t_path_package in t_filelist_package){
									string t_key = t_path_package.Substring(t_packageinfo.resolvedPath.Length + 1);
									t_structure_list.Add(t_key,new CompareItem(){
										path_local = null,
										path_package = t_path_package
									});
								}
							}

							{
								System.Collections.Generic.List<string> t_filelist_local =  BlueBack.AssetLib.Editor.CreateFileNameListWithAssetsPath.CreateAll(t_local_path);
								foreach(string t_path_local in t_filelist_local){
									string t_key = t_path_local.Substring(t_local_path.Length + 1);
									if(t_structure_list.TryGetValue(t_key,out CompareItem t_compareitem) == true){
										t_compareitem.path_local = t_path_local;
									}else{
										t_structure_list.Add(t_key,new CompareItem(){
											path_local = t_path_local,
											path_package = null
										});
									}
								}
							}

							foreach(System.Collections.Generic.KeyValuePair<string,CompareItem> t_item in t_structure_list){
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
												string t_text_package = BlueBack.AssetLib.Editor.LoadTextWithFullPath.Load(t_item.Value.path_package).Replace("\r\n","\n");
												string t_text_local = BlueBack.AssetLib.Editor.LoadTextWithAssetsPath.Load(t_item.Value.path_local).Replace("\r\n","\n");
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
												byte[] t_binary_package = BlueBack.AssetLib.Editor.LoadBinaryWithFullPath.Load(t_item.Value.path_package);
												byte[] t_binary_local = BlueBack.AssetLib.Editor.LoadBinaryWithAssetsPath.Load(t_item.Value.path_local);

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
	}
}
#endif

