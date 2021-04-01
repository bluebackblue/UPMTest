

/** Samples.AssetLib.Asset.Editor
*/
namespace Samples.AssetLib.Asset.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** テキストのロード。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/LoadTextFromAssetsPath")]
		private static void MenuItem_Sample_AssetLib_Asset_LoadTextFromAssetsPath()
		{
			//テキストの保存。
			{
				BlueBack.AssetLib.SaveText.SaveUtf8TextToAssetsPath("xxxBBBxxx","Samples/AssetLib/xxx.txt",false);
				BlueBack.AssetLib.RefreshAsset.Refresh();
			}

			string t_text = BlueBack.AssetLib.LoadText.TryLoadTextFromAssetsPath("Samples/AssetLib/xxx.txt");
			UnityEngine.Debug.Log(t_text);
		}

		/** バイナリのロード。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/LoadBinaryFromAssetsPath")]
		private static void MenuItem_Sample_AssetLib_Asset_LoadBinaryFromAssetsPath()
		{
			//バイナリのセーブ。
			{
				BlueBack.AssetLib.SavelBinary.SaveBinaryToAssetsPath(new byte[]{0x01,0x02,0x03},"Samples/AssetLib/binary.dat");
				BlueBack.AssetLib.RefreshAsset.Refresh();
			}

			byte[] t_binary = BlueBack.AssetLib.LoadBinary.LoadBinaryFromAssetsPath("Samples/AssetLib/binary.dat");
			for(int ii=0;ii<t_binary.Length;ii++){
				UnityEngine.Debug.Log(t_binary[ii].ToString("X2"));
			}
		}

		/** アセットのロード。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/LoadAllAssetsFromAssetsPath")]
		private static void MenuItem_Sample_AssetLib_Asset_LoadAllAssetsFromAssetsPath()
		{
			//プレハブのセーブ。
			{
				UnityEngine.GameObject t_prefab = new UnityEngine.GameObject("temp");
				{
					t_prefab.AddComponent<A_MonoBehaviour>().value = 11;
					t_prefab.AddComponent<B_MonoBehaviour>().value = 22;
					BlueBack.AssetLib.SavePrefab.SavePrefabToAssetsPath(t_prefab,"Samples/AssetLib/ab.prefab");
				}
				UnityEngine.GameObject.DestroyImmediate(t_prefab);
				BlueBack.AssetLib.RefreshAsset.Refresh();
			}

			//全部。
			{
				UnityEngine.Object[] t_list = BlueBack.AssetLib.LoadAsset.LoadAllAssetsFromAssetsPath("Samples/AssetLib/ab.prefab");
				UnityEngine.Debug.Log(t_list.Length.ToString());
				for(int ii=0;ii<t_list.Length;ii++){
					UnityEngine.Debug.Log("LoadAllAssetsFromAssetsPath : " + t_list[ii].GetType().Name);
				}
			}

			//指定型。
			{
				System.Collections.Generic.List<UnityEngine.MonoBehaviour> t_list = BlueBack.AssetLib.LoadAsset.LoadAllSpecifiedAssetsFromAssetsPath<UnityEngine.MonoBehaviour>("Samples/AssetLib/ab.prefab");
				UnityEngine.Debug.Log(t_list.Count.ToString());
				for(int ii=0;ii<t_list.Count;ii++){
					int  t_value = 0;

					A_MonoBehaviour t_a = t_list[ii] as A_MonoBehaviour;
					if(t_a != null){
						t_value = t_a.value;
					}

					B_MonoBehaviour t_b = t_list[ii] as B_MonoBehaviour;
					if(t_b != null){
						t_value = t_b.value;
					}

					UnityEngine.Debug.Log("LoadAllSpecifiedAssetsFromAssetsPath : " + t_list[ii].GetType().Name + " : value = " + t_value.ToString());
				}
			}
		}

		/** アニメーションクリップのセーブ。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/SaveAsAnimationClipToAssetsPath")]
		private static void MenuItem_Sample_AssetLib_Asset_SaveAsAnimationClipToAssetsPath()
		{
			UnityEngine.AnimationClip t_animationclip = new UnityEngine.AnimationClip();
			t_animationclip.wrapMode = UnityEngine.WrapMode.Loop;

			BlueBack.AssetLib.SaveAnimationClip.SaveAsAnimationClipToAssetsPath(t_animationclip,"Samples/AssetLib/anim.anim","xxx");
			BlueBack.AssetLib.RefreshAsset.Refresh();
		}

		/** メッシュのセーブ。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Asset/SaveMeshToAssetsPath")]
		private static void MenuItem_Sample_AssetLib_Asset_SaveMeshToAssetsPath()
		{
			UnityEngine.Mesh t_mesh = new UnityEngine.Mesh();
			t_mesh.vertices = new UnityEngine.Vector3[]{new UnityEngine.Vector3(0,0,0),new UnityEngine.Vector3(1,0,0),new UnityEngine.Vector3(0,1,0)};
			t_mesh.triangles = new int[]{0,1,2};

			BlueBack.AssetLib.SaveMesh.SaveAsMeshToAssetsPath(t_mesh,"Samples/AssetLib/mesh.mesh");
		}
	}
	#endif
}

