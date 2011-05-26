﻿/*
    PureText+ - http://code.google.com/p/puretext-plus/
    
    Copyright (C) 2003 Steve P. Miller, http://www.stevemiller.net/puretext/
    Copyright (C) 2011 Melloware, http://www.melloware.com
    
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.
    
    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
    
    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
    
    The idea of the Original PureText Code is Copyright (C) 2003 Steve P. Miller
    
    NO code was taken from the original project this was rewritten from scratch
    from just the idea of Puretext.
 */
using System;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;

namespace PureTextPlus
{
	/// <summary>
	/// Main class of the application which displays the notification icon and business logic.
	/// </summary>
	public sealed class NotificationIcon
	{
		private NotifyIcon notifyIcon;
		private ContextMenu notificationMenu;
		private static readonly HotkeyHook hotkey = new HotkeyHook();
		
		#region Initialize icon and menu
		public NotificationIcon()
		{
			notifyIcon = new NotifyIcon();
			notificationMenu = new ContextMenu(InitializeMenu());
			
			notifyIcon.DoubleClick += IconDoubleClick;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationIcon));
			notifyIcon.Icon = (Icon)resources.GetObject("$this.Icon");
			notifyIcon.ContextMenu = notificationMenu;
			
			// register the event that is fired after the key press.
			hotkey.KeyPressed += new EventHandler<KeyPressedEventArgs>(Hotkey_KeyPressed);
			ConfigureApplication();
		}
		
		/// <summary>
		/// Creates the context menu on the right click of the tray icon.
		/// </summary>
		/// <returns>a list of MenuItems to display</returns>
		private MenuItem[] InitializeMenu()
		{
			MenuItem mnuConvert = new MenuItem("Convert To Text", IconDoubleClick);
			mnuConvert.DefaultItem = true;
			MenuItem[] menu = new MenuItem[] {
				mnuConvert,
				new MenuItem("Options... ", menuOptionsClick),
				new MenuItem("About "+Preferences.APPLICATION_TITLE+"...", menuAboutClick),
				new MenuItem("-"),
				new MenuItem("Exit", menuExitClick)
			};
			return menu;
		}
		
		/// <summary>
		/// Configures the Hotkey based on preferences.
		/// </summary>
		private void ConfigureApplication() {
			try {
				ModifierKeys modifier = ModifierKeys.None;
				if (Preferences.Instance.ModifierAlt) {
					modifier = modifier | ModifierKeys.Alt;
				}
				if (Preferences.Instance.ModifierControl) {
					modifier = modifier | ModifierKeys.Control;
				}
				if (Preferences.Instance.ModifierShift) {
					modifier = modifier | ModifierKeys.Shift;
				}
				if (Preferences.Instance.ModifierWindows) {
					modifier = modifier | ModifierKeys.Win;
				}
				
				// remove current hotkeys
				hotkey.UnregisterHotKeys();
				
				// get the new hotkey
				KeysConverter keysConverter = new KeysConverter();
				Keys keys = (Keys)keysConverter.ConvertFromString(Preferences.Instance.Hotkey);
				
				// register the control combination as hot key.
				hotkey.RegisterHotKey(modifier, keys);
				
				// set the visibility of the icon
				this.notifyIcon.Visible = Preferences.Instance.TrayIconVisible;
			} catch (Exception) {
				// could not register hotkey!
			}
		}
		#endregion
		
		#region Main - Program entry point
		/// <summary>Program entry point.</summary>
		/// <param name="args">Command Line Arguments</param>
		[STAThread]
		public static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			
			bool isFirstInstance;
			// Please use a unique name for the mutex to prevent conflicts with other programs
			using (Mutex mtx = new Mutex(true, Preferences.APPLICATION_TITLE, out isFirstInstance)) {
				if (isFirstInstance) {
					NotificationIcon notificationIcon = new NotificationIcon();
					notificationIcon.notifyIcon.Visible = true;
					
					Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
					AssemblyName asmName = assembly.GetName();
					notificationIcon.notifyIcon.Text  = String.Format("{0} {1}", Preferences.APPLICATION_TITLE, asmName.Version );

					Application.Run();
					notificationIcon.notifyIcon.Dispose();
				} else {
					// The application is already running
				}
			} // releases the Mutex
		}
		#endregion
		
		#region Event Handlers
		private void menuAboutClick(object sender, EventArgs e)
		{
			FormAbout frmAbout = new FormAbout();
			frmAbout.ShowDialog();
		}
		
		private void menuOptionsClick(object sender, EventArgs e)
		{
			FormOptions frmOptions = new FormOptions();
			if (frmOptions.ShowDialog() == DialogResult.OK) {
				ConfigureApplication();
			}
		}
		
		private void menuExitClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
		
		private void IconDoubleClick(object sender, EventArgs e)
		{
			// put plain text on the clipboard replacing anything that was there
			string plainText = Clipboard.GetText(TextDataFormat.UnicodeText);
			if (String.Empty.Equals(plainText)) {
				return;
			}
			
			// put plain text on the clipboard
			Clipboard.SetText(plainText, TextDataFormat.UnicodeText);
		}
		
		/// <summary>
		/// When the hotkey combo is pressed do the following:
		/// 1. Make the data plain text and put it on the clipboard
		/// 2. Send CTRL+V to Paste in the current foreground application
		/// </summary>
		/// <param name="sender">the sending object</param>
		/// <param name="e">the event of which key was pressed</param>
		void Hotkey_KeyPressed(object sender, KeyPressedEventArgs e)
		{
			// get the text and exit if no text on clipboard
			string plainText = Clipboard.GetText(TextDataFormat.UnicodeText);
			if (String.Empty.Equals(plainText)) {
				return;
			}
			
			// put plain text on the clipboard
			Clipboard.SetText(plainText, TextDataFormat.UnicodeText);
			
			if (Preferences.Instance.PasteIntoActiveWindow) {
				// send CTRL+V for Paste to the active window or control
				InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_V);
			}

			// play a sound if the user wa nts to on every paste
			if (Preferences.Instance.PlaySound) {
				SystemSounds.Asterisk.Play();
			}
		}
		#endregion
	}
}
