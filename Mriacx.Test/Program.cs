using System;
using System.Text;

namespace Mriacx.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Dog();//向上转型①
            animal.call();
        }
    }


    class Animal
    {
        public void call() { Console.WriteLine("无声的叫唤"); }
    }

    class Dog : Animal
    {
        // new的作用是隐藏父类的同名方法
        public new void call() { Console.WriteLine("叫声：汪～汪～汪～"); }
        public void smell() { Console.WriteLine("嗅觉相当不错！"); }
    }
}
