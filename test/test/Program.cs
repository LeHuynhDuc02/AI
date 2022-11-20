// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using test;
using WpfApp1;

internal class Program
{
    static Node begin = new Node();
    static Node end = new Node();
    static List<Node> Ans = new List<Node>();
    static Node end1 = new Node();
    private static void Main(string[] args)
    {
        static bool Equal(Node x, Node y)
        {
            for (int i1 = 0; i1 < 3; i1++)
                for (int j1 = 0; j1 < 3; j1++)
                {
                    if (x.A[i1, j1] != y.A[i1, j1])
                        return false;
                }
            return true;
        }//So sanh hai ma tran x va y
        static void UpdateId(List<Node> list)
        {
            int i = -1;
            foreach (var x in list)
            {
                x.Id = ++i;
            }
        }//Update lai id cua Node trong list
        static bool Check_Left(Node x)
        {
            int i = 0, j = 0;
            for (int i1 = 0; i1 < 3; i1++) //Tim vi tri 0 trong Node
            {
                int kt = 0;
                for (int j1 = 0; j1 < 3; j1++)
                {
                    if (x.A[i1, j1] == 0)
                    {
                        i = i1;
                        j = j1;
                        kt = 1;
                        break;
                    }
                    if (kt == 1)
                        break;
                }
            }
            if (j == 0)
                return false;
            else return true;
        } //Kiem tra xem so 0 co the di chuyen sang trai khong
        static bool Check_Right(Node x)
        {
            int i = 0, j = 0;
            for (int i1 = 0; i1 < 3; i1++) //Tim vi tri 0 trong Node
            {
                int kt = 0;
                for (int j1 = 0; j1 < 3; j1++)
                {
                    if (x.A[i1, j1] == 0)
                    {
                        i = i1;
                        j = j1;
                        kt = 1;
                        break;
                    }
                    if (kt == 1)
                        break;
                }
            }
            if (j == 2)
                return false;
            else return true;
        }//Kiem tra xem so 0 co the di chuyen sang phai khong
        static bool Check_Top(Node x)
        {
            int i = 0, j = 0;
            for (int i1 = 0; i1 < 3; i1++) //Tim vi tri 0 trong Node
            {
                int kt = 0;
                for (int j1 = 0; j1 < 3; j1++)
                {
                    if (x.A[i1, j1] == 0)
                    {
                        i = i1;
                        j = j1;
                        kt = 1;
                        break;
                    }
                    if (kt == 1)
                        break;
                }
            }
            if (i == 0)
                return false;
            else return true;
        }//Kiem tra xem so 0 co the di chuyen len tren khong
        static bool Check_Bottom(Node x)
        {
            int i = 0, j = 0;
            for (int i1 = 0; i1 < 3; i1++) //Tim vi tri 0 trong Node
            {
                int kt = 0;
                for (int j1 = 0; j1 < 3; j1++)
                {
                    if (x.A[i1, j1] == 0)
                    {
                        i = i1;
                        j = j1;
                        kt = 1;
                        break;
                    }
                    if (kt == 1)
                        break;
                }
            }

            if (i == 2)
                return false;
            return true;
        }//Kiem tra xem so 0 co the di chuyen xuong duoi khong
        static bool Check_List(Node x, List<Node> list)
        {
            for (int z = 0; z < list.Count; z++)
            {
                if (Equal(x, list[z]))
                {
                    return true;
                }
            }
            return false;
        }//Kiem tra xem Node x co trong list chua
        static int TinhH(Node x, Node goal)
        {
            int d = 0;
             for (int i = 0; i < 3; i++)
                 for (int j = 0; j < 3; j++)
                 {
                     for (int i1 = 0; i1 < 3; i1++)
                         for (int j1 = 0; j1 < 3; j1++)
                         {
                             if (x.A[i, j] == goal.A[i1, j1])
                                 d += Math.Abs(i1 - i) + Math.Abs(j1 - j);
                         }
                 }
           
           for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (x.A[i, j] != goal.A[i, j])
                    d++;
            return d;
        }//Ham dinh gia Hn
        static Node Get_Open(List<Node> open, Node end) 
        {
            int f = 10000;
            Node x = new Node();

            foreach (var n in open)
            {
                if ((n.Step + n.H < f))// Kiem tra de tim Node co fn nho nhat trong Open
                {
                    x = n;
                    f = n.Step + n.H;
                }        
            }
            return x;
        }//Lay Node tu open ma co fn nho nhat
        static Node Sinh_Buttom(Node pa, Node end)
        {
            Node n1 = new Node(); //Tao node de luu tru gia tri Node khi sinh ra
            n1 = (Node)pa.Clone();
            int i1 = 0, j1 = 0;
            for (int i = 0; i < 3; i++) //Tim vi tri co gia tri bang 0 trong node
            {
                int kt = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (pa.A[i, j] == 0)
                    {
                        i1 = i;
                        j1 = j;
                        kt = 1;
                        break;
                    }
                }
                if (kt == 1) break;
            }

            int tg1 = n1.A[i1, j1]; //Doi cho vi tri 0 xuong duoi de duoc Node con Bottom
            n1.A[i1, j1] = n1.A[i1 + 1, j1];
            n1.A[i1 + 1, j1] = tg1;
            n1.H = TinhH(n1, end);
            n1.Step = n1.Step + 1; //Tang step len 1 (gia cua cha + 1)
            n1.Pa = (Node)pa.Clone(); //Gan gia tri Pa cho node con chinh bang Node cha
            return n1;
        }//Sinh Node con buttom cua Node pa
        static Node Sinh_Top(Node pa, Node end)
        {
            Node n1 = new Node(); //Tao node de luu tru gia tri Node khi sinh ra
            n1 = (Node)pa.Clone();
            int i1 = 0, j1 = 0;
            for (int i = 0; i < 3; i++) //Tim vi tri co gia tri bang 0 trong node
            {
                int kt = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (pa.A[i, j] == 0)
                    {
                        i1 = i;
                        j1 = j;
                        kt = 1;
                        break;
                    }
                }
                if (kt == 1) break;
            }

