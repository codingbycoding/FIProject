

using System;

public class Util {

    public static string GetArg(string name)
    {
        var args = System.Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == name && args.Length > i + 1)
            {
                return args[i + 1];
            }
        }

        return null;
    }

    
    public static int GetArg(string name, int defaultVal = 0)
    {
        var args = System.Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == name && args.Length > i + 1)
            {                  

                try
                {
                    defaultVal = Convert.ToInt32(args[i + 1]);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input string is not a sequence of digits.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number cannot fit in an Int32.");
                }
                
            }
        }

        return defaultVal;
    }


    public static string JumpTag2ServIP(string jumpTag)
    {
        string servIP = "127.0.0.1";
        return servIP;
    }

    public static string JumpTag2Cookie(string jumpTag)
    {
        string[] strs = jumpTag.Split(':');
        return strs[1];
    }

    // jumpTag format : JumpPoint_Sx:Px
    public static int JumpTag2ServPort(string jumpTag, int defaultPort = 0)
    {
        string[] strs = jumpTag.Split(':');
        int servPort = defaultPort;

        try
        {            
            servPort = Convert.ToInt32(strs[0].Substring(1));
        }
        catch (FormatException)
        {
            Console.WriteLine("Input string is not a sequence of digits.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("The number cannot fit in an Int32.");
        }

        if(servPort != defaultPort)
        {
            servPort += 10000;
        }        

        return servPort;
    }
}
