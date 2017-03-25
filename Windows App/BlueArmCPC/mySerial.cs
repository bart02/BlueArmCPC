using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace BlueArmCPC
{
    class mySerial
    {
        private static SerialPort port;
        public static bool opened = false;

        private const int bod = 9600;

        public static void open(string ser)
        {
            port = new SerialPort(ser, bod, Parity.None, 8, StopBits.One);
            port.Open();
            opened = true;
        }

        public static void write(string str)
        {
            if (opened)
            {
                port.Write(str);
            }
        }

        public static void close()
        {
            if (opened)
            {
                port.Close();
            }
            opened = false;
        }
    }
}