            int tg1 = n1.A[i1, j1]; //Doi cho vi tri 0 len tren de duoc Node con Top
            n1.A[i1, j1] = n1.A[i1 - 1, j1];
            n1.A[i1 - 1, j1] = tg1;
            n1.H = TinhH(n1, end);
            n1.Step = n1.Step + 1; //Tang step len 1 (gia cua cha + 1)
            n1.Pa = (Node)pa.Clone();   //Gan gia tri Pa cho node con chinh bang Node cha
            return n1;
        }//Sinh Node con Top cua Node pa
        static Node Sinh_Left(Node pa, Node end)
        {
            Node n1 = new Node();   //Tao node de luu tru gia tri Node khi sinh ra
            n1 = (Node)pa.Clone();
            int i1 = 0, j1 = 0;
            for (int i = 0; i < 3; i++) //Tim vi tri co gia tri bang 0 trong node
            {
                int kt = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (pa.A[i, j] == 0)
                    {
                        i1 = i;
                        j1 = j;
                        kt = 1;
                        break;
                    }
                }
                if (kt == 1) break;
            }

            int tg1 = n1.A[i1, j1]; //Doi cho vi tri 0 sang trai de duoc Node con Left
            n1.A[i1, j1] = n1.A[i1, j1 - 1];
            n1.A[i1, j1 - 1] = tg1;
            n1.H = TinhH(n1, end);
            n1.Step = n1.Step + 1; //Tang step len 1 (gia cua cha + 1)
            n1.Pa = (Node)pa.Clone();   //Gan gia tri Pa cho node con chinh bang Node cha
            return n1;
        }//Sinh Node con Left cua Node pa
        static Node Sinh_Right(Node pa, Node end)
        {
            Node n1 = new Node();   //Tao node de luu tru gia tri Node khi sinh ra
            n1 = (Node)pa.Clone();
            int i1 = 0, j1 = 0;
            for (int i = 0; i < 3; i++) //Tim vi tri co gia tri bang 0 trong node
            {
                int kt = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (pa.A[i, j] == 0)
                    {
                        i1 = i;
                        j1 = j;
                        kt = 1;
                        break;
                    }
                }
                if (kt == 1) break;
            }

            int tg1 = n1.A[i1, j1]; //Doi cho vi tri 0 sang phai de duoc Node con Right
            n1.A[i1, j1] = n1.A[i1, j1 + 1];
            n1.A[i1, j1 + 1] = tg1;
            n1.H = TinhH(n1, end);
            n1.Step = n1.Step + 1; //Tang step len 1 (gia cua cha + 1)
            n1.Pa = (Node)pa.Clone();   //Gan gia tri Pa cho node con chinh bang Node cha
            return n1;
        }//Sinh Node con Right cua Node pa
        static void Sinh_Con(Node pa, Node end, List<Node> open, List<Node> close)
        {
            Node x1 = new Node();   //Tao Node x1 de luu gia tri Node con Bottom duoc sinh ra
            Node x2 = new Node();   //Tao Node x2 de luu gia tri Node con Top duoc sinh ra
            Node x3 = new Node();   //Tao Node x3 de luu gia tri Node con Left duoc sinh ra
            Node x4 = new Node();   //Tao Node x4 de luu gia tri Node con Right duoc sinh ra
            int i = pa.Id;
            if (Check_Bottom(pa)) //Kiem tra xem co sinh duoc Node con Bottom hay khong
            {
                x1 = (Node)Sinh_Buttom(pa, end).Clone(); //Sinh Node con Buttom
                x1.Id = i + 1;
                i++;
                if (Check_List(x1, open) == false && Check_List(x1, close) == false)//Kiem tra va them Node con vao Open neu chua co trong Open va Close
                    open.Add(x1);
            }
                
            if (Check_Top(pa))  //Kiem tra xem co sinh duoc Node con Top hay khong
            {
                x2 = (Node)Sinh_Top(pa, end).Clone();    //Sinh Node con Top
                x2.Id = i + 1;
                i++;
                if (Check_List(x2, open) == false && Check_List(x2, close) == false)//Kiem tra va them Node con vao Open neu chua co trong Open va Close
                    open.Add(x2);
            }
                
            if (Check_Left(pa)) //Kiem tra xem co sinh duoc Node con Left hay khong
            {
                x3 = (Node)Sinh_Left(pa, end).Clone();   //Sinh Node con Left
                x3.Id = i + 1;
                i++;
                if (Check_List(x3, open) == false && Check_List(x3, close) == false)//Kiem tra va them Node con vao Open neu chua co trong Open va Close
                    open.Add(x3);
            }
             
            if (Check_Right(pa))  //Kiem tra xem co sinh duoc Node con Right hay khong
            {
                x4 = (Node)Sinh_Right(pa, end).Clone();  //Sinh Node con Right
                x4.Id = i + 1;
                i++;
                if (Check_List(x4, open) == false && Check_List(x4, close) == false)//Kiem tra va them Node con vao Open neu chua co trong Open va Close
                    open.Add(x4);
            }
                   
        }//Sinh Node con cua Node pa va them vao Open neu no chua co tron Open va Close
        static void Update(Node x, List<Node> open, List<Node> close)
        {
            if (Check_List(x, open) || Check_List(x, close))
            {
                if (Check_List(x, open))
                {
                    for (int i=0; i < open.Count; i++)
                    {
                        if (Equal(open[i], x) && open[i].Step > x.Step)
                        {
                            open[i] = (Node)x.Clone();
                            break;
                        }    
                    }    
                }
                else
                {
                    for (int i = 0; i < close.Count; i++)
                    {
                        if (Equal(close[i], x) && close[i].Step > x.Step)
                        {
                            open.Add((Node)x.Clone());
                            break;
                        }
                    }
                }    
            }    
        }//Neu ma Node co trong Open hoac Close thi update lai Open
        
        end1.Goal1();
        begin.RandomA();
        end.Goal1();
        begin.H = TinhH(begin, end);
        begin.Output();
        Console.WriteLine("**********");
        //A*
        List<Node> open = new List<Node>();
        List<Node> close = new List<Node>();
        open.Add(begin);
       /*  Sinh_Con(begin, end, open, close);
         foreach (var x in open)
             x.Output();*/
        while (open.Count>0)
        {
            Node n = new Node();
            n = Get_Open(open, end);
           // Console.WriteLine("==Cha");
           // n.Output();
            UpdateId(open);
            open.RemoveAt(n.Id);
           /* Sinh_Con(n, end, open, close);
            foreach (var x in open)
                 x.Output();    */   
            
            n.H = TinhH(n, end);
            if (Equal(n, end) /*|| Equal(n, end1)*/)
            {
                Ans.Add(n);
                Node back = new Node();
                back = (Node)n.Clone();
                for (int i = close.Count-1; i>=0; i--)
                {
                    if (Equal((Node)close[i], back.Pa) && back.Pa.Step == close[i].Step)
                    {
                        Ans.Add(close[i]);
                        back = close[i];
                    }
                    if (Equal(back, begin))
                        break;
                }
                for (int i = Ans.Count-1; i>=0; i--)
                    Ans[i].Output();
                Console.WriteLine(Ans.Count - 1);
                break;
            }
            else
            {
                Sinh_Con(n, end, open, close);
                Update(n, open, close);
            }
            close.Add(n);
            //Console.WriteLine("lkkk11");
        }
        
    }
}

//Xoa id
/*
 [0,0]  [0,1]   [0,2]
 [1,0]  [1,1]   [1,2]
 [2,0]  [2,1]   [2,2]
*/