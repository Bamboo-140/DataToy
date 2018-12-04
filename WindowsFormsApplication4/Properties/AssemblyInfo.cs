using System.Resources;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的常规信息通过下列属性集
// 控制。更改这些属性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("DataToy")]
[assembly: AssemblyDescription("      数据库中两个表结构同步(字段及数据类型),但不能复制 键\\触发器\\存储过程,可自由复制分享修改;仅供学习参考.\r\n      说明:通过查询sysobjects来比较两个数据库的数据表的差异,syscolumns比较字段差异,systypes查询字段数据类型,最终根据用户选择进行修复,为了向下兼容SQLServer 2000将'max'长度 换成了2000;")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Bamboo")]
[assembly: AssemblyProduct("DataToy")]
[assembly: AssemblyCopyright("Copyright ©  2018 Bamboo")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 属性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("1263a6c9-7f9e-4f1b-a29d-3226fd6232b1")]

// 程序集的版本信息由下面四个值组成:
//
//      主版本
//      次版本 
//      内部版本号
//      修订号
//
// 可以指定所有这些值，也可以使用“内部版本号”和“修订号”的默认值，
// 方法是按如下所示使用“*”:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.4")]
[assembly: AssemblyFileVersion("1.0.0.4")]
[assembly: NeutralResourcesLanguage("zh-CN")]

