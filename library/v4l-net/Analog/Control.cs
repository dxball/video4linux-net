#region LICENSE
/* 
 * Copyright (C) 2007 Tim Taubert (twenty-three@users.berlios.de)
 * 
 * This file is part of Video4Linux.Net.
 *
 * Video4Linux.Net is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or
 * (at your option) any later version.
 *
 * Video4Linux.Net is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */
#endregion LICENSE

using System;
using System.Collections.Generic;
using Video4Linux.Analog.Kernel;

namespace Video4Linux.Analog
{
	public enum Control : uint
	{
		//User Control
		Brightness       = 0x00980000 | 0x900 + 0,
		Contrast         = 0x00980000 | 0x900 + 1,
		Saturation       = 0x00980000 | 0x900 + 2,
		Hue              = 0x00980000 | 0x900 + 3,
		Volume           = 0x00980000 | 0x900 + 5,
		Balance          = 0x00980000 | 0x900 + 6,
		Bass             = 0x00980000 | 0x900 + 7,
		Treble           = 0x00980000 | 0x900 + 8,
		Mute             = 0x00980000 | 0x900 + 9,
		Loudness         = 0x00980000 | 0x900 + 10,
		BlackLevel       = 0x00980000 | 0x900 + 11,
		WhiteBalance     = 0x00980000 | 0x900 + 12,
		DoWhiteBalance   = 0x00980000 | 0x900 + 13,
		RedBalance       = 0x00980000 | 0x900 + 14,
		BlueBalance      = 0x00980000 | 0x900 + 15,
		Gamma            = 0x00980000 | 0x900 + 16,
		Whiteness        = Gamma,
		Exposure         = 0x00980000 | 0x900 + 17,
		AutoGain         = 0x00980000 | 0x900 + 18,
		Gain             = 0x00980000 | 0x900 + 19,
		HorizontalFlip   = 0x00980000 | 0x900 + 20,
		VerticalFlip     = 0x00980000 | 0x900 + 21,
		HorizontalCenter = 0x00980000 | 0x900 + 22,
		VerticalCenter   = 0x00980000 | 0x900 + 23,
		LastP1           = 0x00980000 | 0x900 + 24,
		
		//Camera Control
		ExposureAuto         = 0x009a0000 | 0x900 + 1,
		ExposureAbsolute     = 0x009a0000 | 0x900 + 2,
		ExposureAutoPriority = 0x009a0000 | 0x900 + 3,
		PanRelative          = 0x009a0000 | 0x900 + 4,
		TiltRelative         = 0x009a0000 | 0x900 + 5,
		PanReset             = 0x009a0000 | 0x900 + 6,
		TiltReset            = 0x009a0000 | 0x900 + 7,
		PanAbsolute          = 0x009a0000 | 0x900 + 8,
		TiltAbsolute         = 0x009a0000 | 0x900 + 9,
		FocusAbsolute        = 0x009a0000 | 0x900 + 10,
		FocusRelative        = 0x009a0000 | 0x900 + 11,
		FocusAuto            = 0x009a0000 | 0x900 + 12,
		ZoomAbsolute         = 0x009a0000 | 0x900 + 13,
		ZoomRelative         = 0x009a0000 | 0x900 + 14,
		ZoomContinuous       = 0x009a0000 | 0x900 + 15,
		IrisAbsolute         = 0x009a0000 | 0x900 + 17,
		IrisRelative         = 0x009a0000 | 0x900 + 18,
	}

	public class DeviceControl {
		public Control Id;
		public String Name;
		public int Min;
		public int Max;
		public int Value;
		public int Step;
		public int Default;
		public v4l2_ctrl_type Type;
		public v4l2_ctrl_flags Flags;
		public List<Tuple<Int32, String>> MenuItems;        // (menu value, name)
	}
}