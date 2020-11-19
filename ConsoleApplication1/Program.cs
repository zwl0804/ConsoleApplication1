using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ConsoleApplication1
{
    class test
    {
        [DllImport("EVOC_BPI_DLL.dll")]
        public unsafe static extern int BPI_Init();

        [DllImport("EVOC_BPI_DLL.dll")]
        public unsafe static extern int BPI_HWM_Get_Temperature(int ucDeviceTemperature, int[] pTemperatureValue);
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] current_Temperature = new int[] { 0x00 };

            if (0 == test.BPI_Init())
            {
                //get temperature
                test.BPI_HWM_Get_Temperature(0, current_Temperature);//get system temperature

                //print temperature
                Console.WriteLine("baseboard temperature is:");
                Console.Write(current_Temperature[0]);
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("init BPI failed!\n");
            }

            Console.ReadKey();
        }
    }
}
