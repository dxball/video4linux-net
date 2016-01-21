
using System;
using System.Runtime.InteropServices;

namespace Video4Linux.Analog.Kernel {

    public enum v4l2_ctrl_type : uint {
        Integer     = 1,
        Boolean     = 2,
        Menu        = 3,
        Button      = 4,
        Integer64   = 5,
        CtrlClass   = 6,
        String      = 7,
        BitMask     = 8,
        IntegerMenu = 9,
    }

    [Flags]
    public enum v4l2_ctrl_flags : uint {
        Disabled        = 0x0001,
        Grabbed         = 0x0002,
        ReadOnly        = 0x0004,
        Update          = 0x0008,
        Inactive        = 0x0010,
        Slider          = 0x0020,
        WriteOnly       = 0x0040,
        Volatile        = 0x0080,
        HasPayLoad      = 0x0100,
        ExecuteOnWrite  = 0x0200,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct v4l2_queryctrl {
        public UInt32 id;
        public v4l2_ctrl_type type;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public String name;
        public Int32 minimum;
        public Int32 maximum;
        public Int32 step;
        public Int32 default_value;
        public v4l2_ctrl_flags flags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public UInt32[] reserved;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct v4l2_querymenu {
        [FieldOffset(0)]
        public UInt32 id;
        [FieldOffset(4)]
        public UInt32 index;
        [FieldOffset(8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public String name;
        [FieldOffset(8)]
        public Int64 value;
        [FieldOffset(40)]
        public UInt32 reserved;
    }
}
