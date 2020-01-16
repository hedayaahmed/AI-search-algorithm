using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSA
{
    class Program
    {
        public class Node
        {
            public string name;//charachter
            public int heuristic;
            public int Cpath;
            public List<Node> Childnode = new List<Node>();
        }

        public class Memory
        {
            public List<Node> Opened = new List<Node>();
            public List<Node> Closed = new List<Node>();
        }

        static public List<Node> Nodes;

        static public List<Memory> All;

        static void Main(string[] args)
        {
            In_Put();
            //Out_Put();
            Gready_Algorithm();
            Output_Data();
        }

        static public void In_Put() ///input of the tree
        {
            Nodes = new List<Node>();

            Node pnn = new Node();
            /////////////// ParentNode1 ////////////////
            pnn.name = "S";pnn.heuristic = 0;pnn.Cpath = 0;
            //ParentChildernn1
            Node PCh = new Node();PCh.name = "A"; PCh.heuristic = 7; PCh.Cpath = 1;
            pnn.Childnode.Add(PCh);
            //ParentChildern2
            PCh = new Node();PCh.name = "B";PCh.heuristic = 10;PCh.Cpath = 8;
            pnn.Childnode.Add(PCh);
            //ParentChildern3
            PCh = new Node(); PCh.name = "C";PCh.heuristic = 5;PCh.Cpath = 4;
            pnn.Childnode.Add(PCh);
            Nodes.Add(pnn);//add s with its children
            //ParentNode2
            pnn = new Node();pnn.name = "A"; pnn.heuristic = 7; pnn.Cpath = 1;
            //ParentChildern1
            PCh = new Node();PCh.name = "D"; PCh.heuristic = 4;PCh.Cpath = 6;
            pnn.Childnode.Add(PCh);
            //ParentChildern2
            PCh = new Node(); PCh.name = "H";PCh.heuristic = 6;PCh.Cpath = 13;//total path from source to the currant node
            pnn.Childnode.Add(PCh);
            Nodes.Add(pnn);
            //ParentNode3
            pnn = new Node(); pnn.name = "B";pnn.heuristic = 10;pnn.Cpath = 8;
            //ParentChildern1
            PCh = new Node();PCh.name = "H";PCh.heuristic = 6;PCh.Cpath = 9;
            pnn.Childnode.Add(PCh);
            //ParentChildern2
            PCh = new Node();PCh.name = "G1"; PCh.heuristic = 0; PCh.Cpath = 12;
            pnn.Childnode.Add(PCh);
            //ParentChildern3
            PCh = new Node();PCh.name = "J"; PCh.heuristic = 8;PCh.Cpath = 12;
             pnn.Childnode.Add(PCh);
            Nodes.Add(pnn);
            //ParentNode4
            pnn = new Node();pnn.name = "C";pnn.heuristic = 5;pnn.Cpath = 4;
            //Cildern1
            PCh = new Node();
            PCh.name = "E";PCh.heuristic = 7;PCh.Cpath = 6;
            pnn.Childnode.Add(PCh);
            //ParentChildern2
            PCh = new Node();PCh.name = "F"; PCh.heuristic = 9;PCh.Cpath = 6;
            pnn.Childnode.Add(PCh);
            Nodes.Add(pnn);
            //ParentNode5
            pnn = new Node(); pnn.name = "D"; pnn.heuristic = 4; pnn.Cpath = 6;
            //Cildern1
            PCh = new Node();PCh.name = "H";PCh.heuristic = 6;PCh.Cpath = 2;
            pnn.Childnode.Add(PCh);
            Nodes.Add(pnn);
            //ParentNode6
            pnn = new Node(); pnn.name = "E";pnn.heuristic = 7; pnn.Cpath = 6;
            //Cildern1
            PCh = new Node(); PCh.name = "F"; PCh.heuristic = 9; PCh.Cpath = 16;
            pnn.Childnode.Add(PCh);
            Nodes.Add(pnn);
            //ParentNode7
            pnn = new Node();pnn.name = "F"; pnn.heuristic = 9;pnn.Cpath = 0;
            //Cildern1
            PCh = new Node();
            PCh.name = "G2"; PCh.heuristic = 0;PCh.Cpath = 2;
            pnn.Childnode.Add(PCh);
            Nodes.Add(pnn);
            //ParentNode8
            pnn = new Node(); pnn.name = "G1";pnn.heuristic = 0;pnn.Cpath = 0;
            Nodes.Add(pnn);
            //ParentNode9
            pnn = new Node();pnn.name = "H";pnn.heuristic = 6;pnn.Cpath = 8;
            //Cildern1
            PCh = new Node();PCh.name = "J"; PCh.heuristic = 8; PCh.Cpath = 4;
            pnn.Childnode.Add(PCh);
            Nodes.Add(pnn);
            //ParentNode10
            pnn = new Node(); pnn.name = "J";pnn.heuristic = 8;pnn.Cpath = 12;
            //Cildern1
            PCh = new Node();PCh.name = "G2"; PCh.heuristic = 0;PCh.Cpath = 2;
            pnn.Childnode.Add(PCh);
            Nodes.Add(pnn);
            //ParentNode11
            pnn = new Node(); pnn.name = "G2"; pnn.heuristic = 0; pnn.Cpath = 0;
            Nodes.Add(pnn);
        }

        static public void Out_Put()
        {
            int i = 0, j = 0;

            for (i = 0; i < Nodes.Count; i++)
            {
                Console.WriteLine(Nodes[i].name + "---------");
                for (j = 0; j < Nodes[i].Childnode.Count; j++)
                {
                    Console.WriteLine(Nodes[i].Childnode[j].name);
                }
            }

        }

        static public void Gready_Algorithm()
        {
            int Flag = 0;
            All = new List<Memory>();
            List<Node> Opened = new List<Node>();
            List<Node> Closed = new List<Node>();
            List<Node> Temp = new List<Node>();

            Node MyNode = new Node();
            MyNode = Nodes[0];

            Opened.Add(MyNode);

            Memory New = new Memory();
            New.Opened = Opened;
            New.Closed = new List<Node>();
            All.Add(New);

            while (true)
            {
                if (MyNode.name == "G1" || MyNode.name == "G2")//make sure reach The gool node
                {
                    break;
                }
                int i = 0, j1 = 0, k = 0, z = 0;
                for (i = 0; i < Nodes.Count; i++)
                {
                    if (Nodes[i].name == Opened[0].name)
                    {
                        Temp = new List<Node>();
                        if (Opened[0].name == "G1" || Opened[0].name == "G2")//reach The gool
                        {
                            MyNode = new Node();
                            MyNode.name = Opened[0].name;
                             break;
                            Closed.Add(Opened[0]);
                           
                            for (j1 = 1; j1 < Opened.Count; j1++){Temp.Add(Opened[j1]);}
                            if (Nodes[i].Childnode.Count > 0)
                            {
                                for (k = 0; k < Nodes[i].Childnode.Count; k++){
                                    Flag = 0;
                                    for (z = 0; z < Opened.Count; z++){
                                        if (Nodes[i].Childnode[k].name == Opened[z].name){ Flag = 1; break; }
                                    }
                                     if (Flag == 0){
                                        for (z = 0; z < Closed.Count; z++){
                                        if (Nodes[i].Childnode[k].name == Closed[z].name)
                                            { Flag = 1; break; }
                                         }   
                                     }   
                                    if (Flag == 0)
                                    { Temp.Add(Nodes[i].Childnode[k]); }}
                            }
                            Opened = Temp;
                            ////
                            List<Node> SortedList = Opened.OrderBy(o => o.heuristic).ToList();
                            Opened = SortedList;
                            New = new Memory();
                            New.Opened = Opened;
                            for (j1 = 0; j1 < Closed.Count; j1++)
                            {New.Closed.Add(Closed[j1]);} // add to close list in the memory class
                            All.Add(New);
                        }
                        else
                        {
                            Closed.Add(Opened[0]);
                            for (j1 = 1; j1 < Opened.Count; j1++){
                                Temp.Add(Opened[j1]);
                            }
                            if (Nodes[i].Childnode.Count > 0){
                            for (k = 0; k < Nodes[i].Childnode.Count; k++)
                                {Flag = 0;
                                   for (z = 0; z < Opened.Count; z++){
                                        if (Nodes[i].Childnode[k].name == Opened[z].name)
                                        { Flag = 1; break; }
                                    }
                                    if (Flag == 0) {
                                       for (z = 0; z < Closed.Count; z++){
                                        if (Nodes[i].Childnode[k].name == Closed[z].name)
                                            { Flag = 1; break; }
                                        }
                                      }  
                                      if (Flag == 0)
                                    { Temp.Add(Nodes[i].Childnode[k]); }  }  }   
                                  Opened = Temp;
                            List<Node> SortedList = Opened.OrderBy(o => o.heuristic).ToList();
                            Opened = SortedList;New = new Memory();
                            New.Opened = Opened;// Edit Open list in the memory class
                            for (j1 = 0; j1 < Closed.Count; j1++){
                                New.Closed.Add(Closed[j1]);
                            }
                            All.Add(New);
                        }
                        break;
                    }
                }
            }
        }

        static public void Output_Data() ///open and close out_put 
        {
            Console.WriteLine("\n                            Gready Algorith                   \n");
            Console.WriteLine("Opened                           Closed");
            int i = 0, j = 0;
            for (i = 0; i < All.Count; i++)
            {
                Console.Write("[");
                for (j = 0; j < All[i].Opened.Count; j++)
                {
                    if (j == All[i].Opened.Count - 1)
                        Console.Write(All[i].Opened[j].name + "(" + All[i].Opened[j].heuristic + ")" + "]");
                    else
                        Console.Write(All[i].Opened[j].name + "(" + All[i].Opened[j].heuristic + ")" + ",");
                }
                if (All[i].Closed.Count == 0)
                {
                    Console.Write("                              [");
                    Console.WriteLine("]");
                }
                else
                {
                    Console.Write("                [");
                    for (j = 0; j < All[i].Closed.Count; j++)
                    {
                        if (j == All[i].Closed.Count - 1)
                            Console.WriteLine(All[i].Closed[j].name + "(" + All[i].Closed[j].heuristic + ")" + "]");
                        else
                            Console.Write(All[i].Closed[j].name + "(" + All[i].Closed[j].heuristic + ")" + ",");
                        
                    }
                }
            }
            j = Console.Read();//just to delay debug Cpathreen, to quit debug click any key
           
        }
    }
}
