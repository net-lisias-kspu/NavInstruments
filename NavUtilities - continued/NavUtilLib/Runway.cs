//NavUtilities by kujuman, © 2014. All Rights Reserved.

using System;

namespace NavUtilLib
{
	public class Runway
    {
        [KSPField]
        public string ident = "runwayID";

		[KSPField]
        public string shortID = "sID4";

        [KSPField]
        public double hdg = 90;

        [KSPField]
        public string body = "Kerbin";

        [KSPField]
        public double altMSL = 100;

        [KSPField]
        public double gsLatitude;

        [KSPField]
        public double gsLongitude;

        [KSPField]
        public double locLatitude;

        [KSPField]
        public double locLongitude;

        [KSPField]
        public double outerMarkerDist = 10000;

        [KSPField]
        public double middleMarkerDist = 2200;

        [KSPField]
        public double innerMarkerDist = 200;

		public bool custom = false;
        
        public bool isINSTarget = false; //true indicates that the runway is not the actual runway and is used as a target point for INS 

		public static Runway fallback() {
			Runway runway = new Runway();
			runway.ident = "---";
			runway.shortID = "---";
			runway.hdg = 0;
			runway.body = "";
			runway.altMSL = 0;
			runway.gsLatitude = 0;
			runway.gsLongitude = 0;
			runway.locLatitude = 0;
			runway.locLongitude = 0;
			runway.outerMarkerDist = 0;
			runway.middleMarkerDist = 0;
			runway.innerMarkerDist = 0;
			return runway;
		}
    }
}
