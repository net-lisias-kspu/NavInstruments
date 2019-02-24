//NavUtilities by kujuman, © 2014. All Rights Reserved.

using System;
using KSP;
using UnityEngine;

namespace NavInstruments.NavUtilLib
{
    public static class ConfigLoader
    {
        private static readonly KSPe.IO.Data.ConfigNode SETTINGS = KSPe.IO.Data.ConfigNode.ForType<NavUtilLibApp>("NavUtilSettings", "settings.cfg");

        public static System.Collections.Generic.List<Runway> GetRunwayListFromConfig()
        {
            System.Collections.Generic.List<Runway> runwayList = new System.Collections.Generic.List<Runway>();

            //ConfigNode runways = ConfigNode.Load(sSettingURL);
            //foreach (ConfigNode node in runways.GetNodes("Runway"))
			foreach (ConfigNode node in GameDatabase.Instance.GetConfigNodes("Runway"))
            {
                Log.detail("NavUtil: Found Runway Node");

                try
                {
					Runway rwy = new Runway();

                    rwy.ident = node.GetValue("ident");

                    Log.detail("NavUtil: Loading " + rwy.ident);

                    
                    rwy.shortID = node.GetValue("shortID");
                    if (rwy.shortID.Length > 4)
                        rwy.shortID.Remove(4);

					string customValue = node.GetValue("custom");
					rwy.custom = customValue != null && bool.Parse(customValue);

                    rwy.hdg = float.Parse(node.GetValue("hdg"));
                    rwy.body = node.GetValue("body");
                    rwy.altMSL = float.Parse(node.GetValue("altMSL"));
                    rwy.gsLatitude = float.Parse(node.GetValue("gsLatitude"));
                    rwy.gsLongitude = float.Parse(node.GetValue("gsLongitude"));
                    rwy.locLatitude = float.Parse(node.GetValue("locLatitude"));
                    rwy.locLongitude = float.Parse(node.GetValue("locLongitude"));

                    rwy.outerMarkerDist = float.Parse(node.GetValue("outerMarkerDist"));
                    rwy.middleMarkerDist = float.Parse(node.GetValue("middleMarkerDist"));
                    rwy.innerMarkerDist = float.Parse(node.GetValue("innerMarkerDist"));

                    runwayList.Add(rwy);

                    Log.detail("NavUtil: Found " + rwy.ident);
                }
                catch (Exception)
                {
                    Log.detail("NavUtil: Error loading runway");
                    throw;
                }

            }

            return runwayList;
        }

        public static void WriteCustomRunwaysToConfig(System.Collections.Generic.List<Runway> runwayList)
        {
            ConfigNode runways = new ConfigNode();
            foreach (Runway r in runwayList)
                runways.AddNode(r.ToConfigNode(true));

			runways.Save(GlobalVariables.Settings.getCustomRunwaysFile(), "CustomRunways");
        }

        public static System.Collections.Generic.List<float> GetGlideslopeListFromConfig()
        {
            System.Collections.Generic.List<float> gsList = new System.Collections.Generic.List<float>();
            foreach (ConfigNode node in GameDatabase.Instance.GetConfigNodes("Glideslope"))
            {
				float gs = float.Parse(node.GetValue("glideslope"));
                gsList.Add(gs);
            }
            return gsList;
        }

