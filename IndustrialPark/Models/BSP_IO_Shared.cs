﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialPark.Models
{
    public static class BSP_IO_Shared
    {
        public static int scoobyRenderWareVersion => 0x00000310;
        public static int bfbbRenderWareVersion => 0x1003FFFF; // fix
        public static int tssmRenderWareVersion => 0x1400FFFF;

        public static int currentRenderWareVersion
        {
            get
            {
                if (HipHopFile.Functions.currentGame == HipHopFile.Game.Scooby)
                    return scoobyRenderWareVersion;
                if (HipHopFile.Functions.currentGame == HipHopFile.Game.BFBB)
                    return bfbbRenderWareVersion;
                if (HipHopFile.Functions.currentGame == HipHopFile.Game.Incredibles)
                    return tssmRenderWareVersion;
                return 0;
            }
        }
    }
}
