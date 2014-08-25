﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Launcher
{
    public class Config
    {
        public static string CFGFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + Assembly.GetEntryAssembly().GetName().Name + ".cfg";

        // Paths
        public static string DisPath = string.Empty;
        public static string IWAD = string.Empty;
        public static string IWADPath = string.Empty;
        public static string FDPath = string.Empty;
        // Basic
        public static bool NoSkill = true;
        public static int Skill = 0;
        public static bool MapNameOn = false;
        public static int MapNumber = 0;
        public static string MapName = string.Empty;
        public static bool ClassNumberOn = false;
        public static int ClassNumber = 0;
        public static string ClassName = string.Empty;
        // Multiplayer
        public static bool MultiplayerOn = false;
        // Mods
        public static List<string> ModList = new List<string>();

        public static void Save()
        {
            List<string> FileData = new List<string>();
            
            FileData.Add("[Paths]");
            FileData.Add("DisPath = \"" + DisPath + "\";");
            FileData.Add("IWADPath = \"" + IWADPath + "\";");
            FileData.Add("FDPath = \"" + FDPath + "\";");
            FileData.Add("");
            FileData.Add("[Basic]");
            FileData.Add("Skill = \"" + Skill.ToString() + "\";");
            FileData.Add("NoSkill = \"" + NoSkill.ToString() + "\";");
            FileData.Add("MapNameOn = \"" + MapNameOn.ToString() + "\";");
            FileData.Add("MapNumber = \"" + MapNumber.ToString() + "\";");
            FileData.Add("MapName = \"" + MapName + "\";");
            FileData.Add("ClassNumberOn = \"" + ClassNumberOn.ToString() + "\";");
            FileData.Add("ClassNumber = \"" + ClassNumber.ToString() + "\";");
            FileData.Add("ClassName = \"" + ClassName + "\";");
            FileData.Add("");
            FileData.Add("[Multiplayer]");

            if (ModList.Count > 0)
            {
                FileData.Add("ModList = {");
                for (int i = 0; i < ModList.Count; i++)
                {
                    FileData.Add("\"" + ModList[i] + "\"");
                }
                FileData.Add("}");
            }

            File.Delete(CFGFilePath);
            File.WriteAllLines(CFGFilePath, FileData);
        }
    }
}