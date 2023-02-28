using System.Diagnostics;

//Task1

var process = Process.Start("NotePad.exe");
process.WaitForExit();
Console.WriteLine(process.ExitCode);

//Task2 

var process2 = Process.Start("NotePad.exe");
Console.WriteLine("0-Wait\n1-Kill");
var res = Int32.Parse(Console.ReadLine());
if(res == 0) { process2.WaitForExit();
Console.WriteLine(process2.ExitCode);}
else if(res == 1) { process2.Kill(); }

