using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UniversityStudy.ProgClasses;

namespace UniversityStudy {

	class InputHandler {

		private enum ArrowMoves { LEFT, UP, DOWN, RIGHT, ENTER, BACKSPACE, ESCAPE, NULL };

		public static void HandleInput(ref Node folders) {

			if (Console.KeyAvailable) {
				ConsoleKeyInfo keyInfo = Console.ReadKey(true);
				DFSClearFlags(folders);

				if (keyInfo.Key == ConsoleKey.UpArrow) {
					DFSSelectedChange(folders, ArrowMoves.UP);
				}
				else if (keyInfo.Key == ConsoleKey.DownArrow) {
					DFSSelectedChange(folders, ArrowMoves.DOWN);
				}
				else if (keyInfo.Key == ConsoleKey.RightArrow) {
					DFSSelectedChange(folders, ArrowMoves.RIGHT);
				}
				else if (keyInfo.Key == ConsoleKey.LeftArrow) {
					DFSSelectedChange(folders, ArrowMoves.LEFT);
				}
				else if (keyInfo.Key == ConsoleKey.Enter) {
					DFSSelectedChange(folders, ArrowMoves.ENTER);
				}
				else if (keyInfo.Key == ConsoleKey.Backspace) {
					DFSSelectedChange(folders, ArrowMoves.BACKSPACE);
				}
				else if (keyInfo.Key == ConsoleKey.Escape) {
					StopProgram();
				}
			}
		}

		private static void DFSClearFlags(Node current) {

			current.dfsState = false;
			for (int i = 0; i < current.children.Count; i++) {
				if (current.children[i].dfsState) {
					DFSClearFlags(current.children[i]);
				}
			}
		}

		private static void StopProgram() {

			Console.Clear();
			Console.Write("Do you want to exit the program? (Enter/Esc)");
			ConsoleKeyInfo key1 = Console.ReadKey ();
			if (key1.Key == ConsoleKey.Escape) {
				ConsoleInterface.working = false;
			}
		}

		private static void TaskLauncher(Node current, int selected) {

			string choise = current.children[selected].value;
			choise = Regex.Replace(choise, @"-+", "");

			General.Dispose();
			General.Initiate();

			Console.Clear();
			Console.Write("# Launching program {0}\n", choise);
			while (!General.infile.EndOfStream) {
				string cur = General.infile.ReadLine();
				Console.WriteLine(cur);
			}
			Console.Write("# Is input is fine? (Enter/Esc)");
			ConsoleKeyInfo key1 = Console.ReadKey ();
			if (key1.Key == ConsoleKey.Escape) {
				return;
			}

			Console.BackgroundColor = ConsoleColor.DarkGray;
			Console.Write("".PadRight(Console.WindowWidth));
			Console.ResetColor();

			General.Dispose();
			General.Initiate();

			switch (choise) {
				case "Task_VI_19":	Part1.Prac4_VI_19();	break;
				case "Task_VII_4":	Part1.Prac4_VII_4();	break;
				case "Task_II_17":	Part1.Prac5_II_17();	break;
				case "Task_IV_4":	Part1.Prac5_IV_4();		break;
				case "Task_V_2":	Part1.Prac5_V_2();		break;
				case "Task_II_3":	Part2.Prac6_II_3();		break;
				case "Task_IV_15":	Part3.Prac6_IV_15();	break;
				case "Task_V_6":	Part2.Prac6_V_6();		break;
				case "Task_VI_2":	Part3.Prac6_VI_2();		break;
				case "Third_Max":	Lecture.Third_Max();	break;
				default: return;
			}

			General.Dispose();
		}

		private static void DFSSelectedChange(Node current, ArrowMoves moved) {

			if (moved == ArrowMoves.NULL) return;

			current.dfsState = true;
			for (int i = 0; i < current.children.Count; i++) {
				if (!current.children[i].dfsState) {
					if (current.children[i].isSelected) {
						switch (moved) {
							case ArrowMoves.LEFT:		ArrowLeft(current, i);		break;
							case ArrowMoves.UP:			ArrowUp(current, i);		break;
							case ArrowMoves.DOWN:		ArrowDown(current, i);		break;
							case ArrowMoves.RIGHT:		ArrowRight(current, i);		break;
							case ArrowMoves.ENTER:		ButtonEnter(current, i);	break;
							case ArrowMoves.BACKSPACE:	ArrowLeft(current, i);		break;
							default: break;
						}
						moved = ArrowMoves.NULL;
						return;
					}
					DFSSelectedChange(current.children[i], moved);
				}
			}
		}

		private static void ArrowUp(Node current, int selected) {

			if (selected != 0) {
				current.children [selected - 1].isSelected = true;
				current.children [selected].isSelected = false;
			} else {
				if (current.value != "TASKS_EXPLORER\n") {
					current.children [selected].isSelected = false;
					current.isSelected = true;
					current.SetExpanded (false);
				}
			}
		}

		private static void ArrowDown(Node current, int selected) {

			if (selected != current.children.Count - 1) {
				current.children [selected + 1].isSelected = true;
				current.children [selected].isSelected = false;
			} else {
				if (selected != current.parent.children.Count - 1) {

				} else {
					ArrowDown (current, current.number); 
				}
			}
		}

		private static void ArrowRight(Node current, int selected) {

			if (current.children[selected].children.Count > 0) {
				current.children[selected].isSelected = false;
				current.children[selected].SetExpanded(true);
				current.children[selected].children[0].isSelected = true;
			}
		}

		private static void ArrowLeft(Node current, int selected) {

			if (current.value != "TASKS_EXPLORER\n") {
				current.children[selected].isSelected = false;
				current.isSelected = true;
				current.SetExpanded(false);
			}
		}

		private static void ButtonEnter(Node current, int selected) {

			if (current.children[selected].children.Count > 0) {
				ArrowRight(current, selected);
			}
			else {
				TaskLauncher(current, selected);
			}
		}
	}
}
