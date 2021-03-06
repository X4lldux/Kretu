//
// MainWindow.cs
//  
// Author:
//       Paweł "X4lldux" Drygas <x4lldux@jabster.pl>
// 
// Copyright (c) 2009 Paweł "X4lldux" Drygas
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using Gtk;

namespace Kretu
{

	public partial class MainWindow : Gtk.Window
	{
		GameEngine game;
		public MainWindow () : base(Gtk.WindowType.Toplevel) {
			Build ();
			var gameBoard = new GameBoard ();
			gameBoard.Show ();
			Add (gameBoard);
			FocusChild = gameBoard;
			Focus = gameBoard;

			game = new GameEngine ();

			game.Draw += delegate(object sender, DrawEventArgs e) {
				Title = "Score: " + game.Points;
				if (game.GameLost)
					Title = "YOU LOOSE!  " + Title;

				gameBoard.DrawBoard (e.Figures, e.Blocks);
			};
			gameBoard.KeyPressed += delegate(object sender, KeyPressedEventArgs e) {
				game.KeyPress (e.Key);
			};
			
		}

		protected void OnDeleteEvent (object sender, DeleteEventArgs a) {
			Application.Quit ();
			a.RetVal = true;
		}
	}
}
