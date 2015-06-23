using System;
using System.Collections.Generic;

using UnityEngine;

public class DrawAllPossiblePaths : MonoBehaviour {


    private static Dictionary<string, string> pathsTable;

	void Start () 
    {
	    pathsTable = new Dictionary<string, string>
			{
#if !UNITY_WEBPLAYER
				{ "DesktopPath", Environment.GetFolderPath( Environment.SpecialFolder.Desktop ) },
				{ "ProgramsPath", Environment.GetFolderPath( Environment.SpecialFolder.Programs ) },
				{ "PersonalPath", Environment.GetFolderPath( Environment.SpecialFolder.Personal ) },
				{ "MyDocumentsPath", Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments ) },
				{ "FavoritesPath", Environment.GetFolderPath( Environment.SpecialFolder.Favorites ) },
				{ "StartupPath", Environment.GetFolderPath( Environment.SpecialFolder.Startup ) },
				{ "RecentPath", Environment.GetFolderPath( Environment.SpecialFolder.Recent ) },
				{ "SendtoPath", Environment.GetFolderPath( Environment.SpecialFolder.SendTo ) },
				{ "StartMenuPath", Environment.GetFolderPath( Environment.SpecialFolder.StartMenu ) },
				{ "MyMusicPath", Environment.GetFolderPath( Environment.SpecialFolder.MyMusic ) },
				{ "MyComputerPath", Environment.GetFolderPath( Environment.SpecialFolder.MyComputer ) },
				{ "DesktopDirectoryPath", Environment.GetFolderPath( Environment.SpecialFolder.DesktopDirectory ) },
				{ "TemplatesPath", Environment.GetFolderPath( Environment.SpecialFolder.Templates ) },
				{ "ApplicationDataPath", Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData ) },
				{ "LocalApplicationDataPath", Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData ) },
				{ "InternetCachePath", Environment.GetFolderPath( Environment.SpecialFolder.InternetCache ) },
				{ "CookiesPath", Environment.GetFolderPath( Environment.SpecialFolder.Cookies ) },
				{ "HistoryPath", Environment.GetFolderPath( Environment.SpecialFolder.History ) },
				{ "CommonApplicationDataPath", Environment.GetFolderPath( Environment.SpecialFolder.CommonApplicationData ) },
				{ "SystemPath", Environment.GetFolderPath( Environment.SpecialFolder.System ) },
				{ "ProgramFilesPath", Environment.GetFolderPath( Environment.SpecialFolder.ProgramFiles ) },
				{ "MyPicturesPath", Environment.GetFolderPath( Environment.SpecialFolder.MyPictures ) },
				{ "CommonProgramFilesPath", Environment.GetFolderPath( Environment.SpecialFolder.CommonProgramFiles ) },
				{ "UnityAppDataPath", Application.dataPath },
				{ "PersistentPath", Application.persistentDataPath },
#endif //!UNITY_WEBPLAYER
#if UNITY_EDITOR
				{ "BuildDataPath", System.IO.Path.GetDirectoryName( Application.dataPath ) + "/BuildData" },
				{ "CachePath", Application.temporaryCachePath },
				{ "StaticPath", "file://" + Application.dataPath + "/StreamingAssets" },
			};
#else // UNITY_EDITOR
				
#if UNITY_WEBPLAYER
				{ "PersistentPath", "/root/" + PersistentPath },
				{ "BuildDataPath",  "/root/" + PersistentPath + "/BuildData" },
				{ "CachePath", "/root/" + CachePath }, 
				{ "StaticPath", Application.dataPath + "/StreamingAssets" }
			};
#else // UNITY_WEBPLAYER
				{ "BuildDataPath", Application.persistentDataPath + "/BuildData" },
#endif // UNITY_WEBPLAYER
#if UNITY_STANDALONE_WIN
				{ "Path.CachePath", Application.temporaryCachePath }, 
				{ "Path.StaticPath", "file://" + Application.dataPath + "/StreamingAssets" }
			};
#endif // UNITY_STANDALONE_WIN
#if UNITY_STANDALONE_OSX
				{ "Path.CachePath", Application.temporaryCachePath }, 
				{ "Path.StaticPath", "file://" + Application.dataPath + "/Data/StreamingAssets" }
			};
#endif // UNITY_STANDALONE_OSX
#if UNITY_IPHONE
				{ "Path.CachePath", Application.temporaryCachePath }, 
				{ "Path.StaticPath", "file://" + Application.dataPath + "/Raw" }
			};
#endif // UNITY_IPHONE
#if UNITY_ANDROID
				{ "Path.CachePath", Application.temporaryCachePath }, 
				{ "Path.StaticPath", "jar:file://" + Application.dataPath + "!/assets"  }
			};
#endif // UNITY_ANDROID
#endif // UNITY_EDITOR
	}
	
	void OnGUI()
    {
	    GUILayout.BeginVertical();
        foreach ( var key in pathsTable.Keys )
	    {
            GUILayout.BeginHorizontal();
            GUILayout.Label(key);
            GUILayout.Label(pathsTable[key] );
            GUILayout.EndHorizontal();
	    }

        GUILayout.EndVertical();
    }
}
