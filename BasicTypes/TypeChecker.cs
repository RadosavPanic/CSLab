using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CSLab.BasicTypes
{
    public class TypeChecker
    {

        /// <summary>
        /// <para>Displays the internal class name for the provided type.</para>                
        /// Param &lt;<typeparamref name="T"/>&gt;: The type to display the internal class name for.
        /// <example>
        /// <para>Example usage:</para>
        /// <code>
        /// DisplayTypeInternalName&lt;long&gt;(); // Output: Int64
        /// DisplayTypeInternalName&lt;decimal&gt;(); // Output: Decimal
        /// </code>        
        /// </example>       
        /// </summary>        
        public static void DisplayTypeInternalName<T>()
        {
            Type type = typeof(T);

            Console.WriteLine($"Provided type \"{type.FullName}\" has internal class: {type.Name}");
        }

        /// <summary>
        /// <para>Displays size for the provided type in bytes. Works for both managed and unmanaged types.</para>                
        /// Param &lt;<typeparamref name="T"/>&gt;: The type to check the size for.
        /// <example>
        /// <para>Example usage:</para>
        /// <code>
        /// DisplaySizeOfType&lt;decimal&gt;(); // Output: 16 Bytes        
        /// </code>        
        /// </example>       
        /// </summary>  
        public static void DisplaySizeOfType<T>()
        {
            int size = Marshal.SizeOf(typeof(T));

            Console.WriteLine($"Provided type has size of {size} Bytes");
        }
    }
}
