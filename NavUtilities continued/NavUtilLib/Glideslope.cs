using System;

namespace NavUtilLib
{
	public class Glideslope
	{

		[KSPField(isPersistant = true)]
		public double glideslope = 0;

		override public string ToString() {
			return "" + glideslope;
		}

	}
}

