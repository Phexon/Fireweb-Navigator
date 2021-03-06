﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gecko.Interop;

namespace Gecko.Services
{
	public static class WindowWatcher
	{
		private static ServiceWrapper<nsIWindowWatcher> _watcher;
		private static bool _windowCreatorLocked;

		static WindowWatcher()
		{
			_watcher = new ServiceWrapper<nsIWindowWatcher>( Contracts.WindowWatcher );
		}

		/// <summary>
		/// After calling this method changing of WindowCreator is not allowed
		/// </summary>
		public static void LockWindowCreator()
		{
			_windowCreatorLocked = true;
		}

		public static nsIWindowCreator2 WindowCreator
		{
			set
			{
				if (_windowCreatorLocked) return;
				_watcher.Instance.SetWindowCreator(value);

			}
		}

		public static GeckoWindow ActiveWindow
		{
			get { return _watcher.Instance.GetActiveWindowAttribute().Wrap( GeckoWindow.Create ); }
			set { _watcher.Instance.SetActiveWindowAttribute( value.DomWindow ); }
		}

		public static IEnumerator<GeckoWindow> GetWindowEnumerator()
		{
			return new Collections.GeckoEnumerator<GeckoWindow, nsIDOMWindow>(
				_watcher.Instance.GetWindowEnumerator(),
				GeckoWindow.Create );
		}


	}
}
