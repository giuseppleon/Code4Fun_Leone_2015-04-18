using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code4Fun_Leone_2015_04_18
{
    class NetworkInformationCalculator
    {
        public static NetworkInformation Calculate(List<NetworkInformation> networkInformations)
        {
            // Return an empty NetworkInformation if the passed list of NetworkInformation is null
            if (networkInformations == null)
                return new NetworkInformation();

            double totalLatency = 0;
            int totalConnections = 0;
            int totalBandwith = 0;
            foreach (NetworkInformation n in networkInformations)
            {
                if (n.NumConnections > 0)
                {
                    //NOTA1: non è chiaro se i valori di latenza presenti nei file rappresentano la latenza media o quella totale e se il valore potrebbe essere decimale. 
                    //Per la banda, invece, dovrebbe rappresentare la banda totale

                    //HYP1: the value of latency_ms is the average latency and the value of bandwidth is the total bandwith
                    totalLatency += n.AverageLatency * n.NumConnections;
                    totalConnections += n.NumConnections;

                    totalBandwith += n.TotalBandwidth;
                }
            }

            if (totalConnections > 0)
            {
                double averageLatency = totalLatency / totalConnections;
                return new NetworkInformation(totalConnections, averageLatency, totalBandwith);
            }
            else
                // Return an empty NetworkInformation if the total number of connection is less or equal to zero
                return new NetworkInformation();
        }
    }
}
