using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code4Fun_Leone_2015_04_18
{
    public class NetworkInformation
    {
        private int _numConnections;

        public int NumConnections
        {
            get { return _numConnections; }
            set { _numConnections = value; }
        }
        private double _averageLatency;

        public double AverageLatency
        {
            get { return _averageLatency; }
            set { _averageLatency = value; }
        }
        private int _totalBandwidth;

        public int TotalBandwidth
        {
            get { return _totalBandwidth; }
            set { _totalBandwidth = value; }
        }

        public NetworkInformation(int numConnections, double averageLatency, int totalBandwidth)
        {
            _numConnections = numConnections;
            _averageLatency = averageLatency;
            _totalBandwidth = totalBandwidth;
        }

        public NetworkInformation()
            : this(0, 0, 0)
        {
        }

        public bool Equals(NetworkInformation n)
        {
            // If parameter is null return false
            if (n == null)
                return false;

            // Return true if the fields match
            return (_numConnections == n.NumConnections) && (_averageLatency == n.AverageLatency) && (_totalBandwidth == n.TotalBandwidth);
        }

    }
}
