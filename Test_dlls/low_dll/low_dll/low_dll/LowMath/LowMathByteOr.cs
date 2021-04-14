using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace low_dll.LowMath
{
    class LowMathByteOr
    {
        public static void BuildLib()
        {
            var assemblyName = "LowMathByteOr";
            var modName = "LowMathByteOr.dll";
            var typeName = "LowMathByteOr_DLL";
            var name = new AssemblyName(assemblyName);
            var domain = System.Threading.Thread.GetDomain();
            var builder = domain.DefineDynamicAssembly(name, AssemblyBuilderAccess.RunAndSave);
            var module = builder.DefineDynamicModule(modName, true);
            var typeBuilder = module.DefineType(typeName, TypeAttributes.Public);
            var methodBuilderOr = typeBuilder.DefineMethod(
                "ByteOr",
                MethodAttributes.Public,
                typeof(int),
                new Type[] { typeof(int), typeof(int) }
            );
            ILGenerator iLGenerator = methodBuilderOr.GetILGenerator();
            iLGenerator.Emit(OpCodes.Ldarg_1);
            iLGenerator.Emit(OpCodes.Ldarg_2);
            iLGenerator.Emit(OpCodes.Or);
            iLGenerator.Emit(OpCodes.Ret);
            typeBuilder.CreateType();
            builder.Save(assemblyName + ".dll");
        }
    }

}