        public static void LoadSettings()
        {
            Log.info("NavUtil: Loading Settings");
            if (SETTINGS.IsLoadable) SETTINGS.Load();
            
            KSPe.ConfigNodeWithSteroids settings = SETTINGS.NodeWithSteroids;
            GlobalVariables.Settings.hsiGUIscale = settings.GetValue<float>("guiScale", 0.5f);
            GlobalVariables.Settings.enableFineLoc = settings.GetValue<bool>("enableFineLoc", true);
            GlobalVariables.Settings.enableWindowsInIVA = settings.GetValue<bool>("enableWindowsInIVA",true);
            GlobalVariables.Settings.loadCustom_rwyCFG = settings.GetValue<bool>("loadCustom_rwyCFG", true);
            GlobalVariables.Settings.useBlizzy78ToolBar = settings.GetValue<bool>("useBlizzy78ToolBar", false);
            GlobalVariables.Settings.hsiPosition.x = settings.GetValue<float>("hsiPositionX", 220f);
            GlobalVariables.Settings.hsiPosition.y = settings.GetValue<float>("hsiPositionY", 500f);
            //GlobalVariables.Settings.hsiPosition.width = settings.GetValue<float>("hsiPositionWidth",???f);
            //GlobalVariables.Settings.hsiPosition.height = settings.GetValue<float>("hsiPositionHeight", ???f);
            GlobalVariables.Settings.rwyEditorGUI.x = settings.GetValue<float>("rwyEditorGUIX", 387f);
            GlobalVariables.Settings.rwyEditorGUI.y = settings.GetValue<float>("rwyEditorGUIY", 132f);
            //GlobalVariables.Settings.rwyEditorGUI.width = settings.GetValue<float>("rwyEditorGUIWidth", ???f);
            //GlobalVariables.Settings.rwyEditorGUI.height = settings.GetValue<float>("rwyEditorGUIHeight", ???f);
            GlobalVariables.Settings.settingsGUI.x = settings.GetValue<float>("settingsGUIX", 75f);
            GlobalVariables.Settings.settingsGUI.y = settings.GetValue<float>("settingsGUIY", 75f);
            GlobalVariables.Settings.hideNavBallWaypoint = settings.GetValue<bool>("hideNavBallWaypoint", false);
            //GlobalVariables.Settings.settingsGUI.width = settings.GetValue<float>("settingsGUIWidth", ???f);
            //GlobalVariables.Settings.settingsGUI.height = settings.GetValue<float>("settingsGUIHeight", ???f);
            {
#if DEBUG
                bool debugMode = settings.GetValue<bool>("debug", true);
#else
                bool debugMode = settings.GetValue<bool>("debug", false);
#endif                
                Log.debuglevel = debugMode ? 5 : 3;
            }
        }

        public static void SaveSettings()
        {
            Log.info("NavUtil: Saving Settings");
            SETTINGS.Clear();
            
            ConfigNode sN = SETTINGS.Node;

            sN.AddValue("guiScale", GlobalVariables.Settings.hsiGUIscale);
            sN.AddValue("enableFineLoc", GlobalVariables.Settings.enableFineLoc);
            sN.AddValue("enableWindowsInIVA", GlobalVariables.Settings.enableWindowsInIVA);
            sN.AddValue("loadCustom_rwyCFG", GlobalVariables.Settings.loadCustom_rwyCFG);
			sN.AddValue("hideNavBallWaypoint", GlobalVariables.Settings.hideNavBallWaypoint);
            sN.AddValue("useBlizzy78ToolBar", GlobalVariables.Settings.useBlizzy78ToolBar);

			sN.AddValue("hsiPositionX", GlobalVariables.Settings.hsiPosition.x);
            sN.AddValue("hsiPositionY", GlobalVariables.Settings.hsiPosition.y);
            //sN.AddValue("hsiPositionWidth", GlobalVariables.Settings.hsiPosition.width);
            //sN.AddValue("hsiPositionHeight", GlobalVariables.Settings.hsiPosition.height);
            sN.AddValue("rwyEditorGUIX", GlobalVariables.Settings.rwyEditorGUI.x);
            sN.AddValue("rwyEditorGUIY", GlobalVariables.Settings.rwyEditorGUI.y);
            //sN.AddValue("rwyEditorGUIWidth", GlobalVariables.Settings.rwyEditorGUI.width);
            //sN.AddValue("rwyEditorGUIHeight", GlobalVariables.Settings.rwyEditorGUI.height);
            sN.AddValue("settingsGUIX", GlobalVariables.Settings.settingsGUI.x);
            sN.AddValue("settingsGUIY", GlobalVariables.Settings.settingsGUI.y);
            //sN.AddValue("settingsGUIWidth", GlobalVariables.Settings.settingsGUI.width);
            //sN.AddValue("settingsGUIHeight", GlobalVariables.Settings.settingsGUI.height);
            sN.AddValue("debug", Log.debuglevel > 3);

            SETTINGS.Save("NavUtil Setting File");
        }
    }
}

