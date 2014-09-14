using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Diagnostics;

namespace Launcher {
    public class Config {
        public static string CFGFilePath = Path.GetDirectoryName (Assembly.GetExecutingAssembly ().Location) + "\\" + Assembly.GetEntryAssembly ().GetName ().Name + ".cfg";

        // Paths
        public static string DisPath = string.Empty;
        public static string IWAD = string.Empty;
        public static string IWADPath = string.Empty;
        public static string FDPath = string.Empty;

        // Basic
        public static bool NoSkill = true;
        public static short Skill = 0;
        public static bool MapNameOn = false;
        public static short MapNumber = 0;
        public static string MapName = string.Empty;
        public static bool ClassNumberOn = false;
        public static short ClassNumber = 0;
        public static string ClassName = string.Empty;

        // Multiplayer
        public static bool MultiplayerOn = false;
        public static int MPPort = 5029;
        // Joining
        public static bool MPJoining = false;
        public static string MPHostname = string.Empty;
        // Hosting
        public static short MPPlayers = 1;
        public static bool Netmode = false;
        public static bool ExtraTics = false;
        public static short MPDup = 0;
        public static bool altdeath = false;
        public static bool Deathmatch = false;

        // Advanced
        public static bool sv_cheats = false;
        public static bool LogToFile = false;
        //public static bool 
        public static string CustomCommands = string.Empty;

        // Gameplay options
        public static bool teamplay = false;
        public static string sv_fallingdamage = string.Empty;
        public static bool sv_weapondrop = false;
        public static bool sv_doubleammo = false;
        public static bool sv_infiniteammo = false;
        public static bool sv_infiniteinventory = false;
        public static bool sv_nomonsters = false;
        public static bool sv_killallmonsters = false;
        public static bool sv_monsterrespawn = false;
        public static bool sv_norespawn = false;
        public static bool sv_itemsrespawn = false;
        public static bool sv_respawnsuper = false;
        public static bool sv_fastmonsters = false;
        public static bool sv_degeneration = false;
        public static bool sv_noautoaim = false;
        public static bool sv_disallowsuicide = false;
        public static Trilean sv_jump = Trilean.Indeterminate;
        public static Trilean sv_crouch = Trilean.Indeterminate;
        public static Trilean sv_freelook = Trilean.Indeterminate;
        public static bool sv_nofov = false;
        public static bool sv_nobfgaim = false;
        public static bool sv_noautomap = false;
        public static bool sv_noautomapallies = false;
        public static bool sv_disallowspying = false;
        public static bool sv_chasecam = false;
        public static bool sv_dontcheckammo = false;
        public static bool sv_killbossmonst = false;
        public static bool sv_nocountendmonst = false;
        // Deathmatch
        public static bool sv_weaponstay = false;
        public static bool sv_noitems = false;
        public static bool sv_noarmor = false;
        public static bool sv_nohealth = false;
        public static bool sv_spawnfarthest = false;
        public static bool sv_samelevel = false;
        public static bool sv_forcerespawn = false;
        public static bool sv_noexit = false;
        public static bool sv_barrelrespawn = false;
        public static bool sv_respawnprotect = false;
        public static bool sv_losefrag = false;
        public static bool sv_keepfrag = false;
        public static bool sv_noteamswitch = false;
        // Cooperative
        public static bool sv_noweaponspawn = false;
        public static bool sv_cooploseinventory = false;
        public static bool sv_cooplosekeys = false;
        public static bool sv_cooploseweapons = false;
        public static bool sv_cooplosearmor = false;
        public static bool sv_cooplosepowerups = false;
        public static bool sv_cooploseammo = false;
        public static bool sv_coophalveammo = false;
        public static bool sv_samespawnspot = false;

        // Mods
        public static List<string> ModList = new List<string> ();

