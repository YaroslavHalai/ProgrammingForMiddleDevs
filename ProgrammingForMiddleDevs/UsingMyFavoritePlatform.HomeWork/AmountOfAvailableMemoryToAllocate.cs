using System;
using System.Diagnostics;

namespace UsingMyFavoritePlatform.HomeWork
{
    public static class AmountOfAvailableMemoryToAllocate
    {
        // Answer: 2,203,981,119,488 bytes = ~2,2 TB
        public static void DisplayAmountOfAvailableMemoryToAllocate()
        {
            using Process currentProcess = Process.GetCurrentProcess();

            // "Private Memory" representing the amount of RAM allocated privately to the process.
            // In general, "Private memory" does not include any memory occupied by shared DLL files used by the process.
            Console.WriteLine($"Windows allocated {currentProcess.PrivateMemorySize64} bytes private memory to '{currentProcess.ProcessName}' process.");
            
            //"Virtual Memory" representing the total virtual address space of the process.
            // Virtual memory is the sum of private memory, shared memory and free memory.
            Console.WriteLine($"'{currentProcess.ProcessName}' process has {currentProcess.VirtualMemorySize64} bytes of addressable virtual space.");

            // "Working Set" representing the portion of the "Virtual memory" that is currently resident in RAM and can be reference without a page fault.
            // Page fault is a type of exception raised by computer hardware when a running program accesses a memory page that is not currently mapped by
            // the memory management unit into the virtual address space of a process.
            Console.WriteLine($"Currently, Windows keeps {currentProcess.WorkingSet64} bytes in RAM to run '{currentProcess.ProcessName}' process.");

            // Shared memory includes:
            // 1) DLLs loaded into the process; 2) Mapped files; 3) .NET IL code that gets compiled; 4) The default process heap 5) stack
            Console.WriteLine($"Shared memory equals to {currentProcess.VirtualMemorySize64 - currentProcess.PrivateMemorySize64} bytes = Virtual - Private");
        }
    }
}