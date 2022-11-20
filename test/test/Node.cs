using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Node:ICloneable
    {
        public int[,]? A; // 1 trang thai
        public int Id=0;//id trong list
        public int H; // ???
        public int Step = 0; // buoc hien tai
        public Node Pa; // trang thai cha
        public virtual object Clone()
        {
            Node m = (Node)this.MemberwiseClone();
            m.A = (int[,])this.A.Clone();
            return m;
        }
        public Node(int[,] a)
        {
            A = a;
        }
        public Node()
        {
            
        }
        public void Input()
        {
            A = new int[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine("Nhap phan tu thu {0} {1}", i, j);
                    A[i,j] = int.Parse(Console.ReadLine());
                }
                    
        }
        public void Output()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    Console.Write(A[i,j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine("Id = " + Id);
            Console.WriteLine("Step = " + Step);
            Console.WriteLine("H = " + H);
            Console.WriteLine("===============================");
        }
        public  void Goal1() // trang thai dich
        {
             A = new int[3, 3];
             A[0, 0] = 0;
             A[0, 1] = 1;
             A[0, 2] = 2;
             A[1, 0] = 3;
             A[1, 1] = 4;
             A[1, 2] = 5;
             A[2, 0] = 6;
             A[2, 1] = 7;
             A[2, 2] = 8;

        }
        public void Goal2() // trang thai dich
        {
            A = new int[3, 3];
            A[0, 0] = 1;
            A[0, 1] = 2;
            A[0, 2] = 3;
            A[1, 0] = 8;
            A[1, 1] = 0;
            A[1, 2] = 4;
            A[2, 0] = 7;
            A[2, 1] = 6;
            A[2, 2] = 5;   
        }
        public void Goal3() // trang thai dich
        {
            A = new int[3, 3];
            A[0, 0] = 1;
            A[0, 1] = 2;
            A[0, 2] = 3;
            A[1, 0] = 4;
            A[1, 1] = 5;
            A[1, 2] = 6;
            A[2, 0] = 7;
            A[2, 1] = 8;
            A[2, 2] = 0;
        }
        public void RandomA()
        {
            A = new int[3, 3];
            A[0, 0] = 0;
            A[0, 1] = 1;
            A[0, 2] = 2;
            A[1, 0] = 3;
            A[1, 1] = 4;
            A[1, 2] = 5;
            A[2, 0] = 6;
            A[2, 1] = 7;
            A[2, 2] = 8;
            int i = 0, j = 0;
            Random x = new Random();
            for (int k = 0; k<500; k++)
            {
                int z = x.Next(1, 5);
                if (z == 1 && i>0)//Len
                {
                    int tg = A[i, j];
                    A[i,j] = A[i-1,j];
                    A[i-1, j] = tg;
                    i = i - 1;
                }
                if (z == 2 && i < 2)//Xuong
                {
                    int tg = A[i, j];
                    A[i, j] = A[i + 1, j];
                    A[i + 1, j] = tg;
                    i = i + 1;
                }
                if (z == 3 && j > 0)//Trai
                {
                    int tg = A[i, j];
                    A[i, j] = A[i, j-1];
                    A[i, j-1] = tg;
                    j = j - 1;
                }
                if (z == 4 && j < 2)//Phai
                {
                    int tg = A[i, j];
                    A[i, j] = A[i, j + 1];
                    A[i, j + 1] = tg;
                    j = j + 1;
                }
            }    
        }
        public void RandomA2() // sinh trang thai ban dau
        {
            A = new int[3, 3];
            
           /* A[0, 0] = 6;
            A[0, 1] = 8;
            A[0, 2] = 7;
            A[1, 0] = 3;
            A[1, 1] = 5;
            A[1, 2] = 4;
            A[2, 0] = 2;
            A[2, 1] = 1;
            A[2, 2] = 0;*/
            A[0, 0] = 6;
            A[0, 1] = 8;
            A[0, 2] = 7;
            A[1, 0] = 3;
            A[1, 1] = 5;
            A[1, 2] = 4;
            A[2, 0] = 0;
            A[2, 1] = 2;
            A[2, 2] = 1;
            /*
            Random x = new Random();
            int i1, i2, j1, j2;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    i1 = x.Next(0, 3);
                    i2 = x.Next(0, 3);
                    j1 = x.Next(0, 3);
                    j2 = x.Next(0, 3);
                    int tg = A[i1, j1];
                    A[i1, j1] = A[i2, j2];
                    A[i2, j2] = tg;
                }    */
        }
        public void RandomA1() // sinh trang thai ban dau xin
        {
            Random x = new Random();
            int z = x.Next(1, 8);
            A = new int[3, 3];
            switch(z)
            {
                case 1:
                    A[0, 0] = 5;
                    A[0, 1] = 2;
                    A[0, 2] = 3;
                    A[1, 0] = 7;
                    A[1, 1] = 4;
                    A[1, 2] = 0;
                    A[2, 0] = 1;
                    A[2, 1] = 6;
                    A[2, 2] = 8;
                    break;
                case 2:
                    A[0, 0] = 3;
                    A[0, 1] = 1;
                    A[0, 2] = 4;
                    A[1, 0] = 7;
                    A[1, 1] = 0;
                    A[1, 2] = 2;
                    A[2, 0] = 6;
                    A[2, 1] = 8;
                    A[2, 2] = 5;
                    break;
                case 3:
                    A[0, 0] = 2;
                    A[0, 1] = 1;
                    A[0, 2] = 8;
                    A[1, 0] = 0;
                    A[1, 1] = 5;
                    A[1, 2] = 4;
                    A[2, 0] = 6;
                    A[2, 1] = 3;
                    A[2, 2] = 7;
                    break;
                case 4:
                    A[0, 0] = 0;
                    A[0, 1] = 8;
                    A[0, 2] = 1;
                    A[1, 0] = 5;
                    A[1, 1] = 4;
                    A[1, 2] = 2;
                    A[2, 0] = 3;
                    A[2, 1] = 6;
                    A[2, 2] = 7;
                    break;
                case 5:
                    A[0, 0] = 2;
                    A[0, 1] = 1;
                    A[0, 2] = 7;
                    A[1, 0] = 0;
                    A[1, 1] = 4;
                    A[1, 2] = 3;
                    A[2, 0] = 6;
                    A[2, 1] = 8;
                    A[2, 2] = 5;
                    break;
                case 6:
                    A[0, 0] = 2;
                    A[0, 1] = 7;
                    A[0, 2] = 3;
                    A[1, 0] = 0;
                    A[1, 1] = 1;
                    A[1, 2] = 8;
                    A[2, 0] = 6;
                    A[2, 1] = 4;
                    A[2, 2] = 5;
                    break;
                case 7:
                    A[0, 0] = 1;
                    A[0, 1] = 0;
                    A[0, 2] = 5;
                    A[1, 0] = 3;
                    A[1, 1] = 8;
                    A[1, 2] = 2;
                    A[2, 0] = 6;
                    A[2, 1] = 7;
                    A[2, 2] = 4;
                    break;
                case 8:
                    A[0, 0] = 1;
                    A[0, 1] = 4;
                    A[0, 2] = 8;
                    A[1, 0] = 0;
                    A[1, 1] = 6;
                    A[1, 2] = 5;
                    A[2, 0] = 7;
                    A[2, 1] = 2;
                    A[2, 2] = 3;
                    break;
                case 9:
                    A[0, 0] = 0;
                    A[0, 1] = 4;
                    A[0, 2] = 7;
                    A[1, 0] = 3;
                    A[1, 1] = 1;
                    A[1, 2] = 2;
                    A[2, 0] = 5;
                    A[2, 1] = 6;
                    A[2, 2] = 8;
                    break;
                case 10:
                    A[0, 0] = 0;
                    A[0, 1] = 6;
                    A[0, 2] = 4;
                    A[1, 0] = 5;
                    A[1, 1] = 2;
                    A[1, 2] = 8;
                    A[2, 0] = 1;
                    A[2, 1] = 7;
                    A[2, 2] = 3;
                    break;
                case 11:
                    A[0, 0] = 5;
                    A[0, 1] = 7;
                    A[0, 2] = 0;
                    A[1, 0] = 8;
                    A[1, 1] = 3;
                    A[1, 2] = 2;
                    A[2, 0] = 1;
                    A[2, 1] = 6;
                    A[2, 2] = 4;
                    break;
                case 12:
                    A[0, 0] = 8;
                    A[0, 1] = 6;
                    A[0, 2] = 4;
                    A[1, 0] = 3;
                    A[1, 1] = 5;
                    A[1, 2] = 1;
                    A[2, 0] = 7;
                    A[2, 1] = 0;
                    A[2, 2] = 2;
                    break;
                case 13:
                    A[0, 0] = 1;
                    A[0, 1] = 2;
                    A[0, 2] = 5;
                    A[1, 0] = 6;
                    A[1, 1] = 4;
                    A[1, 2] = 7;
                    A[2, 0] = 3;
                    A[2, 1] = 0;
                    A[2, 2] = 8;
                    break;
                case 14:
                    A[0, 0] = 0;
                    A[0, 1] = 4;
                    A[0, 2] = 2;
                    A[1, 0] = 5;
                    A[1, 1] = 1;
                    A[1, 2] = 3;
                    A[2, 0] = 6;
                    A[2, 1] = 7;
                    A[2, 2] = 8;
                    break;
                case 15:
                    A[0, 0] = 3;
                    A[0, 1] = 1;
                    A[0, 2] = 4;
                    A[1, 0] = 2;
                    A[1, 1] = 6;
                    A[1, 2] = 8;
                    A[2, 0] = 0;
                    A[2, 1] = 5;
                    A[2, 2] = 7;
                    break;
                case 16:
                    A[0, 0] = 0;
                    A[0, 1] = 4;
                    A[0, 2] = 5;
                    A[1, 0] = 3;
                    A[1, 1] = 2;
                    A[1, 2] = 6;
                    A[2, 0] = 1;
                    A[2, 1] = 7;
                    A[2, 2] = 8;
                    break;
                case 17:
                    A[0, 0] = 4;
                    A[0, 1] = 6;
                    A[0, 2] = 2;
                    A[1, 0] = 8;
                    A[1, 1] = 3;
                    A[1, 2] = 0;
                    A[2, 0] = 1;
                    A[2, 1] = 7;
                    A[2, 2] = 5;
                    break;
                case 18:
                    A[0, 0] = 0;
                    A[0, 1] = 2;
                    A[0, 2] = 5;
                    A[1, 0] = 4;
                    A[1, 1] = 7;
                    A[1, 2] = 3;
                    A[2, 0] = 1;
                    A[2, 1] = 6;
                    A[2, 2] = 8;
                    break;
                case 19:
                    A[0, 0] = 6;
                    A[0, 1] = 8;
                    A[0, 2] = 1;
                    A[1, 0] = 0;
                    A[1, 1] = 4;
                    A[1, 2] = 5;
                    A[2, 0] = 3;
                    A[2, 1] = 2;
                    A[2, 2] = 7;
                    break;
                case 20:
                    A[0, 0] = 2;
                    A[0, 1] = 0;
                    A[0, 2] = 5;
                    A[1, 0] = 7;
                    A[1, 1] = 1;
                    A[1, 2] = 8;
                    A[2, 0] = 4;
                    A[2, 1] = 3;
                    A[2, 2] = 6;
                    break;
            }    
                
        }
    }
}
