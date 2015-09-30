using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Resources;
using System.Text.RegularExpressions;

namespace UniversityStudy {

	class ConsoleInterface {

		private const int RENDER_DELAY = 100;

		public static bool working = true;

		private static Node folders = new Node();

		public static void MainLoop() {

			TitleFillUp();
			folders.SetExpanded(true);
			folders.children[0].isSelected = true;
			while (working) {
				DrawSubtree(folders);
				InputHandler.HandleInput(ref folders);
			}
		}

		private static void DrawSubtree(Node current) {
			
			Console.Clear();
			DrawNode(current, 0);
			Thread.Sleep(RENDER_DELAY);
		}

		private static void DrawNode(Node current, int level) {

			if (current.isSelected) {
				Console.BackgroundColor = ConsoleColor.DarkGray;
			}
			Console.WriteLine(current.value.PadRight(Console.WindowWidth - 1));
			Console.ResetColor();
			foreach (var child in current.children) {
				if (child.isVisible)
					DrawNode(child, level + 1);
			}
		}

		private static void TitleFillUp() {

			System.IO.StreamReader files = new System.IO.StreamReader(@"../../CodeResources/Files.txt");
			System.IO.StreamReader dependences = new System.IO.StreamReader(@"../../CodeResources/Dependences.txt");

			SortedDictionary<string, Node> independedFolders = new SortedDictionary<string, Node>();
			independedFolders.Add("TASKS_EXPLORER\n", new Node("TASKS_EXPLORER\n"));

			while (!files.EndOfStream) {
				string file = files.ReadLine();
				independedFolders.Add(file, new Node(file));
			}

			while (!dependences.EndOfStream) {
				string inp = dependences.ReadLine();
				inp = Regex.Replace(inp, @"\s+", " ");
				inp = Regex.Replace(inp, @"\\n+", "\n");
				string[] edge = inp.Split(' ');
				independedFolders[edge[0]].children.Add(independedFolders[edge[1]]);
				independedFolders[edge[0]].children[independedFolders[edge[0]].children.Count - 1].number = independedFolders[edge[0]].children.Count - 1;
				independedFolders[edge[0]].children[independedFolders[edge[0]].children.Count - 1].parent = independedFolders[edge[0]];
			}

			folders = independedFolders["TASKS_EXPLORER\n"];

			files.Close();
			dependences.Close();
		}
	}

	class Node {

		public List<Node> children;
		public Node parent;
		public string value;
		public int number;

		public bool isExpanded;
		public bool isVisible;
		public bool isSelected;
		public bool dfsState;

		public Node() {
		}

		public Node(string v) {
			this.value = v;
			children = new List<Node>();
			parent = new Node ();
		    isExpanded = false;
			isVisible = false;
			dfsState = false;
			isSelected = false;
		}

		public void SetExpanded(bool var) {

			this.isExpanded = var;
			foreach (var child in children)
				child.SetVisible(var);
		}

		public void SetVisible(bool var) {

			this.isVisible = var;
			foreach (var child in children)
				child.SetVisible(this.isExpanded);
		}
	}
}
