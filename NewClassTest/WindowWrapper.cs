using System;
///  for NumberInfoFormat and Convert()
using System.Windows.Forms;

namespace ClassAccessTest
{
	public class WindowWrapper : System.Windows.Forms.IWin32Window
	//*******************************************************************************************************************************************
	{
		public WindowWrapper (IntPtr handle)
		{
			_hwnd = handle;
		}

		//*******************************************************************************************************************************************
		public IntPtr Handle
		//*******************************************************************************************************************************************
		{
			get { return _hwnd; }
		}

		private IntPtr _hwnd;
		// get the parent form from a  control's handle
		//*******************************************************************************************************************************************
		public static Form ShowReport (IntPtr WinHandle)
		//*******************************************************************************************************************************************
		{
			Form ParentForm = (Form)Control.FromHandle (WinHandle);
			return ParentForm;
			//report . Show ( ParentForm );
		}
	}   // End of WindowWrapper class

}
