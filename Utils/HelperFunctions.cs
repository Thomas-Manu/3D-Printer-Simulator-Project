﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterSimulator
{
    public class HelperFunctions
    {
        public static byte[] ParseCmdPacket(byte[] cmdPacket)
        {
            ushort byteSum = 0;
            for (int i = 0; i < cmdPacket[1] + 4; i++)
            {
                byteSum += cmdPacket[i];
            }
            //ushort checkSum = (ushort)((12 * byteSum) / 16);
            byte[] checksumBytes = new byte[2]; 
            checksumBytes[0] = (byte)(byteSum >> 8);
            checksumBytes[1] = (byte)(byteSum & 0xff);

            return checksumBytes;
        }
        public static bool validateChecksum(byte[] header, byte[] parameters)
        {
            var checksum = header[2] + header[3];
            var sum = 0;
            for (int i = 0; i < 2; i++)
            {
                sum += header[i];
            }
            for (int i = 0; i < parameters.Length; i++)
            {
                sum += parameters[i];
            }
            if (checksum == sum)
            {
                return true;
            }
            return false;
        }
    }
}
