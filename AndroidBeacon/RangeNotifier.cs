using System;
using System.Collections.Generic;
using RadiusNetworks.IBeaconAndroid;

namespace AndroidBeacon
{
	public class RangeEventArgs : EventArgs
	{
		public Region Region { get; set; }

		public ICollection<IBeacon> Beacons { get; set; }
	}

	public class RangeNotifier : Java.Lang.Object, IRangeNotifier
	{
		public event EventHandler<RangeEventArgs> DidRangeBeaconsInRegionComplete;

		public void DidRangeBeaconsInRegion (ICollection<IBeacon> beacons, Region region)
		{
			OnDidRangeBeaconsInRegion (beacons, region);
		}

		void OnDidRangeBeaconsInRegion (ICollection<IBeacon> beacons, Region region)
		{
			if (DidRangeBeaconsInRegionComplete != null) {
				DidRangeBeaconsInRegionComplete (this, new RangeEventArgs { Beacons = beacons, Region = region });
			}
		}
	}
}