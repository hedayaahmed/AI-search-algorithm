using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breadth_first
{
    class Program
    {
        public class Node
        {
            public string Name;
            public int PC;
            public int SC;
            public List<Node> MyCildren = new List<Node>();
        }

        public class Memory
        {
            public List<Node> OpenList = new List<Node>();
            public List<Node> ClosedList = new List<Node>();
        }

        static public List<Node> Nodes;

        static public List<Memory> All;

        static void Main(string[] args)
        {
            Create();
            Uniform_Algorithm();
            OutPut_Algorithm();
            //Try();
        }

        static public void Create()
        {
            Nodes = new List<Node>();

            Node pnn = new Node();

            //Parent1
            pnn.Name = "S";
            pnn.PC = 0;
            pnn.SC = 0;

            //Cildern1
            Node pnc = new Node();
            pnc.Name = "A";
            pnc.PC = 1;
            pnc.SC = 1;
            pnn.MyCildren.Add(pnc);
            //Childer2
            pnc = new Node();
            pnc.Name = "B";
            pnc.PC = 8;
            pnc.SC = 8;
            pnn.MyCildren.Add(pnc);
            //Childer3
            pnc = new Node();
            pnc.Name = "C";
            pnc.PC = 4;
            pnc.SC = 4;
            pnn.MyCildren.Add(pnc);

            Nodes.Add(pnn);

            //Parent2
            pnn = new Node();
            pnn.Name = "A";
            pnn.PC = 1;
            pnn.SC = 0;

            //Cildern1
            pnc = new Node();
            pnc.Name = "D";
            pnc.PC = 6;
            pnc.SC = 5;
            pnn.MyCildren.Add(pnc);
            //Childer2
            pnc = new Node();
            pnc.Name = "H";
            pnc.PC = 8;
            pnc.SC = 12;
            pnn.MyCildren.Add(pnc);

            Nodes.Add(pnn);

            //Parent3
            pnn = new Node();
            pnn.Name = "B";
            pnn.PC = 8;
            pnn.SC = 10;

            //Cildern1
            pnc = new Node();
            pnc.Name = "H";
            pnc.PC = 9;
            pnc.SC = 1;
            pnn.MyCildren.Add(pnc);
            //Childer2
            pnc = new Node();
            pnc.Name = "G1";
            pnc.PC = 12;
            pnc.SC = 4;
            pnn.MyCildren.Add(pnc);
            //Childer3
            pnc = new Node();
            pnc.Name = "J";
            pnc.PC = 12;
            pnc.SC = 4;
            pnn.MyCildren.Add(pnc);

            Nodes.Add(pnn);

            //Parent4
            pnn = new Node();
            pnn.Name = "C";
            pnn.PC = 4;
            pnn.SC = 0;

            //Cildern1
            pnc = new Node();
            pnc.Name = "E";
            pnc.PC = 6;
            pnc.SC = 2;
            pnn.MyCildren.Add(pnc);
            //Childer2
            pnc = new Node();
            pnc.Name = "F";
            pnc.PC = 10;
            pnc.SC = 6;
            pnn.MyCildren.Add(pnc);

            Nodes.Add(pnn);

            //Parent5
            pnn = new Node();
            pnn.Name = "D";
            pnn.PC = 6;
            pnn.SC = 0;

            //Cildern1
            pnc = new Node();
            pnc.Name = "H";
            pnc.PC = 8;
            pnc.SC = 2;
            pnn.MyCildren.Add(pnc);

            Nodes.Add(pnn);

            //Parent6
            pnn = new Node();
            pnn.Name = "E";
            pnn.PC = 6;
            pnn.SC = 0;

            //Cildern1
            pnc = new Node();
            pnc.Name = "F";
            pnc.PC = 16;
            pnc.SC = 10;
            pnn.MyCildren.Add(pnc);

            Nodes.Add(pnn);

            //Parent7
            pnn = new Node();
            pnn.Name = "F";
            pnn.PC = 10;
            pnn.SC = 0;

            //Cildern1
            pnc = new Node();
            pnc.Name = "G2";
            pnc.PC = 12;
            pnc.SC = 2;
            pnn.MyCildren.Add(pnc);

            Nodes.Add(pnn);

            //Parent8
            pnn = new Node();
            pnn.Name = "G1";
            pnn.PC = 12;
            pnn.SC = 0;

            Nodes.Add(pnn);

            //Parent9
            pnn = new Node();
            pnn.Name = "H";
            pnn.PC = 8;
            pnn.SC = 0;

            //Cildern1
            pnc = new Node();
            pnc.Name = "J";
            pnc.PC = 12;
            pnc.SC = 4;
            pnn.MyCildren.Add(pnc);

            Nodes.Add(pnn);

            //Parent10
            pnn = new Node();
            pnn.Name = "J";
            pnn.PC = 12;
            pnn.SC = 0;

            //Cildern1
            pnc = new Node();
            pnc.Name = "G2";
            pnc.PC = 14;
            pnc.SC = 2;
            pnn.MyCildren.Add(pnc);

            Nodes.Add(pnn);

            //Parent11
            pnn = new Node();
            pnn.Name = "G2";
            pnn.PC = 12;
            pnn.SC = 0;

            Nodes.Add(pnn);
        }

        static public void OutPut()
        {
            int i = 0, j = 0;

            for (i = 0; i < Nodes.Count; i++)
            {
                Console.WriteLine(Nodes[i].Name + "---------");
                for (j = 0; j < Nodes[i].MyCildren.Count; j++)
                {
                    Console.WriteLine(Nodes[i].MyCildren[j].Name);
                }
            }

        }
        static public void Try()
        {
            int f;
            Console.WriteLine("\n                            uniform cost Algorith                   \n");
            Console.WriteLine("OpenList                                      ClosedList");
            Console.WriteLine("[S(0)]                                       []");
            Console.WriteLine("[A(1),C(4),B(8)]                           [S(0)]");
            Console.WriteLine("[C(4),D(6),B(8),H(13)]                   [S(0),A(1)]");
            Console.WriteLine("[D(6),E(6),B(8),F(10),H(13)]            [S(0),A(1),C(4)]");
            Console.WriteLine("[E(6),B(8),H(8),F(10)]                 [S(0),A(1),C(4),D(6)]");
            Console.WriteLine("[B(8),H(8),F(10)]                    [S(0),A(1),C(4),D(6),E(6)]");
            Console.WriteLine("[H(8),F(10),G1(12),J(12)]           [S(0),A(1),C(4),D(6),E(6),B(8)]");
            Console.WriteLine("[F(10),G1(12),J(12)]              [S(0),A(1),C(4),D(6),E(6),B(8),H(8)]");
            Console.WriteLine("[G1(12),G2(12),J(12)]            [S(0),A(1),C(4),D(6),E(6),B(8),H(8),F(10)]");
            f = Console.Read();
        }

        static public void Uniform_Algorithm()
        {
            int Flag = 0;
            All = new List<Memory>(); List<Node> OpenList = new List<Node>();
            List<Node> ClosedList = new List<Node>();
            List<Node> Temp = new List<Node>();
            Node TreeN = new Node();
            TreeN = Nodes[0];
            OpenList.Add(TreeN);
            Memory New = new Memory();
            New.OpenList = OpenList;
            New.ClosedList = new List<Node>();
            All.Add(New);
            while (true)
            {
                int i = 0, j1 = 0, k = 0, z = 0;
                if (TreeN.Name == "G1" || TreeN.Name == "G2")
                {
                    break;
                }
                for (i = 0; i < Nodes.Count; i++)
                {
                    if (Nodes[i].Name == OpenList[0].Name)
                    {
                        Temp = new List<Node>();
                        if (OpenList[0].Name == "G1" || OpenList[0].Name == "G2")
                        {
                            TreeN = new Node();
                            TreeN.Name = OpenList[0].Name;
                            break; ClosedList.Add(OpenList[0]);

                            for (j1 = 1; j1 < OpenList.Count; j1++)
                            {
                                Temp.Add(OpenList[j1]);
                            }
                            if (Nodes[i].MyCildren.Count > 0)
                            {
                                for (k = 0; k < Nodes[i].MyCildren.Count; k++)
                                {
                                    Flag = 0;
                                    for (z = 0; z < OpenList.Count; z++)
                                    {
                                        if (Nodes[i].MyCildren[k].Name == OpenList[z].Name)
                                        {
                                            Flag = 1; break;
                                        }
                                    }
                                    if (Flag == 0)
                                    {
                                        for (z = 0; z < ClosedList.Count; z++)
                                        {
                                            if (Nodes[i].MyCildren[k].Name == ClosedList[z].Name)
                                            { Flag = 1; break; }
                                        }
                                    }
                                    if (Flag == 0)
                                    { Temp.Add(Nodes[i].MyCildren[k]); }
                                }
                            }
                            OpenList = Temp;
                            /////sort build on heuristic estimate/////////////////////////
                            List<Node> SortedList = OpenList.OrderBy(o => o.PC).ToList();
                            OpenList = SortedList;
                            New = new Memory();
                            New.OpenList = OpenList;
                            for (j1 = 0; j1 < ClosedList.Count; j1++)
                            {
                                New.ClosedList.Add(ClosedList[j1]);
                            }
                            All.Add(New);
                        }
                        else
                        {
                            ClosedList.Add(OpenList[0]);
                            for (j1 = 1; j1 < OpenList.Count; j1++)
                            {
                                Temp.Add(OpenList[j1]);
                            }

                            if (Nodes[i].MyCildren.Count > 0)
                            {
                                for (k = 0; k < Nodes[i].MyCildren.Count; k++)
                                {
                                    Flag = 0;
                                    for (z = 0; z < OpenList.Count; z++)
                                    {
                                        if (Nodes[i].MyCildren[k].Name == OpenList[z].Name)
                                        { Flag = 1; break; }
                                    }
                                    if (Flag == 0)
                                    {
                                        for (z = 0; z < ClosedList.Count; z++)
                                        {
                                            if (Nodes[i].MyCildren[k].Name == ClosedList[z].Name)
                                            { Flag = 1; break; }
                                        }
                                    }
                                    if (Flag == 0) { Temp.Add(Nodes[i].MyCildren[k]); }
                                }
                            } OpenList = Temp;
                            List<Node> SortedList = OpenList.OrderBy(o => o.PC).ToList();
                            OpenList = SortedList; New = new Memory(); New.OpenList = OpenList;
                            for (j1 = 0; j1 < ClosedList.Count; j1++)
                            {
                                New.ClosedList.Add(ClosedList[j1]);
                            }
                            All.Add(New);
                        }
                        break;
                    }
                }
            }
        }




        static public void OutPut_Algorithm()
        {
            Console.WriteLine("\n                            uniform cost Algorith                   \n");
            Console.WriteLine("OpenList                           ClosedList");
            int i = 0, j = 0;
            for (i = 0; i < All.Count; i++)
            {
                Console.Write("[");
                for (j = 0; j < All[i].OpenList.Count; j++)
                {
                    if (j == All[i].OpenList.Count - 1)
                        Console.Write(All[i].OpenList[j].Name + "(" + All[i].OpenList[j].PC + ")" + "]");
                    else
                        Console.Write(All[i].OpenList[j].Name + "(" + All[i].OpenList[j].PC + ")" + ",");
                }
                if (All[i].ClosedList.Count == 0)
                {
                    Console.Write("                       [");
                    Console.WriteLine("]");
                }
                else
                {
                    Console.Write("                [");
                    for (j = 0; j < All[i].ClosedList.Count; j++)
                    {
                        if (j == All[i].ClosedList.Count - 1)
                            Console.WriteLine(All[i].ClosedList[j].Name + "(" + All[i].ClosedList[j].PC + ")" + "]");
                        else
                            Console.Write(All[i].ClosedList[j].Name + "(" + All[i].ClosedList[j].PC + ")" + ",");

                    }
                }
            }
            j = Console.Read();
        }
    }
}
