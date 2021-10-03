

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief パッケージロック削除。
*/


/** BlueBack.Standalone.Editor
*/
#if(UNITY_EDITOR)
namespace BlueBack.Standalone.Editor
{
	/** DeletePackageLock
	*/
	public static class DeletePackageLock
	{
		/** MenuITem_BlueBack_DeletePackageLock

			「packages-lock.json」を削除するとインストールされているパッケージの最新バージョンがインストールされる。

		*/
		[UnityEditor.MenuItem("BlueBack/DeletePackageLock")]
		private static void MenuITem_BlueBack_DeletePackageLock()
		{
			string t_path = UnityEngine.Application.dataPath + "/../Packages/packages-lock.json";
			UnityEngine.Debug.Log(t_path);
			System.IO.File.Delete(t_path);
		}
	}
}
#endif

