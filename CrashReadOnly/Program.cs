using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashReadOnly
{
    //旨在证明 C# 的只读只是对编译器的约束，可以IL反编译程序分析后通过System.Reflection修改自动属性的值；

    class Program
    {
        static void Main(string[] args)
        {
            //创建演示对象
            ReadOnlyDemo demo = new ReadOnlyDemo();

            //获取私有字段实例并赋值
            typeof(ReadOnlyDemo).GetField(
                "Value_1",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
            )
            .SetValue(demo, 111);

            //获取私有自动属性的真实数据变量实例并赋值
            typeof(ReadOnlyDemo).GetField(
                "<Value_2>k__BackingField",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
            )
            .SetValue(demo, 222);

            //获取私有方法并调用
            typeof(ReadOnlyDemo).GetMethod(
                "Show",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
            )
            .Invoke(demo, null);

            Console.Read();
        }
    }
}
