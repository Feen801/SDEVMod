using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.Mono;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using MyAssetMod.Helper;
using System.Collections;

namespace MyAssetMod
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class MyAssetMod : BaseUnityPlugin
    {
        public static new ManualLogSource Logger;
        private static GameObject hair;
        private static Texture2D eye_texture;

        string[] phrases = new string[]
        {
            "I expected a lot of stupid stuff but...",
            "Genuinely irritating motherfucker lol.",
            "Eat my ass.",
            "It's winter dumbass there's snow outside.",
            "What kind of moron... *sigh*",
            "Impressively dumb.",
            "I want you to be less dumb horny brain and more smart horny brain.",
            "Do you ever stop being a dipshit? Quite sick of sighing every time I get told you said something fucking stupid and over-assuming.",
            "I haven't had a user this fucking obnoxious since...",
            "I made a mistake being too patient with every single fucking over-invested person that has had this kind of attitude.",
            "I'm really sick of your shit, I've been addressing a lot of it regardless and you just don't learn.",
            "Believe me shit like that stupid ass comment actively makes my day worse.",
            "Your dumbass entitled attitude can eat shit.",
            "I blame users for being dumb obnoxious cunts all the time.",
            "Handy users are actually just the most entitled dumb cunts on the planet.",
            "I take great pleasure in the fact that this game punishes dumb horny brains for being dumb.",
            "Blows my mind how dumb you have to be.",
            "You successfully complained enough, congratulations.",
            "You win fuck you.",
            "Someone's just begging for conflict here and I really can't be fucked.",
            "Purposeful trolling's a lot more fun when you make it less obvious buddy.",
            "I'm almost jealous of the shameless worthlessness, must be kinda nice and freeing for everyone's expectations of you to be that low.",
            "Can already tell you'll get on my nerves.",
            "Re:Zero's Rem is a dogshit waifu.",
            "God I hate MMOs.",
            "You are absolutely entitled to being a dumb cunt just as I am entitled to calling you a dumb cunt for it.",
            "I hate platformers that pretend they're out of the 90s and have awful controls just for the sake of difficulty.",
            "Yeah know your place.",
            "Are you an idiot?",
            "My discord is already filled with degenerates I don't want it to degenerate into a hornyposting zone.",
            "Hey, good moment to shut the fuck up.",
            "I fucking hate obnoxious doomer attention whores.",
            "I have to confess I don't exactly hate when people are obnoxious, mostly just gives me a smirk.",
            "I fuckin' hate users.",
            "I can't argue against someone that owns up to being shitty.",
            "I'm disabling anonymous suggestions people are too fucking stupid to realize I can't answer their questions through it.",
            "As entertaining as it is I still hate this shit.",
            "Such an irritating little shit..."
        };

        private void Awake()
        {
            /* 
             * Create logger object. You can use it to print to the console window with
             * LogInfo.LogInfo("message")
             */
            Logger = base.Logger;
            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            /* This checks if the scene being loaded is the "ExtraLoadScene" scene. It loads only after the entire session
             * scene has been loaded but before the loading screen dissapears, so it is a good time to override assets.
             */
            if (Equals(scene.name, Constants.SessionScene))
            {
                //FindFsmString.SearchInterations();
                GameObject go = GameObject.Find("SceneTools/Repositories/InsultRepository/DegradationRepository");
                ArrayList list = go.GetComponents<PlayMakerArrayListProxy>()[0].arrayList;
                ArrayList list2 = go.GetComponents<PlayMakerArrayListProxy>()[2].arrayList;
                int count = list.Count;
                int count2 = list2.Count;
                ShuffleArray(phrases);
                int zed = 0;
                for (int i = 0; i < count; i++)
                {
                    list[i]=("\"" + phrases[zed % phrases.Length] + "\"");
                    zed++;
                }
                for (int i = 0; i < count2; i++)
                {
                    list2[i] = ("\"" + phrases[zed % phrases.Length] + "\"");
                    zed++;
                }
            }
        }

        static void ShuffleArray<T>(T[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                // Swap elements
                T temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
}
