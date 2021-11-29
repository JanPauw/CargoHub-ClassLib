using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjXISD_Lib_Framework
{
    class Depot
    {
        public List<double[]> provs = new List<double[]>();

        public Depot()
        {
            double[] EC = { -32.083291, 24.2221028 };
            double[] FS = { -28.5976039, 22.5742767 };
            double[] GT = { -26.0099267, 27.0062466 };
            double[] KZ = { -28.9214801, 28.638928 };
            double[] LP = { -23.6990395, 24.6527337 };
            double[] MP = { -29.8158345, 30.5616892 };
            double[] NC = { -28.7713485, 16.5090631 };
            double[] NW = { -26.2949848, 20.97143 };
            double[] WC = { -37.3509268, 9.9961142 };

            provs.Add(EC);
            provs.Add(FS);
            provs.Add(GT);
            provs.Add(KZ);
            provs.Add(LP);
            provs.Add(MP);
            provs.Add(NC);
            provs.Add(NW);
            provs.Add(WC);
        }

        public double[] Coords(string prov)
        {
            switch (prov)
            {
                case "Eastern Cape":
                    return provs[0];
                case "Free State":
                    return provs[1];
                case "Guateng":
                    return provs[2];
                case "KwaZulu-Natal":
                    return provs[3];
                case "Limpopo":
                    return provs[4];
                case "Mpumalanga":
                    return provs[5];
                case "Northern Cape":
                    return provs[6];
                case "North West":
                    return provs[7];
                case "Western Cape":
                    return provs[8];
                default:
                    return provs[0];
            }
        }

    }
}
