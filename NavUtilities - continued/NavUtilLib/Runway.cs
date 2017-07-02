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
    }
}
