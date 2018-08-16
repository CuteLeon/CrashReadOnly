using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashReadOnly
{
    class ReadOnlyDemo
    {
        /// <summary>
        /// 私有变量
        /// </summary>
        /// <remarks>IL: .field public initonly int32 Value_1</remarks>
        private readonly int Value_1 = 1000;

        /// <summary>
        /// 只读自动属性
        /// </summary>
        /// <remarks>IL: 增加私有变量以记录自动属性的数据，.field private initonly int32 '<Value_2>k__BackingField'</remarks>
        private int Value_2 { get; } = 2000;

        /// <summary>
        /// 私有输出方法
        /// </summary>
        private void Show() => Console.WriteLine($"Value_1 = {Value_1} \nValue_2 = {Value_2}");
    }
}