        public static void Save () {
            List<string> FileData = new List<string> ();

            FileData.Add ("[Paths]");
            FileData.Add ("DisPath = \"" + DisPath + "\";");
            FileData.Add ("IWADPath = \"" + IWADPath + "\";");
            FileData.Add ("FDPath = \"" + FDPath + "\";");
            FileData.Add ("");
            FileData.Add ("[Basic]");
            FileData.Add ("IWAD = \"" + IWAD + "\"");
            FileData.Add ("Skill = \"" + Skill + "\";");
            FileData.Add ("NoSkill = \"" + NoSkill + "\";");
            FileData.Add ("MapNameOn = \"" + MapNameOn + "\";");
            FileData.Add ("MapNumber = \"" + MapNumber + "\";");
            FileData.Add ("MapName = \"" + MapName + "\";");
            FileData.Add ("ClassNumberOn = \"" + ClassNumberOn + "\";");
            FileData.Add ("ClassNumber = \"" + ClassNumber + "\";");
            FileData.Add ("ClassName = \"" + ClassName + "\";");
            FileData.Add ("");
            FileData.Add ("[Multiplayer");
            FileData.Add ("MultiplayerOn = \"" + MultiplayerOn + "\";");
            FileData.Add ("MPPort = \"" + MPPort + "\";");
            FileData.Add ("MPJoining = \"" + MPJoining + "\";");
            FileData.Add ("MPHostname = \"" + MPHostname + "\";");
            FileData.Add ("MPPlayers = \"" + MPPlayers + "\";");
            FileData.Add ("Netmode = \"" + Netmode + "\";");
            FileData.Add ("ExtraTics = \"" + ExtraTics + "\";");
            FileData.Add ("MPDup = \"" + MPDup + "\";");
            FileData.Add ("Altdeath = \"" + altdeath + "\";");
            FileData.Add ("Deathmatch = \"" + Deathmatch + "\";");
            FileData.Add ("");
            FileData.Add ("[Mods]");

            if (ModList.Count > 0) {
                FileData.Add ("ModList = {");
                foreach (string line in ModList) {
                    FileData.Add ("\"" + line + "\"");
                }
                FileData.Add ("};");
            }

            FileData.Add ("");
            FileData.Add ("[Advanced]");
            FileData.Add ("LogToFile = \"" + LogToFile + "\";");
            FileData.Add ("sv_cheats = \"" + sv_cheats + "\";");
            FileData.Add ("CustomCommands = \"" + CustomCommands + "\";");
            FileData.Add ("");
            FileData.Add ("[Gameplay Settings]");

            File.Delete (CFGFilePath);
            File.WriteAllLines (CFGFilePath, FileData);
        }

        public static void Load () {
            if (!File.Exists (CFGFilePath))
                return;
            string[] FileData = File.ReadAllLines (CFGFilePath);
            bool ParsingModList = false;
            List<string> NewModList = new List<string> ();
            foreach (string line in FileData) {
                if (ParsingModList) {
                    if (line.Equals ("};")) {
                        ModList.AddRange (NewModList);
                        ParsingModList = false;
                        continue;
                    }

                    NewModList.Add (line.Trim ('"'));
                } else {
                    if ((line.StartsWith ("[") && line.EndsWith ("]")) || line.Equals (""))
                        continue;
                    string[] s = line.Split ('=');
                    if (s.Count () < 2)
                        continue;

                    s[0] = s[0].Trim ();
                    s[1] = s[1].Trim ();
                    s[1] = s[1].Remove (s[1].Count () - 1);
                    s[1] = s[1].Trim ('"');

                    // Paths
                    if (s[0].Equals ("DisPath"))
                        DisPath = s[1];
                    if (s[0].Equals ("IWADPath"))
                        IWADPath = s[1];
                    if (s[0].Equals ("FDPath"))
                        FDPath = s[1];
                    // Basic
                    if (s[0].Equals ("IWAD"))
                        IWAD = s[1];
                    if (s[0].Equals ("Skill"))
                        Skill = Convert.ToInt16 (s[1]);
                    if (s[0].Equals ("NoSkill"))
                        NoSkill = Convert.ToBoolean (s[1]);
                    if (s[0].Equals ("MapNameOn"))
                        MapNameOn = Convert.ToBoolean (s[1]);
                    if (s[0].Equals ("MapNumber"))
                        MapNumber = Convert.ToInt16 (s[1]);
                    if (s[0].Equals ("MapName"))
                        MapName = s[1];
                    if (s[0].Equals ("ClassNumberOn"))
                        ClassNumberOn = Convert.ToBoolean (s[1]);
                    if (s[0].Equals ("ClassNumber"))
                        ClassNumber = Convert.ToInt16 (s[1]);
                    if (s[0].Equals ("ClassName"))
                        ClassName = s[1];
                    // Multiplayer
                    if (s[0].Equals ("MultiplayerOn"))
                        MultiplayerOn = Convert.ToBoolean (s[1]);
                    if (s[0].Equals ("MPPort"))
                        MPPort = Convert.ToInt32 (s[1]);
                    if (s[0].Equals ("MPJoining"))
                        MPJoining = Convert.ToBoolean (s[1]);
                    if (s[0].Equals ("MPHostname"))
                        MPHostname = s[1];
                    if (s[0].Equals ("MPPlayers"))
                        MPPlayers = Convert.ToInt16 (s[1]);
                    if (s[0].Equals ("Netmode"))
                        Netmode = Convert.ToBoolean (s[1]);
                    if (s[0].Equals ("ExtraTics"))
                        ExtraTics = Convert.ToBoolean (s[1]);
                    if (s[0].Equals ("MPDup"))
                        MPDup = Convert.ToInt16 (s[1]);
                    if (s[0].Equals ("Altdeath"))
                        altdeath = Convert.ToBoolean (s[1]);
                    if (s[0].Equals ("Deathmatch"))
                        Deathmatch = Convert.ToBoolean (s[1]);
                    // Mods
                    if (s[0].Equals ("ModList"))
                        ParsingModList = true;
                    // Advanced
                    if (s[0].Equals ("sv_cheats"))
                        sv_cheats = Convert.ToBoolean (s[1]);
                    if (s[0].Equals ("CustomCommands"))
                        CustomCommands = s[1];
                }
            }
        }
    }
}